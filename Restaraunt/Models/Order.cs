using System;
using System.Collections.Generic;
using System.Text;

namespace Restaraunt.Models
{
    class Order
    {
        private static int _no = 0;
        public List<OrderItem> OrderItems=new List<OrderItem>(0);
        private double _totalAmount=0;
        public string Date;

        public Order( string date,List<OrderItem> orderItems)
        {
            _no++;
            Date = date;
            OrderItems = orderItems;
        }

        public int No { get { return _no; } }

        public double TotalAmount
        {
            get
            {
                foreach (var item in OrderItems)
                {
                    _totalAmount+=item.Count* item.MenuItem.Price;
                }return _totalAmount;
            }
        }
        //      No - nomresi(1-den baslayaraq nomrelenir)
        //- OrderItems- Sifaris item-lari sifaris item listi)
        //- TotalAmount - umumi meblegi
        //- Date - tarixi
    }
}
