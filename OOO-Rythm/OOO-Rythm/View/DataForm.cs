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
    public partial class DataForm : Form
    {
        Form form;
        public DataForm()
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

        public DataForm(Form form) : this()
        {
            this.form = form;
        }

        private void Pattern_Load(object sender, EventArgs e)
        {
            textInputPassword.Text = Helper.UserPassword;

            textInputFamily.Text = Helper.UserFamily;
            textInputName.Text = Helper.UserName;
            textInputLastName.Text = Helper.UserLastName;

            textInputEmail.Text = Helper.UserEmail;

            UpdateEmails();
            UpdateTelephones();
        }

        void UpdateEmails()
        {
            try
            {
                Helper.GetUserEmails();
            }
            catch
            {

            }
            comboBoxEmail.Items.Clear();
            for(int i = 0; i < Helper.UserEmails.Count; i++)
            {
                comboBoxEmail.Items.Add(Helper.UserEmails[i].Email);
            }
            comboBoxEmail.Enabled = Helper.UserEmails.Count > 0;
            if(comboBoxEmail.Enabled)
            {
                comboBoxEmail.SelectedIndex = 0;
            }
        }

        void UpdateTelephones()
        {
            try
            {
                Helper.GetUserTelephones();
            }
            catch
            {

            }
            comboBoxTelephone.Items.Clear();
            for (int i = 0; i < Helper.UserTelephones.Count; i++)
            {
                comboBoxTelephone.Items.Add(Helper.UserTelephones[i].Telephone);
            }
            comboBoxTelephone.Enabled = Helper.UserTelephones.Count > 0;
            if (comboBoxTelephone.Enabled)
            {
                comboBoxTelephone.SelectedIndex = 0;
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

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            textInputPassword.UseSystemPasswordChar = !(sender as CheckBox).Checked;
            textInputPassword.PasswordChar = '\0';
        }

        private void buttonSavePassword_Click(object sender, EventArgs e)
        {
            try
            {
                if(Helper.NullText(textInputPassword.Text))
                {
                    DialogResult result = MessageBox.Show($"Отсутствие пароля делает вашу учётную запись уязвимой \n" +
                        $"В целях вашей безопасности, вам рекомендуется установить пароль \n" +
                        $"\n" +
                        $"Вы действительно хотите создать учётную запись без пароля?", "Регистрация", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        throw new Exception();
                    }
                }
                Helper.ChangePassword(textInputPassword.Text);
                MessageBox.Show("Пароль успешно изменён", "Смена пароля", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Settings.UserDatas.Default.Password = textInputPassword.Text;
            }
            catch
            {
                MessageBox.Show("Не удалось сменить пароль", "Смена пароля", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить аккаунт?", "Удаление аккаунта", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result == DialogResult.Yes)
                {
                    Helper.DeleteAccount();
                    MessageBox.Show("Аккаует успешно удалён", "Удаление аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Settings.UserDatas.Default.SaveDatas = false;
                    
                    try
                    {
                        form.Close();
                        Close();
                    }
                    catch
                    {
                        Helper.UserID = 0;
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось удалить аккаунт", "Удаление аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveFIO_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.UpdateFIO(
                    textInputFamily.Text,
                    textInputName.Text,
                    textInputLastName.Text
                    );
                MessageBox.Show("ФИО успешно изменено", "Изменение ФИО", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
            catch
            {
                MessageBox.Show("Не удалось изменить ФИО", "Изменение ФИО", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void buttonClearFIO_Click(object sender, EventArgs e)
        {
            textInputFamily.Clear();
            textInputName.Clear();
            textInputLastName.Clear();
        }

        private void buttonSaveEmail_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.UpdateEmail(
                    textInputEmail.Text
                    );
                MessageBox.Show("Email успешно изменён", "Изменение Электронной почты", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Не удалось изменить Email", "Изменение Электронной почты", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = (sender as ComboBox).SelectedIndex;
            textInputEmail.Text = Helper.UserEmails[index].Email;
        }

        private void AddEmail_Click(object sender, EventArgs e)
        {
            string email = textInputEmail.Text;
            if(Helper.NullText(email))
            {
                MessageBox.Show("E-mail не может быть пустым", "Добавление E-mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(!email.Contains('@') || email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries).Length != 2)
            {
                MessageBox.Show("E-mail должен содержать один символ '@' в середине", "Добавление E-mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            try
            {
                Helper.AddEmail(email);
                MessageBox.Show("E-mail успешно добавлен", "Добавление E-mail", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                MessageBox.Show("Не удалось добавить E-mail", "Добавление E-mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateEmails();
        }

        private void RemoveEmail_Click(object sender, EventArgs e)
        {
            int index = comboBoxEmail.SelectedIndex;
            int id = Helper.UserEmails[index].ID;

            try
            {
                Helper.DeleteEmail(id);
                MessageBox.Show("E-mail успешно добавлен", "Удаление E-mail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Не удалось удалить E-mail", "Удаление E-mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateEmails();
        }

        private void comboBoxEmail_EnabledChanged(object sender, EventArgs e)
        {
            RemoveEmail.Enabled = (sender as ComboBox).Enabled;
        }

        private void AddTelephone_Click(object sender, EventArgs e)
        {
            string email = textInputTelephone.Text;
            if (Helper.NullText(email))
            {
                MessageBox.Show("Номер телефона не может быть пустым", "Добавление номера телефона", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Helper.AddTelephone(email);
                MessageBox.Show("Номер телефона успешно добавлен", "Добавление номера телефона", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                MessageBox.Show("Не удалось добавить номер телефона", "Добавление номера телефона", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateTelephones();
        }

        private void DeleteTelephone_Click(object sender, EventArgs e)
        {
            int index = comboBoxTelephone.SelectedIndex;
            int id = Helper.UserTelephones[index].ID;

            try
            {
                Helper.DeleteTelephone(id);
                MessageBox.Show("Номер телефона успешно добавлен", "Удаление номера телефона", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Не удалось удалить номер телефона", "Удаление номера телефона", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateTelephones();
        }

        private void comboBoxTelephone_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = (sender as ComboBox).SelectedIndex;
            textInputTelephone.Text = Helper.UserTelephones[index].Telephone;
        }

        private void comboBoxTelephone_EnabledChanged(object sender, EventArgs e)
        {
            DeleteTelephone.Enabled = (sender as ComboBox).Enabled;
        }
    }
}
