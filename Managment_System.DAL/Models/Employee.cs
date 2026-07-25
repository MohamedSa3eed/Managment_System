using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Managment_System.DAL.Models;

public enum Gender
{
    [EnumMember(Value = "Male")]
    Male = 1,
    [EnumMember(Value = "Female")]
    Female = 2
}

public enum EmpType
{
    [EnumMember(Value = "Full Time")]
    FullTime = 1,
    [EnumMember(Value = "Part Time")]
    PartTime = 2
}

public class Employee : ModelBase
{
    public required string Name { get; set; }
    
    public required int Age { get; set; }
    
    [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{4,10}$]",
        ErrorMessage = "Address must be like 123-street-city-country")]
    public required string Address { get; set; }
    
    [DataType(DataType.Currency)]
    public required decimal Salary { get; set; }
    
    [Display(Name = "Is Active")]
    public required bool IsActive { get; set; }
    
    [EmailAddress]
    public required string Email { get; set; }
    
    [Display(Name = "Phone Number")]
    [RegularExpression(@"^\+?[0-9]{10,15}$", 
        ErrorMessage = "Phone number must be between 10 and 15 digits and can start with +")]
    public required string PhoneNumber { get; set; }
    
    [Display(Name = "Hiring Date")]
    public DateTime HiringDate { get; set; }

    public bool IsDeleted { get; set; }
    
    public Gender Gender { get; set; }
    
    public EmpType EmployeeType { get; set; }
}