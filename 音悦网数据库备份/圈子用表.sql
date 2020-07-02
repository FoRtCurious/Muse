--发布动态表
create table Circle(
   cno int identity(1,1) not null primary key,     --活动编号  
   userid int not null ,          --用户编号外键
   uptime datetime null DEFAULT getdate() ,    -- 上传时间
   content text null ,        -- 文本内容
   imageurl varchar(200) null ,   --附带图片
   thumbs int default 1 ,    --点赞数量 
   replysum int default 0  ,   --回复数量
   varify char(4) null check (varify in ( '通过','失败')) ,    --审核状态
   c_state int default 0,
   foreign key (userid) references users(userid),
)

insert circle values ('20191050','','666666666hznb','../../content/','','','通过','')
insert circle values ('20191052','','666666666xxbnb','../../content/','','','通过','')
insert circle values ('20191054','','666666666lhnb','../../content/','','','通过','')
insert circle values ('20191088','','今晚演唱会不见不散','../../Content/images/circle/01.jpg','','','通过','')
insert circle values ('20191094','','风里雨里工作室等你','../../Content/images/circle/02.jpg','','','通过','')
insert circle values ('20191096','','上辈子作孽这辈子调试','../../Content/images/circle/03.jpg','','','通过','')