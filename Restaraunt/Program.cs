using System;
using Restaraunt.Services;
using System.Collections.Generic;
using Restaraunt.Models;

namespace Restaraunt
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagerOfRestaraunt managerOfRestaraunt = new ManagerOfRestaraunt();

            string ans;
            string answer;
            do
            {
                Console.WriteLine("\n==============================================\n");

                Console.WriteLine("1 - Menu uzerinde emeliyyat aparmaq");
                Console.WriteLine("2 - Sifarisler uzerinde emeliyyat aparmaq");
                Console.WriteLine("0 - Sistemden cixmaq");

                Console.WriteLine("\nIcra etmek istediyiniz emeliyyati secin:");
                ans = Console.ReadLine();
             

                Console.WriteLine("\n==============================================\n");
                
                switch (ans)
                {
                    case "1":                    
                        do
                        {
                            Console.WriteLine("1.1 - Yeni item elave etmek");
                            Console.WriteLine("1.2 - Item uzerinde duzelis et ");
                            Console.WriteLine("1.3 - Item silmek ");
                            Console.WriteLine("1.4 - Butun Item-lari goster ");
                            Console.WriteLine("1.5 - Categoriyasina gore menu item-lari goster  ");
                            Console.WriteLine("1.6 - Qiymet araligina gore menu item - lar goster ");
                            Console.WriteLine("1.7 - Menu item-lar arasinda ada gore axtaris et(search) ");
                            Console.WriteLine("0 - Evvelki menuya qayit ");
                            Console.WriteLine("Menu uzerinde emeliyyat aparmaq");
                            answer = Console.ReadLine();
                            switch (answer)
                            {
                                case "1.1":
                                    AddMenuItems(managerOfRestaraunt);
                                    break;
                                case "1.2":
                                    EditMenuItems(managerOfRestaraunt);
                                    break;
                                case "1.3":
                                    RemoveMenuItem(managerOfRestaraunt);
                                    break;
                                case "1.4":
                                    ShowAllMenuItems(managerOfRestaraunt);
                                    break;
                                case "1.5":
                                    ShowMenuItemByCategory(managerOfRestaraunt);
                                    break;
                                case "1.6":
                                    ShowMenuItemByPrice(managerOfRestaraunt);
                                    break;
                                case "1.7":
                                    Search(managerOfRestaraunt);
                                    break;
                            }
                        } while (answer != "0");
                        break;
                    case "2":
                        do
                        {
                            Console.WriteLine("2.1 - Yeni sifaris elave etmek");
                            Console.WriteLine("2.2 -  Sifarisin legvi -sifaris nomresine esasen silinmesi");
                            Console.WriteLine("2.3 - Butun sifarislerin ekrana cixarilmasi ");
                            Console.WriteLine("2.4 - Verilen tarix araligina gore sifarislrein gosterilmesi ");
                            Console.WriteLine("2.5 - Verilen mebleg araligina gore sifarislerin gosterilmesi ");
                            Console.WriteLine("2.6 - Verilmis bir tarixde olan sifarislerin gosterilmesi ");
                            Console.WriteLine("2.7 - Verilmis nomreye esasen hemin nomreli sifarisin melumatlarinin gosterilmesi ");
                            Console.WriteLine("0 - Evvelki menuya qayit ");
                            Console.WriteLine("Sifaris uzerinde emeliyyat aparmaq");
                            answer = Console.ReadLine();
                            switch (answer)
                            {
                                case "2.1":
                                    Console.WriteLine("Yeni sifaris elave etmek");
                                    break;
                                case "2.2":
                                    Console.WriteLine("Sifarisin legvi");
                                    break;
                                case "2.3":
                                    Console.WriteLine("Butun sifarislerin ekrana cixarilmasi");
                                    break;
                                case "2.4":
                                    Console.WriteLine("Verilen tarix araligina gore sifarislrein gosterilmesi");
                                    break;
                                case "2.5":
                                    Console.WriteLine("Verilen mebleg araligina gore sifarislerin gosterilmesi");
                                    break;
                                case "2.6":
                                    Console.WriteLine("Verilmis bir tarixde olan sifarislerin gosterilmesi");
                                    break;
                                case "2.7":
                                    Console.WriteLine("Verilmis nomreye esasen hemin nomreli sifarisin melumatlarinin gosterilmesi");
                                    break;
                            }
                        } while (answer != "0");
                        break;
                } 

            } while (ans != "0");

            static void AddMenuItems(ManagerOfRestaraunt managerOfRestaraunt)
            {
                bool check = true;
                string name;
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Mehsulun adini elave edin:");
                    }
                    else
                    {
                        Console.WriteLine("Bu adda menu movcuddur,zehmet olmasa yeniden daxil edin");
                    }
                    
                    name = Console.ReadLine();
                    foreach (var item in managerOfRestaraunt.GetAllMenuItems())
                    {
                        if (item.Name == name)
                        {
                            check = false;
                            break;
                        }
                    }
                } while (check == false);

                double priceDouble;
                string priceStr;
                check = true;
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Mehsulun qiymetini daxil edin:");
                        
                    }
                    else
                    {
                        Console.WriteLine("Zehmet olmasa reqem daxil edin:");
                    }
                    priceStr = Console.ReadLine();
                    check = double.TryParse(priceStr, out priceDouble);
                } while (check==false);

                string category;
                check = true;
                bool check1 = false;
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Mehsulun categorysini daxil edin:");
                    }
                    else
                    {
                        Console.WriteLine("Categorya movcud deyil,zehmet olmasa yeniden daxil edin:");
                    }
                    category = Console.ReadLine();
                    foreach (var item in managerOfRestaraunt.category)
                    {
                        if (item == category)
                        {
                            check1 = true;
                            break;
                        }
                    }
                    if (check1==false)
                    {
                        check=false;
                    }
                    else
                    {
                        check = true;
                    }
                } while (check == false);

                managerOfRestaraunt.AddMenuItem(name,priceDouble,category);
            }

            static void EditMenuItems(ManagerOfRestaraunt managerOfRestaraunt) 
            {
                if (managerOfRestaraunt.GetAllMenuItems().Count == 0)
                {
                    Console.WriteLine("Sistemde MenuItem movcud deyil");
                    return;
                }
                string no;
                bool check = true;
                bool check1 = false;
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Zehmet olmasa Menuitem nomresini daxil edin:");

                    }
                    else
                    {
                        Console.WriteLine("MenuItem movcud deyil,zehmet olmasa yeniden daxil edin:");

                    }
                    no = Console.ReadLine();
                    foreach (var item in managerOfRestaraunt.GetAllMenuItems())
                    {
                        if (item.No == no)
                        {
                            check1 = true;
                            break;
                        }
                    }
                    if (check1==false)
                    {
                        check = false;
                    }
                    else
                    {
                        check = true;
                    }
                } while (check == false);

                check = true;
                string name;
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Mehsulun adini elave edin:");
                    }
                    else
                    {
                        Console.WriteLine("Bu adda menu movcuddur,zehmet olmasa yeniden daxil edin");
                    }

                    name = Console.ReadLine();
                    foreach (var item in managerOfRestaraunt.GetAllMenuItems())
                    {
                        if (item.Name == name)
                        {
                            check = false;
                            break;
                        }
                    }
                } while (check == false);

                double priceDouble;
                string priceStr;
                check = true;
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Mehsulun qiymetini daxil edin:");

                    }
                    else
                    {
                        Console.WriteLine("Zehmet olmasa reqem daxil edin:");
                    }
                    priceStr = Console.ReadLine();
                    check = double.TryParse(priceStr, out priceDouble);
                } while (check == false);

                string category;
                check = true;
                check1 = true;
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Mehsulun categorysini daxil edin:");
                    }
                    else
                    {
                        Console.WriteLine("Categorya movcud deyil,zehmet olmasa yeniden daxil edin:");
                    }
                    category = Console.ReadLine();
                    foreach (var item in managerOfRestaraunt.category)
                    {
                        if (item == category)
                        {
                            check1 = false;
                            break;
                        }
                    }
                    if (check1)
                    {
                        check = false;
                    }
                    else
                    {
                        check = true;
                    }
                } while (check == false);

                managerOfRestaraunt.EditMenuItem(no,name,priceDouble,category);
            }



            static void ShowAllMenuItems(ManagerOfRestaraunt managerOfRestaraunt)
            {
                if (managerOfRestaraunt.GetAllMenuItems().Count == 0)
                {
                    Console.WriteLine("Sistemde MenuItem movcud deyil");
                    return;
                }

                managerOfRestaraunt.ShowAllMenuItem();
            }

            static void RemoveMenuItem(ManagerOfRestaraunt managerOfRestaraunt)
            {
                if (managerOfRestaraunt.GetAllMenuItems().Count == 0)
                {
                    Console.WriteLine("Sistemde MenuItem movcud deyil");
                    return;
                }

                string no;
                bool check = true;
                bool check1 = false;
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Zehmet olmasa Menuitem nomresini daxil edin:");

                    }
                    else
                    {
                        Console.WriteLine("MenuItem movcud deyil,zehmet olmasa yeniden daxil edin:");

                    }
                    no = Console.ReadLine();
                    foreach (var item in managerOfRestaraunt.GetAllMenuItems())
                    {
                        if (item.No == no)
                        {
                            check1 = true;
                            break;
                        }
                    }
                    if (check1 == false)
                    {
                        check = false;
                    }
                    else
                    {
                        check = true;
                    }
                } while (check == false);

                managerOfRestaraunt.RemoveMenuItem(no);
            }

            static void ShowMenuItemByCategory(ManagerOfRestaraunt managerOfRestaraunt)
            {
                if (managerOfRestaraunt.GetAllMenuItems().Count == 0)
                {
                    Console.WriteLine("Sistemde MenuItem movcud deyil");
                    return;
                }

                string category;
                bool check = true;
                bool check1 = true;
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Mehsulun categorysini daxil edin:");
                    }
                    else
                    {
                        Console.WriteLine("Categorya movcud deyil,zehmet olmasa yeniden daxil edin:");
                    }
                    category = Console.ReadLine();
                    foreach (var item in managerOfRestaraunt.category)
                    {
                        if (item == category)
                        {
                            check1 = false;
                            break;
                        }
                    }
                    if (check1)
                    {
                        check = false;
                    }
                    else
                    {
                        check = true;
                    }
                } while (check == false);

                if (managerOfRestaraunt.GetMenuItemsByCategoryInterval(category).Count == 0)
                {
                    Console.WriteLine("Categoryda MenuItem movcud deyil:");
                    return;
                }
                foreach (var item in managerOfRestaraunt.GetMenuItemsByCategoryInterval(category))
                {
                    Console.WriteLine($"No - {item.No} Name - {item.Name} Price - {item.Price} Category - {item.Category}");
                }


            }

            static void ShowMenuItemByPrice(ManagerOfRestaraunt managerOfRestaraunt)
            {
                if (managerOfRestaraunt.GetAllMenuItems().Count == 0)
                {
                    Console.WriteLine("Sistemde MenuItem movcud deyil");
                    return;
                }

                double priceDouble1;
                string priceStr1;
                bool check = true;
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Mehsulun ilkin qiymetini daxil edin:");

                    }
                    else
                    {
                        Console.WriteLine("Zehmet olmasa reqem daxil edin:");
                    }
                    priceStr1 = Console.ReadLine();
                    check = double.TryParse(priceStr1, out priceDouble1);
                } while (check == false);

                double priceDouble2;
                string priceStr2;
                check = true;
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Mehsulun ikinci qiymetini daxil edin:");

                    }
                    else
                    {
                        Console.WriteLine("Zehmet olmasa reqem daxil edin:");
                    }
                    priceStr2 = Console.ReadLine();
                    check = double.TryParse(priceStr2, out priceDouble2);
                } while (check == false);

                if (managerOfRestaraunt.GetMenuItemsByPriceInterval(priceDouble1, priceDouble2).Count == 0)
                {
                    Console.WriteLine("Bu araliqda MenuItem movcud deyil:");
                    return;
                }
                foreach (var item in managerOfRestaraunt.GetMenuItemsByPriceInterval(priceDouble1, priceDouble2))
                {
                    Console.WriteLine($"No - {item.No} Name - {item.Name} Price - {item.Price} Category - {item.Category}");
                }
            }

            static void Search(ManagerOfRestaraunt managerOfRestaraunt)
            {
                if (managerOfRestaraunt.GetAllMenuItems().Count == 0)
                {
                    Console.WriteLine("Sistemde MenuItem movcud deyil");
                    return;
                }

                string value;
                Console.WriteLine("Axtaris edeceyiniz deyeri daxil edin:");
                value = Console.ReadLine();

                if (managerOfRestaraunt.SearchMenuItem(value).Count == 0)
                {
                    Console.WriteLine("Hec bir netice tapilmadi:");
                    return;

                }
                foreach (var item in managerOfRestaraunt.SearchMenuItem(value))
                {

                    Console.WriteLine($"No - {item.No} Name - {item.Name} Price - {item.Price} Category - {item.Category}");
                }
            }
        }
    }
}


