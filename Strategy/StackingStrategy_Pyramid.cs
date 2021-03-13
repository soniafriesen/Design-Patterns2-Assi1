using Assi1.Aggregate;
using System;
using System.Collections.Generic;
/*
 * Project: Assi1 (StackingStrategy_Pyramid : StackingStrategy)
 * Purpose: pyramid evaluatestack strategy
 * Coder: Sonia Friesen, 0813682    
 * Date: Due February 16, 2021
 */
namespace Assi1.Strategies
{
    public class StackingStrategy_Pyramid : StackingStrategy
    {
        /*
         * Method: EvaluateStack()
         * Purpose: Evaluate a stack from [0] - [2] (3 elements)
         * Parameters: HeavyObjectList
         * Returns: double
         */
        public double EvaluateStack(HeavyObjectList input)
        {
            //look at the volume of each box
            List<float> volume = new List<float>();
            for (IIterator i = input.CreateIterator(); !i.IsDone(); i.Next())
            {
                volume.Add(i.CurrentItem().Volume);
            }
            volume.Sort();
            volume.Reverse();
            //by reversing after sort we can indicate that we want the most volume at the bottom  to create that Pyramid  shape.
            //test to see if the highest volume, (largest shape) is at the bottom (similar to the bottomweight except were not looking at mass
            if (volume[0] == input.At(0).Volume)
            {
                //now we can test to see if the rest if equal              
                //because I know there are three objects in each list.
                int counter = 0;
                bool isSame = false;
                foreach(float vol in volume)
                {
                    if (vol == input.At(counter).Volume)
                    {
                        counter++;
                        isSame = true;
                        continue;
                    }
                    else
                    {
                        isSame = false;
                        break; //if the second volumes are not the same to volume stack (which should represent a Pyramid )
                    }                       
                }
                if(isSame)
                {
                    //return a value based on the volume of each box 
                    float total = 0;
                    foreach(float vol in volume)
                    {
                        total = total + vol;
                    }
                    float count = total / (input.Length() + 10); //similar to the bottom stack except were using the volume of each box
                    count = (float)Math.Round(count);
                    return count;
                }
                else
                {
                    //because it isnt the same (large, meduim,small)
                    //we must have (large,small,medium) which isnt Pyramid itself
                    float total = 0;
                    foreach (float vol in volume)
                    {
                        total = total + vol;
                    }
                    float count = total / (input.Length() + 20); //similar to the bottom stack except were using the volume of each box
                    count = (float)Math.Round(count);
                    return count;
                }
            }
            //the second largest box is now one the bottom
            else if (volume[1] == input.At(0).Volume)
            {
                //the largest box is now in the middle or top
                //lets check where the largest box is
                float largeBox = input.At(1).Volume; //check ot see if this is the largest box
                if(largeBox == volume[0]) //should be teh largest box (medium, large, small)
                {
                    float total = 0;
                    foreach (float vol in volume)
                    {
                        total = total + vol;
                    }
                    float count = total / (input.Length() + 30); //similar to the bottom stack except were using the volume of each box
                    count = (float)Math.Round(count);
                    return count;
                }
                else //the largest is on the top, medium,small,large
                {
                    float total = 0;
                    foreach (float vol in volume)
                    {
                        total = total + vol;
                    }
                    float count = total / (input.Length() + 40); //similar to the bottom stack except were using the volume of each box
                    count = (float)Math.Round(count);
                    return count;
                }
            }
            //smallest box is on the bottom
            else
            {
                //where is the largest back then
                //in the middle (small,large,medium)
                 //check ot see if this is the largest box
                if (volume[0] == input.At(1).Volume) 
                {
                    float total = 0;
                    foreach (float vol in volume)
                    {
                        total = total + vol;
                    }
                    float count = total / (input.Length() + 50); //similar to the bottom stack except were using the volume of each box
                    count = (float)Math.Round(count);
                    return count;
                }
                else //the largest is on the top, (small,meduim,large)
                {
                    float total = 0;
                    foreach (float vol in volume)
                    {
                        total = total + vol;
                    }
                    float count = total / (input.Length() + 60); //similar to the bottom stack except were using the volume of each box
                    count = (float)Math.Round(count);
                    return count;
                }
            }            
        }
    }
}
