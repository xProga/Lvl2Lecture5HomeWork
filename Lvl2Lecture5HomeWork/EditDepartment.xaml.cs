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

namespace Lvl2Lecture5HomeWork
{
    /// <summary>
    /// Логика взаимодействия для EditDepartment.xaml
    /// </summary>
    public partial class EditDepartment : Window
    {
        private List<Department> liDep = new List<Department>();
        private MainWindow mw;

        public EditDepartment(List<Department> liDep, MainWindow mw)
        {
            this.liDep = liDep;
            this.mw = mw;
            InitializeComponent();
            liDepart.ItemsSource = liDep;
        }

        private void SaveNewDepartment_Click(object sender, RoutedEventArgs e)
        {
            if (liDep.Where(x => x.NameDepartment.Contains(NewDepartmentTextBox.Text)).Count() == 0)
            {
                liDep.Add(new Department { NameDepartment = NewDepartmentTextBox.Text });
            }
            else
            {
                MessageBox.Show("Такой департамент/служба уже существует", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteSelectedDepart_Click(object sender, RoutedEventArgs e)
        {
            if (liDepart.SelectedItems.Count > 0)
            {
                string selItem = liDepart.SelectedItem.ToString();
                Department dep = liDep.Where(x => x.NameDepartment.Equals(selItem)).FirstOrDefault();
                liDep.Remove(dep);
                liDepart.Items.Remove(selItem);
            }
            else
            {
                MessageBox.Show("Не выделено ни одного элемента!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mw.liDep = liDep;
        }
    }
}
