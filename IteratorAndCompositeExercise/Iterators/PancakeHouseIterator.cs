using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IteratorAndCompositeExercise.Program;

namespace IteratorAndCompositeExercise.Iterators
{

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

        public void remove()
        {
            if (position <= 0)
            {
                throw new InvalidOperationException("You can't remove an item until you've done at least one Next()");
            }

            items.RemoveAt(position - 1);
        }
    }
}
