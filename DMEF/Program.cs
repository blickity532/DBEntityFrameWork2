using System.ComponentModel.DataAnnotations;

namespace DMEF
{
    public class Program
    {
        // Entry point of the application
    }
}

public class Customer
{
    public Customer(int customerId, string firstName, string middleName, string lastName, DateTime birthDate, Address address, string email)
    {
        CustomerId = customerId;
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        BirthDate = birthDate;
        Address = address;
        Email = email;
    }

    [Key]
    public int CustomerId
    {
        get; set;
    }

    [Required]
    [MaxLength(50)]
    public string FirstName
    {
        get; set;
    }

    [MaxLength(50)]
    public string MiddleName
    {
        get; set;
    }

    [Required]
    [MaxLength(50)]
    public string LastName
    {
        get; set;
    }

    [Required]
    public DateTime BirthDate
    {
        get; set;
    }

    public ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();

    public int? AddressId
    {
        get; set;
    }

    [Required]
    public Address Address
    {
        get; set;
    }

    [EmailAddress]
    [Required]
    public string Email
    {
        get; set;
    }

    public ICollection<Like> Likes { get; set; } = new List<Like>();
}

public class Like
{
    [Key]
    public int LikeId
    {
        get; set;
    }

    [Required]
    public required string Description
    {
        get; set;
    }
}

public class Address
{
    public Address(int addressId, string street, string city, string state, string zipCode)
    {
        AddressId = addressId;
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    [Key]
    public int AddressId
    {
        get; set;
    }

    [Required]
    [MaxLength(100)]
    public string Street
    {
        get; set;
    }

    [Required]
    [MaxLength(50)]
    public string City
    {
        get; set;
    }

    [Required]
    [MaxLength(50)]
    public string State
    {
        get; set;
    }

    [Required]
    [MaxLength(10)]
    public string ZipCode
    {
        get; set;
    }
}

#pragma warning disable CA1050 // Declare types in namespaces
public class PhoneNumber(int phoneNumberId, string number, int customerId, Customer? customer)
#pragma warning restore CA1050 // Declare types in namespaces
{
    [Key]
    public int PhoneNumberId
    {
        get; set;
    } = phoneNumberId;

    [Required]
    [Phone]
    public string Number
    {
        get; set;
    } = number;

    [Required]
    public int CustomerId
    {
        get; set;
    } = customerId;

    public Customer? Customer
    {
        get; set;
    } = customer;
}
