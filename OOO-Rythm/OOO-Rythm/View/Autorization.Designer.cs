
namespace OOO_Rythm
{
    partial class Autorization
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Autorization));
            this.notifyIconApp = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripForm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.логинToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxLogin = new System.Windows.Forms.ToolStripTextBox();
            this.LoginToForm = new System.Windows.Forms.ToolStripMenuItem();
            this.LoginFromForm = new System.Windows.Forms.ToolStripMenuItem();
            this.парольToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxPassword = new System.Windows.Forms.ToolStripTextBox();
            this.PasswordToForm = new System.Windows.Forms.ToolStripMenuItem();
            this.PasswordFromForm = new System.Windows.Forms.ToolStripMenuItem();
            this.войтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.войтиГостемToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutorizationButton = new System.Windows.Forms.ToolStripMenuItem();
            this.RegistrationButton = new System.Windows.Forms.ToolStripMenuItem();
            this.действияСОкномToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonWindowShow = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonWindowHide = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиИзПриложенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxLogotip = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panelVault = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonGoest = new System.Windows.Forms.Button();
            this.buttonInput = new System.Windows.Forms.Button();
            this.buttonRegistration = new System.Windows.Forms.Button();
            this.textBoxOrganizationName = new System.Windows.Forms.TextBox();
            this.buttonConnectionString = new System.Windows.Forms.Button();
            this.pictureBoxOrganizationLogotip = new System.Windows.Forms.PictureBox();
            this.textBoxLogin = new OOO_Rythm.TextInput();
            this.textBoxPassword = new OOO_Rythm.TextInput();
            this.checkBoxShowPassword = new System.Windows.Forms.CheckBox();
            this.checkBoxSave = new System.Windows.Forms.CheckBox();
            this.contextMenuStripForm.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogotip)).BeginInit();
            this.panelVault.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrganizationLogotip)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIconApp
            // 
            this.notifyIconApp.ContextMenuStrip = this.contextMenuStripForm;
            this.notifyIconApp.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconApp.Icon")));
            this.notifyIconApp.Text = "notifyIcon1";
            this.notifyIconApp.Visible = true;
            this.notifyIconApp.Click += new System.EventHandler(this.notifyIconApp_Click);
            this.notifyIconApp.DoubleClick += new System.EventHandler(this.notifyIconApp_DoubleClick);
            this.notifyIconApp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconApp_MouseClick);
            // 
            // contextMenuStripForm
            // 
            this.contextMenuStripForm.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.contextMenuStripForm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.логинToolStripMenuItem,
            this.парольToolStripMenuItem,
            this.войтиToolStripMenuItem,
            this.действияСОкномToolStripMenuItem});
            this.contextMenuStripForm.Name = "contextMenuStripForm";
            this.contextMenuStripForm.Size = new System.Drawing.Size(237, 92);
            // 
            // логинToolStripMenuItem
            // 
            this.логинToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxLogin,
            this.LoginToForm,
            this.LoginFromForm});
            this.логинToolStripMenuItem.Name = "логинToolStripMenuItem";
            this.логинToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.логинToolStripMenuItem.Text = "Логин";
            // 
            // toolStripTextBoxLogin
            // 
            this.toolStripTextBoxLogin.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripTextBoxLogin.Name = "toolStripTextBoxLogin";
            this.toolStripTextBoxLogin.Size = new System.Drawing.Size(200, 24);
            // 
            // LoginToForm
            // 
            this.LoginToForm.Name = "LoginToForm";
            this.LoginToForm.Size = new System.Drawing.Size(274, 26);
            this.LoginToForm.Text = "Ввести в окно";
            this.LoginToForm.Click += new System.EventHandler(this.LoginToForm_Click);
            // 
            // LoginFromForm
            // 
            this.LoginFromForm.Name = "LoginFromForm";
            this.LoginFromForm.Size = new System.Drawing.Size(274, 26);
            this.LoginFromForm.Text = "Вывести из окна";
            this.LoginFromForm.Click += new System.EventHandler(this.LoginFromForm_Click);
            // 
            // парольToolStripMenuItem
            // 
            this.парольToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxPassword,
            this.PasswordToForm,
            this.PasswordFromForm});
            this.парольToolStripMenuItem.Name = "парольToolStripMenuItem";
            this.парольToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.парольToolStripMenuItem.Text = "Пароль";
            // 
            // toolStripTextBoxPassword
            // 
            this.toolStripTextBoxPassword.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripTextBoxPassword.Name = "toolStripTextBoxPassword";
            this.toolStripTextBoxPassword.Size = new System.Drawing.Size(200, 24);
            // 
            // PasswordToForm
            // 
            this.PasswordToForm.Name = "PasswordToForm";
            this.PasswordToForm.Size = new System.Drawing.Size(274, 26);
            this.PasswordToForm.Text = "Ввести в окно";
            this.PasswordToForm.Click += new System.EventHandler(this.PasswordToForm_Click);
            // 
            // PasswordFromForm
            // 
            this.PasswordFromForm.Name = "PasswordFromForm";
            this.PasswordFromForm.Size = new System.Drawing.Size(274, 26);
            this.PasswordFromForm.Text = "Вывести из окна";
            this.PasswordFromForm.Click += new System.EventHandler(this.PasswordFromForm_Click);
            // 
            // войтиToolStripMenuItem
            // 
            this.войтиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.войтиГостемToolStripMenuItem,
            this.AutorizationButton,
            this.RegistrationButton});
            this.войтиToolStripMenuItem.Name = "войтиToolStripMenuItem";
            this.войтиToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.войтиToolStripMenuItem.Text = "Войти";
            // 
            // войтиГостемToolStripMenuItem
            // 
            this.войтиГостемToolStripMenuItem.Name = "войтиГостемToolStripMenuItem";
            this.войтиГостемToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.войтиГостемToolStripMenuItem.Text = "Войти гостем";
            this.войтиГостемToolStripMenuItem.Click += new System.EventHandler(this.buttonGoest_Click);
            // 
            // AutorizationButton
            // 
            this.AutorizationButton.Name = "AutorizationButton";
            this.AutorizationButton.Size = new System.Drawing.Size(270, 26);
            this.AutorizationButton.Text = "Авторизироваться";
            this.AutorizationButton.Click += new System.EventHandler(this.AutorizationButton_Click);
            // 
            // RegistrationButton
            // 
            this.RegistrationButton.Name = "RegistrationButton";
            this.RegistrationButton.Size = new System.Drawing.Size(270, 26);
            this.RegistrationButton.Text = "Зарегистрироваться";
            this.RegistrationButton.Click += new System.EventHandler(this.RegistrationButton_Click);
            // 
            // действияСОкномToolStripMenuItem
            // 
            this.действияСОкномToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonWindowShow,
            this.buttonWindowHide,
            this.выйтиИзПриложенияToolStripMenuItem});
            this.действияСОкномToolStripMenuItem.Name = "действияСОкномToolStripMenuItem";
            this.действияСОкномToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.действияСОкномToolStripMenuItem.Text = "Действия с окном";
            // 
            // buttonWindowShow
            // 
            this.buttonWindowShow.Name = "buttonWindowShow";
            this.buttonWindowShow.Size = new System.Drawing.Size(280, 26);
            this.buttonWindowShow.Text = "Отобразить";
            // 
            // buttonWindowHide
            // 
            this.buttonWindowHide.Name = "buttonWindowHide";
            this.buttonWindowHide.Size = new System.Drawing.Size(280, 26);
            this.buttonWindowHide.Text = "Скрыть";
            // 
            // выйтиИзПриложенияToolStripMenuItem
            // 
            this.выйтиИзПриложенияToolStripMenuItem.Name = "выйтиИзПриложенияToolStripMenuItem";
            this.выйтиИзПриложенияToolStripMenuItem.Size = new System.Drawing.Size(280, 26);
            this.выйтиИзПриложенияToolStripMenuItem.Text = "Выйти из приложения";
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.Red;
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTitle.Controls.Add(this.tableLayoutPanel1);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(917, 90);
            this.panelTitle.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.26553F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.73446F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxLogotip, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonExit, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(913, 86);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBoxLogotip
            // 
            this.pictureBoxLogotip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxLogotip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLogotip.Image = global::OOO_Rythm.Properties.Resources.OOO_Rythm;
            this.pictureBoxLogotip.Location = new System.Drawing.Point(8, 8);
            this.pictureBoxLogotip.Margin = new System.Windows.Forms.Padding(8);
            this.pictureBoxLogotip.Name = "pictureBoxLogotip";
            this.pictureBoxLogotip.Size = new System.Drawing.Size(70, 70);
            this.pictureBoxLogotip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogotip.TabIndex = 0;
            this.pictureBoxLogotip.TabStop = false;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Font = new System.Drawing.Font("Lucida Console", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(94, 8);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(8);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(515, 70);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Авторизация";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExit.Location = new System.Drawing.Point(632, 15);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(15);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(266, 56);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // panelVault
            // 
            this.panelVault.BackColor = System.Drawing.Color.Red;
            this.panelVault.Controls.Add(this.statusStrip1);
            this.panelVault.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelVault.Location = new System.Drawing.Point(0, 468);
            this.panelVault.Name = "panelVault";
            this.panelVault.Size = new System.Drawing.Size(917, 79);
            this.panelVault.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDate,
            this.toolStripStatusLabelTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 56);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(917, 23);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelDate
            // 
            this.toolStripStatusLabelDate.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabelDate.Name = "toolStripStatusLabelDate";
            this.toolStripStatusLabelDate.Size = new System.Drawing.Size(218, 17);
            this.toolStripStatusLabelDate.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabelTime
            // 
            this.toolStripStatusLabelTime.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabelTime.Name = "toolStripStatusLabelTime";
            this.toolStripStatusLabelTime.Size = new System.Drawing.Size(218, 17);
            this.toolStripStatusLabelTime.Text = "toolStripStatusLabel1";
            // 
            // timerDateTime
            // 
            this.timerDateTime.Enabled = true;
            this.timerDateTime.Tick += new System.EventHandler(this.timerDateTime_Tick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.buttonConnectionString, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.pictureBoxOrganizationLogotip, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxLogin, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBoxPassword, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxShowPassword, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxSave, 2, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 90);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.37037F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.43386F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(917, 378);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel5, 4);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.14819F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.70362F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.03842F));
            this.tableLayoutPanel5.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.textBoxOrganizationName, 2, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 190);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(911, 57);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(141, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 51);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.buttonGoest, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonInput, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonRegistration, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(625, 47);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // buttonGoest
            // 
            this.buttonGoest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGoest.Location = new System.Drawing.Point(5, 5);
            this.buttonGoest.Margin = new System.Windows.Forms.Padding(5);
            this.buttonGoest.Name = "buttonGoest";
            this.buttonGoest.Size = new System.Drawing.Size(198, 37);
            this.buttonGoest.TabIndex = 0;
            this.buttonGoest.Text = "Гость";
            this.buttonGoest.UseVisualStyleBackColor = true;
            this.buttonGoest.Click += new System.EventHandler(this.buttonGoest_Click);
            // 
            // buttonInput
            // 
            this.buttonInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonInput.Location = new System.Drawing.Point(213, 5);
            this.buttonInput.Margin = new System.Windows.Forms.Padding(5);
            this.buttonInput.Name = "buttonInput";
            this.buttonInput.Size = new System.Drawing.Size(198, 37);
            this.buttonInput.TabIndex = 1;
            this.buttonInput.Text = "Войти";
            this.buttonInput.UseVisualStyleBackColor = true;
            this.buttonInput.Click += new System.EventHandler(this.buttonInput_Click);
            // 
            // buttonRegistration
            // 
            this.buttonRegistration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRegistration.Location = new System.Drawing.Point(421, 5);
            this.buttonRegistration.Margin = new System.Windows.Forms.Padding(5);
            this.buttonRegistration.Name = "buttonRegistration";
            this.buttonRegistration.Size = new System.Drawing.Size(199, 37);
            this.buttonRegistration.TabIndex = 2;
            this.buttonRegistration.Text = "Зарегистрироваться";
            this.buttonRegistration.UseVisualStyleBackColor = true;
            this.buttonRegistration.Click += new System.EventHandler(this.buttonRegistration_Click);
            // 
            // textBoxOrganizationName
            // 
            this.textBoxOrganizationName.BackColor = System.Drawing.Color.White;
            this.textBoxOrganizationName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOrganizationName.Location = new System.Drawing.Point(776, 3);
            this.textBoxOrganizationName.Name = "textBoxOrganizationName";
            this.textBoxOrganizationName.ReadOnly = true;
            this.textBoxOrganizationName.Size = new System.Drawing.Size(132, 24);
            this.textBoxOrganizationName.TabIndex = 1;
            this.textBoxOrganizationName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonConnectionString
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.buttonConnectionString, 2);
            this.buttonConnectionString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonConnectionString.Location = new System.Drawing.Point(234, 318);
            this.buttonConnectionString.Margin = new System.Windows.Forms.Padding(5);
            this.buttonConnectionString.Name = "buttonConnectionString";
            this.buttonConnectionString.Size = new System.Drawing.Size(448, 55);
            this.buttonConnectionString.TabIndex = 6;
            this.buttonConnectionString.Text = "Строка подключения";
            this.buttonConnectionString.UseVisualStyleBackColor = true;
            this.buttonConnectionString.Click += new System.EventHandler(this.buttonConnectionString_Click);
            // 
            // pictureBoxOrganizationLogotip
            // 
            this.pictureBoxOrganizationLogotip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxOrganizationLogotip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxOrganizationLogotip.Location = new System.Drawing.Point(707, 20);
            this.pictureBoxOrganizationLogotip.Margin = new System.Windows.Forms.Padding(20);
            this.pictureBoxOrganizationLogotip.Name = "pictureBoxOrganizationLogotip";
            this.tableLayoutPanel2.SetRowSpan(this.pictureBoxOrganizationLogotip, 3);
            this.pictureBoxOrganizationLogotip.Size = new System.Drawing.Size(190, 147);
            this.pictureBoxOrganizationLogotip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOrganizationLogotip.TabIndex = 7;
            this.pictureBoxOrganizationLogotip.TabStop = false;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textBoxLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLogin.InputBackColor = System.Drawing.SystemColors.Window;
            this.textBoxLogin.InputForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxLogin.InputText = "";
            this.textBoxLogin.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxLogin.Location = new System.Drawing.Point(233, 66);
            this.textBoxLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxLogin.MinimumSize = new System.Drawing.Size(124, 53);
            this.textBoxLogin.MultiLine = false;
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.NoReadOnly = true;
            this.textBoxLogin.PasswordChar = '\0';
            this.textBoxLogin.ReadOnly = false;
            this.textBoxLogin.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxLogin.Size = new System.Drawing.Size(221, 71);
            this.textBoxLogin.TabIndex = 9;
            this.textBoxLogin.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textBoxLogin.Title = "Логин";
            this.textBoxLogin.UseSystemPasswordChar = false;
            this.textBoxLogin.Value = "";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textBoxPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPassword.InputBackColor = System.Drawing.SystemColors.Window;
            this.textBoxPassword.InputForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxPassword.InputText = "";
            this.textBoxPassword.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxPassword.Location = new System.Drawing.Point(462, 66);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxPassword.MinimumSize = new System.Drawing.Size(124, 53);
            this.textBoxPassword.MultiLine = false;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.NoReadOnly = true;
            this.textBoxPassword.PasswordChar = '●';
            this.textBoxPassword.ReadOnly = false;
            this.textBoxPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxPassword.Size = new System.Drawing.Size(221, 71);
            this.textBoxPassword.TabIndex = 10;
            this.textBoxPassword.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textBoxPassword.Title = "Пароль";
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.Value = "";
            // 
            // checkBoxShowPassword
            // 
            this.checkBoxShowPassword.AutoSize = true;
            this.checkBoxShowPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxShowPassword.Location = new System.Drawing.Point(237, 140);
            this.checkBoxShowPassword.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.checkBoxShowPassword.Name = "checkBoxShowPassword";
            this.checkBoxShowPassword.Size = new System.Drawing.Size(213, 47);
            this.checkBoxShowPassword.TabIndex = 4;
            this.checkBoxShowPassword.Text = "Показывать пароль";
            this.checkBoxShowPassword.UseVisualStyleBackColor = true;
            this.checkBoxShowPassword.CheckedChanged += new System.EventHandler(this.checkBoxShowPassword_CheckedChanged);
            // 
            // checkBoxSave
            // 
            this.checkBoxSave.AutoSize = true;
            this.checkBoxSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxSave.Location = new System.Drawing.Point(461, 143);
            this.checkBoxSave.Name = "checkBoxSave";
            this.checkBoxSave.Size = new System.Drawing.Size(223, 41);
            this.checkBoxSave.TabIndex = 8;
            this.checkBoxSave.Text = "Запомнить учётные данные";
            this.checkBoxSave.UseVisualStyleBackColor = true;
            this.checkBoxSave.CheckedChanged += new System.EventHandler(this.checkBoxSave_CheckedChanged_1);
            // 
            // Autorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(917, 547);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panelVault);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSize = new System.Drawing.Size(1435, 800);
            this.MinimumSize = new System.Drawing.Size(765, 480);
            this.Name = "Autorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Autorization_FormClosing);
            this.Load += new System.EventHandler(this.Pattern_Load);
            this.contextMenuStripForm.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogotip)).EndInit();
            this.panelVault.ResumeLayout(false);
            this.panelVault.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrganizationLogotip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconApp;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxLogotip;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Panel panelVault;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTime;
        private System.Windows.Forms.Timer timerDateTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox checkBoxShowPassword;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button buttonGoest;
        private System.Windows.Forms.Button buttonInput;
        private System.Windows.Forms.Button buttonRegistration;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonConnectionString;
        private System.Windows.Forms.PictureBox pictureBoxOrganizationLogotip;
        private System.Windows.Forms.TextBox textBoxOrganizationName;
        private System.Windows.Forms.CheckBox checkBoxSave;
        private TextInput textBoxLogin;
        private TextInput textBoxPassword;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripForm;
        private System.Windows.Forms.ToolStripMenuItem логинToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxLogin;
        private System.Windows.Forms.ToolStripMenuItem LoginToForm;
        private System.Windows.Forms.ToolStripMenuItem LoginFromForm;
        private System.Windows.Forms.ToolStripMenuItem парольToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxPassword;
        private System.Windows.Forms.ToolStripMenuItem PasswordToForm;
        private System.Windows.Forms.ToolStripMenuItem PasswordFromForm;
        private System.Windows.Forms.ToolStripMenuItem войтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem войтиГостемToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AutorizationButton;
        private System.Windows.Forms.ToolStripMenuItem RegistrationButton;
        private System.Windows.Forms.ToolStripMenuItem действияСОкномToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonWindowShow;
        private System.Windows.Forms.ToolStripMenuItem buttonWindowHide;
        private System.Windows.Forms.ToolStripMenuItem выйтиИзПриложенияToolStripMenuItem;
    }
}

