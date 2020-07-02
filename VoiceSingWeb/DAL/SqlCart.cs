using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
   public class SqlCart:ICart
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<Cart> ShowCart(int userid)
        {
            var product = db.Cart.Where(o => o.userid == userid);
            return product;
        }   
        public void AddCart(Cart carts)
        {
            db.Cart.Add(carts);
            db.SaveChanges();
        }
        public void AddCart1()
        {
            db.SaveChanges();
        }
        public Cart searchCart(int userid,int goodid)
        {
            var searchcart = db.Cart.Where(o => o.userid == userid && o.goodsid == goodid).FirstOrDefault();
            return searchcart;
        }      
        public int Carts_number(int userid)
        {
            var product = db.Cart.Where(o => o.userid == userid).Count();
            return product;
        }
        public void Delect_cart(int id)
        {
            Cart myCart=db.Cart.Where(o =>o.cartkid == id).FirstOrDefault();
            db.Cart.Remove(myCart);
            db.SaveChanges();
        }
        public void AddOrder(Orders orders)
        {
            db.Orders.Add(orders);
            db.SaveChanges();
        }
        public Cart search_myCart(int cartId)
        {
            var myCart = db.Cart.Where(o => o.cartkid == cartId).FirstOrDefault();
            return myCart;
        }
        public void AddOrderdetails(Orderdetails orderdetails)
        {
            db.Orderdetails.Add(orderdetails);
            db.SaveChanges();
        }
        public void Cart_Remove(Cart myCart)
        {
            db.Cart.Remove(myCart);
            db.SaveChanges();
        }
        public void Cart_update(Cart myCart)
        {
            db.Set<Cart>().Attach(myCart);
            db.Entry(myCart).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public Cart whereCartById(int userid, int goodid)
        {
            Cart myCart = db.Cart.Where(c => c.userid == userid).Where(c => c.goodsid == goodid).FirstOrDefault();
            return myCart;
        }
    }
}
