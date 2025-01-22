using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission_3
{

    //not static so that we can create instances (objects) from this class
    internal class FoodItem
    {
        public string Name;
        public string Category;
        public int Quantity;
        public string ExpDate;


        //Constructor assigns values so that each object can hold it
        public FoodItem(string itemName, string itemCategory, int itemQuantity, string itemExpDate)
        {
            Name = itemName;
            Category = itemCategory;
            Quantity = itemQuantity;
            ExpDate = itemExpDate;
        }
    }
}
