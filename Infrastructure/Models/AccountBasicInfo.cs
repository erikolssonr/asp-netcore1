using System.ComponentModel.DataAnnotations;


namespace Infrastructure.Models;

public class AccountBasicInfo
{
    [Required(ErrorMessage = "You must enter a first name")]
    [Display(Name = "First name", Prompt = "Enter your first name")]
    [MinLength(2, ErrorMessage = "A valid first name is required")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a last name")]
    [Display(Name = "Last name", Prompt = "Enter your last name")]
    [MinLength(2, ErrorMessage = "A valid last name is required")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "You must enter an e-mail address")]
    [Display(Name = "E-mail address", Prompt = "Enter your e-mail address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a valid phone number")]
    [Display(Name = "Phone", Prompt = "Enter your phone number")]
    [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$", ErrorMessage = "Please enter a valid phone number")]
    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Bio (Optional)", Prompt = "Add a short bio...")]
    public string? Biography { get; set; }
}
