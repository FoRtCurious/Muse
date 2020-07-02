create database SingMusicDataBase
go
use SingMusicDataBase
go
-------------------------音乐模块数据-------------------------
/*用户类型表*/--1.普通用户  2.sing会员
create table userType(
	userType_id int identity(1,1) not null primary key,  --自动生成类型id
	userType_name varchar(10)                            --类型名称
)
--insert into userType values('普通用户');
--insert into userType values('sing会员');
--select * from userType;

/*用户信息表*/
CREATE TABLE users(
    userId int identity(20191047,1) not null primary key,  --自动生成账号，从20191047开始，可用来唯一标识账户
	phone_num varchar(11) not null unique,					--手机号码，可用来唯一标识账户
	password varchar(20) not null,							--密码
	name varchar(50) not null  unique,					--用户昵称，可用来唯一标识账户
	photo varchar(200) not null,						   --用户头像地址
	birthday  datetime not null,					   --用户出生年月
	user_sex char(2) check(user_sex in('男','女',null)),--用户性别									   
	register_time datetime not null,				   --用户注册时间
	userType_id int not null,						   --用户类别id，参照用户类型userType表
	area varchar(50),								   --用户所在地
	user_like int,
	user_info varchar(200),
    foreign key (userType_id) references userType(userType_id),
)
--insert into users values('18270032680','123456','`南浅','..\..\Content\images\users\01.jpg','1999-10-5','男','2019-11-4',1,null);
--insert into users values('18270032681','123456','草莓Boy','..\..\Content\images\users\02.jpg','1999/3/5','男','2019/11/4',1,null);
--insert into users values('18270032682','123456','Dj喜洋洋','..\..\Content\images\users\03.jpg','1998/8/10','男','2019/11/4',1,null);
--insert into users values('18270032683','123456','妾身小妲己','..\..\Content\images\users\04.jpg','1999/12/5','女','2019/11/4',1,null);
--insert into users values('18270032684','123456','_西街豆腐君','..\..\Content\images\users\05.jpg','1999/11/15','男','2019/11/4',1,null);
--insert into users values('18270032685','123456','Heboy','..\..\Content\images\users\06.jpg','1999/6/27','男','2019/11/4',1,null);
--insert into users values('13129704434','123456','小猪佩奇','..\..\Content\images\users\07.jpg','2000/10/1','女','2019/11/4',1,null);
--insert into users values('18270032686','123456','林先生是我','..\..\Content\images\users\08.jpg','1999-10-5','男','2019-11-4',1,null);
--insert into users values('18270032687','123456','我是可乐呀','..\..\Content\images\users\09.jpg','1999/3/5','女','2019/11/4',1,null);
--insert into users values('18270032688','123456','啾咪~啾咪~','..\..\Content\images\users\10.jpg','1998/8/10','女','2019/11/4',1,null);
--insert into users values('18270032689','123456','森林岛屿','..\..\Content\images\users\11.jpg','1999/12/5','女','2019/11/4',1,null);
--insert into users values('18270032690','123456','_后街小男孩','..\..\Content\images\users\12.jpg','1999/11/15','男','2019/11/4',1,null);
--insert into users values('18270032691','123456','Rooby','..\..\Content\images\users\13.jpg','1999/6/27','男','2019/11/4',1,null);
--insert into users values('13129704435','123456','酒店不打烊','..\..\Content\images\users\14.jpg','2000/10/1','女','2019/11/4',1,null);
--select * from users;


/*用户好友信息表*/--多对多
create table user_friends(
	id int identity(1,1) not null primary key,		
	userId int not null,							--用户id
	adduserId int not null,							--好友的id
	add_date datetime not null,						--添加时间
	foreign key (userId) references users(userId),   --参照用户表
	foreign key (adduserId) references users(userId)   --参照用户表
)

/*歌曲风格类型表*/--古风1，流行2，电子3，民谣4
create table musicType(
	typeId int identity(1,1) not null primary key,  --类型id
	typeName varchar(20) not null,					--歌曲类型名
)
--insert into musicType values('古风');
--insert into musicType values('流行');
--insert into musicType values('电子');
--insert into musicType values('民谣');
--select * from musicType;

/*歌曲上传类型表*/--原创1，翻唱2
create table upType(
	typeId int identity(1,1) not null primary key,	--类型id
	typeName varchar(20) not null,					--上传类型名
)
--insert into upType values('原创');
--insert into upType values('翻唱');
--select * from upType;

/*用户上传歌曲信息表*/
create table userMusics(
	music_id int identity(1,1) not null primary key,--上传歌曲id
	music_name char(20) not null,	--上传歌曲名
	user_id int not null,           --上传用户id
	imgage_url varchar(200),         --歌曲专辑照片地址
	music_url varchar(200),          --歌曲资源地址
	musicType_id int,               --歌曲风格id
	upType_id int,                  --歌曲上传类型id
	music_like int,                 --歌曲点赞量
	music_lyric varchar(500),       --歌词
	music_info varchar(100),        --歌曲介绍
	upTime datetime,				--歌曲上传时间
	listen_times int,				--歌曲播放次数
	music_state int not null,       --歌曲状态
	music_check int not null,       --歌曲是否已通过审核
	foreign key (musicType_id) references musicType(typeId),
	foreign key (upType_id) references upType(typeId),
	foreign key (user_id) references users(userId),
)
alter table UserMusics add music_check int not null default(1)
--insert into userMusics values('世界美好与你环环相扣',20191047,'..\..\Content\images\userMusics\1.jpg',null,2,2,0,null);
--insert into userMusics values('后来',20191048,'..\..\Content\images\userMusics\2.jpg',null,2,2,0,null);
--insert into userMusics values('遇见',20191049,'..\..\Content\images\userMusics\3.jpg',null,2,2,0,null);
--insert into userMusics values('拜拜',20191050,'..\..\Content\images\userMusics\4.jpg',null,2,2,0,null);
--insert into userMusics values('有幸',20191051,'..\..\Content\images\userMusics\5.jpg',null,2,2,0,null);
--insert into userMusics values('那女孩对我说',20191052,'..\..\Content\images\userMusics\6.jpg',null,2,2,0,null);
--insert into userMusics values('【红昭愿】',20191053,'..\..\Content\images\userMusics\7.jpg',null,1,2,0,null);
--insert into userMusics values('你的酒馆对我打了烊',20191054,'..\..\Content\images\userMusics\8.jpg',null,2,2,0,null);
--insert into userMusics values('可惜不是你',20191055,'..\..\Content\images\userMusics\9.jpg',null,2,2,0,null);
--insert into userMusics values('他的猫',20191056,'..\..\Content\images\userMusics\10.jpg',null,2,2,0,null);
--insert into userMusics values('树洞',20191057,'..\..\Content\images\userMusics\11.jpg',null,2,2,0,null);
--insert into userMusics values('有点甜',20191058,'..\..\Content\images\userMusics\12.jpg',null,2,2,0,null);
--insert into userMusics values('流星雨',20191059,'..\..\Content\images\userMusics\13.jpg',null,2,2,0,null);
--insert into userMusics values('岁月神偷',20191060,'..\..\Content\images\userMusics\14.jpg',null,2,2,0,null);
--insert into userMusics values('最佳听众',20191047,'..\..\Content\images\userMusics\15.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('乐园',20191048,'..\..\Content\images\userMusics\16.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('背对背拥抱',20191049,'..\..\Content\images\userMusics\17.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('小幸运',20191050,'..\..\Content\images\userMusics\18.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('你曾是少年',20191051,'..\..\Content\images\userMusics\19.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('美丽的神话',20191052,'..\..\Content\images\userMusics\20.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('坏女孩',20191053,'..\..\Content\images\userMusics\21.jpg',null,1,2,0,null,null,null,null);
--insert into userMusics values('纸短情长',20191054,'..\..\Content\images\userMusics\22.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('有一种悲伤',20191055,'..\..\Content\images\userMusics\23.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('只对你有感觉',20191056,'..\..\Content\images\userMusics\24.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('年少有为',20191057,'..\..\Content\images\userMusics\25.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('九九八十一',20191058,'..\..\Content\images\userMusics\26.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('当你',20191059,'..\..\Content\images\userMusics\27.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('GQ',20191060,'..\..\Content\images\userMusics\28.jpg',null,2,2,0,null,null,null,null);
--DBCC CHECKIDENT ('dbo.userMusics', RESEED,14)   修改自增id
--select * from userMusics; 


/*伴奏歌曲表*/
create table companyMusics(
	cm_id int identity(1,1) not null primary key,--伴奏id
	cm_name char(20) not null,		--伴奏名
	music_url varchar(200),          --伴奏资源地址
	music_down int,                 --伴奏下载量
	music_upTime datetime,       --伴奏上传时间
	music_type varchar(10),			--伴奏格式
)
execute sp_rename 'companyMusics.music_lyric','music_upTime'
--insert into companyMusics values('世间美好与你环环相扣','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('夜空中最亮的星','~/AppData/','1466',null,'MP3');
--insert into companyMusics values('柏松-世间美好与你环环相扣','~/AppData/','1399',null,'MP3');
--insert into companyMusics values('芒种-原版伴奏','~/AppData/','1546',null,'MP3');
--insert into companyMusics values('最佳听众','~/AppData/','1799',null,'MP3');
--insert into companyMusics values('可惜不是你','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('慢慢喜欢你','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('树洞','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('有点甜-by2','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('一曲相思','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('当你走了','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('流星雨','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('鸽子','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('Insomnia','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('耿','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('忽而今夏','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('有幸(cover)','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('岁月神偷','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('起风了','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('TheDayYouWantAway','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('God is a girl','~/AppData/','1596',null,'MP3');
--select * from companyMusics;

/*视频类型表*/--中国1，日韩2，欧美3，港澳4,台湾5，其他6
create table videoType(
	typeId int identity(1,1) not null primary key,  
	typeName varchar(20) not null,
)
--insert into videoType values('中国');
--insert into videoType values('日韩');
--insert into videoType values('欧美');
--insert into videoType values('港澳');
--insert into videoType values('台湾');
--insert into videoType values('其他');
--DBCC CHECKIDENT ('dbo.videoType', RESEED,5)
--select * from videoType;

/*视频信息表*/
create table videos(
	video_id int identity(1,1) not null primary key,
	user_id int,                --上传作品用户id
	video_name varchar(100) not null,--视频名称
	video_photo varchar(200),	--视频封面
	video_url varchar(200),      --视频资源位置
	videoType_id int,			--视频类型
	video_look int,				--视频播放量
	video_info varchar(500),	--视频简介
	video_upTime datetime,		--视频上传时间
	foreign key (user_id) references users(userId),
	foreign key (videoType_id) references videoType(typeId),
)
--insert into videos values('20191047','【雁心出品】迷津','../../Content/images/videos/1.jpg','../../Content/',1,555); 
--insert into videos values('20191048','缘聚心然','../../Content/images/videos/2.jpg','../../Content/',1,666); 
--insert into videos values('20191049','孤城闭【古风】','../../Content/images/videos/3.jpg','../../Content/',1,777); 
--insert into videos values('20191050','《昭奚旧草》','../../Content/images/videos/4.jpg','../../Content/',1,888); 
--select * from videos;
--execute sp_rename 'videos.vodeo_look','video_look'  //重命名字段
alter table videos alter column video_name varchar(100)

/*歌曲播放记录表*/
create table playRecord(
	id int identity(1,1) not null,
	music_id int,
	user_id int,                --用户id
	play_time datetime,
	primary key(music_id,user_id),
	foreign key (user_id) references users(userId),
	foreign key (music_id) references userMusics(music_id)
)
/*歌曲收藏记录表*/
create table musicCollectRecord(
	id int identity(1,1) not null,
	music_id int,
	user_id int,                --用户id
	collect_time datetime,
	primary key(music_id,user_id),
	foreign key (user_id) references users(userId),
	foreign key (music_id) references userMusics(music_id)
)
--select * from collectRecord;
/*视频播放记录表*/
create table videoCollectRecord(
	id int identity(1,1) not null,
	video_id int,
	user_id int,                --用户id
	collect_time datetime,
	primary key(video_id,user_id),
	foreign key (user_id) references users(userId),
	foreign key (video_id) references videos(video_id)
)

/*视频评论表*/
create table videoComment(
	id int identity(1,1) not null primary key,
	video_id int,
	user_id int,                --用户id
	Comment_time datetime,		--评论时间
	Comment_content	varchar(2000)			--评论内容
	foreign key (user_id) references users(userId),
	foreign key (video_id) references videos(video_id)
)

/*用户留言表*/
create table userLeave(
	id int identity(1,1) not null primary key,
	user_id int,
	Leaveuser_id int,               --用户id
	Leave_time datetime,			--留言时间
	Leave_content varchar(1000),     --留言内容
	foreign key (user_id) references users(userId),
	foreign key (Leaveuser_id) references users(userId)
)
---------------------论坛模块数据-------------------------
--板块表
create table Block (     
	Bno int identity(1,1) not null primary key,
	Bname varchar(20) not null unique ,
	Btopicsum  int not null ,		--话题数量
	Breplysum int  not null ,       --回复数量
	Busersum int  not null ,		--参与用户数量
)
-- 板块表数据
--insert Block values ('网红原创','1','11','111') 
--insert Block values ('大学校园','1','11','111') 
--insert Block values ('我的大学','1','11','111') 
--insert Block values ('游戏新区','1','11','111') 
--insert Block values ('煮酒论歌','1','11','111') 
--insert Block values ('工作听歌','1','11','111') 
--insert Block values ('魔改鬼畜','1','11','111') 
--insert Block values ('今日新曲','1','11','111') 
--insert Block values ('耳机专场','1','11','111') 
--insert Block values ('怀旧翻唱','1','11','111') 
--insert Block values ('议事广场','1','11','111') 
--insert Block values ('用户投诉','1','11','111') 
--insert Block values ('灌水专区','1','11','111') 

--话题表
create table Topic (   
	Tno int identity(1,1) not null primary key,
	Tname varchar(20) not null unique ,
	Holder int not null ,       --主持人
	Location int not null ,     --所属板块
	TContent text not null ,        --内容 
	Readsum int default'1' ,     --阅读量
	Replysum int default'0',    --回复量
	Varify char(4) not null check(Varify in ( '通过','失败') ) ,   --审核状态
	foreign key (Holder) references users(userId),
	foreign key (Location) references Block(Bno),
)

--话题表数据  
--insert Topic values ('网红精选歌曲大赏','20191047',1,'一人一首喜爱的原创歌曲，让世界听到你的声音！','66','2','通过')
--insert Topic values ('我的逗逼室友','20191048',2,'一人一首来自室友的歌曲，让世界听到你的声音！','66','2','通过')
--insert Topic values ('大学里的十佳歌手','20191049',3,'一人一首喜爱的原创歌曲，让世界听到你的声音！','66','2','通过')
--insert Topic values ('音乐提供的游戏加成','20191050',4,'一人一首喜爱的游戏歌曲，让世界听到你的激情！','66','2','通过')
--insert Topic values ('不得不吐槽的那些歌','20191051',5,'你的踩雷并不是毫无意义','66','2','通过')
--insert Topic values ('最适合工作时听的歌','20191052',6,'美妙的歌曲给工作带来不一样的体验','66','2','通过')
--insert Topic values ('听到腿抖到挨打的歌','20191053',7,'上课不准听的歌曲！','66','2','通过')
--insert Topic values ('今日热度最高','20191054',8,'让我们一起听一听今天热度最高的歌曲','66','2','通过')
--insert Topic values ('大触喜爱的音乐耳机','20191055',9,'用最合适的耳机听最合适的歌曲','66','2','通过')
--insert Topic values ('经典铸就美好','20191056',10,'一人一首喜爱的原创歌曲，让世界听到你的声音！','66','2','通过')
--insert Topic values ('在这写下你的所有建议','20191057',11,'你的每一个建议都会有专人给你解决','66','2','通过')  
--insert Topic values ('在这写下你的所有投诉','20191058',12,'你的每一次投诉都会有专人给你解决','66','2','通过')
--insert Topic values ('今天也是元气满满的','20191060',13,'所有好的不好的都会过去','66','2','通过')

--回复表 
create table Reply (        
	Rno int identity(1,1) not null primary key,
	Responder_id int not null ,			--回复人
	RTLocation_id int not null ,		--所属话题
	RBLocation_id int not null ,		--所属板块
	RContent text not null ,			--回复内容
	Rtime datetime NOT NULL DEFAULT getdate() ,   --回复时间
	Likesum int default'0',				--点赞数
	foreign key (Responder_id) references users(userId),
	foreign key (RTLocation_id) references Topic(Tno),
	foreign key (RBLocation_id) references Block(Bno),
)
--回复表数据
--insert Reply values ('20191047',1,1,'那些年那些兔那些事','2019/11/11','666')
--insert Reply values ('20191048',2,2,'那些年那些兔那些事','2019/11/11','666')
--insert Reply values ('20191049',3,3,'那些年那些兔那些事','2019/11/11','666')
--insert Reply values ('20191050',4,4,'那些年那些兔那些事','2019/11/11','666')
--insert Reply values ('20191051',5,5,'那些年那些兔那些事','2019/11/11','666')
--insert Reply values ('20191052',6,6,'那些年那些兔那些事','2019/11/11','666')
--insert Reply values ('20191053',7,7,'那些年那些兔那些事','2019/11/11','666')
--insert Reply values ('20191054',8,8,'那些年那些兔那些事','2019/11/11','666')
--insert Reply values ('20191055',9,9,'那些年那些兔那些事','2019/11/11','666')
--insert Reply values ('20191056',10,10,'那些年那些兔那些事','2019/11/11','666')
--insert Reply values ('20191057',11,11,'那些年那些兔那些事','2019/11/11','666')
--insert Reply values ('20191058',12,12,'那些年那些兔那些事','2019/11/11','666')
--insert Reply values ('20191059',13,13,'那些年那些兔那些事','2019/11/11','666')

----------------活动模块数据-----------------------------------
--类别表
create table   Category (       
	Cno int identity(1,1) not null primary key,
	Cname varchar(20) not null unique ,
	Usersum int default'0',		--参与用户数量
	Actsum  int default'0',     --活动数量
	Clicksum int default'1',    --点击数
)
--insert Category values ('户外','1','2','3')
--insert Category values ('线上','1','2','3')
--insert Category values ('融合','1','2','3')

-- 活动表
create table Activity(       
	Ano int identity(1,1) not null primary key,
	Aname varchar(20) not null unique ,--活动名称
	AContent text not null ,        --活动内容
	AHolder int not null ,          --活动主持人
	ACLocation int not null ,       --所属类别
	Joinsum int not null ,			--参与数量
	Viewsum int not null ,			--浏览量
	DDLine datetime null ,          --截止时间
	foreign key (AHolder) references users(userId),
	foreign key (ACLocation) references Category(Cno),
)

--insert Activity values ('大触觉醒—《阴阳师》','竹林笛音琳琅，歌者轻声和唱。曲调妙扬，快来一同奏响平安世界的动人旋律吧~万元奖金、周边福袋以及全新大触头像框在这里等你！原创报名:录制参赛歌曲→登录音悦网个人主页→点击上传歌曲→填好歌曲相关信息。 复制作品链接至本活动页面报名处的地址栏，点击报名按钮→发布微博加标签TAG#大触觉醒##礼乐和鸣#原创音乐基地@网易阴阳师手游@阴阳师手游同人帐→参赛成功。 与阴阳师游戏无关的作品将视为无效作品。为避免比赛中产生不必要的质疑和纠纷。请所有参赛选手保留比赛歌曲的干声。 原创歌曲参赛作品要求为【演唱曲】，参赛作品命名格式：歌曲名（阴阳师原创）。翻唱报名:翻唱曲目为限定的17首歌曲《御鬼录》、《阴阳名仕录》、《妖怪町奇谭》、《寄我此生》、《平安经年》、风缘(山风视角) 风缘(薰视角)、《春樱之宴》、《平安幻想乡》、《心生七面 善恶难辨》、《寄往明天的回忆之歌》、《少羽之志》、《未名之罪》、《神之将至》、《百鬼阴阳抄》、《荒海物语》、《平安奇妙物语》。 下载本次活动指定的翻唱曲目的伴奏→录制参赛歌曲 → 登录音悦网个人主页 → 点击上传歌曲 → 填好歌曲相关信息。 复制作品链接至本活动页面报名处的地址栏，点击报名按钮 → 发布微博加标签TAG#大触觉醒##礼乐和鸣# ~网易阴阳师手游 ~阴阳师手游同人帐 ~原创音乐基地→ 参赛成功。 如发现盗取、侵权等不实行为，将被直接取消比赛资格。为避免比赛中产生不必要的质疑和纠纷。请所有参赛选手保留比赛歌曲的干声。 参赛曲目作品命名格式：歌曲名（阴阳师翻唱）。',
--                        '20191047',2,1024,'66','2020/11/11')
--insert Activity values ('斗破最燃音声动破苍穹','由《斗破苍穹》小说、动漫、影视三方联合正版IP授权，吴磊、林允主演热播剧同名手游已正式上线，为了回馈粉丝和玩家朋友们，《斗破苍穹手游》特倾情举办斗破苍穹主题曲征集/翻唱大赛，诚邀各位才华横溢的斗者为游戏创作或演唱主题曲。原创报名:录制参赛歌曲→ 登录音悦网个人主页→ 点击上传歌曲→ 填好歌曲相关信息。 复制作品链接至本活动页面，点击报名按钮→ 发布微博加标签TAG#斗破最燃音，声动破苍穹# 并@斗破苍穹斗帝之路手游@斗破苍穹官微@原创音乐基地→ 参赛成功。 参赛作品需为《斗破苍穹》手游及动画相关原创歌曲或大赛指定翻唱歌曲，并由本人亲自创作或演唱，上传不合规定的作品视为无效。 同人原创音乐大赛需围绕以下角色进行创作：萧炎、萧薰儿、彩麟、云韵、纳兰嫣然、小医仙、青鳞、紫研、林修崖。亦可使用手游中“远古八族”职业名进行创作：萧族·焚炎、雷族·千影、石族·漠铁、灵族·御风、古族、魂族、药族、炎族。 翻唱作品选择演唱官方指定歌单曲目，上传作品到活动页面（请使用本活动页面所提供的歌曲伴奏，演唱方式不作要求，旋律及编曲等可进行一定程度改编，但不接受重新填词）。 参赛曲目作品命名须统一前缀【斗破苍穹同人音乐原创】+歌曲名翻唱报名:录制参赛歌曲→ 登录音悦网个人主页→ 点击上传歌曲→ 填好歌曲相关信息。 复制作品链接至本活动页面，点击报名按钮→按弹窗要求填写个人信息→ 发布微博加标签TAG#斗破最燃音，声动破苍穹# 并@斗破苍穹斗帝之路手游@斗破苍穹官微@原创音乐基地→ 参赛成功。 参赛作品需为《斗破苍穹》手游及动画相关原创歌曲或大赛指定翻唱歌曲，并由本人亲自创作或演唱，上传不合规定的作品视为无效。 翻唱作品选择演唱官方指定歌单曲目，上传作品到活动页面（请使用本活动页面所提供的歌曲伴奏，演唱方式不作要求，旋律及编曲等可进行一定程度改编，但不接受重新填词）。 参赛曲目作品命名须统一前缀 【斗破苍穹同人音乐翻唱】+歌曲名;',
--                        '20191048',3,1024,'66','2020/11/11')
--insert Activity values ('草莓音乐节见面会','由音悦网主办的草莓音乐节即将举报，所有有兴趣的原创歌手均可报名参加本次草莓音乐节获得上台演出的机会，同时还能获得由音悦网送出的精美礼品等；所有用户均可报名参加本次音乐会，平台将送出1000张门票让你亲临现场收听你喜欢的原创歌手的现场歌曲',
--                        '20191049',1,1024,'66','2020/11/11')
-- 参与表
create table JoinAct ( 
    JoinAct_no int identity(1,1) not null primary key,      
	JoinUser_id int not null ,
	JoinCategory_id int not null ,
	Jointime datetime NOT NULL DEFAULT getdate() ,   --参与时间 
	foreign key (JoinUser_id) references users(userId),
	foreign key (JoinCategory_id) references Category(Cno),
)
-- 参与表数据
--insert JoinAct values ('20191047',1,'2019/11/11')
--insert JoinAct values ('20191048',1,'2019/11/11')
--insert JoinAct values ('20191049',2,'2019/11/11')
--insert JoinAct values ('20191050',2,'2019/11/11')
--insert JoinAct values ('20191051',2,'2019/11/11')
--insert JoinAct values ('20191052',3,'2019/11/11')
--insert JoinAct values ('20191053',3,'2019/11/11')
--insert JoinAct values ('20191054',3,'2019/11/11')


-----------商场模块数据-----------------------------
--创建收货地址表
create table Receipt_address
(addressid int Identity(1,1) not null primary key,
 userid int not null foreign key references users(userId),
 name varchar(20) not null ,
 address varchar(200) not null,
 telephone varchar(15) not null
)
--创建商品分类表
create table goodsType
(
goodstypeid int Identity(1,1) Not null primary key,
typename varchar(50) Not null
)
--insert into goodsType values('耳机')
--insert into goodsType values('雨伞')
--insert into goodsType values('键盘')
--insert into goodsType values('充电宝')
--insert into goodsType values('尤克里里')

--创建商品表
create table Goods
(goodsid	int Identity(1,1) Not null primary key,
 goodsname varchar(50) Not null,
 price	decimal(7,2) Not null,
 goodstypeid	int	Not null foreign key references goodsType(goodstypeid),
 img varchar(200),
)
alter table Goods alter column goodsname varchar(200) 
insert 
into Goods(goodsname,price,goodstypeid,img)
values ('JBL T120A 立体声入耳式耳机 手机音乐耳机 游戏耳机 耳机耳麦 带麦可通话','128','1','../Content/images/shopping/goods/1.png');
insert 
into Goods(goodsname,price,goodstypeid,img)
values ('网易云音乐定制款W800X头戴式蓝牙耳机','169','1','../Content/images/shopping/goods/3.png');
insert 
into Goods(goodsname,price,goodstypeid,img)
values ('网易云音乐联名款漫步者W280X蓝牙耳机','199','1','../Content/images/shopping/goods/4.png');
insert 
into Goods(goodsname,price,goodstypeid,img)
values ('漫步者（EDIFIER）W3 小黄人联名款 真无线蓝牙入耳式手机通用音乐耳机耳塞','169','1','../Content/images/shopping/goods/5.png');
 
insert 
into Goods(goodsname,price,goodstypeid,img)
values ('热血同行 周边 【热血无畏】晴雨伞','119','2','../Content/images/shopping/goods/6.png');
insert 
into Goods(goodsname,price,goodstypeid,img)
values ('《亲爱的，热爱的》同款晴雨伞，','99','2','../Content/images/shopping/goods/7.png');
insert 
into Goods(goodsname,price,goodstypeid,img)
values ('人间星河晴雨伞 初恋那件小事官方正版','135','2','../Content/images/shopping/goods/8.png');
insert 
into Goods(goodsname,price,goodstypeid,img)
values ('【正版授权】美少女战士折叠晴雨伞','128','2','../Content/images/shopping/goods/9.png');


insert 
into Goods(goodsname,price,goodstypeid,img)
values ('美德威61/88键手卷钢琴便携电子琴硅胶钢琴键盘','298','3','../Content/images/shopping/goods/10.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('洛非/Lofree DOT 圆点蓝牙机械键盘','399','3','../Content/images/shopping/goods/11.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('【网红口红键盘】无线蓝牙机械键盘','699','3','../Content/images/shopping/goods/12.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('手卷钢琴88键盘 初学者电子键盘 便携式软折叠','398','3','../Content/images/shopping/goods/13.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('【能量棒】原木充电宝/移动电源 power bank','169','4','../Content/images/shopping/goods/14.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('愤怒的小鸟智能安全充电宝','69','4','../Content/images/shopping/goods/15.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('皮卡丘卡通可乐罐充电宝8000毫安','89','4','../Content/images/shopping/goods/16.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('【太阳超人充电宝】 初恋那件小事官方正版','185','4','../Content/images/shopping/goods/17.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('Tom全单桃花心木ukulele23寸单板尤克里里小吉他','450','5','../Content/images/shopping/goods/18.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('Nices NC100升级款尤克里里桃花心木23寸入门','288','5','../Content/images/shopping/goods/19.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('Kaka25D单板尤克里里初学者23寸/26寸全小吉他','437','5','../Content/images/shopping/goods/20.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('阿拉德adela熊童子异型尤克里里22寸','388','5','../Content/images/shopping/goods/21.png');

--创建订单表
create table orders
(
orderid	int Identity(1,1)	Not null primary key,
userid	int	Not null foreign key references users(userId),
addressid	int	Not null foreign key references Receipt_address(addressid),
ordertime	datetime Not null,
Tot_amt	decimal(7,2) Not null
)


--创建订单明细表
create table Orderdetails
(
orderdetailsid	int Identity(1,1)	Not null primary key,
orderid	int	Not null foreign key references Orders(orderid),
goodsid	int	Not null foreign key references Goods(goodsid),
qty	int	Not null,
price decimal(7,2) Not null
)
--创建购物车表
create table Cart
(
cartkid	int Identity(1,1)	Not null primary key,
userid	int	Not null foreign key references users(userId),
goodsid	int	Not null foreign key references Goods(goodsid),
qty	int	Not null,
price decimal(7,2)	Not null
)


--后台管理
--创建音乐人申请表
create table UserSingerApply
(
	accusedid	int Identity(10201047,1)	Not null primary key,
	userId	int	Not null foreign key references Users(userId),
	applytime	datetime Not null,
	deal_state int
)
alter table UserSingerApply add deal_state int
--创建被举报用户表
create table AccusedUsers
(
	accusedid	int Identity(10000,1)	Not null primary key,
	userId	int	Not null foreign key references Users(userId),
	accusedtime	datetime Not null,
	accusedreason varchar(1000)	Not null,
	deal_state int
)