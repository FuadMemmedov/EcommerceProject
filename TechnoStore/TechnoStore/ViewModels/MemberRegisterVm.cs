using System.ComponentModel.DataAnnotations;

namespace TechnoStore.ViewModels;

public class MemberRegisterVm
{
	[Required]
	public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string Password { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}
