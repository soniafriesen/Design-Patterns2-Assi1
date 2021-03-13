﻿using Assi1.Aggregate;
using Assi1.Flyweights;
using Assi1.Strategies;
using System;
/*
 * Project: Assi1 (Program)
 * Purpose: Client side, To demonstrate understanding of design patterns
 * Coder: Sonia Friesen, 0813682    
 * Date: Due February 16, 2021
 */
namespace Assi1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Create our HeavyObjects (DO NOT MODIFY THESE VALUES)
            HeavyObject lightest = new HeavyObject(10, 10, 1, 1);
            HeavyObject medium = new HeavyObject(7, 7, 2, 5);
            HeavyObject heavyAndSmall = new HeavyObject(5, 5, 5, 50);
          
            // Create lists of the HeavyObjects and print them for debug purposes
            HeavyObjectList listA = new HeavyObjectList();
            listA.Add(heavyAndSmall);
            listA.Add(medium);
            listA.Add(lightest);
            Console.WriteLine($"Testing First() method in ListA:");
            IIterator iterator = listA.CreateIterator();
            iterator.First().Print();
            Console.WriteLine("\nItems in ListA:");
            for (IIterator i = listA.CreateIterator(); !i.IsDone(); i.Next())
            {
                i.CurrentItem().Print();
            }              
           
            Console.WriteLine();

            HeavyObjectList listB = new HeavyObjectList();
            listB.Add(medium);
            listB.Add(lightest);
            listB.Add(heavyAndSmall);
            iterator = listB.CreateIterator();
            Console.WriteLine($"Testing First() method in ListB:");
            iterator.First().Print();
            Console.WriteLine("\nItems in ListB:");
            for (IIterator i = listB.CreateIterator(); !i.IsDone(); i.Next())
            {
                i.CurrentItem().Print();
            }
            Console.WriteLine();

            HeavyObjectList listC = new HeavyObjectList();
            listC.Add(lightest);
            listC.Add(medium);
            listC.Add(heavyAndSmall);
            iterator = listC.CreateIterator();
            Console.WriteLine($"Testing First() method in listC.");
            iterator.First().Print();
            Console.WriteLine("\nItems in ListC:");
            for (IIterator i = listC.CreateIterator(); !i.IsDone(); i.Next())
            {
                i.CurrentItem().Print();
            }
            Console.WriteLine();
            
            // Create our Flyweight Factory and create the Flyweights out of it
            FlyweightFactory fw = new FlyweightFactory();
            StackingStrategy bottomWeight = fw.GetFlyweight("bottomWeight");
            StackingStrategy pyramid = fw.GetFlyweight("pyramid");
            StackingStrategy topple = fw.GetFlyweight("topple");


            // Print results
            Console.WriteLine("BottomWeight - ListA: " + bottomWeight.EvaluateStack(listA));
            Console.WriteLine("BottomWeight - ListB: " + bottomWeight.EvaluateStack(listB));
            Console.WriteLine("BottomWeight - ListC: " + bottomWeight.EvaluateStack(listC));
            Console.WriteLine();

            Console.WriteLine("Pyramid - ListA: " + pyramid.EvaluateStack(listA));
            Console.WriteLine("Pyramid - ListB: " + pyramid.EvaluateStack(listB));
            Console.WriteLine("Pyramid - ListC: " + pyramid.EvaluateStack(listC));
            Console.WriteLine();

            Console.WriteLine("Topple - ListA: " + topple.EvaluateStack(listA));
            Console.WriteLine("Topple - ListB: " + topple.EvaluateStack(listB));
            Console.WriteLine("Topple - ListC: " + topple.EvaluateStack(listC));

        }
    }
}
