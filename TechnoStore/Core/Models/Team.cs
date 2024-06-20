using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;

public class Team:BaseEntity
{
	public string FullName { get; set; }
	public string Designation { get; set; }
	public string ImageUrl { get; set; }



}
