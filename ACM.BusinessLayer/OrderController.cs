using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BusinessLayer
{
    public class OrderController
    {
        private CustomerRepository CustomerRepository { get; set; }
        private OrderRepository OrderRepository { get; set; }
        private InventoryRepository InventoryRepository { get; set; }
        private EmailLibrary EmailLibrary { get; set; }

        public OrderController(
            CustomerRepository customerRepository,
            OrderRepository orderRepository,
            InventoryRepository inventoryRepository,
            EmailLibrary emailLibrary)
        {
            CustomerRepository = customerRepository;
            OrderRepository = orderRepository;
            InventoryRepository = inventoryRepository;
            EmailLibrary = emailLibrary;
        }

        public OrderController()
        {
            CustomerRepository = new CustomerRepository();
            InventoryRepository = new InventoryRepository();
            OrderRepository = new OrderRepository();
            EmailLibrary = new EmailLibrary();
        }

        public void PlaceOrder(
            Customer customer, 
            Order order, 
            Payment payment, 
            bool allowSplitOrders, 
            bool emailReceipt)
        {
            CustomerRepository.Add(customer);

            OrderRepository.Add(order);

            InventoryRepository.OrderItems(order, allowSplitOrders);

            payment.ProcessPayment();

            if (emailReceipt)
            {
                customer.ValidateEmail();
                CustomerRepository.Update();

                EmailLibrary.SendEmail(customer.EmailAddress, "Here's the receipt");
            }
        }
    }
}
