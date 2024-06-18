using System.ComponentModel.DataAnnotations;

namespace TechnoStore.ViewModels;

public class AdminLoginVm
{
    [Required]
    public string Username { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
}
