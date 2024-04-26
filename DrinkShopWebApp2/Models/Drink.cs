using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkShopWebApp2.Models
{
    // moved enum DrinkName from Data > Enum folder to inside model/class file
    public enum DrinkName
    {
        WhiteChocolateMocha,
        Mocha,
        MochaLatte,
        Latte,
        Americano,
        IcedTea,
        GreenTea,
        ChaiTea,
        VanillaItalianSoda,
        StrawberryItalianSoda,
        CherryItalianSoda
    }

    public class Drink
    {
        // Fields/attributes
        // Primary key - DrinkId
        private int _drinkId;
        //private string _drinkName;
        // Switch to using enum for DrinkName options
        private DrinkName _drinkName;
        // consider creating enums for DrinkType and DrinkSize
        private string _drinkType;
        private string _drinkSize;
        //private string _drinkDescription;
        //private string _drinkImageUrl;
        private decimal _drinkPrice;
        // ?attribute to hold associated foreign key for OrderID
        // ?? not even needed given this data is held many to many
        // relatinship data is held in OrderDetail relational table??
        //private int _orderId;
        // ??or does this just need a Property?? along w/ virtual Property
        // to attach to associated Order entity/object??

        // Constructor(s)
        // Default constructor
        public Drink()
        {
            //DrinkId = drinkId;
            //DrinkName = "";
            DrinkName = DrinkName.WhiteChocolateMocha;
            DrinkType = "";
            DrinkSize = "";
            //DrinkImageUrl = drinkImageUrl;
            DrinkPrice = -1m;
        }
        // Parameterized Constructor(s)
        public Drink(DrinkName drinkName, string drinkType, string drinkSize)
        //public Drink(string drinkName, string drinkType, string drinkSize)
        {
            //DrinkId = drinkId;
            DrinkName = drinkName;
            DrinkType = drinkType;
            DrinkSize = drinkSize;
            //DrinkImageUrl = drinkImageUrl;
            // Use below for now until switch to DrinkPrice w/ specific setter version 
            DrinkPrice = 1.49m;
            //DrinkPrice = this.DrinkPrice;
        }
        public Drink(DrinkName drinkName, string drinkType, string drinkSize, decimal price)
        //public Drink(string drinkName, string drinkType, string drinkSize, decimal price)
        {
            //DrinkId = drinkId;
            DrinkName = drinkName;
            DrinkType = drinkType;
            DrinkSize = drinkSize;
            //DrinkImageUrl = drinkImageUrl;
            DrinkPrice = price;
        }

        // Properties
        // If using Entity Framework do not need to specify [Key] as 
        // the EF assigns Properties named w/ 'ClassnameId' syntax as the
        // Class's Primary Key automatically. 
        //[Key]
        public int DrinkId { get => _drinkId; set => _drinkId = value; }
        [Required(ErrorMessage = "DrinkName is required")]
        //public string? DrinkName { get => DrinkName1; set => DrinkName1 = value; }
        // If switch to using DrinkName enum rather than string.
        public DrinkName DrinkName { get => _drinkName; set => _drinkName = value; }
        [Required(ErrorMessage = "DrinkType is required")]
        //public string? DrinkType { get => _drinkType; set => _drinkType = value; }
        public string? DrinkType
        {
            get { return _drinkType; }
            /*set
            {
                if (string.Equals(value, "coffee", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "tea", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "soda", StringComparison.InvariantCultureIgnoreCase))
                {
                    _drinkType = value;
                }
                else
                {
                    // set default of 'coffee' if input doesn't match one of the three drink types
                    _drinkType = "coffee";
                }
            }*/
            // change above from checking if 'coffee' 'tea' or 'soda' entered to setting
            // DrinkType automatically for user depending on DrinkName value
            set
            {
                string drinkNameString = DrinkName.ToString();
                if (string.Equals(drinkNameString, "WhiteChocolateMocha", StringComparison.InvariantCultureIgnoreCase) || string.Equals(drinkNameString, "Mocha", StringComparison.InvariantCultureIgnoreCase) || string.Equals(drinkNameString, "MochaLatte", StringComparison.InvariantCultureIgnoreCase) || string.Equals(drinkNameString, "Latte", StringComparison.InvariantCultureIgnoreCase) || string.Equals(drinkNameString, "Americano", StringComparison.InvariantCultureIgnoreCase))/*(DrinkName.Equals("WhiteChocolateMocha") || DrinkName.Equals("Mocha") || DrinkName.Equals("MochaLatte") || DrinkName.Equals("Latte") || DrinkName.Equals("Americano"))*/
                /*(Drink.DrinkName.Equals(Drink.DrinkName, "WhiteChocolateMocha", StringComparison.InvariantCultureIgnoreCase) || string.Equals(DrinkName, "Mocha", StringComparison.InvariantCultureIgnoreCase) || string.Equals(DrinkName, "MochaLatte", StringComparison.InvariantCultureIgnoreCase) || string.Equals(DrinkName, "Latte", StringComparison.InvariantCultureIgnoreCase) || string.Equals(DrinkName, "Americano", StringComparison.InvariantCultureIgnoreCase))*/
                {
                    _drinkType = "coffee";
                }
                else if (string.Equals(drinkNameString, "IcedTea", StringComparison.InvariantCultureIgnoreCase) || string.Equals(drinkNameString, "GreenTea", StringComparison.InvariantCultureIgnoreCase) || string.Equals(drinkNameString, "ChaiTea", StringComparison.InvariantCultureIgnoreCase) )/*(DrinkName.Equals("IcedTea") || DrinkName.Equals("GreenTea") || DrinkName.Equals("ChaiTea"))*/
                {
                    _drinkType = "tea";
                }
                else if (string.Equals(drinkNameString, "VanillaItalianSoda", StringComparison.InvariantCultureIgnoreCase) || string.Equals(drinkNameString, "StrawberryItalianSoda", StringComparison.InvariantCultureIgnoreCase) || string.Equals(drinkNameString, "CherryItalianSoda", StringComparison.InvariantCultureIgnoreCase)) /*(DrinkName.Equals("VanillaItalianSoda") || DrinkName.Equals("StrawberryItalianSoda") || DrinkName.Equals("CherryItalianSoda"))*/
                {
                    _drinkType = "soda";
                }
                else
                {
                    // set default of 'coffee' if input doesn't match one of the three drink types
                    _drinkType = "coffee";
                }
            }
        }
        // Add '?' to datatype for DrinkSize to make it 'nullable'
        [Required(ErrorMessage = "DrinkSize is required")]
        //public string? DrinkSize { get => _drinkSize; set => _drinkSize = value; }
        public string? DrinkSize
        {
            get { return _drinkSize; }
            set
            {
                if (string.Equals(value, "small", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "regular", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "large", StringComparison.InvariantCultureIgnoreCase))
                {
                    _drinkSize = value;
                }
                else
                {
                    // set default DrinkSize of 'regular' if input doesn't match one fo the three sizes
                    _drinkSize = "regular";
                }
            }
        }
        // Added '?' to datatype for DrinkImageUrl to make it 'nullable'
        //[Url]
        //public string? DrinkImageUrl { get => _drinkImageUrl; set => _drinkImageUrl = value; }
        // Per learn.microsoft.com tutorial - decimal, int, float, DateTime
        // values types are 'inherently' required therefore do NOT need the
        // 'Required' attribute. 
        //[DisplayFormat(DataFormatString = "{C2, CultureInfo.CurrentCulture}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "(C2, CultureInfo.CurrentCulture)", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{D2}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "(D2)", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18, 2)")]
        //[DataType(DataType.Currency, ErrorMessage = "Drink Price invalid, must be a positive value.")]
        //public decimal DrinkPrice { get => _drinkPrice; set => _drinkPrice = value; }
        public decimal DrinkPrice
        {
            get { return _drinkPrice; }
            set
            {
                // Setting DrinkPrice based on DrinkType and DrinkSize
                if (string.Equals(DrinkType, "coffee", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (string.Equals(DrinkSize, "small", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 2.99m;
                    }
                    else if (string.Equals(DrinkSize, "regular", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 3.99m;
                    }
                    else if (string.Equals(DrinkSize, "large", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 4.99m;
                    }
                }
                else if (string.Equals(DrinkType, "tea", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (string.Equals(DrinkSize, "small", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 1.59m;
                    }
                    else if (string.Equals(DrinkSize, "regular", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 2.59m;
                    }
                    else if (string.Equals(DrinkSize, "large", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 3.59m;
                    }
                }
                else if (string.Equals(DrinkType, "soda", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (string.Equals(DrinkSize, "small", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 2.50m;
                    }
                    else if (string.Equals(DrinkSize, "regular", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 3.50m;
                    }
                    else if (string.Equals(DrinkSize, "large", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 4.50m;
                    }
                }
                _drinkPrice = value;
            }
        }

        // ?? below not needed d/t OrderDetail table is used to hold this many-to-many
        // relational data between Drink object and Order object??
        // ?attribute? too?? Property to hold associated foreign key for OrderID
        //[ForeignKey("Order")]
        //[ForeignKey(nameof(Order))]
        //public int OrderId { get => _orderId; set => _orderId = value; }
        // ??or does this just need a Property?? along w/ virtual Property
        // to attach to associated Order entity/object??
        // Navigation Property
        //public virtual Order Order { get; set; } = null!;
        // Adding below caused error and wouldn't update-database command. 
        // Navigation property for a collection of OrderDetails - rather than using 
        // the ICollection<Drink> Drinks property
        //public virtual ICollection<OrderDetail>? OrderDetails { get; set; } = null!;

        // Methods
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            //return base.ToString();
            // Decide on DrinkPrice formatting if want '$' - and specify 2 decimal place output is C2
            // if just want 2 decimal places w/o '$' sign use D2. 
            string drinkOutput = $"Drink Id: {DrinkId}; Drink Type: {DrinkType}; Drink Name: {DrinkName}; Size: {DrinkSize}; Price: $ {DrinkPrice:D2};";
            //string drinkOutput = $"Drink Id: {DrinkId}; Drink Type: {DrinkType}; Drink Name: {DrinkName}; Size: {DrinkSize}; Price: $ {DrinkPrice:D2}; Order Id: {OrderId}";
            //string drinkOutput = $"Drink Id: {DrinkId}; Drink Type: {DrinkType}; Drink Name: {DrinkName}; Size: {DrinkSize}; Price: $ {DrinkPrice:D2}; Order Id: {Order.OrderId}";
            return drinkOutput;
        }
    }
}
