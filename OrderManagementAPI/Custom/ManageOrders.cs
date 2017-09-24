using OrderManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagementAPI.Custom
{
    public class ManageOrders:IManageOrders
    {
        List<OrderItems> cusOrderList;
        public ManageOrders()
        {
            cusOrderList = new List<OrderItems>
            {
                new OrderItems
                {
                    OrderId = 1, CustomerName = "Mark", Phone = "7777766666", Address = "London",ItemBasketList= new List<Items>
                    {
                        new Items { ItemName = "Iphone6",ItemQuantity = 2 },
                        new Items { ItemName = "Galaxy",  ItemQuantity = 1 }

                    }
                }
            };
        }

        public ManageOrders(List<OrderItems> cusOrderList)
        {
            this.cusOrderList = cusOrderList;
        }
      
        /// <summary>
        /// Get all Orders
        /// </summary>
        /// <returns></returns>
        public List<OrderItems> GetAllOrders()
        {
            return cusOrderList;
        }

        /// <summary>
        /// Get a single order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public OrderItems GetOrder(int orderId)
        {
            return cusOrderList.FirstOrDefault(c => c.OrderId == orderId);
        }

        /// <summary>
        /// Add new order
        /// </summary>
        /// <param name="customerOrder"></param>
        /// <returns></returns>
        public OrderItems AddCustomerOrder(OrderItems customerOrder)
        {

            if (customerOrder == null)
            {
                throw new ArgumentNullException("Not Valid Data");
            }
            var order = cusOrderList.SingleOrDefault(r => r.OrderId == customerOrder.OrderId);
            if (order != null)
            {
                throw new Exception("CustomerOrder already exists");
            }
            cusOrderList.Add(customerOrder);           
            return customerOrder;
        }
       
        /// <summary>
        /// Update the existing order
        /// </summary>
        /// <param name="customerOrder"></param>
        /// <returns></returns>
        public OrderItems UpdateCustomerOrder(OrderItems customerOrder)
        {
            if (customerOrder == null)
            {
                throw new ArgumentNullException("Not Valid Data");
            }
            var item = cusOrderList.SingleOrDefault(r => r.OrderId == customerOrder.OrderId);
            if (item != null)
            {
                cusOrderList.Remove(item);
            }
            else
            {
                throw new Exception("CustomerOrder not exists to update");
            }           
            cusOrderList.Add(customerOrder);
            return customerOrder;
        }

        /// <summary>
        /// Deletes the order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public OrderItems DeleteCustomerOrder(int orderId)
        {
            var itemToRemove = cusOrderList.SingleOrDefault(r => r.OrderId == orderId);
            if (itemToRemove != null)
            {               
                cusOrderList.Remove(itemToRemove);
            }
            return itemToRemove;
        }

        /// <summary>
        /// Add new items for the order
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="itemName"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public OrderItems AddOrderItems(int orderId, string itemName, int quantity)
        {

            var custBasket = cusOrderList.SingleOrDefault(r => r.OrderId == orderId);

            if (custBasket != null)
            {
                List<Items> ItemBasketList = custBasket.ItemBasketList;
                var basketitem = ItemBasketList.SingleOrDefault(r => r.ItemName == itemName);

                if (basketitem != null)
                    throw new Exception("Item already exists");
                Items item = new Models.Items();
                item.ItemName = itemName;
                item.ItemQuantity = quantity;
                ItemBasketList.Add(item);
                custBasket.ItemBasketList = ItemBasketList;
            }
            return custBasket;
        }

        /// <summary>
        /// Update the items in order
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="itemName"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public OrderItems UpdateOrderItems(int orderId, string itemName, int quantity)
        {
            var custbasket = cusOrderList.SingleOrDefault(r => r.OrderId == orderId);

            if (custbasket != null)
            {
                List<Items> ItemBasketList = custbasket.ItemBasketList;
                var basketitem = ItemBasketList.SingleOrDefault(r => r.ItemName == itemName);
                              
                if (basketitem != null)
                    ItemBasketList.Remove(basketitem);
                else
                     throw new ArgumentNullException("Item Not exists");
                Items item = new Models.Items();
                item.ItemName = itemName;
                item.ItemQuantity = quantity;
                ItemBasketList.Add(item);
                custbasket.ItemBasketList = ItemBasketList;
            }
            return custbasket;
        }

        /// <summary>
        /// Remove an item in the order
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="itemName"></param>      
        /// <returns></returns>
        public OrderItems RemoveOrderItems(int orderId, string itemName)
        {

            var custbasket = cusOrderList.SingleOrDefault(r => r.OrderId == orderId);

            if (custbasket != null)
            {
                List<Items> ItemBasketList = custbasket.ItemBasketList;
                var basketitem = ItemBasketList.SingleOrDefault(r => r.ItemName == itemName);

                if (basketitem != null)
                    ItemBasketList.Remove(basketitem);
                else
                    throw new ArgumentNullException("Item Not exists");

                custbasket.ItemBasketList = ItemBasketList;
            }
            return custbasket;
        }       

        /// <summary>
        /// Clears all the items in the order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public OrderItems ClearOrderItemsList(int orderId)
        {
            var custbasket = cusOrderList.SingleOrDefault(r => r.OrderId == orderId);

            if (custbasket != null)
            {
                List<Items> ItemBasketList = custbasket.ItemBasketList;

                ItemBasketList.Clear();
                custbasket.ItemBasketList = ItemBasketList;
            }
            return custbasket;
        }
    }
}