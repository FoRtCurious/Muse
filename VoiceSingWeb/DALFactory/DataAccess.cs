using System.Configuration;
using System.Reflection;
using IDAL;

namespace DALFactory
{
    public class DataAccess
    {
        private static string AssemblyName = ConfigurationManager.AppSettings["Path"].ToString(); //项目名称
        private static string db = ConfigurationManager.AppSettings["DB"].ToString();             //实现接口的具体数据操作类名前缀

        //音乐模块
        public static IUser CreateUser()
        {
            string className = AssemblyName + "." + db + "User";
            IUser iuser = (IUser)Assembly.Load(AssemblyName).CreateInstance(className);  //返回一个SqlUser对象
            return iuser;
        }       
        public static IMusic CreateMusic()
        {
            string className = AssemblyName + "." + db + "Music";
            IMusic imusic = (IMusic)Assembly.Load(AssemblyName).CreateInstance(className);//返回一个SqlMusic对象
            return imusic;
        }
        public static IAccompanyMusic CreateAccompanyMusic()
        {
            string className = AssemblyName + "." + db + "AccompanyMusic";
            IAccompanyMusic iaccompanymusic = (IAccompanyMusic)Assembly.Load(AssemblyName).CreateInstance(className);//返回一个SqlAccompanyMusic对象
            return iaccompanymusic;
        }
        public static IVideo CreateVideo()
        {
            string className = AssemblyName + "." + db + "Video";
            IVideo ivideo = (IVideo)Assembly.Load(AssemblyName).CreateInstance(className);//返回一个SqlVideo对象
            return ivideo;
        }
        public static IVideoComment CreateVideoComment()
        {
            string className = AssemblyName + "." + db + "VideoComment";
            IVideoComment ivideo = (IVideoComment)Assembly.Load(AssemblyName).CreateInstance(className);//返回一个SqlVideoComment对象
            return ivideo;
        }
        public static IMusicComment CreateMusicComment()
        {
            string className = AssemblyName + "." + db + "MusicComment";
            IMusicComment musiccomment = (IMusicComment)Assembly.Load(AssemblyName).CreateInstance(className); //返回一个SqlMusicComment对象
            return musiccomment;
        }
        public static IMusicType CreateMusicType()
        {
            string className = AssemblyName + "." + db + "MusicType";
            IMusicType imusictype = (IMusicType)Assembly.Load(AssemblyName).CreateInstance(className);//返回一个SqlMusicType对象
            return imusictype;
        }
        public static IVideoType CreateVideoType()
        {
            string className = AssemblyName + "." + db + "VideoType";
            IVideoType ivideotype = (IVideoType)Assembly.Load(AssemblyName).CreateInstance(className);//返回一个SqlVideoType对象
            return ivideotype;
        }
        public static IMusicCollectRecord CreateMusicCollectRecord()
        {
            string className = AssemblyName + "." + db + "MusicCollectRecord";
            IMusicCollectRecord irecord = (IMusicCollectRecord)Assembly.Load(AssemblyName).CreateInstance(className);//返回一个SqlMusicCollectRecord对象
            return irecord;
        }
        public static IVideoCollectRecord CreateVideoCollectRecord()
        {
            string className = AssemblyName + "." + db + "VideoCollectRecord";
            IVideoCollectRecord irecord = (IVideoCollectRecord)Assembly.Load(AssemblyName).CreateInstance(className);//返回一个SqlVideoCollectRecord对象
            return irecord;
        }
        public static IUserSingerApply CreateUserSingerApply()
        {
            string className = AssemblyName + "." + db + "UserSingerApply";
            IUserSingerApply iuserapply = (IUserSingerApply)Assembly.Load(AssemblyName).CreateInstance(className);//返回一个SqlUserSingerApply对象
            return iuserapply;
        }

        //社交模块
        public static IUserLeave CreateUserLeave()
        {
            string className = AssemblyName + "." + db + "UserLeave";
            IUserLeave iuserleave = (IUserLeave)Assembly.Load(AssemblyName).CreateInstance(className);//返回一个SqlUserLeave对象
            return iuserleave;
        }
        public static IUser_friends CreateUser_friends()
        {
            string className = AssemblyName + "." + db + "User_friends";
            IUser_friends iuser_friends = (IUser_friends)Assembly.Load(AssemblyName).CreateInstance(className);//返回一个SqlUser_friends对象
            return iuser_friends;
        }
        public static IMail CreateMails()
        {
            string className = AssemblyName + "." + db + "Mails";
            IMail imail = (IMail)Assembly.Load(AssemblyName).CreateInstance(className);   //返回一个SqlMails对象
            return imail;
        }
        public static ICircle CreateCircle()
        {
            string className = AssemblyName + "." + db + "Circle";
            ICircle icircle = (ICircle)Assembly.Load(AssemblyName).CreateInstance(className); //返回一个SqlCircle对象
            return icircle;
        }
        public static IActive CreateActive()
        {
            string className = AssemblyName + "." + db + "Active";
            IActive iactive = (IActive)Assembly.Load(AssemblyName).CreateInstance(className); //返回一个SqlActive对象
            return iactive;
        }
        public static IAccusedUsers CreateAccusedUsers()
        {
            string className = AssemblyName + "." + db + "AccusedUsers";
            IAccusedUsers iaccusedusers = (IAccusedUsers)Assembly.Load(AssemblyName).CreateInstance(className); //返回一个SqlAccusedUsers对象
            return iaccusedusers;
        }

        //商城模块
        public static IGoods CreateGoods()
        {
            string className = AssemblyName + "." + db + "Goods";
            IGoods igoods = (IGoods)Assembly.Load(AssemblyName).CreateInstance(className);//返回一个SqlGoods对象
            return igoods;
        }
        public static IGoodsType CreateGoodsType()
        {
            string className = AssemblyName + "." + db + "GoodsType";
            IGoodsType igoodstype = (IGoodsType)Assembly.Load(AssemblyName).CreateInstance(className);//返回一个SqlGoodsType对象
            return igoodstype;
        }
        public static IOrderdetails CreateOrderdetails()
        {
            string className = AssemblyName + "." + db + "Orderdetails";
            IOrderdetails iorderdetails = (IOrderdetails)Assembly.Load(AssemblyName).CreateInstance(className);//返回一个SqlOrderdetails对象
            return iorderdetails;
        }
        public static IOrders CreateOrders()
        {
            string className = AssemblyName + "." + db + "Orders";
            IOrders iorders = (IOrders)Assembly.Load(AssemblyName).CreateInstance(className);//返回一个SqlOrders对象
            return iorders;
        }
        public static IReceiptAddress CreateReceiptAddress()
        {
            string className = AssemblyName + "." + db + "ReceiptAddress";
            IReceiptAddress iaddress = (IReceiptAddress)Assembly.Load(AssemblyName).CreateInstance(className);//返回一个SqlReceiptAddress对象
            return iaddress;
        }
        public static ICart CreateCart()
        {
            string className = AssemblyName + "." + db + "Cart";
            ICart icart = (ICart)Assembly.Load(AssemblyName).CreateInstance(className);  //返回一个SqlCart对象
            return icart;
        }
        public static ICollect CreateCollect()
        {
            string className = AssemblyName + "." + db + "Collect";
            ICollect icollect = (ICollect)Assembly.Load(AssemblyName).CreateInstance(className);  //返回一个SqlCart对象
            return icollect;
        }
        public static IGoodsComment CreateGoodsComment()
        {
            string className = AssemblyName + "." + db + "GoodsComment";
            IGoodsComment igoodsComment = (IGoodsComment)Assembly.Load(AssemblyName).CreateInstance(className);
            return igoodsComment;
        }
        public static IShopCenter CreateShopCenter()
        {
            string className = AssemblyName + "." + db + "ShopCenter";
            IShopCenter ishopcenter = (IShopCenter)Assembly.Load(AssemblyName).CreateInstance(className); //返回一个SqlShopCenter对象
            return ishopcenter;
        }

        //后台管理
        public static IAdmin CreateAdmin()
        {
            string className = AssemblyName + "." + db + "Admin";
            IAdmin iadmin = (IAdmin)Assembly.Load(AssemblyName).CreateInstance(className);  //返回一个SqlAdmin对象
            return iadmin;
        }
    }
}
