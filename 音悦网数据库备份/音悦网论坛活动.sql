--论坛模块表

--板块表
create table Block (     
	Bno char(5) not null  primary key ,
	Bname varchar(20) not null unique ,
	Btopicsum  int not null ,      --话题数量
	Breplysum int  not null ,       --回复数量
	Busersum int  not null ,      --参与用户数量
)
-- 板块表数据
insert Block values ('11111','网红原创','1','11','111') 
insert Block values ('11112','大学校园','1','11','111') 
insert Block values ('11113','我的大学','1','11','111') 
insert Block values ('11114','游戏新区','1','11','111') 
insert Block values ('11115','煮酒论歌','1','11','111') 
insert Block values ('11116','工作听歌','1','11','111') 
insert Block values ('11117','魔改鬼畜','1','11','111') 
insert Block values ('11118','今日新曲','1','11','111') 
insert Block values ('11119','耳机专场','1','11','111') 
insert Block values ('11120','怀旧翻唱','1','11','111') 
insert Block values ('11121','议事广场','1','11','111') 
insert Block values ('11122','用户投诉','1','11','111') 
insert Block values ('11123','灌水专区','1','11','111') 

--话题表
create table Topic (   
	Tno char(5) not null  primary key ,
	Tname varchar(20) not null unique ,
	Holder int not null ,     --主持人
	Location char(5) not null ,     --所属板块
	TContent text not null ,        --内容 
	Readsum int default'1' ,     --阅读量
	Replysum int default'0',    --回复量
	Varify char(4) not null check(Varify in ( '通过','失败') ) ,   --审核状态
	foreign key (Holder) references users(userid),
	foreign key (Location) references Block(Bno),
)

--话题表数据  
insert Topic values ('22221','网红精选歌曲大赏','20191047','11111','一人一首喜爱的原创歌曲，让世界听到你的声音！','66','2','通过')
insert Topic values ('22222','我的逗逼室友','20191048','11112','一人一首来自室友的歌曲，让世界听到你的声音！','66','2','通过')
insert Topic values ('22223','大学里的十佳歌手','20191049','11113','一人一首喜爱的原创歌曲，让世界听到你的声音！','66','2','通过')
insert Topic values ('22224','音乐提供的游戏加成','20191050','11114','一人一首喜爱的游戏歌曲，让世界听到你的激情！','66','2','通过')
insert Topic values ('22225','不得不吐槽的那些歌','20191051','11115','你的踩雷并不是毫无意义','66','2','通过')
insert Topic values ('22226','最适合工作时听的歌','20191052','11116','美妙的歌曲给工作带来不一样的体验','66','2','通过')
insert Topic values ('22227','听到腿抖到挨打的歌','20191053','11117','上课不准听的歌曲！','66','2','通过')
insert Topic values ('22228','今日热度最高','20191054','11118','让我们一起听一听今天热度最高的歌曲','66','2','通过')
insert Topic values ('22229','大触喜爱的音乐耳机','20191055','11119','用最合适的耳机听最合适的歌曲','66','2','通过')
insert Topic values ('22230','经典铸就美好','20191056','11120','一人一首喜爱的原创歌曲，让世界听到你的声音！','66','2','通过')
insert Topic values ('22231','在这写下你的所有建议','20191057','11121','你的每一个建议都会有专人给你解决','66','2','通过')  
insert Topic values ('22232','在这写下你的所有投诉','20191058','11122','你的每一次投诉都会有专人给你解决','66','2','通过')
insert Topic values ('22233','今天也是元气满满的','20191060','11123','所有好的不好的都会过去','66','2','通过')

--回复表 
create table Reply (        
	Rno char(5) not null primary key ,
	Responder int not null ,      --回复人
	RTLocation char(5) not null ,     --所属话题
	RBLocation char(5) not null ,     --所属板块
	RContent text not null ,            --回复内容
	Rtime datetime NOT NULL DEFAULT getdate() ,   --回复时间
	Likesum int default'0',     --点赞数
	foreign key (Responder) references users(userid),
	foreign key (RTLocation) references Topic(Tno),
	foreign key (RBLocation) references Block(Bno),
)
--回复表数据
insert Reply values ('33331','20191048','22221','11111','那些年那些兔那些事','2019/11/11','66')
insert Reply values ('33332','20191049','22222','11112','那些年那些兔那些事','2019/11/11','66')
insert Reply values ('33333','20191050','22223','11113','那些年那些兔那些事','2019/11/11','66')
insert Reply values ('33334','20191051','22224','11114','那些年那些兔那些事','2019/11/11','66')
insert Reply values ('33335','20191052','22225','11115','那些年那些兔那些事','2019/11/11','66')
insert Reply values ('33336','20191053','22226','11116','那些年那些兔那些事','2019/11/11','66')
insert Reply values ('33337','20191054','22227','11117','那些年那些兔那些事','2019/11/11','66')
insert Reply values ('33338','20191055','22228','11118','那些年那些兔那些事','2019/11/11','66')
insert Reply values ('33339','20191056','22229','11119','那些年那些兔那些事','2019/11/11','66')
insert Reply values ('33340','20191057','22230','11120','那些年那些兔那些事','2019/11/11','66')
insert Reply values ('33341','20191058','22231','11121','那些年那些兔那些事','2019/11/11','66')
insert Reply values ('33342','20191059','22232','11122','那些年那些兔那些事','2019/11/11','66')
insert Reply values ('33343','20191047','22233','11123','那些年那些兔那些事','2019/11/11','66')

--活动模块表

--类别
create table   Category (       
	Cno char(5) not null primary key ,
	Cname varchar(20) not null unique ,
	Usersum int default'0',   --参与用户数量
	Actsum int default'0',     --活动数量
	Clicksum int default'1',    --点击数
)

insert Category values ('44441','户外','1','2','3')
insert Category values ('44442','线上','1','2','3')
insert Category values ('44443','融合','1','2','3')


create table Activity(       -- 活动表
	Ano char (5) not null primary key , 
	Aname varchar(20) not null unique ,
	AContent text not null ,       --活动内容
	AHolder int not null ,          --活动主持人
	ACLocation char(5) not null ,       --所属类别
	Joinsum int not null ,     --参与数量
	Viewsum int not null ,     --浏览量
	DDLine datetime null ,           --截止时间
	foreign key (AHolder) references users(userid),
	foreign key (ACLocation) references Category(Cno),
)

insert Activity values ('55551','大触觉醒—《阴阳师》','竹林笛音琳琅，歌者轻声和唱。曲调妙扬，快来一同奏响平安世界的动人旋律吧~万元奖金、周边福袋以及全新大触头像框在这里等你！原创报名:录制参赛歌曲→登录音悦网个人主页→点击上传歌曲→填好歌曲相关信息。 复制作品链接至本活动页面报名处的地址栏，点击报名按钮→发布微博加标签TAG#大触觉醒##礼乐和鸣#原创音乐基地@网易阴阳师手游@阴阳师手游同人帐→参赛成功。 与阴阳师游戏无关的作品将视为无效作品。为避免比赛中产生不必要的质疑和纠纷。请所有参赛选手保留比赛歌曲的干声。 原创歌曲参赛作品要求为【演唱曲】，参赛作品命名格式：歌曲名（阴阳师原创）。翻唱报名:翻唱曲目为限定的17首歌曲《御鬼录》、《阴阳名仕录》、《妖怪町奇谭》、《寄我此生》、《平安经年》、风缘(山风视角) 风缘(薰视角)、《春樱之宴》、《平安幻想乡》、《心生七面 善恶难辨》、《寄往明天的回忆之歌》、《少羽之志》、《未名之罪》、《神之将至》、《百鬼阴阳抄》、《荒海物语》、《平安奇妙物语》。 下载本次活动指定的翻唱曲目的伴奏→录制参赛歌曲 → 登录音悦网个人主页 → 点击上传歌曲 → 填好歌曲相关信息。 复制作品链接至本活动页面报名处的地址栏，点击报名按钮 → 发布微博加标签TAG#大触觉醒##礼乐和鸣# ~网易阴阳师手游 ~阴阳师手游同人帐 ~原创音乐基地→ 参赛成功。 如发现盗取、侵权等不实行为，将被直接取消比赛资格。为避免比赛中产生不必要的质疑和纠纷。请所有参赛选手保留比赛歌曲的干声。 参赛曲目作品命名格式：歌曲名（阴阳师翻唱）。',
                        '20191047','44442','6','66','2020/11/11')
insert Activity values ('55552','斗破最燃音声动破苍穹','由《斗破苍穹》小说、动漫、影视三方联合正版IP授权，吴磊、林允主演热播剧同名手游已正式上线，为了回馈粉丝和玩家朋友们，《斗破苍穹手游》特倾情举办斗破苍穹主题曲征集/翻唱大赛，诚邀各位才华横溢的斗者为游戏创作或演唱主题曲。原创报名:录制参赛歌曲→ 登录音悦网个人主页→ 点击上传歌曲→ 填好歌曲相关信息。 复制作品链接至本活动页面，点击报名按钮→ 发布微博加标签TAG#斗破最燃音，声动破苍穹# 并@斗破苍穹斗帝之路手游@斗破苍穹官微@原创音乐基地→ 参赛成功。 参赛作品需为《斗破苍穹》手游及动画相关原创歌曲或大赛指定翻唱歌曲，并由本人亲自创作或演唱，上传不合规定的作品视为无效。 同人原创音乐大赛需围绕以下角色进行创作：萧炎、萧薰儿、彩麟、云韵、纳兰嫣然、小医仙、青鳞、紫研、林修崖。亦可使用手游中“远古八族”职业名进行创作：萧族·焚炎、雷族·千影、石族·漠铁、灵族·御风、古族、魂族、药族、炎族。 翻唱作品选择演唱官方指定歌单曲目，上传作品到活动页面（请使用本活动页面所提供的歌曲伴奏，演唱方式不作要求，旋律及编曲等可进行一定程度改编，但不接受重新填词）。 参赛曲目作品命名须统一前缀【斗破苍穹同人音乐原创】+歌曲名翻唱报名:录制参赛歌曲→ 登录音悦网个人主页→ 点击上传歌曲→ 填好歌曲相关信息。 复制作品链接至本活动页面，点击报名按钮→按弹窗要求填写个人信息→ 发布微博加标签TAG#斗破最燃音，声动破苍穹# 并@斗破苍穹斗帝之路手游@斗破苍穹官微@原创音乐基地→ 参赛成功。 参赛作品需为《斗破苍穹》手游及动画相关原创歌曲或大赛指定翻唱歌曲，并由本人亲自创作或演唱，上传不合规定的作品视为无效。 翻唱作品选择演唱官方指定歌单曲目，上传作品到活动页面（请使用本活动页面所提供的歌曲伴奏，演唱方式不作要求，旋律及编曲等可进行一定程度改编，但不接受重新填词）。 参赛曲目作品命名须统一前缀 【斗破苍穹同人音乐翻唱】+歌曲名;',
                        '20191048','44443','1024','66','2020/11/11')
insert Activity values ('55553','草莓音乐节见面会','由音悦网主办的草莓音乐节即将举报，所有有兴趣的原创歌手均可报名参加本次草莓音乐节获得上台演出的机会，同时还能获得由音悦网送出的精美礼品等；所有用户均可报名参加本次音乐会，平台将送出1000张门票让你亲临现场收听你喜欢的原创歌手的现场歌曲',
                        '20191049','44441','1024','66','2020/11/11')
-- 参与表
create table JoinAct (       
	JoinUser char (10) not null ,
	JoinCategory char(10) not null ,
	Jointime datetime NOT NULL DEFAULT getdate() ,   --参与时间 
	primary key (JoinUser,JoinCategory) 
)
-- 参与表数据
insert JoinAct values ('20191047','55551','2019/11/11')
insert JoinAct values ('20191048','55551','2019/11/11')
insert JoinAct values ('20191049','55552','2019/11/11')
insert JoinAct values ('20191050','55552','2019/11/11')
insert JoinAct values ('20191051','55553','2019/11/11')
insert JoinAct values ('20191052','55553','2019/11/11')
insert JoinAct values ('20191053','55553','2019/11/11')
insert JoinAct values ('20191054','55551','2019/11/11')










