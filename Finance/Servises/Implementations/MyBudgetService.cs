using Finance.Models;
using Finance.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Servises.Implementations
{
    public class MyBudgetService : IMyBudgetServise
    {
        private readonly List<Operation> _operations;
        public MyBudgetService()
        {
            _operations = new List<Operation>();
        }
        public void CreateOperation(Operation operation)
        {
            _operations.Add(operation);
        }

        public IEnumerable<Operation> GetAllOperations()
        {
            return _operations;
        }

        public IEnumerable<Operation> GetExpenseOperations()
        {
            return _operations.Where(x => x.Category.CategoryType == CategoryType.Expense);
        }

        public IEnumerable<Operation> GetIncomeOperations()
        {
            return _operations.Where(x => x.Category.CategoryType == CategoryType.Income);
        }

        public void RemoveOperation(Operation operation)
        {
            var item = _operations.FirstOrDefault(x => x.Date == operation.Date 
            && x.Cost == operation.Cost 
            && x.Category.CategoryType == operation.Category.CategoryType);

            if (item != null)
                _operations.Remove(item);
        }
    }
}
