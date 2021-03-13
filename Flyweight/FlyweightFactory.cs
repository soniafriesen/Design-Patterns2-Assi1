using Assi1.Strategies;
using System;
using System.Collections.Generic;
/*
 * Project: Assi1 (FlyweightFactory)
 * Purpose: holds the strategies and inidcates which class to eveluate
 * Coder: Sonia Friesen, 0813682    
 * Date: Due February 16, 2021
 */
namespace Assi1.Flyweights
{
    public class FlyweightFactory
    {
        protected Dictionary<string, StackingStrategy> strategies;
        
        //constructor
        public FlyweightFactory()
        {
            strategies = new Dictionary<string, StackingStrategy>();
        }
        public StackingStrategy GetFlyweight(string type)
        {
            StackingStrategy strategy = null;
            if(strategies.ContainsKey(type))
            {
                strategy = strategies[type];
            }
            else
            {
                switch(type)
                {
                    case "bottomWeight":
                        strategy = new StackingStrategy_BottomWeight();
                        break;
                    case "pyramid":
                        strategy = new StackingStrategy_Pyramid();
                        break;
                    case "topple":
                        strategy = new StackingStrategy_Topple();
                        break;
                    default:
                        throw new ArgumentNullException($"{type} is not a strategy type.");                       

                }
                strategies[type] = strategy;
            }
            return strategy;
        }
    }
}
