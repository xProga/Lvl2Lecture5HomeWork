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
    /// Логика взаимодействия для EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        private List<Employees> liEmp = new List<Employees>();
        private List<Department> liDep = new List<Department>();
        private MainWindow mw;

        public EditEmployee(List<Employees> liEmp, List<Department> liDep, MainWindow mw)
        {
            this.liEmp = liEmp;
            this.liDep = liDep;
            this.mw = mw;
            InitializeComponent();
            foreach (var item in liDep)
            {
                DepartmentComboBox.Items.Add(item.NameDepartment);
            }
            listEmployees.ItemsSource = liEmp;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FirstNameTextBox.Text != string.Empty && LastNameTextBox.Text != string.Empty)
            {
                if (liEmp.Where(x => x.FirstName.Equals(FirstNameTextBox.Text) && x.LastName.Equals(LastNameTextBox.Text)).Count() > 0)
                {
                    liEmp.Where(x => x.FirstName.Equals(FirstNameTextBox.Text) && x.LastName.Equals(LastNameTextBox.Text))
                        .FirstOrDefault().Department.NameDepartment = DepartmentComboBox.SelectedItem.ToString();
                }
                else
                {
                    liEmp.Add(new Employees(FirstNameTextBox.Text, LastNameTextBox.Text, new Department { NameDepartment = DepartmentComboBox.SelectedItem.ToString() }));
                }
            }
            else
            {
                MessageBox.Show("Одно или несколько полей не заполнены!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void listEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string[] emp = (Employees)listEmployees.Items.CurrentItem;
            //string firstName = emp[0];
            //string lastName = emp[1];
            //Employees employee = liEmp.Where(x => x.FirstName.Equals(firstName) && x.LastName.Equals(lastName)).FirstOrDefault();
            //Employees employee = (Employees)listEmployees.Items.;

            //int currPos = listEmployees.Items.CurrentPosition;
            Employees employee = (Employees)listEmployees.SelectedItem;

            FirstNameTextBox.Text = employee.FirstName;
            LastNameTextBox.Text = employee.LastName;
            DepartmentComboBox.SelectedItem = liDep.Where(x => x.NameDepartment.Contains(employee.Department.NameDepartment))
                .Select(x => x.NameDepartment).FirstOrDefault();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mw.liEmp = liEmp;
        }
    }
}
