using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
using System.IO;
using OOO_Rythm.Settings;

namespace OOO_Rythm
{
    public partial class Autorization : Form
    {
        public Autorization()
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


        public void GetRoles()
        {
            Helper.GetRoles();
        }

        public void GetLogotip()
        {
            string connectionString = Properties.Settings.Default.ConnectionString;
            ConnectionDataBase dataBase = new ConnectionDataBase(connectionString);
            try
            {
                SqlConnection connection = dataBase.SqlConnection;
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT OrganizationLogotip, OrganizationName FROM Organization where OrganizationName = @name", connection);
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@name", "ООО \"Ритм\"");
                SqlDataReader reader = command.ExecuteReader();

                if(!reader.HasRows)
                {
                    reader.Close();
                    connection.Close();
                    return;
                }

                try
                {
                    reader.Read();
                    textBoxOrganizationName.Text = reader.GetString(1);
                }
                catch (Exception ex)
                {
                    reader.Close();
                    connection.Close();
                    throw ex;
                }

                try
                {
                    byte[] image = (byte[])reader.GetSqlBytes(0).Buffer;
                    //reader.GetString(0);
                    MemoryStream memory = new MemoryStream(image);
                    pictureBoxOrganizationLogotip.Image = new Bitmap(memory);
                    Helper.Logotip = new Bitmap(memory);
                    memory.Close();
                }
                catch(Exception ex)
                {
                    pictureBoxOrganizationLogotip.Image = new Bitmap(100, 100);
                    Helper.Logotip = new Bitmap(50, 50);

                }

                reader.Close();

                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                textBoxOrganizationName.Text = "";
                pictureBoxOrganizationLogotip.Image = new Bitmap(100, 100);
                Helper.Logotip = new Bitmap(50, 50);
            }
        }

        private void Pattern_Load(object sender, EventArgs e)
        {
            GetLogotip();

            checkBoxSave.Checked = UserDatas.Default.SaveDatas;
            UserDatas userDatas = UserDatas.Default;
            textBoxLogin.Text = userDatas.Login;
            textBoxPassword.Text = userDatas.Password;
            checkBoxSave.CheckedChanged += CheckBoxSave_CheckedChanged;

            try
            {
                GetRoles();
            }
            catch
            {

            }
        }

        private void CheckBoxSave_CheckedChanged(object sender, EventArgs e)
        {
            UserDatas userDatas = UserDatas.Default;
            userDatas.SaveDatas = (sender as CheckBox).Checked;
            //if(!(sender as CheckBox).Checked)
            //{
            //    userDatas.Login = "";
            //    userDatas.Password = "";
            //}
            userDatas.Save();
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

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !(sender as CheckBox).Checked;
            textBoxPassword.PasswordChar = '\0';
        }

        private void buttonConnectionString_Click(object sender, EventArgs e)
        {
            ConnectionForm connectionForm = new ConnectionForm();
            Hide();
            connectionForm.ShowDialog();
            Show();
            GetLogotip();
        }

        private void buttonGoest_Click(object sender, EventArgs e)
        {
            GetLogotip();

            try
            {
                GetRoles();
                Helper.UserID = 0;

                MessageBox.Show($"Вы вошли, как {Helper.Roles[0].Name}", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                runToAssortiment();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Не удалось подключиться к базе данных", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        void runToAssortiment()
        {
            ProductForm productForm = new ProductForm();
            Hide();
            productForm.ShowDialog();
            Show();
        }

        private void buttonInput_Click(object sender, EventArgs e)
        {
            
            GetLogotip();

            try
            {
                GetRoles();

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Не удалось подключиться к базе данных", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Helper.UserInput(textBoxLogin.Text, textBoxPassword.Text);
                string messageText = $"Авторизация прошла успешно \n";
                if(Helper.HaveUserFIO())
                {
                    messageText += $"ФИО пользователя: {Helper.UserFIO}";
                }    

                MessageBox.Show(messageText, "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {

                MessageBox.Show($"Неверный логин или пароль, или пользователья заблокирован", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!Helper.HaveUserRole())
            {
                MessageBox.Show($"Пользователь не имеет роль в системе", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveUserDatas();
            runToAssortiment();
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            GetLogotip();
            //SaveUserDatas();

            try
            {
                string login = textBoxLogin.Text;
                string password = textBoxPassword.Text;
                if (Helper.NullText(login))
                {
                    MessageBox.Show($"Логин не может быть пустым", "Регистрация" +
                        $"Учётная запись не была создана", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Helper.UserPresent(login))
                {
                    MessageBox.Show($"Пользователь с данным логином уже существует \n" +
                        $"Учётная запись не была создана", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Helper.NullText(password))
                {
                    DialogResult result = MessageBox.Show($"Отсутствие пароля делает вашу учётную запись уязвимой \n" +
                        $"В целях вашей безопасности, вам рекомендуется установить пароль \n" +
                        $"\n" +
                        $"Вы действительно хотите создать учётную запись без пароля?", "Регистрация", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        MessageBox.Show($"Учётная запись не была создана", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                Helper.Registration(login, password);
                MessageBox.Show("Аккаунт успешно создан", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                buttonInput_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Учётная запись не была создана из-за неизвестной ошибки \n" +
                    $"Возможно, проблемы с подключением к базе данных", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        void SaveUserDatas()
        {
            
            UserDatas userDatas = UserDatas.Default;
            //if (!userDatas.SaveDatas)
            //    return;
            userDatas.Login = textBoxLogin.Text;
            userDatas.Password = textBoxPassword.Text;
            userDatas.Save();
        }

        private void Autorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            UserDatas.Default.Save();
        }
    }
}
