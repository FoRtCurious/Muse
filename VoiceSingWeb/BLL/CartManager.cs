using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using DALFactory;

namespace BLL
{
   public  class CartManager
    {  
        ICart icart = DataAccess.CreateCart();
        public IEnumerable<Cart> ShowCart(int userid)
        {
            var product = icart.ShowCart(userid);
            return product;
        }
        public void AddCart(Cart cart)
        {
            icart.AddCart(cart);
        }
        public void AddCart1()
        {
            icart.AddCart1();
        }
        public Cart searchCart(int userid, int goodid)
        {
           var searchcart= icart.searchCart(userid,goodid);
            return searchcart;
        }
        public int Carts_number(int userid)
        {
            var product = icart.Carts_number(userid);
            return product;
        }
        public void Delect_cart(int id)
        {
            icart.Delect_cart(id);

        }
        public void AddOrder(Orders orders)
        {
            icart.AddOrder(orders);
        }
        public Cart search_myCart(int cartId)
        {
            var myCart = icart.search_myCart(cartId);
            return myCart;
        }
        public void AddOrderdetails(Orderdetails orderdetails)
        {
            icart.AddOrderdetails(orderdetails);
        }
        public void Cart_Remove(Cart myCart)
        {
            icart.Cart_Remove(myCart);
        }
        public void Cart_update(Cart myCart)
        {
            icart.Cart_update(myCart);
        }
        public Cart whereCartById(int userid, int goodid)
        {
            Cart myCart = icart.whereCartById(userid, goodid);
            return myCart;
        }
    }
}
