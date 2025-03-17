using Avalonia.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Linq;
using Wow.Models;

namespace Wow;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        SetData();
    }

    private void SetData()
    {
        /*var setList = DataSource.Helper.dataBase.Products.Include(x => x.ProductSales.Select(x => x.Countofproduct)).ToList();
        var selectList = DataSource.Helper.dataBase.ProductSales;
        var a = selectList.Select(x => x.Countofproduct);
        lb.ItemsSource = setList;

        if (Convert.ToInt32(a) >= 100)
        {

        }*/

        lb.ItemsSource = DataSource.Helper.dataBase.ProductSales.Include(x => x.ProductNavigation);
    }
}