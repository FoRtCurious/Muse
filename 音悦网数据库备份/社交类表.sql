-----------------�---------------------

--�ר����
create table ActiveAlbum (
id int identity(1,1) not null primary key,  --�Զ������˺ţ���1��ʼ����������ʶ˳��
Activeid int null ,              --���� 
      foreign key (Activeid) references Active(actno),
Musicid int null ,            --���ֱ��
      foreign key (Musicid) references UserMusics(music_id),
add_date datetime null  ,        --���ʱ��
music_state int default'0'            -- ״̬��ʶ����������
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

--����α�  
create table Activehide (
id int identity(1,1) not null primary key,  --�Զ������˺ţ���1��ʼ����������ʶ˳��
userid int null ,                         --�û�id 
    foreign key (userid) references Users(userId),
activeid int null ,                      --�����λ��� 
    foreign key (activeid) references Active(actno),
hide_time datetime   ,                  --����ʱ��
hide_state int default'0'              -- ״̬��ʶ����������
)

-----------------�---------------------


-------------------������ר������--------------------
create table SingerAlbumLeave (
id int identity(1,1) not null primary key,  --�Զ������˺ţ���1��ʼ����������ʶ˳��
userid int null ,                          --�����û�ͨ���û����userId��������, ȡ����Session
    foreign key (userid) references Users(userId),
leaveid int null ,                         --�����Ե��û�ר�����û�id
    foreign key (leaveid) references Users(userId),
content text null,                        -- �ظ�����
leave_time datetime null  ,               --����ʱ��
reply_state int default'0'               -- ״̬��ʶ�� ���Ա��ٱ�
)







-------------------������ר������--------------------













-----------------Ͷ��---------------------

--�Ͷ�߱�
create table ActiveComplain (
id int identity(1,1) not null primary key,  --�Զ������˺ţ���1��ʼ����������ʶ˳��
userid int null ,                --����Ͷ�ߵ��û�id
      foreign key (userid) references Users(userId),
activeid int null ,                      --��Ͷ�߻��� 
    foreign key (activeid) references Active(actno),
content text null,             --Ͷ��ԭ��
complain_time datetime null ,       --Ͷ��ʱ�� 
complain_state int default '1' ,           --״̬ 0�������չʾ��   1 ���������״̬��    2��ʾ��Ͷ�߽�ֹչʾ
)

--Ȧ�Ӷ�̬Ͷ�߱�
create table CircleComplain (
id int identity(1,1) not null primary key,  --�Զ������˺ţ���1��ʼ����������ʶ˳��
userid int null ,                --����Ͷ�ߵ��û�id
      foreign key (userid) references Users(userId),
circleid int null ,                      --��Ͷ�߻��� 
    foreign key (circleid) references Circle(cno),
content text null,             --Ͷ��ԭ��
complain_time datetime null ,       --Ͷ��ʱ�� 
complain_state int default '1' ,           --״̬ 0�������չʾ��   1 ���������״̬��    2��ʾ��Ͷ�߽�ֹչʾ
)

--�û�Ͷ�߱�
create table UserComplain (
id int identity(1,1) not null primary key,  --�Զ������˺ţ���1��ʼ����������ʶ˳��
userid int null ,                --����Ͷ�ߵ��û�id
      foreign key (userid) references Users(userId),
complainid int null ,                      --��Ͷ���û��˺� 
    foreign key (complainid) references Users(userId),
content text null,             --Ͷ��ԭ��
complain_time datetime null ,       --Ͷ��ʱ�� 
complain_state int default '1' ,           --״̬ 0�������չʾ��   1 ���������״̬��    2��ʾ��Ͷ�߽�ֹչʾ
)

-----------------Ͷ��---------------------



-----------------�ʼ�---------------------

--�ʼ��� 
create table Mails (
id int identity(1,1) not null primary key,  --�Զ������˺ţ���1��ʼ��������Ψһ��ʶ�ʼ� 
sent_user int null ,                --������ͨ���û�����û���Ž�������
foreign key (sent_user) references Users(userId),
recip_user int null ,               --�ռ���ͨ���û�����ֻ��Ž�������
    foreign key (recip_user) references Users(userId),
title varchar(100) null ,                   --�ʼ����⣬����100�ֽ�
mail text null ,                            --���� 
mail_state int default'0'            -- ״̬��ʶ��0Ϊδ����1Ϊ�Ѷ���2Ϊ�����ʼ�����������չʾ
)
insert into Mails values ('20191047','20191048','��������','�����ʼ����ݣ������ʼ����ݣ������ʼ����ݣ������ʼ����ݣ������ʼ����ݣ������ʼ����ݣ�1','0')
insert into Mails values ('20191047','20191048','��������','�����ʼ����ݣ������ʼ����ݣ������ʼ����ݣ������ʼ����ݣ������ʼ����ݣ������ʼ����ݣ�2','1')
insert into Mails values ('20191047','20191048','��������','�����ʼ����ݣ������ʼ����ݣ������ʼ����ݣ������ʼ����ݣ������ʼ����ݣ������ʼ����ݣ�3','2')

insert into Mails values ('20191048','20191047','��������','�����ʼ����ݣ������ʼ����ݣ������ʼ����ݣ������ʼ����ݣ������ʼ����ݣ������ʼ����ݣ�4','0')
insert into Mails values ('20191048','20191047','��������','�����ʼ����ݣ������ʼ����ݣ������ʼ����ݣ������ʼ����ݣ������ʼ����ݣ������ʼ����ݣ�5','1')
insert into Mails values ('20191048','20191047','��������','�����ʼ����ݣ������ʼ����ݣ������ʼ����ݣ������ʼ����ݣ������ʼ����ݣ������ʼ����ݣ�6','2')


--�ʼ�˽�ű� ��¼�����������  
create table MailChat (
id int identity(1,1) not null primary key,  --�Զ������˺ţ���1��ʼ����������ʶ˳��
sentid int null ,                --������ͨ���û����userId��������
    foreign key (sentid) references Users(userId),
recipid int null ,               --�ռ���ͨ���û����userId��������
    foreign key (recipid) references Users(userId),
click_sum int default'0' ,             -- �����������������
create_time datetime null  ,        --���촴��ʱ��
chat_state int default'0'              -- ״̬��ʶ����������
)
insert into MailChat values ('20191048','20191049','0','2020-05-20','0')

--�����¼��
create table MailChatRecords ( 
id int identity(1,1) not null primary key,  --�Զ������˺ţ���1��ʼ����������ʶ˳��
recordid int null ,          --����MailChat��ͨ��MC��id��MCR��
    foreign key (recordid) references MailChat(id),
sentid int null,                  --������
    foreign key (sentid) references Users(userId),
recipid int null ,               --�ռ���ͨ���û����userId��������
    foreign key (recipid) references Users(userId),
content text null ,                --  ����  
sent_time  datetime null ,         --�����¼� 
record_state int default '0' ,      --��ʶ״̬��0 Ϊ��չʾ��1Ϊ��ˣ�2Ϊ����չʾ
otherstate  int default '0' ,    --�������� 
)


-----------------�ʼ�---------------------



-----------------Ȧ��¥��¥------------------

--Ȧ�ӻظ���     ��Ȧ�Ӻ� 
create table Circlereply (
id int identity(1,1) not null primary key,  --�Զ������˺ţ���1��ʼ����������ʶ˳��
userid int null ,                          --������ͨ���û����userId��������, ȡ����Session
    foreign key (userid) references Users(userId),
at_cno int null ,                         --���ظ���Ȧ�Ӻ�
    foreign key (at_cno) references Circle(cno),
content text null,                        -- �ظ�����
reply_time datetime null  ,               --����ʱ��
reply_state int default'0'               -- ״̬��ʶ����������

)

--�ظ��ظ���    ���û�
create table CircleUserReply (
id int identity(1,1) not null primary key,  --�Զ������˺ţ���1��ʼ����������ʶ˳��
userid int null ,                          --������ͨ���û����userId��������, ȡ����Session
    foreign key (userid) references Users(userId),
replyid int null ,                         --���ظ������۱��
    foreign key (replyid) references circlereply(id),
content text null,                        -- �ظ�����
reply_time datetime null  ,               --����ʱ��
reply_state int default'0'               -- ״̬��ʶ����������
)

-----------------Ȧ��¥��¥------------------






--���λ�Ժ�չʾ��ͼ
create view View_showactive
as 
   select * from Active where actno not in
   (
      select  activeid from Activehide 
    )

--select * from View_showactive 

--ֱ���ֶ���Active�����һ�� State    int�� 0�������չʾ��   1 ���������״̬��    2��ʾ��Ͷ�߽�ֹչʾ
--ֱ���ֶ���Circle�����һ�� State    int�� 0�������չʾ��   1 ���������״̬��    2��ʾ��Ͷ�߽�ֹչʾ

alter table Circle alter column thumbs int
alter table Circle alter column replysum int