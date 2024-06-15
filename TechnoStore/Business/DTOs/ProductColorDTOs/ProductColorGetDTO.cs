using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.ProductColorDTOs;

public class ProductColorGetDTO
{
    public int Id { get; set; }
    public string HexCode { get; set; }
    public string Name { get; set; }
    
}
