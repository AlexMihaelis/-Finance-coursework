using Finance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Servises.Interfaces
{
    public interface ICategoryServise
    {
        IEnumerable<Category> GetIncomeCategories();
        IEnumerable<Category> GetExpensesCategories();
    }
}
