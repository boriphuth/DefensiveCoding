using ACM.BusinessLayer;
using Core.Common;
using System;
using System.Windows.Forms;

namespace ACM.Application
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlaceOrder();

        }

        private static void PlaceOrder()
        {
            var customer = new Customer();
            //populate customer

            var order = new Order();
            //populate order

            var payment = new Payment();
            //populate payment info from the UI

            var orderController = new OrderController();

            orderController.PlaceOrder(
                customer, 
                order, 
                payment, 
                allowSplitOrders:true, 
                emailReceipt:true);
        }

    }
}
