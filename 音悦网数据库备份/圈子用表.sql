--������̬��
create table Circle(
   cno int identity(1,1) not null primary key,     --����  
   userid int not null ,          --�û�������
   uptime datetime null DEFAULT getdate() ,    -- �ϴ�ʱ��
   content text null ,        -- �ı�����
   imageurl varchar(200) null ,   --����ͼƬ
   thumbs int default 1 ,    --�������� 
   replysum int default 0  ,   --�ظ�����
   varify char(4) null check (varify in ( 'ͨ��','ʧ��')) ,    --���״̬
   c_state int default 0,
   foreign key (userid) references users(userid),
)

insert circle values ('20191050','','666666666hznb','../../content/','','','ͨ��','')
insert circle values ('20191052','','666666666xxbnb','../../content/','','','ͨ��','')
insert circle values ('20191054','','666666666lhnb','../../content/','','','ͨ��','')
insert circle values ('20191088','','�����ݳ��᲻����ɢ','../../Content/images/circle/01.jpg','','','ͨ��','')
insert circle values ('20191094','','�������﹤���ҵ���','../../Content/images/circle/02.jpg','','','ͨ��','')
insert circle values ('20191096','','�ϱ��������Ⱳ�ӵ���','../../Content/images/circle/03.jpg','','','ͨ��','')