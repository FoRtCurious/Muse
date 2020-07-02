--�����û���
create table users(
 userid varchar(16) not null primary key,
 password varchar(16) not null
)

--�����û������
create table userinfo
(
 userid varchar(16) not null primary key  foreign key references users(userid),
 nickname varchar(16) not null,
 country varchar(20) not null,
 city varchar(20) not null,
 sex char(2) not null check(sex in('��','Ů')),
)

--�����ջ���ַ��
create table Receipt_address
(addressid int Identity(1,1) not null primary key,
 userid varchar(16) not null foreign key references users(userid),
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

--������Ʒ��
create table Goods
(goodsid	int Identity(1,1) Not null primary key,
 goodsname varchar(50) Not null,
 price	decimal(7,2) Not null,
 goodstypeid	int	Not null foreign key references goodsType(goodstypeid)
)

--����������
create table orders
(
orderid	int Identity(1,1)	Not null primary key,
userid	varchar(16)	Not null foreign key references users(userid),
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