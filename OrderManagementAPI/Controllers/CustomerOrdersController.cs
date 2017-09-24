using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OrderManagementAPI.Custom;
using OrderManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace OrderManagementAPI.Controllers
{
    public class Singleton
    {
        private static ManageOrders instance;

        private Singleton() { }

        public static ManageOrders Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ManageOrders();
                }
                return instance;
            }
        }
    }
    public class CustomerOrdersController : ApiController
    {
        private static ManageOrders manageOrders = Singleton.Instance;

        /// <summary>
        /// Get all Orders
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetAllOrders()
        {
            var item = manageOrders.GetAllOrders();
            return new HttpResponseMessage()
            {
                Content = new StringContent(JArray.FromObject(item).ToString(), Encoding.UTF8, "application/json")
            };
        }

        /// <summary>
        /// Get a single order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public HttpResponseMessage GetOrder(int orderId)
        {
            var orderItems = manageOrders.GetOrder(orderId);
            if (orderItems == null)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Customer Order Not Found")
                };

            }
            else
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent(JsonConvert.SerializeObject(orderItems).ToString(), Encoding.UTF8, "application/json")                   
                };
            }
        }

        /// <summary>
        /// Add new order
        /// </summary>
        /// <param name="objData"></param>
        /// <returns></returns>
        public IHttpActionResult PostCustomerOrder(JObject objData)
        {
            dynamic jsonData = objData;
            var cusbasket = jsonData.ToObject<OrderItems>();
            var id = manageOrders.AddCustomerOrder(cusbasket);
            return Ok(id);
        }

        /// <summary>
        /// Update the existing order
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public OrderItems PutCustomerOrder(OrderItems orders)
        {
            var data = manageOrders.UpdateCustomerOrder(orders);
            return data;
        }

        /// <summary>
        /// Deletes the order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public OrderItems DeleteCustomerOrder(int orderId)
        {
            var data = manageOrders.DeleteCustomerOrder(orderId);
            return data;
        }

        /// <summary>
        /// Add new item for the order
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="itemName"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        [HttpGet]
        public OrderItems PostCustomerOrderItem(int orderId, string itemName, int quantity)
        {
            var data = manageOrders.AddOrderItems(orderId, itemName, quantity);
            return data;
        }

        /// <summary>
        /// Update the item in order
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="itemName"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        [HttpGet]
        public OrderItems PutCustomerOrderItem(int orderId, string itemName, int quantity)
        {
            var data = manageOrders.UpdateOrderItems(orderId, itemName, quantity);
            return data;
        }

        /// <summary>
        /// Remove an item in the order
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="itemName"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public OrderItems DeleteCustomerOrderItem(int orderId, string itemName)
        {
            var data = manageOrders.RemoveOrderItems(orderId, itemName);
            return data;
        }

        /// <summary>
        /// Delete all the items in the order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public OrderItems DeleteOrderItemsList(int orderId)
        {
            var data = manageOrders.ClearOrderItemsList(orderId);
            return data;
        }

    }
}
