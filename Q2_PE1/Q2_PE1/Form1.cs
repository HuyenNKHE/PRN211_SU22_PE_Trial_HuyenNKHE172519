using Q2_PE1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q2_PE1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Id.Hide();
            LoadData();
        }

        private void LoadData()
        {
            using (PE_PRN_Sum21Context context = new PE_PRN_Sum21Context())
            {
                var data1 = context.Employees.Select(item => new
                {
                    EmployeeID = item.EmployeeId,
                    EmployeeName = item.EmployeeName,
                    Male = item.Male,
                    Salary = item.Salary,
                    Phone = item.Phone

                }).ToList();
                dtGrid.DataSource = data1;

            }

        }

        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            Id.Text = dtGrid.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            tbName.Text = dtGrid.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            if (dtGrid.Rows[e.RowIndex].Cells[2].FormattedValue.ToString() == "True")
            {
                rdMale.Checked = true;
            }
            else if (dtGrid.Rows[e.RowIndex].Cells[2].FormattedValue.ToString() == "False")
            {
                rdFemale.Checked = true;
            }

            nudSalary.Value = Convert.ToInt32(dtGrid.Rows[e.RowIndex].Cells[3].FormattedValue.ToString());
            tbPhone.Text = dtGrid.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (PE_PRN_Sum21Context context = new PE_PRN_Sum21Context())
            {
                //Tao doi tuong se ínsert
                Employee employee = new Employee();


                employee.EmployeeName = tbName.Text;
                
                if (rdMale.Checked == true)
                {
                    employee.Male = true;
                }
                else if (rdFemale.Checked == true)
                    employee.Male = false;

                employee.Salary = (float)nudSalary.Value;
                employee.Phone= tbPhone.Text;

                context.Employees.Add(employee);
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Insert successfully");
                    LoadData();
                }

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (PE_PRN_Sum21Context context = new PE_PRN_Sum21Context())
            {
                
                Employee employee = context.Employees
                     .SingleOrDefault(item => item.EmployeeId == Convert.ToInt32(Id.Text));
                employee.EmployeeName = tbName.Text;
                if (rdMale.Checked == true)
                {
                    employee.Male = true;
                }
                else if (rdFemale.Checked == true)
                    employee.Male = false;

                employee.Salary = (float)nudSalary.Value;
                employee.Phone = tbPhone.Text;
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Update successfully");
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (PE_PRN_Sum21Context context = new PE_PRN_Sum21Context())
            {
                Employee employee = context.Employees
                     .SingleOrDefault(item => item.EmployeeId == Convert.ToInt32(Id.Text));
                context.Employees.Remove(employee);
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Delete successfully");
                    LoadData();
                }
            }
        }
    }
}
