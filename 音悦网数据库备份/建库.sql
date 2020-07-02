create database SingMusicDataBase
go
use SingMusicDataBase
go
-------------------------����ģ������-------------------------
/*�û����ͱ�*/--1.��ͨ�û�  2.sing��Ա
create table userType(
	userType_id int identity(1,1) not null primary key,  --�Զ���������id
	userType_name varchar(10)                            --��������
)
--insert into userType values('��ͨ�û�');
--insert into userType values('sing��Ա');
--select * from userType;

/*�û���Ϣ��*/
CREATE TABLE users(
    userId int identity(20191047,1) not null primary key,  --�Զ������˺ţ���20191047��ʼ��������Ψһ��ʶ�˻�
	phone_num varchar(11) not null unique,					--�ֻ����룬������Ψһ��ʶ�˻�
	password varchar(20) not null,							--����
	name varchar(50) not null  unique,					--�û��ǳƣ�������Ψһ��ʶ�˻�
	photo varchar(200) not null,						   --�û�ͷ���ַ
	birthday  datetime not null,					   --�û���������
	user_sex char(2) check(user_sex in('��','Ů',null)),--�û��Ա�									   
	register_time datetime not null,				   --�û�ע��ʱ��
	userType_id int not null,						   --�û����id�������û�����userType��
	area varchar(50),								   --�û����ڵ�
	user_like int,
	user_info varchar(200),
    foreign key (userType_id) references userType(userType_id),
)
--insert into users values('18270032680','123456','`��ǳ','..\..\Content\images\users\01.jpg','1999-10-5','��','2019-11-4',1,null);
--insert into users values('18270032681','123456','��ݮBoy','..\..\Content\images\users\02.jpg','1999/3/5','��','2019/11/4',1,null);
--insert into users values('18270032682','123456','Djϲ����','..\..\Content\images\users\03.jpg','1998/8/10','��','2019/11/4',1,null);
--insert into users values('18270032683','123456','���С槼�','..\..\Content\images\users\04.jpg','1999/12/5','Ů','2019/11/4',1,null);
--insert into users values('18270032684','123456','_���ֶ�����','..\..\Content\images\users\05.jpg','1999/11/15','��','2019/11/4',1,null);
--insert into users values('18270032685','123456','Heboy','..\..\Content\images\users\06.jpg','1999/6/27','��','2019/11/4',1,null);
--insert into users values('13129704434','123456','С������','..\..\Content\images\users\07.jpg','2000/10/1','Ů','2019/11/4',1,null);
--insert into users values('18270032686','123456','����������','..\..\Content\images\users\08.jpg','1999-10-5','��','2019-11-4',1,null);
--insert into users values('18270032687','123456','���ǿ���ѽ','..\..\Content\images\users\09.jpg','1999/3/5','Ů','2019/11/4',1,null);
--insert into users values('18270032688','123456','���~���~','..\..\Content\images\users\10.jpg','1998/8/10','Ů','2019/11/4',1,null);
--insert into users values('18270032689','123456','ɭ�ֵ���','..\..\Content\images\users\11.jpg','1999/12/5','Ů','2019/11/4',1,null);
--insert into users values('18270032690','123456','_���С�к�','..\..\Content\images\users\12.jpg','1999/11/15','��','2019/11/4',1,null);
--insert into users values('18270032691','123456','Rooby','..\..\Content\images\users\13.jpg','1999/6/27','��','2019/11/4',1,null);
--insert into users values('13129704435','123456','�Ƶ겻����','..\..\Content\images\users\14.jpg','2000/10/1','Ů','2019/11/4',1,null);
--select * from users;


/*�û�������Ϣ��*/--��Զ�
create table user_friends(
	id int identity(1,1) not null primary key,		
	userId int not null,							--�û�id
	adduserId int not null,							--���ѵ�id
	add_date datetime not null,						--���ʱ��
	foreign key (userId) references users(userId),   --�����û���
	foreign key (adduserId) references users(userId)   --�����û���
)

/*����������ͱ�*/--�ŷ�1������2������3����ҥ4
create table musicType(
	typeId int identity(1,1) not null primary key,  --����id
	typeName varchar(20) not null,					--����������
)
--insert into musicType values('�ŷ�');
--insert into musicType values('����');
--insert into musicType values('����');
--insert into musicType values('��ҥ');
--select * from musicType;

/*�����ϴ����ͱ�*/--ԭ��1������2
create table upType(
	typeId int identity(1,1) not null primary key,	--����id
	typeName varchar(20) not null,					--�ϴ�������
)
--insert into upType values('ԭ��');
--insert into upType values('����');
--select * from upType;

/*�û��ϴ�������Ϣ��*/
create table userMusics(
	music_id int identity(1,1) not null primary key,--�ϴ�����id
	music_name char(20) not null,	--�ϴ�������
	user_id int not null,           --�ϴ��û�id
	imgage_url varchar(200),         --����ר����Ƭ��ַ
	music_url varchar(200),          --������Դ��ַ
	musicType_id int,               --�������id
	upType_id int,                  --�����ϴ�����id
	music_like int,                 --����������
	music_lyric varchar(500),       --���
	music_info varchar(100),        --��������
	upTime datetime,				--�����ϴ�ʱ��
	listen_times int,				--�������Ŵ���
	music_state int not null,       --����״̬
	music_check int not null,       --�����Ƿ���ͨ�����
	foreign key (musicType_id) references musicType(typeId),
	foreign key (upType_id) references upType(typeId),
	foreign key (user_id) references users(userId),
)
alter table UserMusics add music_check int not null default(1)
--insert into userMusics values('�����������㻷�����',20191047,'..\..\Content\images\userMusics\1.jpg',null,2,2,0,null);
--insert into userMusics values('����',20191048,'..\..\Content\images\userMusics\2.jpg',null,2,2,0,null);
--insert into userMusics values('����',20191049,'..\..\Content\images\userMusics\3.jpg',null,2,2,0,null);
--insert into userMusics values('�ݰ�',20191050,'..\..\Content\images\userMusics\4.jpg',null,2,2,0,null);
--insert into userMusics values('����',20191051,'..\..\Content\images\userMusics\5.jpg',null,2,2,0,null);
--insert into userMusics values('��Ů������˵',20191052,'..\..\Content\images\userMusics\6.jpg',null,2,2,0,null);
--insert into userMusics values('������Ը��',20191053,'..\..\Content\images\userMusics\7.jpg',null,1,2,0,null);
--insert into userMusics values('��ľƹݶ��Ҵ�����',20191054,'..\..\Content\images\userMusics\8.jpg',null,2,2,0,null);
--insert into userMusics values('��ϧ������',20191055,'..\..\Content\images\userMusics\9.jpg',null,2,2,0,null);
--insert into userMusics values('����è',20191056,'..\..\Content\images\userMusics\10.jpg',null,2,2,0,null);
--insert into userMusics values('����',20191057,'..\..\Content\images\userMusics\11.jpg',null,2,2,0,null);
--insert into userMusics values('�е���',20191058,'..\..\Content\images\userMusics\12.jpg',null,2,2,0,null);
--insert into userMusics values('������',20191059,'..\..\Content\images\userMusics\13.jpg',null,2,2,0,null);
--insert into userMusics values('������͵',20191060,'..\..\Content\images\userMusics\14.jpg',null,2,2,0,null);
--insert into userMusics values('�������',20191047,'..\..\Content\images\userMusics\15.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('��԰',20191048,'..\..\Content\images\userMusics\16.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('���Ա�ӵ��',20191049,'..\..\Content\images\userMusics\17.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('С����',20191050,'..\..\Content\images\userMusics\18.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('����������',20191051,'..\..\Content\images\userMusics\19.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('��������',20191052,'..\..\Content\images\userMusics\20.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('��Ů��',20191053,'..\..\Content\images\userMusics\21.jpg',null,1,2,0,null,null,null,null);
--insert into userMusics values('ֽ���鳤',20191054,'..\..\Content\images\userMusics\22.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('��һ�ֱ���',20191055,'..\..\Content\images\userMusics\23.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('ֻ�����ио�',20191056,'..\..\Content\images\userMusics\24.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('������Ϊ',20191057,'..\..\Content\images\userMusics\25.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('�žŰ�ʮһ',20191058,'..\..\Content\images\userMusics\26.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('����',20191059,'..\..\Content\images\userMusics\27.jpg',null,2,2,0,null,null,null,null);
--insert into userMusics values('GQ',20191060,'..\..\Content\images\userMusics\28.jpg',null,2,2,0,null,null,null,null);
--DBCC CHECKIDENT ('dbo.userMusics', RESEED,14)   �޸�����id
--select * from userMusics; 


/*���������*/
create table companyMusics(
	cm_id int identity(1,1) not null primary key,--����id
	cm_name char(20) not null,		--������
	music_url varchar(200),          --������Դ��ַ
	music_down int,                 --����������
	music_upTime datetime,       --�����ϴ�ʱ��
	music_type varchar(10),			--�����ʽ
)
execute sp_rename 'companyMusics.music_lyric','music_upTime'
--insert into companyMusics values('�����������㻷�����','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('ҹ������������','~/AppData/','1466',null,'MP3');
--insert into companyMusics values('����-�����������㻷�����','~/AppData/','1399',null,'MP3');
--insert into companyMusics values('â��-ԭ�����','~/AppData/','1546',null,'MP3');
--insert into companyMusics values('�������','~/AppData/','1799',null,'MP3');
--insert into companyMusics values('��ϧ������','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('����ϲ����','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('����','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('�е���-by2','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('һ����˼','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('��������','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('������','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('����','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('Insomnia','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('��','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('��������','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('����(cover)','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('������͵','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('�����','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('TheDayYouWantAway','~/AppData/','1596',null,'MP3');
--insert into companyMusics values('God is a girl','~/AppData/','1596',null,'MP3');
--select * from companyMusics;

/*��Ƶ���ͱ�*/--�й�1���պ�2��ŷ��3���۰�4,̨��5������6
create table videoType(
	typeId int identity(1,1) not null primary key,  
	typeName varchar(20) not null,
)
--insert into videoType values('�й�');
--insert into videoType values('�պ�');
--insert into videoType values('ŷ��');
--insert into videoType values('�۰�');
--insert into videoType values('̨��');
--insert into videoType values('����');
--DBCC CHECKIDENT ('dbo.videoType', RESEED,5)
--select * from videoType;

/*��Ƶ��Ϣ��*/
create table videos(
	video_id int identity(1,1) not null primary key,
	user_id int,                --�ϴ���Ʒ�û�id
	video_name varchar(100) not null,--��Ƶ����
	video_photo varchar(200),	--��Ƶ����
	video_url varchar(200),      --��Ƶ��Դλ��
	videoType_id int,			--��Ƶ����
	video_look int,				--��Ƶ������
	video_info varchar(500),	--��Ƶ���
	video_upTime datetime,		--��Ƶ�ϴ�ʱ��
	foreign key (user_id) references users(userId),
	foreign key (videoType_id) references videoType(typeId),
)
--insert into videos values('20191047','�����ĳ�Ʒ���Խ�','../../Content/images/videos/1.jpg','../../Content/',1,555); 
--insert into videos values('20191048','Ե����Ȼ','../../Content/images/videos/2.jpg','../../Content/',1,666); 
--insert into videos values('20191049','�³Ǳա��ŷ硿','../../Content/images/videos/3.jpg','../../Content/',1,777); 
--insert into videos values('20191050','�����ɾɲݡ�','../../Content/images/videos/4.jpg','../../Content/',1,888); 
--select * from videos;
--execute sp_rename 'videos.vodeo_look','video_look'  //�������ֶ�
alter table videos alter column video_name varchar(100)

/*�������ż�¼��*/
create table playRecord(
	id int identity(1,1) not null,
	music_id int,
	user_id int,                --�û�id
	play_time datetime,
	primary key(music_id,user_id),
	foreign key (user_id) references users(userId),
	foreign key (music_id) references userMusics(music_id)
)
/*�����ղؼ�¼��*/
create table musicCollectRecord(
	id int identity(1,1) not null,
	music_id int,
	user_id int,                --�û�id
	collect_time datetime,
	primary key(music_id,user_id),
	foreign key (user_id) references users(userId),
	foreign key (music_id) references userMusics(music_id)
)
--select * from collectRecord;
/*��Ƶ���ż�¼��*/
create table videoCollectRecord(
	id int identity(1,1) not null,
	video_id int,
	user_id int,                --�û�id
	collect_time datetime,
	primary key(video_id,user_id),
	foreign key (user_id) references users(userId),
	foreign key (video_id) references videos(video_id)
)

/*��Ƶ���۱�*/
create table videoComment(
	id int identity(1,1) not null primary key,
	video_id int,
	user_id int,                --�û�id
	Comment_time datetime,		--����ʱ��
	Comment_content	varchar(2000)			--��������
	foreign key (user_id) references users(userId),
	foreign key (video_id) references videos(video_id)
)

/*�û����Ա�*/
create table userLeave(
	id int identity(1,1) not null primary key,
	user_id int,
	Leaveuser_id int,               --�û�id
	Leave_time datetime,			--����ʱ��
	Leave_content varchar(1000),     --��������
	foreign key (user_id) references users(userId),
	foreign key (Leaveuser_id) references users(userId)
)
---------------------��̳ģ������-------------------------
--����
create table Block (     
	Bno int identity(1,1) not null primary key,
	Bname varchar(20) not null unique ,
	Btopicsum  int not null ,		--��������
	Breplysum int  not null ,       --�ظ�����
	Busersum int  not null ,		--�����û�����
)
-- ��������
--insert Block values ('����ԭ��','1','11','111') 
--insert Block values ('��ѧУ԰','1','11','111') 
--insert Block values ('�ҵĴ�ѧ','1','11','111') 
--insert Block values ('��Ϸ����','1','11','111') 
--insert Block values ('����۸�','1','11','111') 
--insert Block values ('��������','1','11','111') 
--insert Block values ('ħ�Ĺ���','1','11','111') 
--insert Block values ('��������','1','11','111') 
--insert Block values ('����ר��','1','11','111') 
--insert Block values ('���ɷ���','1','11','111') 
--insert Block values ('���¹㳡','1','11','111') 
--insert Block values ('�û�Ͷ��','1','11','111') 
--insert Block values ('��ˮר��','1','11','111') 

--�����
create table Topic (   
	Tno int identity(1,1) not null primary key,
	Tname varchar(20) not null unique ,
	Holder int not null ,       --������
	Location int not null ,     --�������
	TContent text not null ,        --���� 
	Readsum int default'1' ,     --�Ķ���
	Replysum int default'0',    --�ظ���
	Varify char(4) not null check(Varify in ( 'ͨ��','ʧ��') ) ,   --���״̬
	foreign key (Holder) references users(userId),
	foreign key (Location) references Block(Bno),
)

--���������  
--insert Topic values ('���쾫ѡ��������','20191047',1,'һ��һ��ϲ����ԭ���������������������������','66','2','ͨ��')
--insert Topic values ('�ҵĶ�������','20191048',2,'һ��һ���������ѵĸ������������������������','66','2','ͨ��')
--insert Topic values ('��ѧ���ʮ�Ѹ���','20191049',3,'һ��һ��ϲ����ԭ���������������������������','66','2','ͨ��')
--insert Topic values ('�����ṩ����Ϸ�ӳ�','20191050',4,'һ��һ��ϲ������Ϸ������������������ļ��飡','66','2','ͨ��')
--insert Topic values ('���ò��²۵���Щ��','20191051',5,'��Ĳ��ײ����Ǻ�������','66','2','ͨ��')
--insert Topic values ('���ʺϹ���ʱ���ĸ�','20191052',6,'����ĸ���������������һ��������','66','2','ͨ��')
--insert Topic values ('�����ȶ�������ĸ�','20191053',7,'�Ͽβ�׼���ĸ�����','66','2','ͨ��')
--insert Topic values ('�����ȶ����','20191054',8,'������һ����һ�������ȶ���ߵĸ���','66','2','ͨ��')
--insert Topic values ('��ϲ�������ֶ���','20191055',9,'������ʵĶ���������ʵĸ���','66','2','ͨ��')
--insert Topic values ('������������','20191056',10,'һ��һ��ϲ����ԭ���������������������������','66','2','ͨ��')
--insert Topic values ('����д��������н���','20191057',11,'���ÿһ�����鶼����ר�˸�����','66','2','ͨ��')  
--insert Topic values ('����д���������Ͷ��','20191058',12,'���ÿһ��Ͷ�߶�����ר�˸�����','66','2','ͨ��')
--insert Topic values ('����Ҳ��Ԫ��������','20191060',13,'���кõĲ��õĶ����ȥ','66','2','ͨ��')

--�ظ��� 
create table Reply (        
	Rno int identity(1,1) not null primary key,
	Responder_id int not null ,			--�ظ���
	RTLocation_id int not null ,		--��������
	RBLocation_id int not null ,		--�������
	RContent text not null ,			--�ظ�����
	Rtime datetime NOT NULL DEFAULT getdate() ,   --�ظ�ʱ��
	Likesum int default'0',				--������
	foreign key (Responder_id) references users(userId),
	foreign key (RTLocation_id) references Topic(Tno),
	foreign key (RBLocation_id) references Block(Bno),
)
--�ظ�������
--insert Reply values ('20191047',1,1,'��Щ����Щ����Щ��','2019/11/11','666')
--insert Reply values ('20191048',2,2,'��Щ����Щ����Щ��','2019/11/11','666')
--insert Reply values ('20191049',3,3,'��Щ����Щ����Щ��','2019/11/11','666')
--insert Reply values ('20191050',4,4,'��Щ����Щ����Щ��','2019/11/11','666')
--insert Reply values ('20191051',5,5,'��Щ����Щ����Щ��','2019/11/11','666')
--insert Reply values ('20191052',6,6,'��Щ����Щ����Щ��','2019/11/11','666')
--insert Reply values ('20191053',7,7,'��Щ����Щ����Щ��','2019/11/11','666')
--insert Reply values ('20191054',8,8,'��Щ����Щ����Щ��','2019/11/11','666')
--insert Reply values ('20191055',9,9,'��Щ����Щ����Щ��','2019/11/11','666')
--insert Reply values ('20191056',10,10,'��Щ����Щ����Щ��','2019/11/11','666')
--insert Reply values ('20191057',11,11,'��Щ����Щ����Щ��','2019/11/11','666')
--insert Reply values ('20191058',12,12,'��Щ����Щ����Щ��','2019/11/11','666')
--insert Reply values ('20191059',13,13,'��Щ����Щ����Щ��','2019/11/11','666')

----------------�ģ������-----------------------------------
--����
create table   Category (       
	Cno int identity(1,1) not null primary key,
	Cname varchar(20) not null unique ,
	Usersum int default'0',		--�����û�����
	Actsum  int default'0',     --�����
	Clicksum int default'1',    --�����
)
--insert Category values ('����','1','2','3')
--insert Category values ('����','1','2','3')
--insert Category values ('�ں�','1','2','3')

-- ���
create table Activity(       
	Ano int identity(1,1) not null primary key,
	Aname varchar(20) not null unique ,--�����
	AContent text not null ,        --�����
	AHolder int not null ,          --�������
	ACLocation int not null ,       --�������
	Joinsum int not null ,			--��������
	Viewsum int not null ,			--�����
	DDLine datetime null ,          --��ֹʱ��
	foreign key (AHolder) references users(userId),
	foreign key (ACLocation) references Category(Cno),
)

--insert Activity values ('�󴥾��ѡ�������ʦ��','���ֵ������ţ����������ͳ��������������һͬ����ƽ������Ķ������ɰ�~��Ԫ�����ܱ߸����Լ�ȫ�´�ͷ�����������㣡ԭ������:¼�Ʋ�����������¼������������ҳ������ϴ���������ø��������Ϣ�� ������Ʒ���������ҳ�汨�����ĵ�ַ�������������ť������΢���ӱ�ǩTAG#�󴥾���##���ֺ���#ԭ�����ֻ���@��������ʦ����@����ʦ����ͬ���ʡ������ɹ��� ������ʦ��Ϸ�޹ص���Ʒ����Ϊ��Ч��Ʒ��Ϊ��������в�������Ҫ�����ɺ;��ס������в���ѡ�ֱ������������ĸ����� ԭ������������ƷҪ��Ϊ���ݳ�������������Ʒ������ʽ��������������ʦԭ��������������:������ĿΪ�޶���17�׸���������¼��������������¼�������������̷���������Ҵ���������ƽ�����꡷����Ե(ɽ���ӽ�) ��Ե(޹�ӽ�)������ӣ֮�硷����ƽ�������硷������������ �ƶ��ѱ桷������������Ļ���֮�衷��������֮־������δ��֮�������֮�����������ٹ��������������ĺ��������ƽ����������� ���ر��λָ���ķ�����Ŀ�İ����¼�Ʋ������� �� ��¼������������ҳ �� ����ϴ����� �� ��ø��������Ϣ�� ������Ʒ���������ҳ�汨�����ĵ�ַ�������������ť �� ����΢���ӱ�ǩTAG#�󴥾���##���ֺ���# ~��������ʦ���� ~����ʦ����ͬ���� ~ԭ�����ֻ��ء� �����ɹ��� �緢�ֵ�ȡ����Ȩ�Ȳ�ʵ��Ϊ������ֱ��ȡ�������ʸ�Ϊ��������в�������Ҫ�����ɺ;��ס������в���ѡ�ֱ������������ĸ����� ������Ŀ��Ʒ������ʽ��������������ʦ��������',
--                        '20191047',2,1024,'66','2020/11/11')
--insert Activity values ('������ȼ�������Ʋ��','�ɡ����Ʋ�񷡷С˵��������Ӱ��������������IP��Ȩ�����ڡ����������Ȳ���ͬ����������ʽ���ߣ�Ϊ�˻�����˿����������ǣ������Ʋ�����Ρ�������ٰ춷�Ʋ������������/����������������λ�Ż�����Ķ���Ϊ��Ϸ�������ݳ���������ԭ������:¼�Ʋ��������� ��¼������������ҳ�� ����ϴ������� ��ø��������Ϣ�� ������Ʒ���������ҳ�棬���������ť�� ����΢���ӱ�ǩTAG#������ȼ���������Ʋ��# ��@���Ʋ�񷶷��֮·����@���Ʋ���΢@ԭ�����ֻ��ء� �����ɹ��� ������Ʒ��Ϊ�����Ʋ�񷡷���μ��������ԭ�����������ָ���������������ɱ������Դ������ݳ����ϴ����Ϲ涨����Ʒ��Ϊ��Ч�� ͬ��ԭ�����ִ�����Χ�����½�ɫ���д��������ס���޹�������롢���ϡ�������Ȼ��Сҽ�ɡ����ۡ����С������¡����ʹ�������С�Զ�Ű��塱ְҵ�����д��������塤���ס����塤ǧӰ��ʯ�塤Į�������塤���硢���塢���塢ҩ�塢���塣 ������Ʒѡ���ݳ��ٷ�ָ���赥��Ŀ���ϴ���Ʒ���ҳ�棨��ʹ�ñ��ҳ�����ṩ�ĸ������࣬�ݳ���ʽ����Ҫ�����ɼ������ȿɽ���һ���̶ȸı࣬��������������ʣ��� ������Ŀ��Ʒ������ͳһǰ׺�����Ʋ��ͬ������ԭ����+��������������:¼�Ʋ��������� ��¼������������ҳ�� ����ϴ������� ��ø��������Ϣ�� ������Ʒ���������ҳ�棬���������ť��������Ҫ����д������Ϣ�� ����΢���ӱ�ǩTAG#������ȼ���������Ʋ��# ��@���Ʋ�񷶷��֮·����@���Ʋ���΢@ԭ�����ֻ��ء� �����ɹ��� ������Ʒ��Ϊ�����Ʋ�񷡷���μ��������ԭ�����������ָ���������������ɱ������Դ������ݳ����ϴ����Ϲ涨����Ʒ��Ϊ��Ч�� ������Ʒѡ���ݳ��ٷ�ָ���赥��Ŀ���ϴ���Ʒ���ҳ�棨��ʹ�ñ��ҳ�����ṩ�ĸ������࣬�ݳ���ʽ����Ҫ�����ɼ������ȿɽ���һ���̶ȸı࣬��������������ʣ��� ������Ŀ��Ʒ������ͳһǰ׺ �����Ʋ��ͬ�����ַ�����+������;',
--                        '20191048',3,1024,'66','2020/11/11')
--insert Activity values ('��ݮ���ֽڼ����','������������Ĳ�ݮ���ֽڼ����ٱ�����������Ȥ��ԭ�����־��ɱ����μӱ��β�ݮ���ֽڻ����̨�ݳ��Ļ��ᣬͬʱ���ܻ�����������ͳ��ľ�����Ʒ�ȣ������û����ɱ����μӱ������ֻᣬƽ̨���ͳ�1000����Ʊ���������ֳ�������ϲ����ԭ�����ֵ��ֳ�����',
--                        '20191049',1,1024,'66','2020/11/11')
-- �����
create table JoinAct ( 
    JoinAct_no int identity(1,1) not null primary key,      
	JoinUser_id int not null ,
	JoinCategory_id int not null ,
	Jointime datetime NOT NULL DEFAULT getdate() ,   --����ʱ�� 
	foreign key (JoinUser_id) references users(userId),
	foreign key (JoinCategory_id) references Category(Cno),
)
-- ���������
--insert JoinAct values ('20191047',1,'2019/11/11')
--insert JoinAct values ('20191048',1,'2019/11/11')
--insert JoinAct values ('20191049',2,'2019/11/11')
--insert JoinAct values ('20191050',2,'2019/11/11')
--insert JoinAct values ('20191051',2,'2019/11/11')
--insert JoinAct values ('20191052',3,'2019/11/11')
--insert JoinAct values ('20191053',3,'2019/11/11')
--insert JoinAct values ('20191054',3,'2019/11/11')


-----------�̳�ģ������-----------------------------
--�����ջ���ַ��
create table Receipt_address
(addressid int Identity(1,1) not null primary key,
 userid int not null foreign key references users(userId),
 name varchar(20) not null ,
 address varchar(200) not null,
 telephone varchar(15) not null
)
--������Ʒ�����
create table goodsType
(
goodstypeid int Identity(1,1) Not null primary key,
typename varchar(50) Not null
)
--insert into goodsType values('����')
--insert into goodsType values('��ɡ')
--insert into goodsType values('����')
--insert into goodsType values('��籦')
--insert into goodsType values('�ȿ�����')

--������Ʒ��
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
values ('JBL T120A ���������ʽ���� �ֻ����ֶ��� ��Ϸ���� �������� �����ͨ��','128','1','../Content/images/shopping/goods/1.png');
insert 
into Goods(goodsname,price,goodstypeid,img)
values ('���������ֶ��ƿ�W800Xͷ��ʽ��������','169','1','../Content/images/shopping/goods/3.png');
insert 
into Goods(goodsname,price,goodstypeid,img)
values ('����������������������W280X��������','199','1','../Content/images/shopping/goods/4.png');
insert 
into Goods(goodsname,price,goodstypeid,img)
values ('�����ߣ�EDIFIER��W3 С���������� �������������ʽ�ֻ�ͨ�����ֶ�������','169','1','../Content/images/shopping/goods/5.png');
 
insert 
into Goods(goodsname,price,goodstypeid,img)
values ('��Ѫͬ�� �ܱ� ����Ѫ��η������ɡ','119','2','../Content/images/shopping/goods/6.png');
insert 
into Goods(goodsname,price,goodstypeid,img)
values ('���װ��ģ��Ȱ��ġ�ͬ������ɡ��','99','2','../Content/images/shopping/goods/7.png');
insert 
into Goods(goodsname,price,goodstypeid,img)
values ('�˼��Ǻ�����ɡ �����Ǽ�С�¹ٷ�����','135','2','../Content/images/shopping/goods/8.png');
insert 
into Goods(goodsname,price,goodstypeid,img)
values ('��������Ȩ������Ůսʿ�۵�����ɡ','128','2','../Content/images/shopping/goods/9.png');


insert 
into Goods(goodsname,price,goodstypeid,img)
values ('������61/88���־���ٱ�Я�����ٹ轺���ټ���','298','3','../Content/images/shopping/goods/10.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('���/Lofree DOT Բ��������е����','399','3','../Content/images/shopping/goods/11.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('������ں���̡�����������е����','699','3','../Content/images/shopping/goods/12.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('�־����88���� ��ѧ�ߵ��Ӽ��� ��Яʽ���۵�','398','3','../Content/images/shopping/goods/13.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('����������ԭľ��籦/�ƶ���Դ power bank','169','4','../Content/images/shopping/goods/14.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('��ŭ��С�����ܰ�ȫ��籦','69','4','../Content/images/shopping/goods/15.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('Ƥ����ͨ���ֹ޳�籦8000����','89','4','../Content/images/shopping/goods/16.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('��̫�����˳�籦�� �����Ǽ�С�¹ٷ�����','185','4','../Content/images/shopping/goods/17.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('Tomȫ���һ���ľukulele23�絥���ȿ�����С����','450','5','../Content/images/shopping/goods/18.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('Nices NC100�������ȿ������һ���ľ23������','288','5','../Content/images/shopping/goods/19.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('Kaka25D�����ȿ������ѧ��23��/26��ȫС����','437','5','../Content/images/shopping/goods/20.png');

insert 
into Goods(goodsname,price,goodstypeid,img)
values ('������adela��ͯ�������ȿ�����22��','388','5','../Content/images/shopping/goods/21.png');

--����������
create table orders
(
orderid	int Identity(1,1)	Not null primary key,
userid	int	Not null foreign key references users(userId),
addressid	int	Not null foreign key references Receipt_address(addressid),
ordertime	datetime Not null,
Tot_amt	decimal(7,2) Not null
)


--����������ϸ��
create table Orderdetails
(
orderdetailsid	int Identity(1,1)	Not null primary key,
orderid	int	Not null foreign key references Orders(orderid),
goodsid	int	Not null foreign key references Goods(goodsid),
qty	int	Not null,
price decimal(7,2) Not null
)
--�������ﳵ��
create table Cart
(
cartkid	int Identity(1,1)	Not null primary key,
userid	int	Not null foreign key references users(userId),
goodsid	int	Not null foreign key references Goods(goodsid),
qty	int	Not null,
price decimal(7,2)	Not null
)


--��̨����
--���������������
create table UserSingerApply
(
	accusedid	int Identity(10201047,1)	Not null primary key,
	userId	int	Not null foreign key references Users(userId),
	applytime	datetime Not null,
	deal_state int
)
alter table UserSingerApply add deal_state int
--�������ٱ��û���
create table AccusedUsers
(
	accusedid	int Identity(10000,1)	Not null primary key,
	userId	int	Not null foreign key references Users(userId),
	accusedtime	datetime Not null,
	accusedreason varchar(1000)	Not null,
	deal_state int
)