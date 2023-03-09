using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOO_Rythm
{
    public partial class EditProduct : Form
    {
        

        public EditProduct()
        {
            InitializeComponent();

            labelTitle.Text = "Просмотр информации о товаре";
            Text = labelTitle.Text;

            string tire = "–";
            string text = Text == "" ? "" : tire;
            string title = Text;
            Text += $" {text} ООО \"Ритм\" {tire} {Application.ProductName} {tire} {Application.ProductVersion}";

            notifyIconApp.Text = Text;
            notifyIconApp.BalloonTipText = title;

            labelTitle.TextChanged += labelTitle_Click;

            textInputDescription.ScrollBars = ScrollBars.Both;

            categories = new IndexNameRowsCollection("ProductCategory", "CategoryID", "CategoryName", true);
            for(int i = 0; i < categories.Count; i++)
            {
                comboBoxWithNameCategory.Items.Add(categories[i].Name);
            }
            manufacture = new IndexNameRowsCollection("ProductManufacture", "ManufactureID", "ManufactureName", true);
            for (int i = 0; i < manufacture.Count; i++)
            {
                comboBoxWithNameManufacture.Items.Add(manufacture[i].Name);
            }
            supplier = new IndexNameRowsCollection("ProductSupplier", "SupplierID", "SupplierName", true);
            for (int i = 0; i < supplier.Count; i++)
            {
                comboBoxWithNameSupplier.Items.Add(supplier[i].Name);
            }

            numericControlWithNameCost.ValueChanged += NumericControlWithNameCost_ValueChanged;
            numericControlWithNameDiscount.ValueChanged += NumericControlWithNameCost_ValueChanged;
        }

        private void NumericControlWithNameCost_ValueChanged(object arg1, EventArgs arg2)
        {
            labelCost.Text = "Цена со скидкой = ";
            double cost = Convert.ToDouble(numericControlWithNameCost.Value);
            int discount = Convert.ToInt32(numericControlWithNameDiscount.Value);
            cost -= (cost * discount / 100.0);
            labelCost.Text += cost.ToString("c2");

            
        }

        public EditProduct(Role role) : this()
        {
            Role = role;

            
        }

        public EditProduct(Role role, Product product) : this(role)
        {
            Product = product;

            if(Add)
            {
                buttonEdit.Text = "Добавить товар";
            }
        }

        Role role;
        Product product;

        public Product Product
        {
            get => product;
            set => product = value;
        }

        public bool Add => Product.ID == 0;

        public Role Role
        {
            get => role;
            set => role = value;
        }

        public void SetReadOnly(bool readOnly)
        {
            textInputName.ReadOnly = readOnly;
            comboBoxWithNameCategory.ReadOnly = readOnly;
            comboBoxWithNameManufacture.ReadOnly = readOnly;
            comboBoxWithNameSupplier.ReadOnly = readOnly;
            textInputDescription.ReadOnly = readOnly;
            numericControlWithNameCost.ReadOnly = readOnly;
            numericControlWithNameDiscount.ReadOnly = readOnly;
        }

        IndexNameRowsCollection categories, manufacture, supplier;

        private void Pattern_Load(object sender, EventArgs e)
        {
            if(Product.ID == 0)
            {
                comboBoxWithNameCategory.SelectedIndex = 0;
                comboBoxWithNameManufacture.SelectedIndex = 0;
                comboBoxWithNameSupplier.SelectedIndex = 0;
            }
            else
            {
                comboBoxWithNameCategory.SelectedIndex = categories.GetIndexFromID(Product.CategoryID);
                comboBoxWithNameManufacture.SelectedIndex = manufacture.GetIndexFromID(Product.ManufactureID);
                comboBoxWithNameSupplier.SelectedIndex = supplier.GetIndexFromID(Product.SupplierID);
            }

            textInputArticul.SetReadOnlyOrNoReadOnly();

            numericControlWithNameCost.Value = Product.Cost;
            numericControlWithNameDiscount.Value = Product.Discount;

            checkBoxEdit.Checked = !checkBoxEdit.Checked;
            checkBoxEdit.Checked = checkBoxEdit.Checked;

            textInputDescription.Text = Product.Description;

            textInputArticul.Text = Product.Articul;
            textInputName.Text = Product.Name;
            checkBoxEdit.Checked = false;
            int indexRole = Role.ID;
            if (indexRole == 3 || indexRole == 4)
            {
                if (Product.ID < 1)
                {
                    checkBoxEdit.Checked = true;
                    textInputArticul.NoReadOnly = true;
                    labelTitle.Text = "Добавление товара";
                }
                else
                {
                    checkBoxEdit.Visible = true;
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string date = now.ToLongDateString();
            string time = now.ToLongTimeString();
            toolStripStatusLabelDate.Text = date;
            toolStripStatusLabelTime.Text = time;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string message2 = Add ? "Добавление" : "Изменение";
            try
            {


                Product.Articul = textInputArticul.Text;

                if(Helper.NullText(Product.Articul))
                {
                    
                    MessageBox.Show($"Артикул не может быть пустым", $"{message2} товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Product.Name = textInputName.Text;
                Product.CategoryID = categories[comboBoxWithNameCategory.SelectedIndex].ID;
                Product.ManufactureID = manufacture[comboBoxWithNameManufacture.SelectedIndex].ID;
                Product.SupplierID = supplier[comboBoxWithNameSupplier.SelectedIndex].ID;
                Product.Description = textInputDescription.Text;
                Product.Cost = numericControlWithNameCost.Value;
                Product.Discount = (byte)((int)numericControlWithNameDiscount.Value);
               // Product.Photo = null;

                ProductsCollection products = Product.Products;

                if (!Add)
                {
                    products.Update(product.ID);
                }
                else
                {
                    products.Insert(Product);
                }

                string message1 = Add ? "добавление" : "изменён";
                MessageBox.Show($"Товар успешно {message1}", $"{message2} товара", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                Close();
            }
            catch (Exception ex)
            {
                string message1 = Add ? "добавить" : "изменить";
                MessageBox.Show($"Не удалось {message1} товар", $"{message2} товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDropProduct_Click(object sender, EventArgs e)
        {
            try
            {

                ProductsCollection products = Product.Products;


                products.DeleteFromDB(product.ID);
                

                MessageBox.Show($"Товар успешно удалён", $"Удаление товара", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                Close();
            }
            catch (Exception ex)
            {
                string message1 = Add ? "добавить" : "изменить";
                MessageBox.Show($"Не удалось удалить товар", $"Удаление товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEdit_VisibleChanged(object sender, EventArgs e)
        {
            buttonDropProduct.Visible = (sender as Button).Visible && !Add;
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

            Text = labelTitle.Text;

            string tire = "–";
            string text = Text == "" ? "" : tire;
            string title = Text;
            Text += $" {text} ООО \"Ритм\" {tire} {Application.ProductName} {tire} {Application.ProductVersion}";

            notifyIconApp.Text = Text;
            notifyIconApp.BalloonTipText = title;
        }

        private void checkBoxEdit_CheckedChanged(object sender, EventArgs e)
        {
            SetReadOnly(!(sender as CheckBox).Checked);
            if(!(sender as CheckBox).Checked)
            {
                labelTitle.Text = "Просмотр информации о товаре";
            }
            else
            {
                labelTitle.Text = "Редактирование товара";
            }
            buttonEdit.Visible = (sender as CheckBox).Checked;
        }

    }
}
