using Infrastructure.Attributes;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class SignUpViewModel
{
    [Display(Name = "First name", Prompt = "Enter your first name")]
    [Required(ErrorMessage = "You must enter your first name")]
    [MinLength(2, ErrorMessage = "A valid first name is required")]
    public string FirstName { get; set; } = null!;


    [Display(Name = "Last name", Prompt = "Enter your last name")]
    [Required(ErrorMessage = "You must enter your last name")]
    [MinLength(2, ErrorMessage = "A valid last name is required")]
    public string LastName { get; set; } = null!;


    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "You must enter your email address")]
    [Display(Name = "Email adress", Prompt = "Enter your email address")]
    [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*\.[a-zA-Z]{2,}$", ErrorMessage = "A valid email address is required")]
    public string Email { get; set; } = null!;


    [DataType(DataType.Password)]
    [Required(ErrorMessage = "You must enter a password")]
    [Display(Name = "Password", Prompt = "********")]
    [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password must be min 8 char, one uppercase, lowercase, special char and digit.")]
    public string Password { get; set; } = null!;


    [DataType(DataType.Password)]
    [Required(ErrorMessage = "You must enter your password again")]
    [Display(Name = "Confirm password", Prompt = "********")]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = null!;


    [Display(Name = "I agree to the Terms & Conditions.")]
    [CheckboxRequired(ErrorMessage = "You must accept the Terms & Conditions")]
    public bool TermsAndConditions { get; set; }
}

