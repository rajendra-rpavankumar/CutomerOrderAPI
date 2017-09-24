using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementAPI.Models;
using OrderManagementAPI.Custom;

namespace OrderManagementTests
{
    //[TestFixture]
    [SetUpFixture]
    public class TestClass
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
        [SetUp]
        public void SetUp()
        {
            orderManage = new ManageOrders(orderItems);
        }

        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");
        }

        [Test()]
        public void GetAllOrdersTest()
        {
            ManageOrders order = new ManageOrders();
            var expected = order.GetAllOrders();
            Assert.IsNotNull(expected);
        }

        [Test()]
        public void GetOrderTest()
        {
            OrderItems expected = orderManage.GetOrder(11);
            Assert.IsNotNull(expected);
        }

        [Test()]
        public void AddCustomerOrderTest()
        {
            OrderItems expected = orderManage.AddCustomerOrder(addOrderItem);
            var exp = orderManage.GetAllOrders();
            Assert.AreEqual(expected.OrderId, addOrderItem.OrderId);
        }

        [Test()]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void AddNullCustomerOrderTest()
        {
            //OrderItems expected = orderManage.AddCustomerOrder(null);

            var exception = Assert.Catch(() => orderManage.AddCustomerOrder(null));
            Assert.IsInstanceOf<Exception>(exception);
        }

        [Test()]
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

        [Test()]
        public void UpdateCustomerOrderTest()
        {
            OrderItems expected = orderManage.UpdateCustomerOrder(updateOrder);
            Assert.IsNotNull(expected);
        }

        [Test()]
        public void UpdateNullCustomerOrderTest()
        {
            //OrderItems expected = orderManage.UpdateCustomerOrder(null);
            var exception = Assert.Catch(() => orderManage.UpdateCustomerOrder(null));
            Assert.IsInstanceOf<Exception>(exception);

        }

        [Test()]
       // [ExpectedException(typeof(Exception))]
        public void UpdateInvalidCustomerOrderTest()
        {
            //OrderItems expected = orderManage.UpdateCustomerOrder(new OrderItems());
            var exception = Assert.Catch(() => orderManage.UpdateCustomerOrder(new OrderItems()));
            Assert.IsInstanceOf<Exception>(exception);
        }

        [Test()]
        public void DeleteCustomerOrderTest()
        {
            OrderItems expected = orderManage.DeleteCustomerOrder(11);
            Assert.IsNotNull(expected);
        }

        [Test()]
        public void DeleteInvalidCustomerOrderTest()
        {
            OrderItems expected = orderManage.DeleteCustomerOrder(3);
            Assert.IsNull(expected);
        }

        [Test()]
        public void AddOrderItemsTest()
        {
            OrderItems expected = orderManage.AddOrderItems(11, "HTCDesire", 2);
            Assert.IsNotNull(expected);
        }

        [Test()]
        public void AddInvalidOrderIdItemsTest()
        {
            OrderItems expected = orderManage.AddOrderItems(4, "HTCDesire", 2);
            Assert.IsNull(expected);
        }

        [Test()]
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

        [Test()]
        public void UpdateOrderItemsTest()
        {
            OrderItems expected = orderManage.UpdateOrderItems(11, "GalaxyNote", 20);
            Assert.IsNotNull(expected);
        }

        [Test()]
        public void UpdateInvalidOrderItemsTest()
        {
            OrderItems expected = orderManage.UpdateOrderItems(4, "GalaxyNote", 20);
            Assert.IsNull(expected);
        }

        [Test()]       
        public void UpdateOrderItemsNotExistTest()
        {                    
            var exception = Assert.Catch(() => orderManage.UpdateOrderItems(11, "Galaxy", 20));
            Assert.IsInstanceOf<Exception>(exception);

            //Assert.Throws<ArgumentNullException>(() => orderManage.UpdateOrderItems(11, "Galaxy", 20)());
        }

        [Test()]
        public void RemoveOrderItemsTest()
        {
            OrderItems expected = orderManage.RemoveOrderItems(11, "GalaxyNote");
            Assert.IsNotNull(expected);
        }

        [Test()]
        public void RemoveInvalidOrderItemsTest()
        {
            OrderItems expected = orderManage.RemoveOrderItems(4, "GalaxyNote");
            Assert.IsNull(expected);
        }

        [Test()]
       // [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveItemsNotExistTest()
        {
            //OrderItems expected = orderManage.RemoveOrderItems(11, "Galaxy");
            var exception = Assert.Catch(() => orderManage.RemoveOrderItems(11, "Galaxy"));
            Assert.IsInstanceOf<Exception>(exception);
        }

        [Test()]
        public void ClearOrderItemsListTest()
        {
            OrderItems expected = orderManage.ClearOrderItemsList(11);
            Assert.IsNotNull(expected);
        }

        [Test()]
        public void ClearInvalidOrderItemsListTest()
        {
            OrderItems expected = orderManage.ClearOrderItemsList(5);
            Assert.IsNull(expected);
        }
    }
}
