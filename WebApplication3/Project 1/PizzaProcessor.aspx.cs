using System;
using System.Collections.Generic;
using System.Web;
using Utilities;

namespace WebApplication3
{
    public partial class PizzaProcessor : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            Order ord = new Order(HttpContext.Current);
            ////Customer Data
            string name = Request["txtName"];
            string address = Request["txtAddress"];
            string phoneNum = Request["txtPhone"];

            //Get totals
            string orderTotal = ord.GetOrderTotal();

            //Display info
            List<string> receiptLines = ord.getOrderReceipt();
            lblCustInfo.Text = $"<b>Customer:</b> {name} <br /> <b>Phone:</b> {phoneNum} <br /> <b>Address:</b> {address}";
            lblItems.Text = string.Join("", receiptLines);
            lblTotal.Text = $"<b>Your total is {orderTotal}</b>";

        }
    }
}