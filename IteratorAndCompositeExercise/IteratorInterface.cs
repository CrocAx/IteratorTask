using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorAndCompositeExercise
{
    public interface Menu
    {
        public Iterator createIterator();
    }
    public interface Iterator
    {
        Boolean hasNext();
        Object Next();
    }
}
