using Business.DTOs.ProductDTOs;
using Core.Models;

namespace TechnoStore.ViewModels;

public class CheckOutVm
{
	public ProductGetDTO Product { get; set; }

	public int Count { get; set; }
}
