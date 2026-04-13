using Sh0pDB;
using Sh0pDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DBInterface
{
    /// <summary>
    /// Логика взаимодействия для EditCategory.xaml
    /// </summary>
    public partial class EditCategory : Window
    {
        private ShopDBContext _DB;

        public EditCategory()
        {
            InitializeComponent();
            _DB = new ShopDBContext();
            FillListBox();
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Category_ListBox.Items.Count > 0)
            {
                InputTextBox.Text = Category_ListBox.SelectedItem.ToString();
            }
        }
        private void FillListBox()
        {
            Category_ListBox.ItemsSource = _DB.categories.ToList();        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _DB.categories.Remove(_DB.categories.First(c=>c.Type == InputTextBox.Text));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _DB.categories.Add(new Category { Type = InputTextBox.Text });
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _DB.SaveChanges();
            MessageBox.Show("Данные обновлены!");
            FillListBox();
        }
    }
}
