using OrderManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagementAPI.Custom
{
    public interface IManageOrders
    {
        List<OrderItems> GetAllOrders();
        OrderItems GetOrder(int orderId);
        OrderItems AddCustomerOrder(OrderItems customerOrder);
        OrderItems UpdateCustomerOrder(OrderItems customerOrder);
        OrderItems DeleteCustomerOrder(int orderId);
        OrderItems AddOrderItems(int orderId, string itemName, int quantity);
        OrderItems RemoveOrderItems(int orderId, string itemName);
        OrderItems UpdateOrderItems(int orderId, string itemName, int quantity);
        OrderItems ClearOrderItemsList(int orderId);
    }
}