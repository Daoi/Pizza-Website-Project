using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebApplication3
{
    public class Order
    {
        Dictionary<string, decimal> toppingsPricing = new Dictionary<string, decimal>() { { "Pepperoni", .75m }, { "Sausage", .75m }, { "Bacon", .75m },
                                                                                   { "Ham", .75m }, { "Chicken", .75m }, { "Shrimp", .75m },
                                                                                   { "Hot Peppers", .50m }, { "Sweet Peppers", .50m }, { "Onion", .50m },
                                                                                   { "Black Olives", .50m }, { "Mushroom", .50m },
                                                                                   { "Pineapple", .50m }, { "Apple", .50m }, { "Garlic", .50m },
                                                                                   { "Mozzarella", .50m }, { "Ricotta", .50m },
                                                                                   { "Extra Cheese", 1.00m }, { "Avocado", 1.00m }, { "Caviar", 1.00m },
                                                                                   { "Roasted Veggies", 1.00m }, { "Kalamata Olives", 1.00m }, { "Wagyu", 51.00m },
        };

        Dictionary<string, decimal> optionsPricing = new Dictionary<string, decimal>() { {"Small", 7.99m}, {"Medium", 8.99m}, {"Large", 10.99m},
                                                                                         { "Extra Large", 12.99m}, {"Immense", 14.99m},
                                                                                         {"Regular Crust", 0.00m}, {"Thin Crust", 0.00m}, {"Stuffed Crust", 1.00m},
                                                                                         {"Deep Dish Crust", 1.00m}, {"Garlic Butter Crust", 2.00m},
                                                                                         {"Homemade Sauce", 0.00m}, {"Garlic Sauce", 0.00m}, {"BBQ Sauce", 0.00m}, {"Pumpkin Sauce", 1.00m},
                                                                                         {"Upgrade", 8.00m}, {"Delivery", 3.00m}
        };
        public decimal orderTotal { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phoneNum { get; set; }
        public string tip { get; set; }
        public string familyMeal { get; set; }
        public string[] familySide { get; set; }
        public string delivery { get; set; }
        public string pizzaSize { get; set; }
        public string pizzaCrust { get; set; }
        public string pizzaSauce { get; set; }
        public string[] pizzaOptions { get; set; }
        public string[] toppingList { get; set; }
        private HttpContext context;
        public decimal taxRate = 1.0634m;
        public string taxAmount {get; set;}
        public Order(HttpContext context)
        {
            this.context = context;
            orderTotal = 0.00m;
            //Customer Data
            name = context.Request["txtName"];
            address = context.Request["txtAddress"];
            phoneNum = context.Request["txtPhone"];
            //Other Options
            tip = context.Request["txtTip"];
            familyMeal = context.Request["familyDrpDwn"];
            delivery = context.Request["deliveryDrpDwn"];
            //If they upgraded, record their choices
            if (familyMeal.Equals("Upgrade"))
            {
                familySide = $"{context.Request["familySideDrpDwn"]},{HttpContext.Current.Request["familyDrinkDrpDwn"]}".Split(',');
            }
            //Pizza Data
            pizzaSize = context.Request["sizeDrpDwn"];
            pizzaCrust = context.Request["crustDrpDwn"];
            pizzaSauce = context.Request["sauceType"];
            pizzaOptions = $"{pizzaSize},{pizzaCrust},{pizzaSauce},tip,{familyMeal},{delivery}".Split(',');
            //Toppings
            toppingList = $"{context.Request["toppings"]},{context.Request["pToppings"]}".Split(',');
            optionsPricing.Add("tip", decimal.Parse(tip));
        }

        public string GetOrderTotal()
        {
            decimal optionsSubTotal = SumCollection.SumValues(optionsPricing, pizzaOptions);
            decimal toppingsSubTotal = SumCollection.SumValues(toppingsPricing, toppingList);
            orderTotal += (optionsSubTotal + toppingsSubTotal - decimal.Parse(tip))*taxRate + decimal.Parse(tip);
            taxAmount = (orderTotal - optionsSubTotal - toppingsSubTotal).ToString("c");
            return orderTotal.ToString("c");
        }

        public List<string> getOrderReceipt()
        {
            return ReceiptGenerator.CreateReceipt(this, optionsPricing, toppingsPricing);

        }
    }
}