using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.TeamDTOs;

public class TeamGetDTO
{
	public int Id { get; set; }
	public string FullName { get; set; }
	public string Designation { get; set; }
	public string ImageUrl { get; set; }
}
