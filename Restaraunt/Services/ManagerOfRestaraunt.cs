using System;
using System.Collections.Generic;
using System.Text;
using Restaraunt.Models;

namespace Restaraunt.Services
{
    class ManagerOfRestaraunt : IRestaurantManager

    {
        public ManagerOfRestaraunt()
        {
            _menuItems = new List<MenuItem>(0);
            _orders = new List<Order>(0);

            category = new List<string> { "baslangic", "icki", "anayemek", "desert" };
        }
        private List<MenuItem> _menuItems;
        public List<MenuItem> MenuItems { get { return _menuItems; } }

        private List<Order> _orders;

        public List<string> category;

        public List<Order> Orders { get { return _orders; } }

        public void AddMenuItem(string name, double price, string category)
        {
            MenuItem menuItem = new MenuItem(name, price, category);
            _menuItems.Add(menuItem);
        }

        public void AddOrder(string date, List<OrderItem> orderItem)
        {
            Order order = new Order(date, orderItem);
            _orders.Add(order);
        }

        public void EditMenuItem(string no, string name, double price, string category)
        {
            foreach (var item in _menuItems)
            {
                if (item.No == no)
                {
                    item.Name = name;
                    item.Price = price;
                    item.Category = category;
                    break;
                }

            }
        }

        public List<MenuItem> GetMenuItemsByCategoryInterval(string category)
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            foreach (var item in _menuItems)
            {
                if (item.Category == category)
                {
                    menuItems.Add(item);
                }

            }
            return menuItems;
        }

        public List<MenuItem> GetMenuItemsByPriceInterval(double smallPrice, double bigPrice)
        {
            double value = smallPrice;
            if (smallPrice > bigPrice)
            {
                smallPrice = bigPrice;
                bigPrice = value;
            }
            List<MenuItem> menuItems = new List<MenuItem>();
            foreach (var item in _menuItems)
            {
                if (item.Price >= smallPrice && item.Price <= bigPrice)
                {
                    menuItems.Add(item);
                }
            }
            return menuItems;
        }

        public List<Order> GetOrderByDate(string date)
        {
            List<Order> orders = new List<Order>();
            foreach (var item in _orders)
            {
                if (item.Date == date)
                {
                    orders.Add(item);
                }
            }
            return orders;
        }

        public Order GetOrderByNo(int no)
        {
            foreach (var item in _orders)
            {
                if (item.No == no)
                {
                    return item;
                }
            }
            return null;
        }


        public List<Order> GetOrdersByPriceInterval(double smallPrice, double bigPrice)
        {
            double value = smallPrice;
            if (smallPrice > bigPrice)
            {
                smallPrice = bigPrice;
                bigPrice = value;
            }
            List<Order> orders = new List<Order>();
            foreach (var item in _orders)
            {
                if (item.TotalAmount >= smallPrice && item.TotalAmount <= bigPrice)
                {
                    orders.Add(item);
                }
            }
            return orders;
        }

        public void RemoveOrder(int no)
        {
            foreach (var item in _orders)
            {
                if (item.No == no)
                {
                    _orders.Remove(item);
                    break;
                }
            }
        }

        public List<MenuItem> SearchMenuItem(string search)
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            foreach (var item in _menuItems)
            {
                if (item.Name.Contains(search))
                {
                    menuItems.Add(item);
                }
            }
            return menuItems;
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return _menuItems;
        }

        public void ShowAllMenuItem()
        {
            foreach (var item in _menuItems)
            {
                Console.WriteLine($"No - {item.No} Name - {item.Name} Price - {item.Price} Category - {item.Category}");
            }
        }

        public void RemoveMenuItem(string no)
        {
            foreach (var item in _menuItems)
            {
                if (item.No == no)
                {
                    _menuItems.Remove(item);
                    break;
                }
            }
        }
        
    }
}
