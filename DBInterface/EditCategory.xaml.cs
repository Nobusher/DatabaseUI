using Sh0pDB;
using Sh0pDB.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Category> items;
        private bool IsChanged = true;

        public EditCategory()
        {
            InitializeComponent();
            _DB = new ShopDBContext();
            items = new ObservableCollection<Category>(_DB.categories.ToList());
            items.CollectionChanged += (s, e) => IsChanged = false;
            FillListBox();
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Category_ListBox.Items.Count > 0&&Category_ListBox.SelectedItem!=null)
            {
                InputTextBox.Text = Category_ListBox.SelectedItem.ToString();
            }
        }
        private void FillListBox()
        {
            Category_ListBox.ItemsSource = items;        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _DB.categories.Remove(_DB.categories.First(c=>c.Type == InputTextBox.Text));
            items.Remove((Category)Category_ListBox.SelectedItem);
            InputTextBox.Clear();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(InputTextBox.Text))
            {
                CategoryBuf_ListBox.Items.Add(new Category { Type = InputTextBox.Text });
                InputTextBox.Clear();
            }
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            foreach (var c in CategoryBuf_ListBox.Items)
            {
                _DB.categories.Add((Category)c);
                items.Add((Category)c);
            }
            _DB.SaveChanges();
            IsChanged = true;
            MessageBox.Show("Данные обновлены!");
            CategoryBuf_ListBox.Items.Clear();

        }

        private void Exit_NoSave_Click(object sender, RoutedEventArgs e)
        {
            if (IsChanged == false)
            {
                System.Media.SystemSounds.Exclamation.Play();
                var result = MessageBox.Show("Вы не сохранили изменения.\nВы хотите сохранить их?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    _DB.SaveChanges();
                    this.Close();
                }
                else if (result == MessageBoxResult.No)
                {
                    this.Close();
                }
            }
            this.Close();
        }

        private void CategoryBuf_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
