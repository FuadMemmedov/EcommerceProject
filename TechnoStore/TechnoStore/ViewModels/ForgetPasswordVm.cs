using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace TechnoStore.ViewModels;

public class ForgetPasswordVm
{
    public AppUser? appUser { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}
