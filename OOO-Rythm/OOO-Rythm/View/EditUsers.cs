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
    public partial class EditUsers : Form
    {
        public EditUsers()
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

        private void Pattern_Load(object sender, EventArgs e)
        {
            textInputLogin.InputText_Changed += TextInputLogin_InputText_Changed1;


            Helper.GetRoles();
            rolesAll = new List<Role>(Helper.Roles);

            for(int i =0; i < rolesAll.Count; i++)
            {
                comboBoxRole.Items.Add(rolesAll[i].Name);
            }
            comboBoxRole.SelectedIndex = 0;

            getAllUsers();
        }

        List<Role> rolesAll;

        private void TextInputLogin_InputText_Changed1(object arg1, EventArgs arg2)
        {
            buttonAddUser.Enabled = !(Helper.Users.Contains((arg1 as TextInput).Text) || (arg1 as TextInput).NullValue);
            int index = Helper.Users.IndexOf((arg1 as TextInput).Text);
            if (index >= 0)
            {
                listBoxUser.SelectedIndex = index;
                index = Helper.Users[index].ID;
            }
            else
                index = -1;
            bool thisUser = index == Helper.UserID;
            buttonDropUser.Enabled = !buttonAddUser.Enabled && !thisUser && !(arg1 as TextInput).NullValue;

        }

        void getAllUsers()
        {
            
            listBoxUser.Items.Clear();
            try
            {
                Helper.GetAllUsers();
                for (int i = 0; i < Helper.Users.Count; i++)
                {
                    listBoxUser.Items.Add(Helper.Users[i].Login);
                }

                int id = Helper.Users.FindIndex(p => p.ID == Helper.UserID);
                listBoxUser.SelectedIndex = id;
            }
            catch
            {

            }
        }

        List<Role> roles = new List<Role>();

        void getRoles()
        {
            listBoxRole.Items.Clear();
            try
            {

                List<int> rolesIDs = new List<int>();

                roles.Clear();


                User user = Helper.Users.GetUser(labelLogin.Text);
                int userID = user.ID;
                checkBoxBlocked.Checked = user.Blocked;

                if (Helper.HaveUserRole(userID, rolesIDs))
                {
                    listBoxRole.Enabled = true;
                    for (int i = 0; i < rolesIDs.Count; i++)
                    {
                        int roleID = rolesIDs[i];
                        Role role = Helper.Roles.GetRoleFromID(roleID);
                        roles.Add(role);
                        listBoxRole.Items.Add(role.Name);
                    }
                    listBoxRole.SelectedIndex = 0;
                    if (userID == Helper.UserID && listBoxRole.Items.Count < 2)
                    {
                        listBoxRole.Enabled = false;
                    }
                    buttonChangeBlocked.Enabled = userID != Helper.UserID;
                }
                else
                {
                    listBoxRole.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                listBoxRole.Enabled = false;
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.AddUser(textInputLogin.Text);
                MessageBox.Show("Пользователь успешно добавлен", "Добавление пользователя", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getAllUsers();
            }
            catch
            {
                MessageBox.Show("Не удалось добавить пользователя", "Добавление пользователя", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void buttonDrop_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.DeleteAccount(textInputLogin.Text);
                MessageBox.Show("Пользователь успешно удалён", "Удаление пользователя", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getAllUsers();
            }
            catch
            {
                MessageBox.Show("Не удалось удалить пользователя", "Удаление пользователя", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void listBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (sender as ListBox).SelectedIndex;
            string login = Helper.Users[id].Login;
            textInputLogin.Text = login;
            labelLogin.Text = login;
        }

        private void labelLogin_TextChanged(object sender, EventArgs e)
        {
            getRoles();
        }

        private void listBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = (sender as ListBox).SelectedIndex;
            Role role = roles[index];
            labelRole.Text = role.Name;
            //int roleID = role.ID;
            //index = rolesAll.FindIndex(p => p.ID == roleID);
            //comboBoxRole.SelectedIndex = index;
        }

        private void labelLogin_Click(object sender, EventArgs e)
        {

        }

        //bool haveRole;
        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show((sender as ComboBox).SelectedIndex.ToString() + " - " + (sender as ComboBox).SelectedValue);
        }

        private void buttonRoleApp_Click(object sender, EventArgs e)
        {
            int index = comboBoxRole.SelectedIndex;
            try
            {
                Helper.AddUserRole(labelLogin.Text, rolesAll[index].ID);
                MessageBox.Show("Роль успешно добавлена", "Добавление роли", MessageBoxButtons.OK, MessageBoxIcon.Information);

                getRoles();
            }
            catch
            {
                MessageBox.Show("Не удалось добавить роль", "Добавление роли", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void buttonDeleteRole_Click(object sender, EventArgs e)
        {
            int index = listBoxRole.SelectedIndex;
            try
            {
                Helper.DeleteUserRole(labelLogin.Text, roles[index].ID);
                MessageBox.Show("Роль успешно удалена", "Удаление роли", MessageBoxButtons.OK, MessageBoxIcon.Information);

                getRoles();
            }
            catch
            {
                MessageBox.Show("Не удалось удалить роль", "Удаление роли", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void buttonChangeBlocked_Click(object sender, EventArgs e)
        {
            User user = Helper.Users.GetUser(labelLogin.Text);
            int userID = user.ID;
            bool blocked = !checkBoxBlocked.Checked;
            string title = "", doing ="";
            if (blocked)
            {
                title = "Блокирововка";
                doing = "Заблокирова";
                }
            else
            {
                title = "Разблокировка";
                doing = "Разблкирова";
            }

            title += " пользователя";
            try
            {
                Helper.SetUserBlocked(userID, blocked);

                MessageBox.Show($"Пользователь успешно {doing}н", title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                getAllUsers();




            }
            catch (Exception ex)
            {

                MessageBox.Show($"Не удалось {doing}ть пользователя", title, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
