using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace DrinkShopWebApp2.Models
{
    public class Order
    {
        // Fields/attributes
        // Primary key - OrderId
        private int _orderId;
        // ?? consider seperating out Date and Time into two separate attributes??
        // Timestamp for when order created and when completed.
        private DateTime _orderDate;
        private DateTime _orderFilled;

        private decimal _orderTotal;
        // Use foreign key CustomerId to associate specific customer w/ this Order 
        // object/entity rather than using below attribute/property combo. 
        //private Customer _customer;
        // ?attribute to hold associated foreign key for CustomerID
        // ?? rather than _customer??
        private int _customerId;

        // ?attribute to hold associated foreign key for DrinkID
        //private int _drinkId;
        // Since the Order entity/object can have many associated Drink objects
        // which are linked to using the DrinkId foreign key ?? Have ICollection
        // virtual list of the DrinkIds for this Order entity/object vs
        // the Drinks List above??

        // Use the one-to-many collection of Drink objects/entities for this
        // Order entity/object - couldn't get to work using private attributes/fields
        // with a public Property - had to create List of Drink objects using 
        // the virtual ICollection<Drink> navigation property below (see Navigation
        // properties sections). 
        //private List<Drink> _drinks;
        //private virtual List<Drink> _drinks;
        //private ICollection<Drink> _drinks;
        //private List<Order> _orders;
        //private List<Order> _ordersList;
        private List<Order> _ordersTableList;
        //private ICollection<Order> _orders;
        //private ICollection<Order> _ordersList;

        // ?? eliminate the ToDo model and move the Orders queue data structure
        // into the Order model. ??
        private Queue<Order> _ordersQueue;

        // Constructor(s) ?? None of the tutorials actually appeared to show 
        // Model class constructors?? or private attributes/fields
        // Default constructor
        public Order()
        {
            //OrderId = orderId;
            // ?? need to use/assign a default CustomerId value??
            // rather than below??
            //Customer = null;
            // Create an empty List of Drink objects. 
            //Drinks = new List<Drink>();
            //??OrderDetails = OrderDetails;
            // Set OrderDate to today's date.
            OrderDate = new DateTime();
            OrderFilled = null;
            // Call a method to calculate the orderTotal
            OrderTotal = CalcTotal();
        }
        // Parameterized Constructor(s)
        public Order(int customerId)
        //public Order(Customer customer)
        {
            //OrderId = orderId;
            // ?? need to use/assign a default CustomerId value??
            // rather than below??
            //Customer = customer;
            CustomerId = customerId;
            // Create an empty List of Drink objects. 
            //Drinks = new List<Drink>();
            //??OrderDetails = OrderDetails;
            // Set OrderDate to today's date.
            OrderDate = new DateTime();
            OrderFilled = null;
            // Call a method to calculate the orderTotal
            OrderTotal = CalcTotal();
        }

        /*public Order(int customerId, List<Drink> drinks)
        //public Order(Customer customer, List<Drink> drinks)
        {
            //OrderId = orderId;
            // ?? need to use/assign a default CustomerId value??
            // rather than below??
            //Customer = customer;
            CustomerId = customerId;
            //Drinks = drinks;
            //??OrderDetails = OrderDetails;
            // Set OrderDate to today's date.
            OrderDate = new DateTime();
            OrderFilled = null;
            // Call a method to calculate the orderTotal
            OrderTotal = CalcTotal();
        }*/

        // Properties:
        // If using Entity Framework do not need to specify [Key] as 
        // the EF assigns Properties named w/ 'ClassnameId' syntax as the
        // Class's Primary Key automatically. 
        //[Key]
        public int OrderId { get => _orderId; set => _orderId = value; }
        // DataType attribute for formatting DateTime object
        [DataType(DataType.DateTime, ErrorMessage = "OrderDate DateTime is invalid.")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy - hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get => _orderDate; set => _orderDate = value; }
        [DataType(DataType.DateTime, ErrorMessage = "OrderFilled DateTime is invalid.")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy - hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public DateTime? OrderFilled { get => _orderFilled; set => _orderFilled = value.Value; }
        //public Customer? Customer { get => _customer; set => _customer = value; }
        //public List<Drink> Drinks { get => _drinks; set => _drinks = value; }
        //public List<Order> Orders { get; set; }
        //public List<Order> OrdersTableList { get; set; }
        public List<Order>? OrdersTableList 
        {
            get { return _ordersTableList; } 
            set
            {
                _ordersTableList = Orders.ToList();
            }
        }

        //[DataType(DataType.Currency, ErrorMessage = "Order invalid, must be a positive value.")]
        //[DisplayFormat(DataFormatString = "{C2, CultureInfo.CurrentCulture}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "(C2, CultureInfo.CurrentCulture)", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{D2}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "(D2)", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18, 2)")]
        //public decimal OrderTotal { get => _orderTotal; set => _orderTotal = value; }
        public decimal? OrderTotal 
        {
            get { return _orderTotal; }
            set
            {
                _orderTotal = CalcTotal();
            }
        }
        //public int DrinkId { get => _drinkId; set => _drinkId = value; }
        //[ForeignKey(nameof(CustomerId))]
        //[ForeignKey("Customer")]
        public int CustomerId { get => _customerId; set => _customerId = value; }
        //public Queue<Order>? OrdersQueue { get => _ordersQueue; set => _ordersQueue = value; }
        public Queue<Order>? OrdersQueue
        {
            get { return _ordersQueue; }
            set
            {
                OrdersQueue = new Queue<Order>();
                if (OrdersTableList != null)
                {
                    //List<Order> ordersList = Orders.ToList();
                    List<Order> ordersList = OrdersTableList;
                    //List<Order> ordersList = new ICollection<Order> Orders;
                    //Orders.Sort();
                    //Orders.ToImmutableSortedDictionary();
                    // Sort all Order object by OrderDate in ascending order then add/enqueue
                    // to OrderQueueu
                    ordersList.Sort();
                    foreach (Order order in ordersList)
                    {
                        OrdersQueue.Enqueue(order);
                    }
                }
            }
        }

        // Navigation Properties: 
        // MS learn tutorial on EF MVC used below to hold multiple rows of data associated
        // w/ this class entity's primary key value - i.e. Drinks property of an Order entity
        // would hold all the 'Drink' entities/objects related this this Order entity -
        // so if this Order entity has multiple related Drink rows (Drink rows w/ this Order
        // entity's/object's primary key in the Drink rows OrderId foreign key column).
        // Uses keyword 'virtual' so 'Navigation Properties' can take advantage of EF functionality
        // - necessary d/t need a List (such as ICollection) to be able to do CRUD operations
        // on a navigation property which holds multiple entities (such as w/ many-to-many &
        // one-to-many type relationships). 
        // Since the Order entity/object can have many associated Drink objects
        // which are linked to using the DrinkId foreign key ?? Have ICollection
        // virtual list of the DrinkIds for this Order entity/object vs
        // the Drinks List above - public List<Drink> Drinks;??
        //public virtual ICollection<Drink> Drinks { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; } = null!;

        // DrinkId property is a foreign key w/ the corresponding 'navigation property' of Order.Drinks.
        // This Order entity/object 'Drinks' List/collection can hold many associated Drink entities/objects. 
        //??public virtual Drink Drink { get; set; }

        // Navigation Properties: 
        // CustomerId property is a foreign key w/ the corresponding 'navigation property' of Customer.
        // This Order entity/object can only be associated w/ one Customer entity/object. 
        // Below defines one Customer entity per order – the CustomerId property is used to represent
        // the Foreign key relationship to the Customer table (if omit the CustomerId property EF Core
        // will create it anyway, as a ‘shadow property’. 
        //public Customer Customer { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;

        // Navigation property for a collection of OrderDetails - rather than using 
        // the ICollection<Drink> Drinks property
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = null!;
        

        // Methods
        public decimal CalcTotal()
        {
            decimal total = 0m;
            if (OrderDetails != null)
            //if (Drinks != null)
            {
                foreach (OrderDetail drink in OrderDetails)
                //foreach (Drink drink in Drinks)
                {
                    total += drink.Drink.DrinkPrice;
                    //total += drink.DrinkPrice;
                }
            }

            return total;
        }

        public string? DisplayOrderQueue()
        {
            //return base.ToString();
            string ToDoOutput = "";
            //string ToDoOutput = $"ToDo Id: {ToDoId}; ToDo Date: {ToDoDate}; ";
            if (OrdersQueue != null)
            {

                ToDoOutput += $"Orders in Queue: {OrdersQueue.Count}/n Orders: /n";
                foreach (Order order in OrdersQueue)
                {
                    ToDoOutput += $"{order.ToString} /n";
                }
            }
            else
            {
                ToDoOutput += $"Orders in Queue: none;";
            }
            return ToDoOutput;
        }


        public override bool Equals(object? obj)
        {
            //return base.Equals(obj);
            if (obj == null) return false;
            Order objAsDate = obj as Order;
            if (objAsDate == null) return false;
            else return Equals(objAsDate);
        }

        public int SortByDateAscending(DateTime date1, DateTime date2)
        {
            return date1.CompareTo(date2);
        }

        // Default comparer for Order by OrderDate
        public int CompareTo(Order compareOrder)
        {
            if (compareOrder == null)
            {
                return 1;
            }
            else
            {
                return this.OrderDate.CompareTo(compareOrder.OrderDate);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /*public override DateTime GetHashCode()
        {
            //return base.GetHashCode();
            return OrderDate;
        }*/

        public bool Equals(Order other)
        //public override bool Equals(object? obj)
        {
            //return base.Equals(obj);
            if (other == null) return false;
            return (this.OrderDate.Equals(other.OrderDate));
        }


        public override string? ToString()
        {
            //return base.ToString();
            //return $"Order Id: {OrderId}; Order Date: {OrderDate}; Customer Id: {Customer.CustomerId}; Customer Name: {Customer.FirstName} {Customer.LastName}; ";
            string orderOutput = $"Order Id: {OrderId}; Order Date: {OrderDate}; Order Completed: {OrderFilled} /nCustomer Id: {Customer.CustomerId}; Customer Name: {Customer.FirstName} {Customer.LastName}; /n";
            orderOutput += $"Drinks: /n";
            if (OrderDetails != null)
            //if (Drinks != null)
            {
                //orderOutput += $"Drinks: /n";
                foreach (OrderDetail drink in OrderDetails)
                //foreach (Drink drink in Drinks)
                {
                    orderOutput += $"{drink.Drink.ToString} /n";
                    //orderOutput += $"{drink.ToString} /n";
                }
            }
            else
            {
                //orderOutput += "Drinks: No drinks in this order. /n";
                orderOutput += "No drinks in this order. /n";
            } 
            // Decide on OrderTotal formatting if want '$' - and specify 2 decimal place outputis C2
            // if just want 2 decimal places w/o '$' sign use D2. 
            orderOutput += $"Order Total: $ {OrderTotal:D2}";
            return orderOutput;
        }
    }
}
