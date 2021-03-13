/*
 * Project: Assi1 (ConcreteListIterator : IIterator)
 * Purpose: has the aggregate list, and does iteration methods
 * Coder: Sonia Friesen, 0813682    
 * Date: Due February 16, 2021
 */
namespace Assi1.Aggregate
{
    class ConcreteListIterator : IIterator
    {
        protected HeavyObjectList aggregate;
        protected int index;

        public ConcreteListIterator(HeavyObjectList aggregate)
        {
            this.aggregate = aggregate;
            index = 0;
        }
        public HeavyObject First()
        {
            return aggregate.At(0);
        }
        public HeavyObject CurrentItem()
        {
            return aggregate.At(index);
        } 
        public HeavyObject GetPreviousItem()
        {
            if ((index - 1) == -1)
                return default;
            else
                return aggregate.At(index - 1);
        }
        public bool IsDone()
        {
            return index >= aggregate.Length();
        }
        public void Next()
        {
            ++index;
        }       
    }
}
