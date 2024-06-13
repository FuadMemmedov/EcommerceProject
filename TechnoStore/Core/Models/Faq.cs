using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;

public class Faq:BaseEntity
{
    public string Question { get; set; }
    public string Answer { get; set; }
}
