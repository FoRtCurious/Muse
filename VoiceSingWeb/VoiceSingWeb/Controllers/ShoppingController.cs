using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using VoiceSingWeb.Models;
using System.Text.RegularExpressions;
using PagedList;
using System.Data.Entity;

namespace VoiceSingWeb.Controllers
{
    public class ShoppingController : Controller
    {
        GoodsManager goodsManager = new GoodsManager();
        GoodsCommentManager GoodsCommentManager = new GoodsCommentManager();
        CollectManager collectManager = new CollectManager();
        OrdersManager ordersManager = new OrdersManager();
        OrderdetailsManager orderdetailsManager = new OrderdetailsManager();
        ReceiptAddressManager receiptAddressManager = new ReceiptAddressManager();
        CartManager cartManager = new CartManager();


        #region 主页展示
        public ActionResult Index()
        {
            /// <summary>
            /// 主页热门与推荐展示
            /// </summary>
            /// <param name="shoppingHomeViewModel">主页viewmodel</param>
            /// <param name="shoppingHomeViewModel.Allgoods">全部随机八个商品</param>
            /// <param name="shoppingHomeViewModel.Suggest_Goods">根据已登入用户所收藏推荐</param>
            /// typeid为了得到用户收藏商品类别个数
            /// Suggest_goods是一个对应商品类别的视图
            /// <returns></returns>
            ShoppingHomeViewModel shoppingHomeViewModel = new ShoppingHomeViewModel();
            shoppingHomeViewModel.Allgoods = goodsManager.GetGoods().Where(o => o.good_state == 1).OrderBy(p => Guid.NewGuid()).Take(8);
            int userid = Convert.ToInt32(Session["UserId"]);
            List<int> typeid = collectManager.GetCollectgoodtypeid(userid).ToList();
            shoppingHomeViewModel.typecount = typeid.Count();
            if (typeid.Count >= 1)
            {
                shoppingHomeViewModel.Suggest_Goods = collectManager.GetSuggestgoods(userid);
            }
            else shoppingHomeViewModel.Suggestgoods = goodsManager.GetGoods().OrderBy(p => Guid.NewGuid()).Take(4);           
            return View(shoppingHomeViewModel);
        }
        #endregion

        #region 商品详情页
        public ActionResult gooddetail(int id)
        {           
            GoodsdetailsViewModel viewmodel = new GoodsdetailsViewModel();
            viewmodel.Goodsdatail = goodsManager.Getgooddetails(id);//商品详情展示商品表

            viewmodel.Sorce = GoodsCommentManager.Sorce(id);//展示该商品对应分数
            viewmodel.Comments = GoodsCommentManager.GetComments(id);//全部
            viewmodel.CommentsImg = GoodsCommentManager.GetCommentsImg(id);//展示图片评论
            viewmodel.CommentsGood = GoodsCommentManager.GetCommentsGood(id);//好评
            viewmodel.CommentsBad = GoodsCommentManager.GetCommentsBad(id);//差评
            viewmodel.Add_comment = GoodsCommentManager.GetAdd_Comments(id);//追评
            return View(viewmodel);       
        }
        #endregion

        public ActionResult Comment(int id ,int? page ,int? sorce)
        {
            IEnumerable<GoodsComment> comment = null;
            if (sorce==null)
            {
             comment = GoodsCommentManager.GetComments(id).OrderByDescending(o=>o.commmenttime);
            }
            else if(sorce == 1)
            {
                comment = GoodsCommentManager.GetCommentsGood(id).OrderByDescending(o => o.commmenttime);
            }
            else if (sorce == 2)
            {
                comment= GoodsCommentManager.GetCommentsBad(id).OrderByDescending(o => o.commmenttime);
            }
            else if(sorce==3)
            {
                comment = GoodsCommentManager.GetCommentsImg(id).OrderByDescending(o => o.commmenttime);
            }
            ViewBag.sorce = sorce;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(comment.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult AddComentPage(int id,int? page)
        {
            IEnumerable<Add_comment> comment = null;
            comment = GoodsCommentManager.GetAdd_Comments(id).OrderByDescending(o => o.commmenttime);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(comment.ToPagedList(pageNumber, pageSize));
        }

        #region 商品详情推荐商品分布视图
        public ActionResult goodDetails_hot_Product()
        {
            var products_hot = goodsManager.GetGoods().OrderBy(p => Guid.NewGuid()).Take(4);
            return View(products_hot);
        }
        #endregion

        #region 商品列表页
        public ActionResult goodsList(int? ID, int? low, int? high, string method, string search)
        {
            var list = goodsManager.GetGoodslist(ID, low, high, method, search);
            ViewData["ID"] = ID;
            ViewData["high"] = high;
            return View(list);
        }
        #endregion

        #region 购物车商品推荐分布视图
        public ActionResult Carts_hot_Product()
        {
            var Carts_hot = goodsManager.GetGoods().OrderBy(p => Guid.NewGuid()).Take(4);//随机展示4个数据
            return View(Carts_hot);//数据传到视图中
        }
        #endregion
        //购物车
        
        #region 展示用户购物车
        public ActionResult AddCart_goods()
        {
            int userid = Convert.ToInt32(Session["UserId"]);
            var product = cartManager.ShowCart(userid);
            return View(product);
        }
        #endregion

        #region 立即购买准备
        public ActionResult BuyNow( string goodid,string goodnum)
        {
            if(Session["UserId"] != null)
            {
                int userid = Convert.ToInt32(Session["UserId"]);
                int num = Convert.ToInt32(goodnum);//
                int ID = Convert.ToInt32(goodid);//
                PlaceOrder_AddressViewModel placeOrder_AddressViewModel = new PlaceOrder_AddressViewModel();
                Goods goods = goodsManager.Getgooddetails(ID);
                PlaceOrderModel sc = new PlaceOrderModel
                {
                    Userid = userid,
                    Goodid = ID,
                    Image = goods.img,
                    Goodname = goods.goodsname,
                    Qty = num,
                    Price = goods.price,
                    Tot_amt = goods.price * num,
                };
                List<PlaceOrderModel> list = new List<PlaceOrderModel>();
                list.Add(sc);
                placeOrder_AddressViewModel.orderlist = list;
                placeOrder_AddressViewModel.MyAddr = new ReceiptAddressManager().GetReceipt_Addresses(userid);
                return View(placeOrder_AddressViewModel);
            }
            else
            {
                return Content("<script>alert('您还没有登入！');history.go(-1);</script>");
            }

        }
        #endregion

        #region 立即购买实现
        public ActionResult Buy(Orders orders, string addrId, string csum,string Qty,string Goodid)
        {
            orders.userid= Convert.ToInt32(Session["UserId"]);
            decimal total = Convert.ToDecimal(csum);
            orders.addressid = Convert.ToInt32(addrId);
            orders.ordertime = DateTime.Now;
            orders.Tot_amt = total;
            cartManager.AddOrder(orders);
            Orderdetails orderdetails = new Orderdetails();
            orderdetails.orderid = orders.orderid;
            orderdetails.goodsid = Convert.ToInt32(Goodid);
            orderdetails.qty = Convert.ToInt32(Qty);
            orderdetails.price = total;
            cartManager.AddOrderdetails(orderdetails);
            return Content("购买成功！");

        }
        #endregion

        #region 添加商品加入购物车
        public ActionResult AddCart(Cart carts,int goodnum,int goodid,decimal cost)
        {    

            if(Session["UserId"] != null)
            {
                   int userid;
                   userid = Convert.ToInt32(Session["UserId"]);
                var searchcart = cartManager.searchCart(userid, goodid);
                if(searchcart !=null)
                {
                    if (goodnum<=1)
                    {
                        goodnum =1;
                    }
                    searchcart.qty += goodnum;
                    try
                    {
                        searchcart.price = cost * searchcart.qty;
                        cartManager.AddCart1();
                    }
                    catch(Exception)
                    { }                  
                }
                else
                {
                    if (goodnum <= 1)
                    {
                        goodnum = 1;
                    }
                    carts.goodsid = goodid;
                    carts.userid= Convert.ToInt32(Session["UserId"]);
                    carts.qty = goodnum;
                    carts.price = cost * goodnum;
                    cartManager.AddCart(carts);
                }
                return Content("success");    
            }
            else
            { return Content("Login"); }
        }
        #endregion

        #region 购物车数字标识
        public ActionResult Carts_number()
        {
            int userid;
            if (Session["UserId"] != null)
            {
                userid = Convert.ToInt32(Session["UserId"]);
                ViewData["number"]= cartManager.Carts_number(userid);
            }
            else
            {
                ViewData["number"] = 0;
            }
            return PartialView();
        }
        #endregion

        #region 删除购物车商品
        public string Delect_cart(int id)
        {
            cartManager.Delect_cart(id);
            return "移除商品成功";
        }
        #endregion

        #region 修改用户购物车数据
        public string Update(int id,int count)
        {
            int userid = Convert.ToInt32(Session["UserId"]);
            var beforeCart = cartManager.whereCartById(userid, id);
            beforeCart.goodsid = id;
            beforeCart.userid= Convert.ToInt32(Session["UserId"]);
            //beforeCart.qty = count;
            //cartManager.Cart_Update(beforeCart);
            if(count<=0)
            {
                string data = "修改有误，请重新修改！";
                return data;
            }
            else
            {
                beforeCart.qty = count;
                decimal price = goodsManager.Getgooddetails(beforeCart.goodsid).price;
                beforeCart.price = count * price;
                cartManager.Cart_update(beforeCart);
                string data = "修改成功！";
                return data;
            }
        }
        #endregion

        #region 实现购买
        public ActionResult CreateOrder(Orders orders, string cartsId, string addrId, string csum)
        {
            decimal total = Convert.ToDecimal(csum);
            string[] addrArr = cartsId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (total == 0)
            {
                return Content("您还没有勾选所需商品！");
            }
            else
            {
                orders.addressid = Convert.ToInt32(addrId);
                orders.ordertime = DateTime.Now;
                orders.userid = Convert.ToInt32(Session["UserId"]);
                orders.Tot_amt = total;
                cartManager.AddOrder(orders);
                foreach (var item in addrArr)
                {
                    int cartId = Convert.ToInt32(item);
                    var myCart = cartManager.search_myCart(cartId);
                    Orderdetails orderdetails = new Orderdetails();
                    orderdetails.goodsid = myCart.goodsid;
                    orderdetails.orderid = orders.orderid;
                    orderdetails.qty = myCart.qty;
                    orderdetails.price = myCart.price;
                    cartManager.AddOrderdetails(orderdetails);
                    cartManager.Cart_Remove(myCart);
                }
                return Content("购买成功！");
            }
        }
        #endregion

        //个人中心

        #region 待评论数量
        public ActionResult Commentnumber()
        {
            int userid = Convert.ToInt32(Session["UserId"]);
            ViewData["number"] = GoodsCommentManager.Comment_number(userid);
            return PartialView();
        }
        #endregion

        #region 评论准备
        public ActionResult AddComment(int id)
        {
             Orderdetails orderdetail = GoodsCommentManager.orderdetails(id);
            GoodCommentModel ViewModel = new GoodCommentModel
            {
                orderdetailsid = id,
                goodid = orderdetail.goodsid,
                Name = orderdetail.Goods.goodsname,
                Time = Convert.ToString(orderdetail.Orders.ordertime),
                img = orderdetail.Goods.img
            };
            return View(ViewModel);
        }
        #endregion

        #region 上传图片
        public ActionResult UploadImg(HttpPostedFileBase upload)
        {
            HttpPostedFileBase imageName = Request.Files[0];
            string file = null;
            try
            {
                file = imageName.FileName;
            }
            catch (Exception)
            {
                return Content("<script>alert('图片未能正常上传！');history.go(-1);</script>");
            }
            string fileFormat = file.Split('.')[file.Split('.').Length - 1]; // 以“.”截取，获取“.”后面的文件后缀
            Regex imageFormat = new Regex(@"^(bmp)|(png)|(gif)|(jpg)|(jpeg)"); // 验证文件后缀的正则表达式
            // 验证后缀不合格
            if (string.IsNullOrEmpty(file) || !imageFormat.IsMatch(fileFormat))
            {
                return Content("<script>alert('请上传正确格式照片！');history.go(-1);</script>");
            }
            // 验证后缀合格
            else
            {
                string timeStamp = DateTime.Now.Ticks.ToString(); // 获取当前时间的string类型
                string firstFileName = timeStamp.Substring(0, timeStamp.Length - 4); // 通过截取获得文件名
                string imageStr = "Content/images/shopping/Comment/"; // 获取保存图片的项目文件夹
                string uploadPath = Server.MapPath("~/" + imageStr); // 将项目路径与文件夹合并

                string pictureFormat = file.Split('.')[file.Split('.').Length - 1];// 设置文件格式
                string fileName = firstFileName + "." + fileFormat;// 设置完整（文件名+文件格式） 
                string saveFile = uploadPath + fileName;//保存文件路径
                imageName.SaveAs(saveFile);// 保存文件
                var imageUrl = "../../Content/images/shopping/Comment/" + fileName;// 设置数据库保存的路径
                var CkeditorFuncNum = System.Web.HttpContext.Current.Request["CKEditorFuncNum"];
                return Content("<script>window.parent.CKEDITOR.tools.callFunction(" + CkeditorFuncNum + ", \"" + imageUrl + "\");</script>");
            }
        }
        #endregion

        #region 评论
        [ValidateInput(false)]
        public ActionResult SendComment(GoodsComment comment, int detailsid, int goodid, int socre1, int socre2, int socre3, string content)
        {
            Orderdetails orderdetails = GoodsCommentManager.orderdetails(detailsid);
            orderdetails.commmentstate = 1;
            int userid = Convert.ToInt32(Session["UserId"]);
            comment.userId = userid;
            comment.goodsid = goodid;
            comment.commmenttime = DateTime.Now;
            comment.content = content;
            comment.Sorce = (socre1 + socre2 + socre3) / 3;
            GoodsCommentManager.AddComment(comment);
            return Content("success");
        }
        #endregion

        public ActionResult PlusComment(int id)
        {
            GoodsComment goodsComment = GoodsCommentManager.GetNowComment(id);
            PlusGoodsCommentModel plusGoodsComment = new PlusGoodsCommentModel
            {
                commentid = id,
                goodid = goodsComment.goodsid,
                name = goodsComment.Goods.goodsname,
                content = goodsComment.content,
                img = goodsComment.Goods.img,
                Time = Convert.ToString(goodsComment.commmenttime)                
            };
            return View(plusGoodsComment);
        }

        [ValidateInput(false)]
        public ActionResult PlusAddComment(Addcomment addcomment,int commentid,int goodid,string content)
        {
            int userid = Convert.ToInt32(Session["UserId"]);
            var comment = GoodsCommentManager.GetMyNowComment(commentid);
            addcomment.addcontent = content;
            addcomment.goodscommentid = commentid;
            addcomment.userId = userid;
            addcomment.goodsid = goodid;
            addcomment.addcommmenttime = DateTime.Now;
            GoodsCommentManager.PlusAddComment(addcomment);
            comment.addcom = 1;
            GoodsCommentManager.GoodComment_update(comment);
            return Content("success");
        }


        #region 用户收藏商品
        public ActionResult AddCollect(Collect collect,int goodid)
        {
            if(Session["UserId"] != null)
            {
                int userid = Convert.ToInt32(Session["UserId"]);
                var searchcollect = collectManager.searchCollect(userid, goodid);
                if(searchcollect!=null)
                {
                    //return Content("您已收藏该商品，可以前往个人中心查看！");
                    return Content("<script>alert('您已收藏该商品，可以前往个人中心查看！');history.go(-1);</script>");
                }
                else
                {
                    collect.userId = userid;
                    collect.goodsid = goodid;
                    collect.collecttime = DateTime.Now;
                    collectManager.Add_collect(collect);
                    return Content("<script>alert('收藏成功！');history.go(-1);</script>");
                }
                
            }
            else
            {
                 return Content("<script>alert('您还没有登入哦！');history.go(-1);</script>"); 
            }           
        }
        #endregion

        #region 删除收藏商品
        public string Delect_collect(int id)
        {
            collectManager.Delect_Collcet(id);
            return "删除成功！";
        }
        #endregion

        #region 个人中心展示
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Shop_Center()
        {
            ShopCenterViewModel viewModel = new ShopCenterViewModel();
            int userid = Convert.ToInt32(Session["UserId"]);
            
            viewModel.MyAddr= receiptAddressManager.GetReceipt_Addresses(userid);
            viewModel.MyOrder= ordersManager.GetOrders1(userid);
            viewModel.MyCollect = collectManager.GetCollects(userid);
            viewModel.MyComment = GoodsCommentManager.GetOrderdetail_Views(userid);
            viewModel.Comments = GoodsCommentManager.GetMyComments(userid);
            return View(viewModel);
        }
        #endregion

        #region 展示收货地址
        public ActionResult MyAddress()
        {
            return View();
        }
        #endregion

        #region 添加收货地址
        public ActionResult Add_address(Receipt_address addr)
        {
           
            if (Session["UserId"] != null)
            {
                addr.userid = Convert.ToInt32(Session["UserId"]);
                receiptAddressManager.Add_address(addr);
                return Content("success");
            }
            else
            {
                return Content("Login");
            }
        }
        #endregion

        #region 修改收货地址准备
        public ActionResult UpdateAddressView(int addressid)
        {   //获得某用户ID下的第一个addressid
            Receipt_address receipt_Address = receiptAddressManager.GetAddress(addressid);
            UpdateAddressModel ViewModel = new UpdateAddressModel
            {
                Addressid = addressid,
                Name = receipt_Address.name,
                Phonenumber = receipt_Address.telephone,
                Address = receipt_Address.address
               
            };
            return View(ViewModel); 
        }
        #endregion

        #region 修改收货地址
        public ActionResult UpdateAddress(UpdateAddressModel myaddr)
        {
            Receipt_address receipt_Address = receiptAddressManager.GetAddress(myaddr.Addressid);
            receipt_Address.name = myaddr.Name;
            receipt_Address.telephone = myaddr.Phonenumber;
            receipt_Address.address = myaddr.Address;
            receiptAddressManager.Update_adddress(receipt_Address);
            return Content("success");
        }
        #endregion

        #region 删除收货地址
        public string Delect_address(int id)
        {
            receiptAddressManager.Delect_address(id);
            
            return "删除地址成功";
        }
        #endregion

        #region 展示订单细节
        public ActionResult Myorder_details(int detailId)
        {
           var order_product= orderdetailsManager.GetOrderdetails(detailId);
            return View(order_product);
        }
        #endregion

        #region 购买页面收货地址
        public ActionResult MyOrderaddress()
        {
            int userid = Convert.ToInt32(Session["UserId"]);
            var orderaddress = receiptAddressManager.MyOrderaddress(userid);
            return View(orderaddress);
        }
        #endregion   
    }
}