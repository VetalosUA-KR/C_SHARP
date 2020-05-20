using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseWorkers
{
    public partial class Form1 : Form
    {
        DataBaseWorkersDataContext DatabaseDC = new DataBaseWorkersDataContext();
        public Form1()
        {
            InitializeComponent();
            LoadWorkersFrom();

            //listBoxWorkers.DisplayMember = "FirstName";
        }

        private void LoadWorkersFrom()
        {
            listBoxWorkers.Items.Clear();
           foreach(Worker w in  DatabaseDC.Workers)
            {
                listBoxWorkers.Items.Add(w);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (IsWorkerFormValid())
            {
                Worker workerToSave;
                //edycja
                if (listBoxWorkers.SelectedItems.Count == 1)
                {
                    listBoxWorkers.Enabled = true;
                    buttonDelete.Visible = false;
                    buttonSave.Text = "Dodaj";

                    workerToSave = listBoxWorkers.SelectedItem as Worker;
                }
                //dodawanie
                else
                {
                    workerToSave = new Worker();
                    DatabaseDC.Workers.InsertOnSubmit(workerToSave);
                }

                workerToSave.LastName = textBoxLastName.Text;
                workerToSave.FirstName = textBoxFirstName.Text;
                workerToSave.DateBegin = dateTimePickerDateBegin.Value;
                workerToSave.Salary = numericUpDownSalary.Value;
                workerToSave.Manager = checkBoxManager.Checked;

                DatabaseDC.SubmitChanges();
                ClearForm();

                LoadWorkersFrom();
            }
            else
            {
                MessageBox.Show("Formularz wipelniony niepoprawnie");
            }
        }

        private bool IsWorkerFormValid()
        {
            if(textBoxFirstName.Text.Length == 0)
            {
                return false;
            }
            if (textBoxLastName.Text.Length == 0)
            {
                return false;
            }
            if(dateTimePickerDateBegin.Value > DateTime.Today)
            {
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            dateTimePickerDateBegin.Value = DateTime.Today;
            numericUpDownSalary.Value = numericUpDownSalary.Minimum;
            checkBoxManager.Checked = false;
        }

        private void listBoxWorkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxWorkers.SelectedItems.Count == 1)
            {
                listBoxWorkers.Enabled = false;
                buttonSave.Text = "Zmien";
                buttonDelete.Visible = true;

                Worker selectedWorker = listBoxWorkers.SelectedItem as Worker;

                textBoxFirstName.Text = selectedWorker.FirstName;
                textBoxLastName.Text = selectedWorker.LastName;
                dateTimePickerDateBegin.Value = selectedWorker.DateBegin;
                numericUpDownSalary.Value = selectedWorker.Salary;
                checkBoxManager.Checked = selectedWorker.Manager;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxWorkers.SelectedItems.Count == 1)
            {
                Worker selectedWorker = listBoxWorkers.SelectedItem as Worker;

                DatabaseDC.Workers.DeleteOnSubmit(selectedWorker);
                DatabaseDC.SubmitChanges();

                buttonSave.Text = "Dodaj";
                buttonDelete.Visible = false;
                listBoxWorkers.Enabled = true;
                ClearForm();

                LoadWorkersFrom();
            }
        }
    }
}
