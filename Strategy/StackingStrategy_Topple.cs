using Assi1.Aggregate;
using System;
using System.Collections.Generic;
/*
 * Project: Assi1 (StackingStrategy_Topple : StackingStrategy)
 * Purpose: topple evaluatestack strategy
 * Coder: Sonia Friesen, 0813682    
 * Date: Due February 16, 2021
 */
namespace Assi1.Strategies
{
    public class StackingStrategy_Topple : StackingStrategy
    {
        /*
        * Method: EvaluateStack()
        * Purpose: Evaluate a stack from [0] - [2] (3 elements)
        * Parameters: HeavyObjectList
        * Returns: double
        */
        public double EvaluateStack(HeavyObjectList input)
        {
            //opposite of a pyramid, we need to look at mass and volume.
            //logically for a topple, the smallest shape  should logically be on the bottom with the largest shape on top 
            //looking at density. (least, middle, most) will topple but also (small,medium,large) shape
            //create a list to make the ideal senario
            List<float> topple = new List<float>();
            for(IIterator i = input.CreateIterator(); !i.IsDone(); i.Next())
            {
                topple.Add(i.CurrentItem().Density);
            }
            topple.Sort(); //this should give us a least,meduim,most denisty structure with least at [0];            

            //similar to the other structures, we can see if the list[0] is the same as topple[0] for the ideal toople structure
            if(input.At(0).Density == topple[0]) //if the bottom is the most dense
            {
                //we need to find the second most dense and see if it is in the middle
                if(input.At(1).Density == topple[1])
                {
                    //this gaurentees that we have a toople (because there us only 3 elements in every list, this would not work in a real world situation where there could be mutliple lists with different lengths). 
                    float total = 0.0f;
                    foreach(float dens in topple)
                    {
                        total = total + dens;
                    }
                    float count  = total / input.Length();
                    return (float)Math.Round(count);
                }
                else //heavy,least,meduim
                {
                    float total = 0.0f;
                    foreach (float dens in topple)
                    {
                        total = total + dens;
                    }
                    float count = total / input.Length() + 15;
                    return (float)Math.Round(count);
                }                
            }
            else if(input.At(0).Density == topple[1]) // we have a medium,heavy,least or meduim, least, heavy, more chance of topple than the previous else above
            {
                if (input.At(1).Density == topple[0])
                {
                    //medium,heavy,least
                    float total = 0.0f;
                    foreach (float dens in topple)
                    {
                        total = total + dens;
                    }
                    float count = total / input.Length() + 35;
                    return (float)Math.Round(count);
                }
                else //we have a medium,least,heavy
                {
                    float total = 0.0f;
                    foreach (float dens in topple)
                    {
                        total = total + dens;
                    }
                    float count = total / input.Length() + 25; //almost equal posiblity of it toppling wth senario (heavy,least,meduim)
                    return (float)Math.Round(count);
                }
            }
            else
            {
                //we have a least,meduim,heavy or least,heavy,medium
                if(input.At(1).Density == topple[1]) //meduim in the middle
                {
                    //least,meduim,heavy, proabbly wont topple at all
                    float total = 0.0f;
                    foreach (float dens in topple)
                    {
                        total = total + dens;
                    }
                    float count = total / input.Length() + 55; 
                    return (float)Math.Round(count);
                }
                else
                {
                    //least,heavy,medium
                    float total = 0.0f;
                    foreach (float dens in topple)
                    {
                        total = total + dens;
                    }
                    float count = (float)Math.Round(total / input.Length() + 85);
                    return count;
                }
            }
        }
    }
}
