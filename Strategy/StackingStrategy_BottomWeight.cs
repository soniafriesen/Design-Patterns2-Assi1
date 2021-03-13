using Assi1.Aggregate;
using System;
using System.Collections.Generic;
/*
 * Project: Assi1 (StackingStrategy_BottomWeight : StackingStrategy)
 * Purpose: bottom weight evaluatestack strategy
 * Coder: Sonia Friesen, 0813682    
 * Date: Due February 16, 2021
 */
namespace Assi1.Strategies
{
    public class StackingStrategy_BottomWeight : StackingStrategy
    {
        /*
        * Method: EvaluateStack()
        * Purpose: Evaluate a stack from [0] - [2] (3 elements)
        * Parameters: HeavyObjectList
        * Returns: double
        */
        public double EvaluateStack(HeavyObjectList input)
        {            
            //rewards points based on the postition the heaviest object is one. 
            //input[0] should be the heaviest in the stack  for it to be a bottomweight stack
            //create a list that will hold the volume and mass of each object
            List<float> mass = new List<float>();
            for (IIterator i = input.CreateIterator(); !i.IsDone(); i.Next())
            {
                mass.Add(i.CurrentItem().Mass);
            }
            //after loading the mass of each object into a list, we can now see if the heaviest in index [0]          
            //with the mass , then sort, then reverse,because sort is ascending order and I want descending
            mass.Sort();
            mass.Reverse();

            //lets see the stack first has the heaviest object on the bottom.
            float total = 0.0f;
            if(mass[0] == input.At(0).Mass)
            {
                //if we have the heaviest at the bottom
                //im going to add all the values up and divide by the number of elements
                foreach(float value in mass)
                {
                    total = total + value;
                }
                float count = total / input.Length();
                return (float)Math.Round(count);
            }  
            else if(mass[1] == input.At(0).Mass)
            {
                //if we have the second heaviest object on the bottom
                //use this algorithm
                //total the massess like before
                foreach(float value in mass)
                {
                    total = total + value;
                }
                //this time we are going to return a value that is the total divided by the #elements + 2
                float count = total / (input.Length() + 2);
                return (float)Math.Round(count);
            }
            else
            {
                //the bottom is basically at the top
                //total the massess like before
                foreach (float value in mass)
                {
                    total = total + value;
                }
                //this time we are going to return a value that is the total divided by the #elements + 4
                float count = total / (input.Length() + 4);
                return (float)Math.Round(count);
            }
        }
        

    }
}
