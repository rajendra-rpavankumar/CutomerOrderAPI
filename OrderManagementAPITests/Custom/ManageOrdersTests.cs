using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManagementAPI.Custom;
using OrderManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementAPI.Custom.Tests
{
    [TestClass()]
    public class ManageOrdersTests
    {
        ManageOrders orderManage;

        List<OrderItems> orderItems = new List<OrderItems>
        {
            new OrderItems
            {
                OrderId = 11,
                CustomerName = "MarkTest",
                Phone = "7777666662",
                Address = "London",
                ItemBasketList = new List<Items>
                {
                        new Items { ItemName = "Iphone8",ItemQuantity = 2 },
                        new Items { ItemName = "GalaxyNote",  ItemQuantity = 1 }
                }
            }
        };
        OrderItems addOrderItem = new OrderItems
        {
            OrderId = 3,
            CustomerName = "TestOrder",
            Phone = "7777666662",
            Address = "Birmingham",
            ItemBasketList = new List<Items>
            {
                    new Items { ItemName = "Apple",ItemQuantity = 5 }
            }

        };
        OrderItems updateOrder = new OrderItems
        {
            OrderId = 11,
            CustomerName = "MarkTest",
            Phone = "777766666",
            Address = "Kensington",
            ItemBasketList = new List<Items>
            {
                    new Items { ItemName = "Apple",ItemQuantity = 5 }
            }

        };

        [TestInitialize]
        public void Initialize()
        {
            orderManage = new ManageOrders(orderItems);
        }

        [TestMethod()]
        public void GetAllOrdersTest()
        {
            ManageOrders order = new ManageOrders();
            var expected = order.GetAllOrders();
            Assert.IsNotNull(expected);
        }

        [TestMethod()]
        public void GetOrderTest()
        {
            OrderItems expected = orderManage.GetOrder(11);
            Assert.IsNotNull(expected);
        }

        [TestMethod()]
        public void AddCustomerOrderTest()
        {
            OrderItems expected = orderManage.AddCustomerOrder(addOrderItem);
            var exp = orderManage.GetAllOrders();
            Assert.AreEqual(expected.OrderId, addOrderItem.OrderId);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullCustomerOrderTest()
        {
            OrderItems expected = orderManage.AddCustomerOrder(null);                      
        }

        [TestMethod()]      
        public void AddExistingCustomerOrderTest()
        {            
            try
            {
                OrderItems expected = orderManage.AddCustomerOrder(orderItems.First());
            }
            catch (Exception ex)
            {
                Assert.AreEqual("CustomerOrder already exists", ex.Message);
            }
        }

        [TestMethod()]
        public void UpdateCustomerOrderTest()
        {
            OrderItems expected = orderManage.UpdateCustomerOrder(updateOrder);
            Assert.IsNotNull(expected);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateNullCustomerOrderTest()
        {
            OrderItems expected = orderManage.UpdateCustomerOrder(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void UpdateInvalidCustomerOrderTest()
        {
            OrderItems expected = orderManage.UpdateCustomerOrder(new OrderItems());
        }

        [TestMethod()]
        public void DeleteCustomerOrderTest()
        {
            OrderItems expected = orderManage.DeleteCustomerOrder(11);
            Assert.IsNotNull(expected);
        }

        [TestMethod()]
        public void DeleteInvalidCustomerOrderTest()
        {
            OrderItems expected = orderManage.DeleteCustomerOrder(3);
            Assert.IsNull(expected);
        }

        [TestMethod()]
        public void AddOrderItemsTest()
        {
            OrderItems expected = orderManage.AddOrderItems(11, "HTCDesire", 2);
            Assert.IsNotNull(expected);
        }

        [TestMethod()]
        public void AddInvalidOrderIdItemsTest()
        {
            OrderItems expected = orderManage.AddOrderItems(4, "HTCDesire", 2);
            Assert.IsNull(expected);
        }

        [TestMethod()]
        public void AddOrderItemsExistTest()
        {
            try
            {
                OrderItems expected = orderManage.AddOrderItems(11, "Iphone8", 2);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Item already exists", ex.Message);
            }
        }

        [TestMethod()]
        public void UpdateOrderItemsTest()
        {
            OrderItems expected = orderManage.UpdateOrderItems(11, "GalaxyNote", 20);
            Assert.IsNotNull(expected);
        }

        [TestMethod()]
        public void UpdateInvalidOrderItemsTest()
        {
            OrderItems expected = orderManage.UpdateOrderItems(4, "GalaxyNote", 20);
            Assert.IsNull(expected);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateOrderItemsNotExistTest()
        {            
                OrderItems expected = orderManage.UpdateOrderItems(11, "Galaxy", 20);                        
        }

        [TestMethod()]
        public void RemoveOrderItemsTest()
        {
            OrderItems expected = orderManage.RemoveOrderItems(11, "GalaxyNote");
            Assert.IsNotNull(expected);
        }

        [TestMethod()]
        public void RemoveInvalidOrderItemsTest()
        {
            OrderItems expected = orderManage.RemoveOrderItems(4, "GalaxyNote");
            Assert.IsNull(expected);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveItemsNotExistTest()
        {
            OrderItems expected = orderManage.RemoveOrderItems(11, "Galaxy");
        }

        [TestMethod()]
        public void ClearOrderItemsListTest()
        {
            OrderItems expected = orderManage.ClearOrderItemsList(11);
            Assert.IsNotNull(expected);
        }

        [TestMethod()]
        public void ClearInvalidOrderItemsListTest()
        {
            OrderItems expected = orderManage.ClearOrderItemsList(5);
            Assert.IsNull(expected);
        }
    }
}