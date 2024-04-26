using System.ComponentModel.DataAnnotations;

namespace DrinkShopWebApp2.Models
{
    public class Customer
    {
        // Fields/attributes
        /*private int _customerId;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;*/
        // ?? consider adding date object
        // to hold date when customer first
        // created to use as 'joined'/'customer since xxxx' data.

        // ?? create an attribute to hold all customers objects - in a sorted order? Or which
        // can then be sorted/searched??
        //?? create another attribute/property to hold all Customer objects in database in sorted
        // order - sorted by lastname - then use this for binary search or other search method
        // private Dictionary<CustomerId, Customer> _sortedCustomers;
        // private List<Customer> _sortedCustomersList;

        // Constructor(s)
        // Default constructor
        public Customer()
        {
            //CustomerId = customerId;
            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
        }

        // Parameterized Constructor(s)
        public Customer(string firstName, string lastName)
        {
            //CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = "";
            Phone = "";
        }

        public Customer(string firstName, string lastName, string phone)
        {
            //CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = "";
            Phone = phone;
        }

        /*public Customer(string firstName, string lastName, string email)
        {
            //CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = "";
        }*/

        public Customer(string firstName, string lastName, string email, string phone)
        {
            //CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        // Properties
        // If using Entity Framework do not need to specify [Key] as 
        // the EF assigns Properties named w/ 'ClassnameId' syntax as the
        // Class's Primary Key automatically. 
        //[Key]
        //public int CustomerId { get => _customerId; set => _customerId = value; }
        public int CustomerId { get; set; }

        // Had to remove most data annotations from Customer class as the
        // Razor pages refused to build 'd/t multiple annotations of the same type' per message. 
        // Data Annotations - for data validation rules ?? place on 
        // attributes/fields or properties better practice??
        //[Required(ErrorMessage = "First name required")]
        [StringLength(50, ErrorMessage = "Invalid First Name: name cannot be longer than 50 characters.")]
        // Can use a RegularExpression to add validation to make sure characters are only in alphabet
        // no spaces/numbers or special characters.
        // Below version ensures frist letter is capitalized and rest are letters of the alphabet.
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        // ?? version if just want alphabetic letters but capitalization doesn't matter??
        //[RegularExpression(@"^[a-zA-Z""'\s-]*$")]
        //public string FirstName { get => _firstName; set => _firstName = value; } = null!;
        public string FirstName { get; set; } = null!;
        // ?? version if just want alphabetic letters but capitalization doesn't matter??
        //[RegularExpression(@"^[a-zA-Z""'\s-]*$")]
        //[Required(ErrorMessage = "Last name required")]
        [StringLength(50, ErrorMessage = "Invalid First Name: name cannot be longer than 50 characters.")]
        //public string LastName { get => _lastName; set => _lastName = value; }
        public string LastName { get; set; } = null!;
        //[DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email address is invalid")]
        //[RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$")]
        //public string? Email { get => _email; set => _email = value; }
        public string? Email { get; set; }
        //[DataType(DataType.PhoneNumber)]
        // ??[RegularExpression(@"^\d{3}-\d{3}-\d{4}$")] string phone)
        //[RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        [Phone(ErrorMessage = "Phone number is invalid")]
        //public string? Phone { get => _phone; set => _phone = value; }
        public string? Phone { get; set; }

        //?? create another attribute/property to hold all Customer objects in database in sorted
        // order - sorted by lastname - then use this for binary search or other search method
        // public Dictionary<CustomerId, Customer> SortedCustomers {get; set;}
        //public List<Customer> SortedCustomersList {get; set;}

        // Collection of Order objects – navigation property – can have 0 or > orders – creates the
        // one to many relationship in the DB to be generated. 
        public ICollection<Order> Orders { get; set; } = null!;


        // Methods
        // Write methods to sort/search SortedCustomers (dict) vs SortedCustomersList (List)

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
            return $"Customer Id: {CustomerId}; Customer Name: {FirstName} {LastName}; Email: {Email}; Phone: {Phone}";
        }
    }
}
