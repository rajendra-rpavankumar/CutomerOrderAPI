# CustomerOrdersAPI

CI : [![Build status](https://ci.appveyor.com/api/projects/status/p4fxw6guu3vdpo8c?svg=true)](https://ci.appveyor.com/project/rpavankumar-reddy/customerordersapi)
CodeCoverage: [![codecov](https://codecov.io/gh/rpavankumar-reddy/CustomerOrdersAPI/branch/master/graph/badge.svg)](https://codecov.io/gh/rpavankumar-reddy/CustomerOrdersAPI)





API which will allow users to add and remove items and change the quantity of the items. Users can also be able to simply clear out all items from their order and start again.

Additional functionality of Creating Orders has been implemented.

Different  API endpoints are implemented for adding,updating,deleting orders and also for adding, updating and deleting the items in the order.

The following lines describe how to use the api's for different functionality

1.GetAllOrders - To Get all the orders use the 
below API EndPoint

http://localhost:[port]/api/CustomerOrders/GetAllOrders 

which returns

Output
------

```
[
  {
    "OrderId": 1,
    "CustomerName": "Mark",
    "Phone": "7777766666",
    "Address": "London",
    "ItemBasketList": [
      {
        "ItemName": "Iphone6",
        "ItemQuantity": 2
      },
      {
        "ItemName": "Galaxy",
        "ItemQuantity": 1
      }
    ]
  }
]
```

2.GetOrder - To get the particular single order use the API EndPoint

http://localhost:[port]/api/CustomerOrders/GetOrder?orderId=1

Input:
------
OrderId

Output:
-------
```
{
  "OrderId": 1,
  "CustomerName": "Mark",
  "Phone": "7777766666",
  "Address": "London",
  "ItemBasketList": [
    {
      "ItemName": "Iphone6",
      "ItemQuantity": 2
    },
    {
      "ItemName": "Galaxy",
      "ItemQuantity": 1
    }
  ]
}
```

3.AddNewOrder - To add a new order use the API EndPoint

http://localhost:[port]/api/CustomerOrders/PostCustomerOrder 

Input:
------
```
{
    "OrderId": 2,
    "CustomerName": "Mark2",
    "Phone": "7777666662",
    "Address": "Birmingham",
    "ItemBasketList": [
      {
        "ItemName": "Philips",
        "ItemQuantity": 2
      },
      {
        "ItemName": "Samsung",
        "ItemQuantity": 2
      }
    ]
  }
```

Output:
------
```
  {
    "OrderId": 2,
    "CustomerName": "Mark2",
    "Phone": "7777666662",
    "Address": "Birmingham",
    "ItemBasketList": [
      {
        "ItemName": "Philips",
        "ItemQuantity": 2
      },
      {
        "ItemName": "Samsung",
        "ItemQuantity": 2
      }
    ]
  }
  ```


4.UpdateOrder - to update an existing order use the API Endpoint

http://localhost:[port]/api/CustomerOrders/PutCustomerOrder 

Input:
-----
```
  {
    "OrderId": 2,
    "CustomerName": "MarkWaugh",
    "Phone": "7775556667",
    "Address": "Houston",
    "ItemBasketList": [
      {
        "ItemName": "Philips",
        "ItemQuantity": 2
      },
      {
        "ItemName": "Samsung",
        "ItemQuantity": 2
      }
    ]
  }
```

Output:
------
```
{
  "OrderId": 2,
  "CustomerName": "MarkWaugh",
  "Phone": "7775556667",
  "Address": "Houston",
  "ItemBasketList": [
    {
      "ItemName": "Philips",
      "ItemQuantity": 2
    },
    {
      "ItemName": "Samsung",
      "ItemQuantity": 2
    }
  ]
}
```



5.DeleteOrder - To delete an order use the API
EndPoint

http://localhost:[port]/api/CustomerOrders/DeleteCustomerOrder?orderId=2 

Input - orderId
------
Output - Returns the deleted order
------

```
{
  "OrderId": 2,
  "CustomerName": "MarkWaugh",
  "Phone": "7775556667",
  "Address": "Houston",
  "ItemBasketList": [
    {
      "ItemName": "Philips",
      "ItemQuantity": 2
    },
    {
      "ItemName": "Samsung",
      "ItemQuantity": 2
    }
  ]
}
```

6.AddOrderItems - To add new Items to the order use the API EndPoint

http://localhost:[port]/api/CustomerOrders/PostCustomerOrderItem?orderId=1&itemName=HTC&quantity=5

Input : orderId,itemName,quantity
-----

Output: Returns the Order with added Item
------

```
{
  "OrderId": 1,
  "CustomerName": "Mark",
  "Phone": "7777766666",
  "Address": "London",
  "ItemBasketList": [
    {
      "ItemName": "Iphone6",
      "ItemQuantity": 2
    },
    {
      "ItemName": "Galaxy",
      "ItemQuantity": 1
    },
    {
      "ItemName": "HTC",
      "ItemQuantity": 5
    }
  ]
}
```

7.UpdateOrderItems - To update the items(to change the quantiy) in the order use the API Endpoint

http://localhost:[port]/api/CustomerOrders/PutCustomerOrderItem?orderId=1&itemName=HTC&quantity=100

Input : orderId,itemName,quantity
-----

Output: Returns the Order with updated quantity in the item
-----
```
{
  "OrderId": 1,
  "CustomerName": "Mark",
  "Phone": "7777766666",
  "Address": "London",
  "ItemBasketList": [
    {
      "ItemName": "Iphone6",
      "ItemQuantity": 2
    },
    {
      "ItemName": "Galaxy",
      "ItemQuantity": 1
    },
    {
      "ItemName": "HTC",
      "ItemQuantity": 100
    }
  ]
}
```

8.RemoveOrderItems - To delete an item in the order use the API endPoint

http://localhost:[port]/api/CustomerOrders/DeleteCustomerOrderItem?orderId=1&itemName=Galaxy


Input : orderId,itemName,quantity
-----

Output: Returns the Order by removing the item
-----
```
{
  "OrderId": 1,
  "CustomerName": "Mark",
  "Phone": "7777766666",
  "Address": "London",
  "ItemBasketList": [
    {
      "ItemName": "Iphone6",
      "ItemQuantity": 2
    },
    {
      "ItemName": "HTC",
      "ItemQuantity": 100
    }
  ]
}
```


9.ClearItemsList - To delete all the items in the order use the API Endpoint

http://localhost:[port]/api/CustomerOrders/DeleteOrderItemsList?orderId=1

Input : orderId
-----
Output: Returns the Order with Empty Items List
-----
```
{
  "OrderId": 1,
  "CustomerName": "Mark",
  "Phone": "7777766666",
  "Address": "London",
  "ItemBasketList": []
}
```

