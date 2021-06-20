using System;
using System.Collections.Generic;
using System.Text;
using Restaraunt.Models;


namespace Restaraunt.Services
{
    interface IRestaurantManager
    {
        public List<MenuItem> MenuItems { get; }
        public List<Order> Orders { get; }
        void AddOrder(string date, List<OrderItem> orderItem);
        void RemoveOrder(int no);
        List<Order> GetOrderByDate(string date);
        List<Order> GetOrdersByPriceInterval(double smallPrice, double bigPrice);
        Order GetOrderByNo(int no);

        void AddMenuItem( string name, double price, string category);
        void EditMenuItem(string no, string name, double price, string category);
        List<MenuItem> GetMenuItemsByCategoryInterval(string category);
        List<MenuItem> GetMenuItemsByPriceInterval(double smallPrice, double bigPrice);
        List<MenuItem> SearchMenuItem(string search);





        //  - MenuItems - restorandaki menu item-lari
        //- Orders - restorana edilmis sifarisler
        //- AddOrder - Sifaris(Order) elave etmek - order elave edilerken hansi MenuItem-larindan hansi sayda satis oldugu gonderilir
        //- RemoveOrder - Sifarisin geri qaytarilmasi
        //- GetOrdersByDatesInterval - Verilen tarix araligina gore hemin tarix araligina olan sifarislerin qaytarilmasi
        //- GetOrderByDate - Verilen bir tarixe gore hemin tarix(il, ay, gun) ucun olan sifarislerin qaytarilmasi
        //- GetOrdersByPriceInterval - Verilmis mebleg araligina gore edilmis satislarin qaytarilmasi
        //- GetOrderByNo - Verilmis nomreye esasen satisin qaytarilmasi
        //- AddMenuItem - Yeni menuItem(yemek, icki, desser ve s.) elave etmek
        //- EditMenuITem - Mehsulun adini, sayini ve meblegini, categoriyasini deyismek(code-a gore tapilacaq)
        //- Verilmis kateqoriyaya esasen hemin kateqoriyada olan menuItem-larin qaytarilmasi
        //- Verilmis qiymet araligina esasen hemin araliqda olan menuItemlerin qaytarilmasi
        //- Verilmis search deyerine esasen menuItem-larin search edilib qaytarilmasi
    }
}
