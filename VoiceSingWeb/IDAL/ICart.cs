using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
   public interface ICart
    {
        IEnumerable<Cart> ShowCart(int userid);
        //购物车商品展示
        Cart searchCart(int userid, int goodid);
        //寻找用户加入购物车商品对应的表，判断是否为空
        void AddCart(Cart cart);
        //新商品加入购物车
        void AddCart1();
        //购物车原有商品修改  
        void Delect_cart(int id);
        //删除购物车商品
        int Carts_number(int userid);
        //统计购物车商品数量        
        void AddOrder(Orders orders);
        //添加订单      
        void AddOrderdetails(Orderdetails orderdetails);
        //添加订单细节
        Cart search_myCart(int cartId);
        //找到购买的商品
        void Cart_Remove(Cart myCart);
        //购买后移除购物车中对应商品
        Cart whereCartById(int userid, int goodid);
        //找到所需修改的购物车表数据
        void Cart_update(Cart myCart);
        //修改购物车数据
        
    }
}
