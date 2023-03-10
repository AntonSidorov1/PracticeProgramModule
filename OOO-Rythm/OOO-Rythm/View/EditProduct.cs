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
            for (int i = 0; i < categories.Count; i++)
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

            sities = new IndexNameRowsCollection("Sity", "SityID", "SityName", true);
            for (int i = 0; i < sities.Count; i++)
            {
                comboBoxWithNameSity.Items.Add(sities[i].Name);
            }
            comboBoxWithNameSity.SelectedIndexChanged += ComboBoxWithNameSity_SelectedIndexChanged;
            comboBoxWithNameStock.SelectedIndexChanged += ComboBoxWithNameStock_SelectedIndexChanged;
            comboBoxWithNamePounkt.SelectedIndexChanged += ComboBoxWithNamePounkt_SelectedIndexChanged;

            organizations = new IndexNameRowsCollection("Organization", "OrganizationID", "OrganizationName", true);

            stocks = new RowWithNoteLinkCollection("Stock", "StockID", "StockAddress", "StockSityID", true);

            pounkts1 = new RowWithNoteLinkCollection("Pounkt", "PounktID", "PounktAddress", "PounktStockID", true);
            pounkts2 = new RowWithNoteLinkCollection("Pounkt", "PounktID", "PounktAddress", "PounktOrganizationID", true);

            RowWithNoteLinkCollection pounkts = new RowWithNoteLinkCollection();

            pounkts2 = pounkts2.GetRowsFromLink(ourOrganization.ID);
            for (int i = 0; i < pounkts2.Count; i++)
            {
                RowWithNoteLink pounkt = pounkts1.GetRowFromID(pounkts2[i].ID);
                pounkts.Add(pounkt);
            }
            pounkts1 = pounkts;

            shops = new IndexNameRowsCollection("Shop", "PounktID", "ShopName", true);
            pounktsOfIssue = new IndexNameRowsCollection("PounktOfIssue", "PounktID", "PounktOfIssoueName", true);


            //for (int i = 0; i < supplier.Count; i++)
            //{
            //    comboBoxWithNameSity.Items.Add(supplier[i].Name);
            //}


            numericControlWithNameCost.ValueChanged += NumericControlWithNameCost_ValueChanged;
            numericControlWithNameDiscount.ValueChanged += NumericControlWithNameCost_ValueChanged;

            numericCountAtStock.ReadOnlyChanged += NumericCountAtStock_ReadOnlyChanged;
            numericCountInShop.ReadOnlyChanged += NumericCountInShop_ReadOnlyChanged;

            productInPounkt = new RowWithNoteLinkCollection("ProductInStock", "StockID", "QuantityInStock", "ProductID", true);
            productInShop = new RowWithNoteLinkCollection("ProductInShop", "ShopID", "QuantityInShop", "ProductID", true);
        }

        private void NumericCountInShop_ReadOnlyChanged(object arg1, EventArgs arg2)
        {
            buttonAddShop.Visible = numericCountInShop.NoReadOnly;
        }

        private void NumericCountAtStock_ReadOnlyChanged(object arg1, EventArgs arg2)
        {
            buttonAddStock.Visible = numericCountAtStock.NoReadOnly;
        }

        RowWithNoteLinkCollection productInPounkt, productInShop;

        public RowWithNoteLink NowStock
        {
            get
            {
                int indexSity = comboBoxWithNameSity.SelectedIndex;
                IndexNameRow sity = sities[indexSity];
                RowWithNoteLinkCollection stocks = this.stocks.GetRowsFromLink(sity.ID);
                return stocks[comboBoxWithNameStock.SelectedIndex];
            }
        }

        public RowWithNoteLinkCollection NowPounkts
        {
            get
            {
                
                
                IndexNameRow stock = NowStock;
                return pounkts1.GetRowsFromLink(stock.ID);
            }
        }

        public RowWithNoteLink NowPounkt
        {
            get
            {
                return NowPounkts[comboBoxWithNamePounkt.SelectedIndex];
            }
        }

        private void ComboBoxWithNamePounkt_SelectedIndexChanged(object arg1, EventArgs arg2)
        {
            try
            {
                int index = (arg1 as ComboBox).SelectedIndex;
                
                RowWithNoteLinkCollection pounkts = NowPounkts;
                int pounkt = pounkts[index].ID;
                bool haveShop = shops.Contains(pounkt);

                if (haveShop)
                {
                    labelShop.Text = "Магазин: " + shops.GetNameFromID(pounkt);
                    numericCountInShop.NoReadOnly = checkBoxEdit.Checked;
                }
                else
                {
                    labelShop.Text = "Магазин отсутствует";
                    numericCountInShop.Value = 0;
                    numericCountInShop.ReadOnly = true;
                }


                if (pounktsOfIssue.Contains(pounkt))
                {
                    labelPounkt.Text = "Пункт выдачи: " + pounktsOfIssue.GetNameFromID(pounkt);
                }
                else
                {
                    labelPounkt.Text = "Пункт выдачи отсутствует";
                }

                if (!haveShop)
                    return;

                SetCountEnabled();

                try
                {
                    int product = Product.ID;
                    int stock = NowPounkt.ID;
                    if (productInShop.Contains(stock, product))
                    {
                        RowWithNoteLink row = productInShop.GetRowsFromIdAndLink(stock, product)[0];
                        numericCountInShop.Value = row.Value;
                    }
                    else
                    {
                        numericCountInShop.Value = 0;
                    }
                }
                catch (Exception e)
                {
                    numericCountInShop.Value = 0;
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void ComboBoxWithNameStock_SelectedIndexChanged(object arg1, EventArgs arg2)
        {
            int index = (arg1 as ComboBox).SelectedIndex;
            comboBoxWithNamePounkt.Items.Clear();

            int pounkt = pounkts1[index].ID;

            comboBoxWithNamePounkt.Items.Clear();

            numericCountAtStock.Value = 0;

            RowWithNoteLinkCollection rows = NowPounkts;
            for (int i = 0; i < rows.Count; i++)
            {
                if (pounkts2.Contains(rows[i].ID))
                    comboBoxWithNamePounkt.Items.Add(rows[i].Name);
            }

            if (comboBoxWithNamePounkt.Items.Count > 0)
            {
                comboBoxWithNamePounkt.Enabled = true;
                comboBoxWithNamePounkt.SelectedIndex = 0;
            }
            else
            {
                comboBoxWithNamePounkt.Enabled = false;
            }


            SetCountEnabled();
            try
            {
                int product = Product.ID;
                int stock = NowStock.ID;
                if(productInPounkt.Contains(stock, product))
                {
                    RowWithNoteLink row = productInPounkt.GetRowsFromIdAndLink(stock, product)[0];
                    numericCountAtStock.Value = row.Value;
                }
                else
                {
                    numericCountInShop.Value = 0;
                }
            }
            catch (Exception e)
            {

            }

        }

        private void ComboBoxWithNameSity_SelectedIndexChanged(object arg1, EventArgs arg2)
        {
            int index = (arg1 as ComboBox).SelectedIndex;
            int sity = sities[index].ID;
            comboBoxWithNameStock.Items.Clear();
            comboBoxWithNamePounkt.Items.Clear();
            RowWithNoteLinkCollection rows = stocks.GetRowsFromLink(sity);
            for(int i =0; i < rows.Count; i++)
            {
                comboBoxWithNameStock.Items.Add(rows[i].Name);
            }

            if (rows.Count > 0)
            {
                comboBoxWithNameStock.Enabled = true;
                comboBoxWithNameStock.SelectedIndex = 0;
            }
            else
            {
                comboBoxWithNameStock.Enabled = false;
            }
        }

        RowWithNoteLinkCollection stocks, pounkts1, pounkts2;
        IndexNameRowsCollection shops, pounktsOfIssue;
        
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

        public bool Add => Product.ID < 1;

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

        IndexNameRowsCollection categories, manufacture, supplier, sities, organizations;

        IndexNameRow ourOrganization => organizations.Find(p => p.Name == "ООО \"Ритм\"");

        private void Pattern_Load(object sender, EventArgs e)
        {
            if(Add)
            {
                panelCount.Visible = false;
                comboBoxWithNameCategory.SelectedIndex = 0;
                comboBoxWithNameManufacture.SelectedIndex = 0;
                comboBoxWithNameSupplier.SelectedIndex = 0;
                panelCount.Visible = false;
            }
            else
            {
                comboBoxWithNameCategory.SelectedIndex = categories.GetIndexFromID(Product.CategoryID);
                comboBoxWithNameManufacture.SelectedIndex = manufacture.GetIndexFromID(Product.ManufactureID);
                comboBoxWithNameSupplier.SelectedIndex = supplier.GetIndexFromID(Product.SupplierID);
                comboBoxWithNameSity.SelectedIndex = 0;
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

        private void comboBoxWithNamePounkt_EnabledChanged(object sender, EventArgs e)
        {
            labelShop.Visible = (sender as Controls.ComboBoxWithName).Enabled; 
            labelPounkt.Visible = (sender as Controls.ComboBoxWithName).Enabled;
            SetCountEnabled();
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string date = now.ToLongDateString();
            string time = now.ToLongTimeString();
            toolStripStatusLabelDate.Text = date;
            toolStripStatusLabelTime.Text = time;
        }

        private void buttonAddStock_Click(object sender, EventArgs e)
        {
            try
            {
                int product = Product.ID;
                int stock = NowStock.ID;
                int count = (int)numericCountAtStock.Value;
                //productInPounkt.Update(product, stock, count);
                productInPounkt.Update(stock, product, count);

                MessageBox.Show("Количество товара на складе успешно изменено", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Не удалось изменить количество товара на складе", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddShop_Click(object sender, EventArgs e)
        {

            try
            {
                int product = Product.ID;
                int stock = NowPounkt.ID;
                int count = (int)numericCountInShop.Value;
                productInShop.Update(stock, product, count);
                //productInPounkt.Update(stock, product, count);
                //productInShop.Update(stock, count, product);

                MessageBox.Show("Количество товара в магазине успешно изменено", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Не удалось изменить количество товара в магазине", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        public void SetCountEnabled()
        {

            numericCountAtStock.NoReadOnly = comboBoxWithNameStock.Enabled && checkBoxEdit.Checked;
            numericCountInShop.NoReadOnly = comboBoxWithNamePounkt.Enabled && checkBoxEdit.Checked;


        }

        private void comboBoxWithNameStock_EnabledChanged(object sender, EventArgs e)
        {
            comboBoxWithNamePounkt.Enabled = (sender as Controls.ComboBoxWithName).Enabled;
            SetCountEnabled();
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


            SetCountEnabled();
        }

    }
}
