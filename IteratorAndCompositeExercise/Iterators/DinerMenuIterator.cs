using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IteratorAndCompositeExercise.Program;

namespace IteratorAndCompositeExercise.Iterators
{
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

        public void remove()
        {
            if (position <= 0)
            {
                throw new InvalidOperationException
                    ("You can't remove an item until you've done at leas one next()");
            }
          
            for (int i = position; i < items.Length - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[items.Length - 1] = null;
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
}
