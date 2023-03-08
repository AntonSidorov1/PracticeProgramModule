using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OOO_Rythm
{
    public partial class ConnectionForm : Form
    {

        string filesFilter = "Server Connection File (*.servpodkl)|*.servpodkl|Sidorov TXT (*.stxt)|*.stxt|Json File (*.json)|*.json|TXT-File (*.txt)|*.txt|All Files (*.*)|*.*";
        
        public ConnectionForm()
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
            buttonConnectionClear_Click(sender, e);
            ConnectionCopy();
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

        private void buttonConnectionClear_Click(object sender, EventArgs e)
        {
            DatabaseConnectionRythm connectionRythm = DatabaseConnectionRythm.SettingsConnection();
            textBoxConnectionString.Text = connectionRythm.ConnectionString;
            checkBoxLocalServer.Checked = connectionRythm.LocalServer;
        }

        private void buttonConnectionRun_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseConnectionRythm.SaveSettings(textBoxConnectionString.Text, checkBoxLocalServer.Checked);
                doMessage();
                ConnectionCopy();
            }
            catch
            {
                MessageBox.Show("Не удалось изменить строку подключения", "Изменение строки подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
            

        void doMessage()
        {
            MessageBox.Show("Строка подключения успешно изменена", "Изменение строки подключения", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        void ConnectionCopy()
        {
            
            DatabaseConnectionRythm connectionRythm = DatabaseConnectionRythm.SettingsConnection();
            textInputDataSourse.Text = connectionRythm.DataSource;
            textInputInitialCatalog.Text = connectionRythm.InitialCatalog;
            checkBoxIntegratedSecurity.Checked = connectionRythm.IntegratedSecurity;
            checkBoxPersistSecurityInfo.Checked = connectionRythm.PersistSecurityInfo;
            textInputUserID.Text = connectionRythm.UserID;
            textInputPassword.Text = connectionRythm.Password;
            checkBoxLocalServer.Checked = connectionRythm.LocalServer;
        }

        private void checkBoxLocalServer_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LocalServer = (sender as CheckBox).Checked;
            Properties.Settings.Default.Save();
        }

        private void buttonMakeConnection_Click(object sender, EventArgs e)
        {
            MakeConnection();
            buttonConnectionClear_Click(sender, e);
            doMessage();
        }


        void MakeConnection()
        {
            DatabaseConnectionRythm connectionRythm = new DatabaseConnectionRythm();
            connectionRythm.DataSource = textInputDataSourse.Text;
            connectionRythm.InitialCatalog = textInputInitialCatalog.Text;
            connectionRythm.IntegratedSecurity = checkBoxIntegratedSecurity.Checked;
            connectionRythm.PersistSecurityInfo = checkBoxPersistSecurityInfo.Checked;
            connectionRythm.Password = textInputPassword.Text;
            connectionRythm.UserID = textInputUserID.Text;
            connectionRythm.LocalServer = checkBoxLocalServer.Checked;
            connectionRythm.SaveSettings();
        }

        private void buttonCheckConnection_Click(object sender, EventArgs e)
        {
            DatabaseConnectionRythm connectionRythm = DatabaseConnectionRythm.SettingsConnection();
            string connectionString = connectionRythm.ConnectionString;
            try
            {
                
                SqlConnection connection = connectionRythm.SqlConnection;
                connection.Open();
                connection.Close();
                connection.Dispose();
                MessageBox.Show($"Подключение к базе данных по строке \"{connectionString}\" успешно", "Подключение к базе данных", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
            catch
            {

                MessageBox.Show($"Не удалось подключиться к базе данных по строке \"{connectionString}\"", "Подключение к базе данных", MessageBoxButtons.OK, MessageBoxIcon.Error); ;

            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveFileDialogConnection.Filter = filesFilter;
            string fileName = "";
            try
            {
                DialogResult result = saveFileDialogConnection.ShowDialog();
                if(result == DialogResult.OK)
                {
                    fileName = saveFileDialogConnection.FileName;
                    DatabaseConnectionRythm connectionRythm = DatabaseConnectionRythm.SettingsConnection();
                    connectionRythm.LocalServer = checkBoxLocalServer.Checked;
                    connectionRythm.SaveJson(fileName);

                    MessageBox.Show($"Строка подключения \"{connectionRythm.ConnectionString}\" успешно сохранена в файл \"{fileName}\"", "Сохранение строки подключения", MessageBoxButtons.OK, MessageBoxIcon.Information); ;

                }
            }
            catch
            {
                MessageBox.Show($"Не удалось строку подключения в файл \"{fileName}\"", "Сохранение строки подключения", MessageBoxButtons.OK, MessageBoxIcon.Error); ;

            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            openFileDialogConnection.Filter = filesFilter;
            string fileName = "";
            try
            {
                DialogResult result = openFileDialogConnection.ShowDialog();
                if (result == DialogResult.OK)
                {
                    fileName = openFileDialogConnection.FileName;
                    DatabaseConnectionRythm connectionRythm = new DatabaseConnectionRythm();
                    connectionRythm.Loadjson(fileName);
                    //checkBoxLocalServer.Checked = connectionRythm.LocalServer;
                    connectionRythm.SaveSettings();

                    MessageBox.Show($"Строка подключения \"{connectionRythm.ConnectionString}\" успешно получена из файла \"{fileName}\"", "Получение строки подключения из файла", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    buttonConnectionClear_Click(sender, e);
                    buttonConnectionRun_Click(sender, e);
                }
            }
            catch
            {
                MessageBox.Show($"Не удалось получить строку подключения из файл \"{fileName}\"", "Получение строки подключения из файла", MessageBoxButtons.OK, MessageBoxIcon.Error); ;

            }
        }
    }
}
