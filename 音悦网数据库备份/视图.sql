create view Suggest_type
as
select distinct goodstypeid,userId
from Goods t,Collect r
where t.goodsid=r.goodsid;


--select * from Suggest_goods

create view Suggest_good
as
select t.goodstypeid,s.userId,t.goodsid,t.goodsname,t.img,t.price
from Goods t,Suggest_type s
where t.goodstypeid=s.goodstypeid

--select * from Suggest_good
