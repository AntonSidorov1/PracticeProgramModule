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

        private void Pattern_Load(object sender, EventArgs e)
        {
            
            outputAssortiment();
            UpdateFIO();
        }

        void outputAssortiment()
        {
            DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
            query.Table = "Product";
            TableDataBaseGrid table = query.GetCells();

            for(int i = 0; i < table.Rows.Count; i++)
            {
                int rowID = dataGridViewProduct.Rows.Add();
                DataGridViewRow row = dataGridViewProduct.Rows[rowID];
                row.Height = 150;
                row.Cells[0].Value = table.Rows[i]["ProductID"];
                row.Cells[1].Value = table.Rows[i]["ProductArticle"];

                
                try
                {
                    row.Cells[2].Value = table.Rows[i].GetCell("ProductPhoto").ImageValue;
                }
                catch
                {
                    row.Cells[2].Value = new Bitmap(Helper.Logotip, 50, 50);
                }

                double cost = Convert.ToDouble(table.Rows[i].GetCell("ProductCost").DecimalValue);
                int discount = Convert.ToInt32(table.Rows[i].GetCell("ProductDiscount").ByteValue);
                double costWithDiscount = cost - (cost * discount / 100);

                row.Cells[3].Value = "!";
                row.Cells[4].Value = "+";

                row.Cells[5].Value = "Название - " + table.Rows[i].GetCell("ProductName").TextValue + Environment.NewLine;
                row.Cells[5].Value += "Цена - " + cost.ToString("c2") + Environment.NewLine;
                row.Cells[5].Value += "Скидка - " + (discount/100.0).ToString("0 %") + Environment.NewLine;
                row.Cells[5].Value += "Цена со скидеой - " + costWithDiscount.ToString("c2") + Environment.NewLine;

                if(discount >= 15)
                {
                    row.DefaultCellStyle.BackColor = Color.Pink;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
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

        private void listBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int roleID = (sender as ListBox).SelectedIndex;
                labelRole.Text = roles[roleID].Name;

                roleID = roles[roleID].ID;
                if(roleID == 2 || roleID == 3)
                {
                    buttonEditUser.Visible = true;
                }
                else
                {
                    buttonEditUser.Visible = false;
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
                        labelRole.Text = "Гость";
                    }
                }
                else
                {
                    Helper.UserID = 0;
                    listBoxRole.Visible = false;
                    buttonDatas.Visible = false;
                    labelRole.Text = "Гость";
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
                return;
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
    }
}
