if exists (select * from sysobjects where name = 'Collect')
drop table Collect
go
create table Collect
(
   collectid int identity(1,1) not null primary key,
   userId int not null references Users(userId),
   goodsid int not null references Goods(goodsid),
   collecttime datetime not null 
)