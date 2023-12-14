using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Models
{
    public class Operation
    {
        public Operation()
        {
            
        }
        public Operation(Category category, decimal cost, DateTime date)
        {
            Category = category;
            Cost = cost;
            Date = date;
        }

        public Category Category { get; set; }
        public decimal Cost { get; set; }
        public DateTime? Date { get; set; }
    }
}
