using System.Collections.Generic;


namespace WebApplication3
{
    public class ReceiptGenerator
    {
        public static List<string> CreateReceipt(Order ord, Dictionary<string,decimal> optionsPrice, Dictionary<string, decimal> toppingsPrice)
        {
            List<string> receiptLines = new List<string>();
            receiptLines.Add("<h2>Your Pizza</h2> <br />");
            foreach (string s in ord.pizzaOptions)
            {
                if (optionsPrice.ContainsKey(s))
                    receiptLines.Add($"{s}...           ${optionsPrice[s]} <br />");
            }
            receiptLines.Add("<h2>Pizza Addons...</h2> <br />");
            foreach (string s in ord.toppingList)
            {
                if (toppingsPrice.ContainsKey(s))
                    receiptLines.Add($"{s}...           ${toppingsPrice[s]} <br />");
            }

            if (ord.familyMeal.Equals("Upgrade"))
            {
                receiptLines.Add($"<h2>Family meal upgrade...</h2><br />");
                receiptLines.Add($"Upgrade Side: {ord.familySide[0]} <br />");
                receiptLines.Add($"Upgrade Drink: {ord.familySide[1]} <br />");
            }
            if (ord.delivery.Equals("delivery"))
                receiptLines.Add($"<b>Delivery fee(Not a tip!)...</b>      $3.00 <br />");
            if (!ord.tip.Equals("0.00"))
                receiptLines.Add($"<b>Tip:</b> ${ord.tip}<br />");
            receiptLines.Add($"Sales Tax(6.34%)...{ord.taxAmount}<br><br />");
            return receiptLines;
        }
    }
}