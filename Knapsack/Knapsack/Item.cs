using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack
{
    public class Item
    {
        private int Value { get;  }
        private int Weight { get;  }
        private bool IsChosen { get; set; }

        public Item(int value, int weight, bool isChosen)
        {
            Value = value;
            Weight = weight;
            IsChosen = isChosen;
        }
        public int GetValue()
        {
            return Value;
        }
        public int GetWeight()
        {
            return Weight;
        }
        public bool GetIsChosen()
        {
            return IsChosen;
        }
        public void GetIsChosen(bool isChosen)
        {
            IsChosen = isChosen;
        }
    }
}
