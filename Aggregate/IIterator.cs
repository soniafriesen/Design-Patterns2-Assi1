/*
 * Project: Assi1 (IIterator Interface)
 * Purpose: Interface 
 * Coder: Sonia Friesen, 0813682    
 * Date: Due February 16, 2021
 */
namespace Assi1
{
    public interface IIterator
    {
        HeavyObject First();
        void Next();
        bool IsDone();
        HeavyObject CurrentItem();
        HeavyObject GetPreviousItem();
    }
}
