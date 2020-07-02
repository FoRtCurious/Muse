-----------------活动---------------------

--活动专辑表
create table ActiveAlbum (
id int identity(1,1) not null primary key,  --自动生成账号，从1开始，可用来标识顺序
Activeid int null ,              --活动编号 
      foreign key (Activeid) references Active(actno),
Musicid int null ,            --音乐编号
      foreign key (Musicid) references UserMusics(music_id),
add_date datetime null  ,        --添加时间
music_state int default'0'            -- 状态标识，备用数据
)
insert into ActiveAlbum values ('4','1','2020-04-04','0' )
insert into ActiveAlbum values ('4','2','2020-04-04','0' )
insert into ActiveAlbum values ('4','3','2020-04-04','0' )
insert into ActiveAlbum values ('4','4','2020-04-04','0' )
insert into ActiveAlbum values ('4','5','2020-04-04','0' )
insert into ActiveAlbum values ('4','6','2020-04-04','0' )
insert into ActiveAlbum values ('4','7','2020-04-04','0' )
insert into ActiveAlbum values ('4','8','2020-04-04','0' )
insert into ActiveAlbum values ('4','9','2020-04-04','0' )
insert into ActiveAlbum values ('4','10','2020-04-04','0' )
insert into ActiveAlbum values ('3','11','2020-04-04','0' )
insert into ActiveAlbum values ('3','12','2020-04-04','0' )
insert into ActiveAlbum values ('3','13','2020-04-04','0' )
insert into ActiveAlbum values ('3','14','2020-04-04','0' )
insert into ActiveAlbum values ('3','15','2020-04-04','0' )
insert into ActiveAlbum values ('2','16','2020-04-04','0' )
insert into ActiveAlbum values ('2','17','2020-04-04','0' )
insert into ActiveAlbum values ('2','18','2020-04-04','0' )
insert into ActiveAlbum values ('2','19','2020-04-04','0' )
insert into ActiveAlbum values ('2','20','2020-04-04','0' )

--活动屏蔽表  
create table Activehide (
id int identity(1,1) not null primary key,  --自动生成账号，从1开始，可用来标识顺序
userid int null ,                         --用户id 
    foreign key (userid) references Users(userId),
activeid int null ,                      --被屏蔽活动编号 
    foreign key (activeid) references Active(actno),
hide_time datetime   ,                  --屏蔽时间
hide_state int default'0'              -- 状态标识，备用数据
)

-----------------活动---------------------


-------------------音乐人专辑留言--------------------
create table SingerAlbumLeave (
id int identity(1,1) not null primary key,  --自动生成账号，从1开始，可用来标识顺序
userid int null ,                          --留言用户通过用户表的userId进行区分, 取决于Session
    foreign key (userid) references Users(userId),
leaveid int null ,                         --被留言的用户专辑的用户id
    foreign key (leaveid) references Users(userId),
content text null,                        -- 回复内容
leave_time datetime null  ,               --发送时间
reply_state int default'0'               -- 状态标识， 可以被举报
)







-------------------音乐人专辑留言--------------------













-----------------投诉---------------------

--活动投诉表
create table ActiveComplain (
id int identity(1,1) not null primary key,  --自动生成账号，从1开始，可用来标识顺序
userid int null ,                --发起投诉的用户id
      foreign key (userid) references Users(userId),
activeid int null ,                      --被投诉活动编号 
    foreign key (activeid) references Active(actno),
content text null,             --投诉原因
complain_time datetime null ,       --投诉时间 
complain_state int default '1' ,           --状态 0代表可以展示，   1 代表在审核状态，    2表示被投诉禁止展示
)

--圈子动态投诉表
create table CircleComplain (
id int identity(1,1) not null primary key,  --自动生成账号，从1开始，可用来标识顺序
userid int null ,                --发起投诉的用户id
      foreign key (userid) references Users(userId),
circleid int null ,                      --被投诉活动编号 
    foreign key (circleid) references Circle(cno),
content text null,             --投诉原因
complain_time datetime null ,       --投诉时间 
complain_state int default '1' ,           --状态 0代表可以展示，   1 代表在审核状态，    2表示被投诉禁止展示
)

--用户投诉表
create table UserComplain (
id int identity(1,1) not null primary key,  --自动生成账号，从1开始，可用来标识顺序
userid int null ,                --发起投诉的用户id
      foreign key (userid) references Users(userId),
complainid int null ,                      --被投诉用户账号 
    foreign key (complainid) references Users(userId),
content text null,             --投诉原因
complain_time datetime null ,       --投诉时间 
complain_state int default '1' ,           --状态 0代表可以展示，   1 代表在审核状态，    2表示被投诉禁止展示
)

-----------------投诉---------------------



-----------------邮件---------------------

--邮件表 
create table Mails (
id int identity(1,1) not null primary key,  --自动生成账号，从1开始，可用来唯一标识邮件 
sent_user int null ,                --发件人通过用户表的用户编号进行区分
foreign key (sent_user) references Users(userId),
recip_user int null ,               --收件人通过用户表的手机号进行区分
    foreign key (recip_user) references Users(userId),
title varchar(100) null ,                   --邮件主题，限制100字节
mail text null ,                            --内容 
mail_state int default'0'            -- 状态标识，0为未读，1为已读，2为垃圾邮件，用于区分展示
)
insert into Mails values ('20191047','20191048','这是主题','这是邮件内容，这是邮件内容！这是邮件内容，这是邮件内容！这是邮件内容，这是邮件内容！1','0')
insert into Mails values ('20191047','20191048','这是主题','这是邮件内容，这是邮件内容！这是邮件内容，这是邮件内容！这是邮件内容，这是邮件内容！2','1')
insert into Mails values ('20191047','20191048','这是主题','这是邮件内容，这是邮件内容！这是邮件内容，这是邮件内容！这是邮件内容，这是邮件内容！3','2')

insert into Mails values ('20191048','20191047','这是主题','这是邮件内容，这是邮件内容！这是邮件内容，这是邮件内容！这是邮件内容，这是邮件内容！4','0')
insert into Mails values ('20191048','20191047','这是主题','这是邮件内容，这是邮件内容！这是邮件内容，这是邮件内容！这是邮件内容，这是邮件内容！5','1')
insert into Mails values ('20191048','20191047','这是主题','这是邮件内容，这是邮件内容！这是邮件内容，这是邮件内容！这是邮件内容，这是邮件内容！6','2')


--邮件私信表 记录左侧可聊天好友  
create table MailChat (
id int identity(1,1) not null primary key,  --自动生成账号，从1开始，可用来标识顺序
sentid int null ,                --发件人通过用户表的userId进行区分
    foreign key (sentid) references Users(userId),
recipid int null ,               --收件人通过用户表的userId进行区分
    foreign key (recipid) references Users(userId),
click_sum int default'0' ,             -- 点击次数，排序依据
create_time datetime null  ,        --聊天创建时间
chat_state int default'0'              -- 状态标识，备用数据
)
insert into MailChat values ('20191048','20191049','0','2020-05-20','0')

--聊天记录表
create table MailChatRecords ( 
id int identity(1,1) not null primary key,  --自动生成账号，从1开始，可用来标识顺序
recordid int null ,          --关联MailChat表，通过MC表传id到MCR表
    foreign key (recordid) references MailChat(id),
sentid int null,                  --发件人
    foreign key (sentid) references Users(userId),
recipid int null ,               --收件人通过用户表的userId进行区分
    foreign key (recipid) references Users(userId),
content text null ,                --  内容  
sent_time  datetime null ,         --发送事件 
record_state int default '0' ,      --标识状态，0 为可展示，1为审核，2为不可展示
otherstate  int default '0' ,    --备用数据 
)


-----------------邮件---------------------



-----------------圈子楼中楼------------------

--圈子回复表     对圈子号 
create table Circlereply (
id int identity(1,1) not null primary key,  --自动生成账号，从1开始，可用来标识顺序
userid int null ,                          --发件人通过用户表的userId进行区分, 取决于Session
    foreign key (userid) references Users(userId),
at_cno int null ,                         --被回复的圈子号
    foreign key (at_cno) references Circle(cno),
content text null,                        -- 回复内容
reply_time datetime null  ,               --发送时间
reply_state int default'0'               -- 状态标识，备用数据

)

--回复回复表    对用户
create table CircleUserReply (
id int identity(1,1) not null primary key,  --自动生成账号，从1开始，可用来标识顺序
userid int null ,                          --发件人通过用户表的userId进行区分, 取决于Session
    foreign key (userid) references Users(userId),
replyid int null ,                         --被回复的评论编号
    foreign key (replyid) references circlereply(id),
content text null,                        -- 回复内容
reply_time datetime null  ,               --发送时间
reply_state int default'0'               -- 状态标识，备用数据
)

-----------------圈子楼中楼------------------






--屏蔽活动以后展示视图
create view View_showactive
as 
   select * from Active where actno not in
   (
      select  activeid from Activehide 
    )

--select * from View_showactive 

--直接手动给Active表添加一个 State    int型 0代表可以展示，   1 代表在审核状态，    2表示被投诉禁止展示
--直接手动给Circle表添加一个 State    int型 0代表可以展示，   1 代表在审核状态，    2表示被投诉禁止展示

alter table Circle alter column thumbs int
alter table Circle alter column replysum int