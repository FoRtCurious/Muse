﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SingMusicDataBaseEntities : DbContext
    {
        public SingMusicDataBaseEntities()
            : base("name=SingMusicDataBaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccusedUsers> AccusedUsers { get; set; }
        public virtual DbSet<Active> Active { get; set; }
        public virtual DbSet<ActiveAlbum> ActiveAlbum { get; set; }
        public virtual DbSet<ActiveComplain> ActiveComplain { get; set; }
        public virtual DbSet<Activehide> Activehide { get; set; }
        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Block> Block { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Circle> Circle { get; set; }
        public virtual DbSet<CircleComplain> CircleComplain { get; set; }
        public virtual DbSet<Circlereply> Circlereply { get; set; }
        public virtual DbSet<CircleUserReply> CircleUserReply { get; set; }
        public virtual DbSet<Collect> Collect { get; set; }
        public virtual DbSet<CompanyMusics> CompanyMusics { get; set; }
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<GoodsType> GoodsType { get; set; }
        public virtual DbSet<JoinAct> JoinAct { get; set; }
        public virtual DbSet<MailChat> MailChat { get; set; }
        public virtual DbSet<MailChatRecords> MailChatRecords { get; set; }
        public virtual DbSet<Mails> Mails { get; set; }
        public virtual DbSet<MusicCollectRecord> MusicCollectRecord { get; set; }
        public virtual DbSet<MusicComment> MusicComment { get; set; }
        public virtual DbSet<MusicType> MusicType { get; set; }
        public virtual DbSet<Orderdetails> Orderdetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PlayRecord> PlayRecord { get; set; }
        public virtual DbSet<Receipt_address> Receipt_address { get; set; }
        public virtual DbSet<Reply> Reply { get; set; }
        public virtual DbSet<SingerAlbumLeave> SingerAlbumLeave { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<UpType> UpType { get; set; }
        public virtual DbSet<User_friends> User_friends { get; set; }
        public virtual DbSet<UserComplain> UserComplain { get; set; }
        public virtual DbSet<UserLeave> UserLeave { get; set; }
        public virtual DbSet<UserMusics> UserMusics { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserSingerApply> UserSingerApply { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<VideoCollectRecord> VideoCollectRecord { get; set; }
        public virtual DbSet<VideoComment> VideoComment { get; set; }
        public virtual DbSet<Videos> Videos { get; set; }
        public virtual DbSet<VideoType> VideoType { get; set; }
        public virtual DbSet<Suggest_good> Suggest_good { get; set; }
        public virtual DbSet<Suggest_type> Suggest_type { get; set; }
        public virtual DbSet<View_showactive> View_showactive { get; set; }
        public virtual DbSet<Addcomment> Addcomment { get; set; }
        public virtual DbSet<GoodsComment> GoodsComment { get; set; }
        public virtual DbSet<Add_comment> Add_comment { get; set; }
        public virtual DbSet<orderdetail_View> orderdetail_View { get; set; }
        public virtual DbSet<ActiveAlbumLeave> ActiveAlbumLeave { get; set; }
    
        public virtual ObjectResult<Nullable<int>> Sorce_avg(Nullable<int> goodsid)
        {
            var goodsidParameter = goodsid.HasValue ?
                new ObjectParameter("goodsid", goodsid) :
                new ObjectParameter("goodsid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Sorce_avg", goodsidParameter);
        }
    }
}