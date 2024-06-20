using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;

public class Comment:BaseEntity
{
    public string? FullName { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    [Required] 
    public string Content { get; set; }
    public int BlogId { get; set; }       
    public Blog Blog { get; set; }
    public AppUser User { get; set; }
}
