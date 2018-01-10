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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Lvl2Lecture5HomeWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public class Department
    {
        public string NameDepartment { get; set; }
    }

    public class Employees
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Department Department { get; set; }

        public Employees(string firstName, string lastName, Department department)
        {
            FirstName = firstName;
            LastName = lastName;
            Department = department;
        }
    }
    
    public partial class MainWindow : Window
    {
        public List<Employees> liEmp = new List<Employees>();
        public List<Department> liDep = new List<Department>();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<Department> liDep = new List<Department> {
                new Department{ NameDepartment = "Служба снабжения"},
                new Department{ NameDepartment = "Служба ремонта"},
                new Department{ NameDepartment = "Отдел кадров"}
            };
            this.liDep = liDep;

            Department dp = new Department() { NameDepartment = "Отдел кадров" };
            List<Employees> liEmp = new List<Employees>
            {
                new Employees("Алексей", "Алексеев", dp),
                new Employees("Ольга", "Олеговна", dp),
                new Employees("Василий", "Васильевич", dp)
            };
            this.liEmp = liEmp;

            lbEmployees.ItemsSource = liEmp;
            lbDepartment.ItemsSource = liEmp;

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddRemoveDep_Click(object sender, RoutedEventArgs e)
        {
            EditDepartment ed = new EditDepartment(liDep, this);
            ed.ShowDialog();
        }

        private void EditEmployees_Click(object sender, RoutedEventArgs e)
        {
            EditEmployee ee = new EditEmployee(liEmp, liDep, this);
            ee.ShowDialog();
        }

        private void lbEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbEmployees.SelectedIndex != lbDepartment.SelectedIndex)
            {
                lbDepartment.SelectedIndex = lbEmployees.SelectedIndex;
            }
        }

        private void lbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbDepartment.SelectedIndex != lbEmployees.SelectedIndex)
            {
                lbEmployees.SelectedIndex = lbDepartment.SelectedIndex;
            }
        }
    }
}
