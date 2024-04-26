using System.Numerics;

namespace DrinkShopWebApp2.Models
{
    public class OrderDetail
    {
        // Fields/attributes
        // Primary key - OrderDetailId
        private int _orderDetailId;
        private int _orderId;
        private int _drinkId;


        // Constructor(s) ?? None of the tutorials actually appeared to show 
        // Model class constructors?? or private attributes/fields
        // Default constructor
        public OrderDetail()
        {
        }
        // Parameterized Constructor(s)
        public OrderDetail(int orderDetailId, int orderId, int drinkId)
        {
            OrderDetailId = orderDetailId;
            OrderId = orderId;
            DrinkId = drinkId;
        }

        // Properties
        // If using Entity Framework do not need to specify [Key] as 
        // the EF assigns Properties named w/ 'ClassnameId' syntax as the
        // Class's Primary Key automatically. 
        //[Key]
        public int OrderDetailId { get => _orderDetailId; set => _orderDetailId = value; }
        // below 2 represent FK relationships
        public int OrderId { get => _orderId; set => _orderId = value; }
        public int DrinkId { get => _drinkId; set => _drinkId = value; }

        // Navigation Properties:
        // OrderId property is a foreign key w/ the corresponding 'navigation property' of Order.
        // Navigation property for Order 
        public virtual Order Order { get; set; } = null!;
        // DrinkId property is a foreign key w/ the corresponding 'navigation property' of Drink.
        // Navigation property for Drink
        public virtual Drink Drink { get; set; } = null!;

        // Methods

        public override string? ToString()
        {
            //return base.ToString();
            return $"Order Detail Id : {OrderDetailId}; Order Id : {OrderId}; Drink Id : {DrinkId}";
        }
    }
}
