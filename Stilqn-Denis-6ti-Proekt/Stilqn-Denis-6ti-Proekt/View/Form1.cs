using Stilqn_Denis_6ti_Proekt.Controller;
using Stilqn_Denis_6ti_Proekt.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stilqn_Denis_6ti_Proekt.View
{
    public partial class Form1 : Form
    {
        AnimalLogic anmlController = new AnimalLogic();
        BreedLogic breedController = new BreedLogic();
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadRecord(Animal anml)
        {
            txtId.Text = anml.Id.ToString();
            txtName.Text = anml.Name.ToString();
            txtAge.Text = anml.Name;
            cmbBreedId.Text = breedController.GetTypeById(int.Parse(txtId.Text));
            listBoxDiscription.Items.Add(anml.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Breed> allBreeds = breedController.GetAllBreeds();
            cmbBreedId.DataSource = allBreeds;
            cmbBreedId.DisplayMember = "Breed";
            cmbBreedId.ValueMember = "Id";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text) || txtName.Text == "")
            {
                MessageBox.Show("Въведете данни!");
                txtId.Focus();
                txtId.BackColor = Color.Red;
                return;
            }
            txtId.BackColor = Color.White;
            Animal newAnml = new Animal();
            newAnml.Id=int.Parse(txtId.Text);
            newAnml.Name = txtName.Text;
            newAnml.Age = int.Parse(txtAge.Text);
            newAnml.BreedId = (int)cmbBreedId.SelectedValue;
            newAnml.Description = listBoxDiscription.Text;

            anmlController.Create(newAnml);
            MessageBox.Show("Добавен!");
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            List<Animal> allAnml = anmlController.GetAll();
            listBoxAll.Items.Clear();
            foreach (var item in allAnml)
            {
                listBoxAll.Items.Add($"{item.Id}. {item.Name}- {item.Age} ");
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Въведи ид!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);

            }
            Animal findAnml = anmlController.Get(findId);
            if (findAnml == null)
            {
                MessageBox.Show("Не е намерено такоша ид.");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            txtId.BackColor = Color.White;
            LoadRecord(findAnml);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int findId;
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Въведете ид!!!");
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);

            }
            Animal findAnml = anmlController.Get(findId);
            if (findAnml == null)
            {
                MessageBox.Show("Не е намерено такова ид!");
                txtId.BackColor = Color.Red;
                return;
            }
            else
            {
                txtId.BackColor = Color.White;
                findAnml.Id = int.Parse(txtId.Text);
                findAnml.Name = txtName.Text;
                findAnml.Age= int.Parse(txtAge.Text);
                findAnml.Description = listBoxDiscription.Items.ToString();
                MessageBox.Show("Всичко е готово!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Въведи ид!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
                txtId.BackColor = Color.White;
            }
            Animal findAnml = anmlController.Get(findId);
            if (findAnml == null)
            {
                MessageBox.Show("Не е намерено такова ид!");
                txtId.BackColor = Color.Red;
                return;
            }
            else
            {
                DialogResult answear = MessageBox.Show("Искате ли да изтриете записа?", "Question", MessageBoxButtons.YesNo);
                if (answear == DialogResult.Yes)
                {
                    anmlController.Delete(findId);
                    MessageBox.Show("Успешно изтрихте записа.");
                }
                else
                {
                    return;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAge.Clear();
            txtName.Clear();
            txtId.Clear();
            cmbBreedId.Text = "";
            listBoxDiscription.Items.Clear();
            listBoxAll.Items.Clear();
        }
    }
}
