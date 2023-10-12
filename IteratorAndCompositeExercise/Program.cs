using System.Collections;
using System.Globalization;
using System.IO.Pipes;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;

namespace IteratorAndCompositeExercise
{
    // For this exercise try complete the Iterator and Composite example introduced in the book Head First Design Patterns by O'Reilly
    // Chapeter 9 the Iterator and Composite Patterns (starts at page 315)
    // Link to pdf: https://github.com/ajitpal/BookBank/blob/master/%5BO%60Reilly.%20Head%20First%5D%20-%20Head%20First%20Design%20Patterns%20-%20%5BFreeman%5D.pdf
    internal class Program
    {
        static void Main(string[] args)
        {
            PancakeHouseMenu pancakeHouseMenu = new PancakeHouseMenu();
            DinerMenu dinerMenu = new DinerMenu();

            Waitress waitress = new Waitress(pancakeHouseMenu, dinerMenu);

            waitress.PrintMenu();
            Console.ReadLine();
        }

        public interface Iterator
        {
            Boolean hasNext();
            Object Next();
        }

        public class DinerMenuIterator : Iterator
        {
            MenuItem[] items;
            int position = 0;

            public DinerMenuIterator(MenuItem[] items)
            {
                this.items = items;
            }

            public Object Next()
            {
                MenuItem menuItem = items[position];
                position++;
                return menuItem;
            }
            public Boolean hasNext()
            {
                if (position >= items.Length || items[position] == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public class PancakeHouseIterator : Iterator
        {
            ArrayList items;
            int position = 0;

            public PancakeHouseIterator(ArrayList items)
            {
                this.items = items;
            }

            public Object Next()
            {
                object menuItem = items[position];
                position++;
                return menuItem;
            }
            public Boolean hasNext()
            {
                return position < items.Count;
            }
        }

        public class MenuItem
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public bool Vegetarian { get; set; }
            public double Price { get; set; }

            public MenuItem(string name, string description, bool vegetarian, double price) 
            { 
                Name = name;
                Description = description;
                Vegetarian = vegetarian;
                Price = price;
            }

            public string GetName()
            {
                return Name;
            }

            public string GetDescription()
            {
                return Description;
            }

            public Boolean GetVegetarian()
            {
                return Vegetarian;
            }

            public double GetPrice()
            {
                return Price;
            }
        }

        public class PancakeHouseMenu
        {
            public ArrayList MenuItems { get; set; }

            public PancakeHouseMenu()
            {
                MenuItems = new ArrayList();

                AddItem("K&B´s Pancake Breakfast", "Pancakes with scrambled eggs, and toast", false, 2.99);
                AddItem("Regular Pancake Breakfast", "Pancakes with fried eggs, sausage", false, 2.99);
                AddItem("Bluebetty Pancakes", "Pancakes made with fresh blueberries", true, 3.49);
                AddItem("Waffles", "Waffles, with your choise of blueberries or stawberries", true, 3.59);
            }

            public void AddItem(string name, string description, bool vegetarian, double price)
            {
                MenuItem menuItem = new MenuItem(name, description, vegetarian, price);
                MenuItems.Add(menuItem);
            }

            public Iterator createIterator()
            {
                return new PancakeHouseIterator(MenuItems);
            }
        }

        public class DinerMenu
        {
            private int Max_Items = 6;
            int numberOfItems = 0;
            MenuItem[] MenuItems;

            public DinerMenu()
            {
                MenuItems = new MenuItem[Max_Items];

                AddItem("Vegetarian BLT", "(Fakin´) Bacon with lettuce & tomato on whole wheat", true, 2.99);
                AddItem("BLT", "Bacon with lettuce & tomato on whole wheat", false, 2.99);
                AddItem("Soup of the day", "Soup of the day, with  a side of potato salad", false, 3.29);
                AddItem("Hotdog", "A hot dog, with saurkraut, relish, onions, topped with cheese", false, 3.05);

            }

            public void AddItem(string name, string description, bool vegetarian, double price)
            {
                MenuItem menuItem = new MenuItem(name, description, vegetarian, price);
                if (numberOfItems >= Max_Items)
                {
                    Console.WriteLine("Sorry, menu is full! Can't add item to menu");
                } else
                {
                    MenuItems[numberOfItems] = menuItem;
                    numberOfItems++;
                }
            }

            public Iterator createIterator()
            {
                return new DinerMenuIterator(MenuItems);
            }


        }

        public class Waitress
        {
            PancakeHouseMenu pancakeHouseMenu;
            DinerMenu dinerMenu;

            public Waitress (PancakeHouseMenu pancakeHousemMenu, DinerMenu dinerMenu)
            {
                this.pancakeHouseMenu = pancakeHousemMenu;
                this.dinerMenu = dinerMenu;
            }

            public void PrintMenu()
            {
                Iterator pancakeIterator = pancakeHouseMenu.createIterator();
                Iterator dinerIterator = dinerMenu.createIterator();
                Console.WriteLine("MENU\n-----\nBREAKFAST");
                printMenu(pancakeIterator);
                Console.WriteLine("\nLUNCH");
                printMenu(dinerIterator);
            }

            private void printMenu (Iterator iterator)
            {
                while (iterator.hasNext())
                {
                    MenuItem menuItem = (MenuItem)iterator.Next();
                    Console.WriteLine(menuItem.GetName() + ", "
                    + menuItem.GetPrice() + " -- "
                    + menuItem.GetDescription());
                }
            }
        }

    }
}