using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Project: Assi1 (HeavyObjectList : IAggregate)
 * Purpose: Concrete Aggregate List, holds heavy objects in a custom list
 * Coder: Sonia Friesen, 0813682    
 * Date: Due February 16, 2021
 */
namespace Assi1.Aggregate
{
    public class HeavyObjectList : IAggregate
    {
        protected List<HeavyObject> container = new List<HeavyObject>();
        public IIterator CreateIterator()
        {
            return new ConcreteListIterator(this);
        }
        public void Add(HeavyObject item)
        {
            container.Add(item);
        }
        public HeavyObject At(int index)
        {
            return container[index];
        }
        public int Length()
        {
            return container.Count;
        }     
       
    }
}
