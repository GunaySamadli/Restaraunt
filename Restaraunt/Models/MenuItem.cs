using System;
using System.Collections.Generic;
using System.Text;

namespace Restaraunt.Models
{
    class MenuItem
    {
        public static int Total = 99;

        public MenuItem(string name, double price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
            Total++;
            _no = Category.ToUpper()[0].ToString() + Category.ToUpper()[1].ToString() + Total.ToString();
        }
        private string _no;

        public string No
        {
            get
            {
                return _no;
            }
        }
        public string Name;
        public double Price;
        public string Category;
    }
}
