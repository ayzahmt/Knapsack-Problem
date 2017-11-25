using System;
using System.Collections.Generic;

namespace Knapsack
{
    class Program
    {
        public static int KnapsackWeight;
        public static int ItemCount;
        public static int[,] ValuesMatrix;

        public static void Main(string[] args)
        {
            var ins = new Program();
            var list = new List<Item>();

            Console.Write("Enter Knapsack Max Weight: ");
            KnapsackWeight = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Item Count: ");
            ItemCount = Convert.ToInt32(Console.ReadLine());

            ValuesMatrix = new int[ItemCount+1, KnapsackWeight+1];

            for (var i = 1; i <= ItemCount; i++)
            {
                Console.Write("Enter " + i + ".Item Value: ");
                var value = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter " + i + ".Item Weight: ");
                var weight = Convert.ToInt32(Console.ReadLine());
                var item = new Item(value,weight,false);
                list.Add(item); 
            }

            ins.PrepareValues(KnapsackWeight);

            #region Find The Maximum Value

            ins.KnapsackProcess(list);

            for (var i = 0; i <= ItemCount; i++)
            {               
                for (var j = 0; j <= KnapsackWeight; j++)
                {
                    Console.Write(ValuesMatrix[i,j]);
                    Console.Write("\t");
                }
                Console.WriteLine("\n");
            }
            #endregion

            #region Find Chosen Items
            var chosenList = ins.FindChosenItems(list);

            Console.WriteLine("Maximum Value: " + ValuesMatrix[ItemCount,KnapsackWeight]);
            Console.WriteLine("Chosen Item(s)");

            for (var i = 1; i <= chosenList.Count; i++)
            {
                if (chosenList[i-1].GetIsChosen())
                {
                    Console.WriteLine(i +". Item - Value: " + chosenList[i - 1].GetValue() + " - " + "Weight: " + chosenList[i - 1].GetWeight());
                }
            }
            Console.ReadLine();
            #endregion
        }

        void KnapsackProcess(List<Item> list)
        {
            for (var i = 1; i <= ItemCount; i++)
            {
                for (var j = 1; j <= KnapsackWeight; j++)
                {
                    if (list[i-1].GetWeight() > j)
                    {
                        ValuesMatrix[i, j] = ValuesMatrix[i - 1, j];
                    }
                    else
                    {
                        ValuesMatrix[i, j] =
                            Math.Max(list[i - 1].GetValue() + ValuesMatrix[i - 1, j - list[i - 1].GetWeight()],
                                ValuesMatrix[i - 1, j]);
                    }
                }
            }
        }

        void PrepareValues(int knapsackWeight)
        {                        
            for (var i = 0; i <= ItemCount; i++)
            {
                for (var j = 0; j <= knapsackWeight; j++)
                {
                    ValuesMatrix[i, j] = 0;
                }
            }
        }

        List<Item> FindChosenItems(List<Item> list)
        {
            var indis = ItemCount;
            var weight = KnapsackWeight;
            while (indis > 0 && weight > 0)
            {                
                if (ValuesMatrix[indis, weight] != ValuesMatrix[indis - 1, weight])
                {
                    list[indis - 1].GetIsChosen(true);
                    weight = weight - list[indis-1].GetWeight();
                }
                indis--;
            }
            return list;
        }

    }
}
