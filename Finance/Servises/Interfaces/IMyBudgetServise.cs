using Finance.Models;
using Finance.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Servises
{
    public interface IMyBudgetServise
    {
        IEnumerable<Operation> GetAllOperations();
        IEnumerable<Operation> GetIncomeOperations();
        IEnumerable<Operation> GetExpenseOperations();
        void CreateOperation(Operation operation);
        void RemoveOperation(Operation operation);
    }
}
