using Finance.Models;
using Finance.Models.Enums;
using Finance.Servises.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Servises.Implementations
{
    public class CategoryServise : ICategoryServise
    {
        private readonly IEnumerable<Category> _categories;
        public CategoryServise()
        {
            _categories = new List<Category>
            {
                new Category{ Name = "Образование", Image = ImageSource.FromFile("graduationcap.png"), CategoryType = Models.Enums.CategoryType.Expense },
                new Category{ Name = "Транспорт", Image = ImageSource.FromFile("bus.png"), CategoryType = Models.Enums.CategoryType.Expense },
                new Category{ Name = "Красота и здоровье", Image = ImageSource.FromFile("pharmacy.png"), CategoryType = Models.Enums.CategoryType.Expense },
                new Category{ Name = "Продукты", Image = ImageSource.FromFile("shoppingbasket.png"), CategoryType = Models.Enums.CategoryType.Expense },
                new Category{ Name = "кафе и рестораны", Image = ImageSource.FromFile("utensils.png"), CategoryType = Models.Enums.CategoryType.Expense },
                new Category{ Name = "Подарки", Image = ImageSource.FromFile("gift.png"), CategoryType = Models.Enums.CategoryType.Expense },
                new Category{ Name = "Подарки", Image = ImageSource.FromFile("gift.png"), CategoryType = Models.Enums.CategoryType.Income },
                new Category{ Name = "Дом", Image = ImageSource.FromFile("housechimney.png"), CategoryType = Models.Enums.CategoryType.Expense },
                new Category{ Name = "Семья", Image = ImageSource.FromFile("family.png"), CategoryType = Models.Enums.CategoryType.Expense },
                new Category{ Name = "Спорт", Image = ImageSource.FromFile("gym.png"), CategoryType = Models.Enums.CategoryType.Expense },
                new Category{ Name = "Досуг", Image = ImageSource.FromFile("heart.png"), CategoryType = Models.Enums.CategoryType.Expense },
                new Category{ Name = "Отдых", Image = ImageSource.FromFile("planealt.png"), CategoryType = Models.Enums.CategoryType.Expense },
                new Category{ Name = "Другое", Image = ImageSource.FromFile("question.png"), CategoryType = Models.Enums.CategoryType.Expense },
                new Category{ Name = "Другое", Image = ImageSource.FromFile("question.png"), CategoryType = Models.Enums.CategoryType.Income },
                new Category{ Name = "Зарплата", Image = ImageSource.FromFile("wallet.png"), CategoryType = Models.Enums.CategoryType.Income },
                new Category{ Name = "Перевод", Image = ImageSource.FromFile("commentsdollar.png"), CategoryType = Models.Enums.CategoryType.Income },
                new Category{ Name = "Возврат", Image = ImageSource.FromFile("moneybillwave.png"), CategoryType = Models.Enums.CategoryType.Income },
                new Category{ Name = "Проценты", Image = ImageSource.FromFile("bank.png"), CategoryType = Models.Enums.CategoryType.Income }
            };
        }

        public IEnumerable<Category> GetExpensesCategories()
        {
            return _categories.Where(x => x.CategoryType == Models.Enums.CategoryType.Expense);

        }

        public IEnumerable<Category> GetIncomeCategories()
        {
            return _categories.Where(x => x.CategoryType == Models.Enums.CategoryType.Income);
        }
    }
}
