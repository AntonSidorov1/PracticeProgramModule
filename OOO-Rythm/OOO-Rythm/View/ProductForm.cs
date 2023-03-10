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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();

            Text = labelTitle.Text;

            string tire = "–";
            string text = Text == "" ? "" : tire;
            string title = Text;
            Text += $" {text} ООО \"Ритм\" {tire} {Application.ProductName} {tire} {Application.ProductVersion}";

            notifyIconApp.Text = Text;
            notifyIconApp.BalloonTipText = title;

            
        }

        List<Role> roles = new List<Role>();

        int[,] discounts = new int[,]
        {
            {0, 100 },
            {0, 9 },
            {10, 14 },
            {15, 24 },
            {25, 49 },
            {50, 100 },
            {0, 25 },
            {0, 50 }

        };

        public new void Show()
        {
            try
            {
                base.Show();
            }
            catch
            {

            }
        }


        CategoryFilterCollection filters;
        private void Pattern_Load(object sender, EventArgs e)
        {
            for(int i =0; i < discounts.GetLength(0); i++)
            {
                int start = discounts[i, 0];
                int end = discounts[i, 1];
                string diapozon = string.Join("..", start, end);
                comboBoxDiscounts.Items.Add(diapozon);
            }
            comboBoxDiscounts.SelectedIndex = 0;
            comboBoxDiscounts.SelectedIndexChanged += comboBoxSortName_SelectedIndexChanged;
            try
            {
                filters = CategoryFilterCollection.Default;
                for (int i = 0; i < filters.Count; i++)
                {
                    comboBoxCategoryFilters.Items.Add(filters[i].Name);
                }
                comboBoxCategoryFilters.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

            }
            textInputName.InputText_Changed += comboBoxSortName_SelectedIndexChanged;

            comboBoxSortName.SelectedIndex = 0;
            comboBoxSortCost.SelectedIndex = 0;

            //outputAssortiment();
            UpdateFIO();
        }

        ProductsCollection products;
        CategoryCollection categories;

        void outputAssortiment()
        {
            DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
            query.Table = "Product";

            int index = listBoxCategory.SelectedIndex;
            int indexCategory = categories[index].ID;

            products = ProductsCollection.DefaultFromDB(indexCategory,
                textInputName.Text, 
                (Sort)comboBoxSortName.SelectedIndex, 
                (Sort)comboBoxSortCost.SelectedIndex);

            int indexDiscount = comboBoxDiscounts.SelectedIndex;

            products = products.GetProductsForDiscountDiapozon(discounts[indexDiscount, 0], discounts[indexDiscount, 1]);
            ProductsCollection products1 = ProductsCollection.DefaultRemote;

            dataGridViewProduct.Rows.Clear();

            labelCount.Text = products.Count + " из " + products1.Count;

            for(int i = 0; i < products.Count; i++)
            {
                int rowID = dataGridViewProduct.Rows.Add();
                DataGridViewRow row = dataGridViewProduct.Rows[rowID];

                Product product = products[i];
                product.Products = products;
                row.Height = 150;
                row.Cells[0].Value = product.ID;
                row.Cells[1].Value = product.Articul;
                
                try
                {
                    row.Cells[2].Value = product.Photo;
                }
                catch
                {
                    row.Cells[2].Value = new Bitmap(Helper.Logotip, 50, 50);
                }

                double cost = product.CostWithoutDiscount;
                double discount = product.DiscountPersent;
                int discount1 = product.Discount;
                double costWithDiscount = product.CostWithDiscount;

                row.Cells[3].Value = "!";


                string description = "";
                description = "Название - " + product.Name + Environment.NewLine;
                description += "Цена - " + cost.ToString("c2") + Environment.NewLine;
                description += "Скидка - " + discount.ToString("0 %") + Environment.NewLine;
                description += "Цена со скидеой - " + costWithDiscount.ToString("c2") + Environment.NewLine;

                if(discount1 >= 15)
                {
                    row.DefaultCellStyle.BackColor = Color.Pink;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
                row.Cells[4].Value = description;

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

        Role role;
        private void listBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int roleID = (sender as ListBox).SelectedIndex;
                labelRole.Text = roles[roleID].Name;

                role = roles[roleID];
                roleID = role.ID;
                if(roleID == 2 || roleID == 3)
                {
                    buttonEditUser.Visible = true;
                }
                else
                {
                    buttonEditUser.Visible = false;
                }

                if(roleID == 3 || roleID == 4)
                {
                    buttonAddProduct.Visible = true;
                }
                else
                {
                    buttonAddProduct.Visible = false;
                }
            }
            catch
            {

            }
        }

        private void buttonDatas_Click(object sender, EventArgs e)
        {
            DataForm form = new DataForm(this);
            Hide();
            form.ShowDialog();
            Show();
            UpdateFIO();
        }

        void UpdateFIO()
        {
            try
            {
                Helper.GetRoles();
                if (Helper.HaveUserRole())
                {
                    List<int> rolesIDs = Helper.RolesIDs;

                    roles.Clear();
                    listBoxRole.Items.Clear();
                    if (Helper.UserID > 0)
                    {
                        for (int i = 0; i < rolesIDs.Count; i++)
                        {
                            int roleID = rolesIDs[i];
                            Role role = Helper.Roles.GetRoleFromID(roleID);
                            roles.Add(role);
                            listBoxRole.Items.Add(role.Name);
                        }
                        listBoxRole.SelectedIndex = 0;
                    }
                    else
                    {
                        listBoxRole.Visible = false;
                        buttonDatas.Visible = false;
                        labelLogin.Visible = false;
                        labelRole.Text = "Гость";
                        Helper.GetRoles();
                        role = Helper.Roles.Goest;
                    }
                }
                else
                {
                    Helper.UserID = 0;
                    listBoxRole.Visible = false;
                    buttonDatas.Visible = false;
                    labelLogin.Visible = false;
                    labelRole.Text = "Гость";
                    Helper.GetRoles();
                    role = Helper.Roles.Goest;
                }
            }
            catch
            {

            }
            try
            {
                Helper.GetUserEmails();
            }
            catch
            {

            }

            try
            {
                Helper.GetUserTelephones();
            }
            catch
            {

            }

            if (Helper.UserID == 0)
            {
                labelFIO.Visible = false;
                labelLogin.Visible = false;
                return;
            }
            else
            {
                labelLogin.Visible = true;
                labelLogin.Text = Helper.Login;
            }
            if(!Helper.HaveUserFIO())
            {
                labelFIO.Visible = false;
                return;
            }

            try
            {
                labelFIO.Visible = true;
                labelFIO.Text = Helper.UserFIO;
            }
            catch
            {
                labelFIO.Visible = false;
            }

            
        }

        private void buttonEditUser_Click(object sender, EventArgs e)
        {
            EditUsers editUsers = new EditUsers();
            Hide();
            editUsers.ShowDialog();
            Show();
            UpdateFIO();
        }

        private void comboBoxCategoryFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = (sender as ComboBox).SelectedIndex;
            filterOutput(filters[index].ID);
        }


        void filterOutput(int index = 0)
        {
            try
            {
                listBoxCategory.Items.Clear();
                categories = CategoryCollection.DefaultFromDB(index);
                for (int i = 0; i < categories.Count; i++)
                {
                    listBoxCategory.Items.Add(categories[i].Name);
                }
                listBoxCategory.SelectedIndex = 0;
            }
            catch(Exception ex)
            {

            }
        }

        private void listBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelCategory.Text = categories[(sender as ListBox).SelectedIndex].Name;
            outputAssortiment();
        }

        private void comboBoxSortName_SelectedIndexChanged(object sender, EventArgs e)
        {
            outputAssortiment();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void notifyIconApp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Show();
        }

        private void dataGridViewProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 3)
                return;
            dataGridViewProduct_CellContentDoubleClick(sender, e);

        }

        private void dataGridViewProduct_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            Product product = products[index];
            EditProduct editProduct = new EditProduct(role, product);
            Hide();
            editProduct.ShowDialog();
            Show();
            outputAssortiment();
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {

            Product product = new Product();
            product.Products = products;
            EditProduct editProduct = new EditProduct(role, product);
            Hide();
            editProduct.ShowDialog();
            Show();
            outputAssortiment();
        }
    }
}
