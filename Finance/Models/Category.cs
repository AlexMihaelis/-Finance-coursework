using Finance.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Models
{
    public class Category
    {
        public ImageSource Image { get; set; }
        public string Name { get; set; }
        public CategoryType CategoryType { get; set; }
    }
}
