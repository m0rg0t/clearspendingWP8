using System;
using System.Linq;
using System.Globalization;
using System.Threading;
using ClearSpendingSDK.Models;
// The production parameter types do not call MVVM APIs. No package behavior is emulated.
namespace GalaSoft.MvvmLight { public class ViewModelBase {} }
class Program
{
    static int assertions;
    static void Equal(string expected, string actual) { assertions++; if (expected != actual) throw new Exception("Expected " + expected + "; got " + actual); }
    static void Main()
    {
        string input = "Тест &page=999#x +/?%= value";
        object[] models = { new SearchParamCustomerItem(), new SearchParamSupplierItem(), new SearchParamContractItem() };
        foreach (object model in models)
        {
            foreach (var property in model.GetType().GetProperties().Where(p => p.PropertyType == typeof(string)))
            {
                property.SetValue(model, input, null);
                string query = model.ToString();
                string pair = query.Substring(1).Split('&').Single(p => p.StartsWith(property.Name.ToLowerInvariant() + "="));
                Equal(property.Name.ToLowerInvariant() + "=" + Uri.EscapeDataString(input), pair);
                Equal(input, Uri.UnescapeDataString(pair.Substring(pair.IndexOf('=') + 1)));
                Equal("1", query.Substring(1).Split('&').Single(p => p.StartsWith("page=")).Substring(5));
                property.SetValue(model, null, null);
            }
        }
        var parameters = new SearchParamItem();
        parameters.Contract.Productsearch = "bolts";
        Equal("?productsearch=bolts&page=1&perpage=10", parameters.ToString());
        parameters.CurrentType = SearchParamItem.SearchType.Customers;
        parameters.Customer.Namesearch = "";
        Equal("?page=1&perpage=0", parameters.ToString());
        parameters.CurrentType = SearchParamItem.SearchType.Suppliers;
        Equal("?page=1&perpage=50", parameters.ToString());
        Console.WriteLine("PASS " + assertions + " query encoding and routing assertions; no HTTP or credentials");
    }
}
