using IteratorAndCompositeExercise.Iterators;
using IteratorAndCompositeExercise.Menus;
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


        public class Waitress
        {
            Menu pancakeHouseMenu;
            Menu dinerMenu;

            public Waitress (Menu pancakeHousemMenu, Menu dinerMenu)
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