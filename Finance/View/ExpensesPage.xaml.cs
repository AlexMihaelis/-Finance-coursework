using Finance.Models;
using Finance.Servises;
using Finance.Servises.Interfaces;

namespace Finance.View;

public partial class ExpensesPage : ContentPage
{
    private readonly IMyBudgetServise _myBudgetServise;
    private readonly IEnumerable<Category> _categories;

    public ExpensesPage(ICategoryServise categoryServise, IMyBudgetServise myBudgetServise)
	{
		InitializeComponent();
        _myBudgetServise = myBudgetServise;

        _categories = categoryServise.GetExpensesCategories();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        GetOperations();
        CalculateSum();
    }

    private void CalculateSum(Func<Operation, bool> condition = null)
    {
        var operations = _myBudgetServise.GetExpenseOperations();

        if (condition != null)
        {
            operations = operations.Where(condition);
        }

        SumLabel.Text = operations.Sum(x => x.Cost).ToString("N2");
    }

    private void GetOperations(Func<Operation, bool> condition = null)
    {
        var operations = _myBudgetServise.GetExpenseOperations();

        if (condition != null)
        {
            operations = operations.Where(condition);
        }

        OperationListView.ItemsSource = operations.ToList();
    }

    private void ChangePeriod(object sender, EventArgs e)
    {
        var btn = (Button)sender;

        switch (btn.Text)
        {
            case "День":
                CalculateSum(x => x.Date > DateTime.Now.AddDays(-1));
                GetOperations(x => x.Date > DateTime.Now.AddDays(-1));
                break;
            case "Неделя":
                CalculateSum(x => x.Date > DateTime.Now.AddDays(-7));
                GetOperations(x => x.Date > DateTime.Now.AddDays(-7));
                break;
            case "Месяц":
                CalculateSum(x => x.Date > DateTime.Now.AddMonths(-1));
                GetOperations(x => x.Date > DateTime.Now.AddMonths(-1));
                break;
            case "Год":
                CalculateSum(x => x.Date > DateTime.Now.AddYears(-1));
                GetOperations(x => x.Date > DateTime.Now.AddYears(-1));
                break;
            default:
                break;
        }
    }

    private void AddExpense(object sender, EventArgs e)
    {
        ValidateLabel.IsVisible = false;
        if (!InvalidateOperation())
        {
            ValidateLabel.IsVisible = true;
            return;
        }

        var newOperation = new Operation((Category)CategoryListView.SelectedItem, decimal.Parse(AddExpensesEntry.Text), AddExpensesDatePicker.Date);
        _myBudgetServise.CreateOperation(newOperation);
        GoMain();
    }

    private bool InvalidateOperation()
    {
        bool isValid = true;
        if (string.IsNullOrWhiteSpace(AddExpensesEntry.Text) || !decimal.TryParse(AddExpensesEntry.Text, out var cost))
        {
            isValid = false;
        }
        else if (CategoryListView.SelectedItem == null)
        {
            isValid = false;
        }
        else if (AddExpensesDatePicker.Date == default)
        {
            isValid = false;
        }

        return isValid;
    }

    private void GoMain()
    {
        ExpensesGrid.IsVisible = true;
        AddExpensesGrid.IsVisible = false;
        GoMainGrid.IsVisible = false;
        GoAddExpenseGrid.IsVisible = true;
        OnAppearing();
    }

    private void GoAddExpense()
    {
        ExpensesGrid.IsVisible = false;
        AddExpensesGrid.IsVisible = true;
        GoAddExpenseGrid.IsVisible = false;
        GoMainGrid.IsVisible = true;
        CategoryListView.ItemsSource = _categories.ToList();
    }

    private void RemoveOperation(object sender, SwipedEventArgs e)
    {
        
    }

    private void GoAddExpense(object sender, EventArgs e)
    {
        GoAddExpense();
    }

    private void GoMainExpense(object sender, EventArgs e)
    {
        GoMain();
    }
}