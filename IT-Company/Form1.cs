using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT_Company
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
            
            
        }

      

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {
            
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            ComboBoxMethod();
            DataGridViewMethod();



        }

        public void ComboBoxMethod()
        {
            var db = new IT_CompanyEntities();
            //ComboBox in Add - Page
            comboBoxAdd.DataSource = db.Department.ToList();
            comboBoxAdd.ValueMember = "DepartmentID";
            comboBoxAdd.DisplayMember = "Department1";

            //ComboBox in Update- page
            comboBoxUpdate.DataSource = db.Department.ToList();
            comboBoxUpdate.ValueMember = "DepartmentID";
            comboBoxUpdate.DisplayMember = "Department1";
        }

        public void ClearTextBoxAddMetod()
        {
            
            textBoxAddFirstName.Text = "";
            textBoxAddLastName.Text = "";
            textBoxAddAdress.Text = "";
            textBoxAddPostalCode.Text = "";
            textBoxAddCity.Text = "";
            textBoxAddCountry.Text = "";
            textBoxAddEmail.Text = "";
            textBoxAddPhone.Text = "";

        }

        public void DataGridViewMethod()
        {
            using (var db = new IT_CompanyEntities())
            {
                var query = from emp in db.Employees
                            join dep in db.Department
                            on emp.DepartmentID equals dep.DepartmentID
                            orderby emp.First_Name
                            select new
                            {
                                emp.EmployeeID,
                                emp.First_Name,
                                emp.Last_Name,
                                emp.Address,
                                emp.Postal_Code,
                                emp.CIty,
                                emp.Country,
                                emp.Email,
                                emp.Phone,
                                dep.Department1
                            };

                dataGridView1.DataSource = query.ToList();

            }
        }

       public void ClearTextBoxUpdateMethod()
        {
            textBoxEditEmployeeID.Text = "";
            textBoxEditFirstName.Text = "";
            textBoxEditLastName.Text = "";
            textBoxEditAddress.Text = "";
            textBoxEditPostalCode.Text = "";
            textBoxEditCity.Text = "";
            textBoxEditCountry.Text = "";
            textBoxEditEmail.Text = "";
            textBoxEditPhone.Text = "";

        }



        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int depID = int.Parse(comboBoxAdd.SelectedValue.ToString());

                using(var db = new IT_CompanyEntities())
                {
                    var _employee = new Employees();
                    _employee.First_Name = textBoxAddFirstName.Text;
                    _employee.Last_Name = textBoxAddLastName.Text;
                    _employee.Address = textBoxAddAdress.Text;
                    _employee.Postal_Code = textBoxAddPostalCode.Text;
                    _employee.CIty = textBoxAddCity.Text;
                    _employee.Country = textBoxAddCountry.Text;
                    _employee.Email = textBoxAddEmail.Text;
                    _employee.Phone = textBoxAddPhone.Text;
                    _employee.DepartmentID = depID;

                    db.Employees.Add(_employee);
                    db.SaveChanges();
                    MessageBox.Show($"{_employee.First_Name} {_employee.Last_Name} has been added");
                    ClearTextBoxAddMetod();
                    comboBoxAdd.ResetText();
                    ComboBoxMethod();
                    DataGridViewMethod();
                }
            }

            catch(Exception )
            {
                MessageBox.Show("You have to select all textboxes");
                
            }

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                int empID = int.Parse(textBoxEditEmployeeID.Text);
                int depID = int.Parse(comboBoxUpdate.SelectedValue.ToString());
                using (var db = new IT_CompanyEntities())
                {

                    var query = from emp in db.Employees
                                join dep in db.Department
                                on emp.DepartmentID equals dep.DepartmentID
                                where emp.EmployeeID == empID
                                select emp;

                    var items = query.Where(x => x.DepartmentID == x.Department.DepartmentID)
                      .FirstOrDefault();

                    items.EmployeeID = empID;
                    items.First_Name = textBoxEditFirstName.Text;
                    items.Last_Name = textBoxEditLastName.Text;
                    items.Address = textBoxEditAddress.Text;
                    items.Postal_Code = textBoxEditPostalCode.Text;
                    items.CIty = textBoxEditCity.Text;
                    items.Country = textBoxEditCountry.Text;
                    items.Email = textBoxEditEmail.Text;
                    items.Phone = textBoxEditPhone.Text;
                    items.DepartmentID = depID;

                    db.SaveChanges();
                    MessageBox.Show($"{items.First_Name} {items.Last_Name} has been updated");
                    ClearTextBoxUpdateMethod();
                    comboBoxUpdate.ResetText();
                    ComboBoxMethod();
                    DataGridViewMethod();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You have to select all textboxes");
            }
        }

      

        private void ButtonSearch_Click(object sender, EventArgs e)
        {



            
            
        }




        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

           


            
           
        }

        private void ButtonSearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                int empIDSearch = int.Parse(textBoxEditEmployeeID.Text);

                using (var db = new IT_CompanyEntities())
                {

                    var quary = from emp in db.Employees
                                join dep in db.Department
                                on emp.DepartmentID equals dep.DepartmentID
                                where emp.EmployeeID == empIDSearch
                                select emp;

                    var items = quary.Where(x => x.DepartmentID == x.Department.DepartmentID)
                        .FirstOrDefault();

                    empIDSearch = items.EmployeeID;
                    textBoxEditFirstName.Text = items.First_Name;
                    textBoxEditLastName.Text = items.Last_Name;
                    textBoxEditAddress.Text = items.Address;
                    textBoxEditPostalCode.Text = items.Postal_Code;
                    textBoxEditCity.Text = items.CIty;
                    textBoxEditCountry.Text = items.Country;
                    textBoxEditEmail.Text = items.Email;
                    textBoxEditPhone.Text = items.Phone;
                    comboBoxUpdate.SelectedValue = items.Department.DepartmentID;

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect ID");
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int _employeeID = int.Parse(textBoxDeleteEmployee.Text);

                using(var db = new IT_CompanyEntities())
                {
                    var quary = from emp in db.Employees
                                join dep in db.Department
                                on emp.DepartmentID equals dep.DepartmentID
                                where emp.EmployeeID == _employeeID
                                select emp;

                    var items = quary.Where(x => x.DepartmentID == x.Department.DepartmentID)
                        .FirstOrDefault();

                    DialogResult dialogResult = MessageBox.Show("Are you sure do you want to delete "
                   + items.First_Name + " " + items.Last_Name, "Delete Message", MessageBoxButtons.YesNo);
                        

                    if(dialogResult == DialogResult.Yes)
                    {
                        db.Employees.Remove(items);
                        db.SaveChanges();
                        textBoxDeleteEmployee.Text = "";
                        MessageBox.Show($"{items.First_Name} {items.Last_Name} has been deleted");
                    }

                    else if(dialogResult == DialogResult.No)
                    {
                        
                        textBoxDeleteEmployee.Text = "";
                    }


                }

                DataGridViewMethod();


            }

            catch(Exception )
            {
                MessageBox.Show("Incorrect ID");
            }
        }

        private void ButtonSharePoint_CheckedChanged(object sender, EventArgs e)
        {
            using (var db = new IT_CompanyEntities())
            {
                var query = from emp in db.Employees
                            join dep in db.Department
                            on emp.DepartmentID equals dep.DepartmentID
                            where dep.Department1 == "SharePoint"
                            select new {
                                emp.EmployeeID,
                                emp.First_Name,
                                emp.Last_Name,
                                emp.Address,
                                emp.Postal_Code,
                                emp.CIty,
                                emp.Country,
                                emp.Email,
                                emp.Phone,
                                dep.Department1
                            };

                dataGridView1.DataSource = query.ToList();
                
            }
        }

        private void ButtonNET_CheckedChanged(object sender, EventArgs e)
        {

            using (var db = new IT_CompanyEntities())
            {
                var query = from emp in db.Employees
                            join dep in db.Department
                            on emp.DepartmentID equals dep.DepartmentID
                            where dep.Department1 == ".NET"
                            select new
                            {
                                emp.EmployeeID,
                                emp.First_Name,
                                emp.Last_Name,
                                emp.Address,
                                emp.Postal_Code,
                                emp.CIty,
                                emp.Country,
                                emp.Email,
                                emp.Phone,
                                dep.Department1
                            };

                dataGridView1.DataSource = query.ToList();
                
            }
        }

        private void ButtonJava_CheckedChanged(object sender, EventArgs e)
        {
            using (var db = new IT_CompanyEntities())
            {
                var query = from emp in db.Employees
                            join dep in db.Department
                            on emp.DepartmentID equals dep.DepartmentID
                            where dep.Department1 == "Java"
                            select new
                            {
                                emp.EmployeeID,
                                emp.First_Name,
                                emp.Last_Name,
                                emp.Address,
                                emp.Postal_Code,
                                emp.CIty,
                                emp.Country,
                                emp.Email,
                                emp.Phone,
                                dep.Department1
                            };

                dataGridView1.DataSource = query.ToList();

            }
        }

        private void ButtonFrontend_CheckedChanged(object sender, EventArgs e)
        {
            using (var db = new IT_CompanyEntities())
            {
                var query = from emp in db.Employees
                            join dep in db.Department
                            on emp.DepartmentID equals dep.DepartmentID
                            where dep.Department1 == "Frontend"
                            select new
                            {
                                emp.EmployeeID,
                                emp.First_Name,
                                emp.Last_Name,
                                emp.Address,
                                emp.Postal_Code,
                                emp.CIty,
                                emp.Country,
                                emp.Email,
                                emp.Phone,
                                dep.Department1
                            };

                dataGridView1.DataSource = query.ToList();

            }
        }

        private void ButtonSQL_CheckedChanged(object sender, EventArgs e)
        {
            using (var db = new IT_CompanyEntities())
            {
                var query = from emp in db.Employees
                            join dep in db.Department
                            on emp.DepartmentID equals dep.DepartmentID
                            where dep.Department1 == "SQL"
                            select new
                            {
                                emp.EmployeeID,
                                emp.First_Name,
                                emp.Last_Name,
                                emp.Address,
                                emp.Postal_Code,
                                emp.CIty,
                                emp.Country,
                                emp.Email,
                                emp.Phone,
                                dep.Department1
                            };

                dataGridView1.DataSource = query.ToList();

            }
        }

        private void ButtonSupport_CheckedChanged(object sender, EventArgs e)
        {
            using (var db = new IT_CompanyEntities())
            {
                var query = from emp in db.Employees
                            join dep in db.Department
                            on emp.DepartmentID equals dep.DepartmentID
                            where dep.Department1 == "Support"
                            select new
                            {
                                emp.EmployeeID,
                                emp.First_Name,
                                emp.Last_Name,
                                emp.Address,
                                emp.Postal_Code,
                                emp.CIty,
                                emp.Country,
                                emp.Email,
                                emp.Phone,
                                dep.Department1
                            };

                dataGridView1.DataSource = query.ToList();

            }
        }

        private void ButtonHR_CheckedChanged(object sender, EventArgs e)
        {
            using (var db = new IT_CompanyEntities())
            {
                var query = from emp in db.Employees
                            join dep in db.Department
                            on emp.DepartmentID equals dep.DepartmentID
                            where dep.Department1 == "HR"
                            select new
                            {
                                emp.EmployeeID,
                                emp.First_Name,
                                emp.Last_Name,
                                emp.Address,
                                emp.Postal_Code,
                                emp.CIty,
                                emp.Country,
                                emp.Email,
                                emp.Phone,
                                dep.Department1
                            };

                dataGridView1.DataSource = query.ToList();

            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            using (var db = new IT_CompanyEntities())
            {
                var query = from emp in db.Employees
                            join dep in db.Department
                            on emp.DepartmentID equals dep.DepartmentID
                            orderby emp.First_Name
                             select new
                            {
                                emp.EmployeeID,
                                emp.First_Name,
                                emp.Last_Name,
                                emp.Address,
                                emp.Postal_Code,
                                emp.CIty,
                                emp.Country,
                                emp.Email,
                                emp.Phone,
                                dep.Department1
                            };
                           

                dataGridView1.DataSource = query.ToList();

            }
        }
    }
    }

