
namespace OOO_Rythm
{
    partial class DataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataForm));
            this.notifyIconApp = new System.Windows.Forms.NotifyIcon(this.components);
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
            this.textInputPassword = new OOO_Rythm.TextInput();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxShowPassword = new System.Windows.Forms.CheckBox();
            this.buttonSavePassword = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonClearFIO = new System.Windows.Forms.Button();
            this.buttonSaveFIO = new System.Windows.Forms.Button();
            this.textInputFamily = new OOO_Rythm.TextInput();
            this.textInputName = new OOO_Rythm.TextInput();
            this.textInputLastName = new OOO_Rythm.TextInput();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.textInputEmail = new OOO_Rythm.TextInput();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.textInputTelephone = new OOO_Rythm.TextInput();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.действияВТелефономToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddTelephone = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTelephone = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxTelephone = new System.Windows.Forms.ComboBox();
            this.comboBoxEmail = new System.Windows.Forms.ComboBox();
            this.panelTitle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogotip)).BeginInit();
            this.panelVault.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIconApp
            // 
            this.notifyIconApp.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconApp.Icon")));
            this.notifyIconApp.Text = "notifyIcon1";
            this.notifyIconApp.Visible = true;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.Red;
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTitle.Controls.Add(this.tableLayoutPanel1);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(798, 90);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(794, 86);
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
            this.labelTitle.Size = new System.Drawing.Size(439, 70);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Данные пользователя";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExit.Location = new System.Drawing.Point(556, 15);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(15);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(223, 56);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Назад";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // panelVault
            // 
            this.panelVault.BackColor = System.Drawing.Color.Red;
            this.panelVault.Controls.Add(this.statusStrip1);
            this.panelVault.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelVault.Location = new System.Drawing.Point(0, 478);
            this.panelVault.Name = "panelVault";
            this.panelVault.Size = new System.Drawing.Size(798, 79);
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
            this.statusStrip1.Size = new System.Drawing.Size(798, 23);
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
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel2.Controls.Add(this.textInputPassword, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.buttonDelete, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.buttonClearFIO, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.buttonSaveFIO, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.textInputFamily, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.textInputName, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.textInputLastName, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel6, 2, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 90);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.59538F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.52601F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.87861F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(798, 388);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // textInputPassword
            // 
            this.textInputPassword.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputPassword.InputText = "";
            this.textInputPassword.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputPassword.Location = new System.Drawing.Point(24, 290);
            this.textInputPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textInputPassword.MinimumSize = new System.Drawing.Size(124, 53);
            this.textInputPassword.MultiLine = false;
            this.textInputPassword.Name = "textInputPassword";
            this.textInputPassword.PasswordChar = '●';
            this.textInputPassword.Size = new System.Drawing.Size(231, 74);
            this.textInputPassword.TabIndex = 0;
            this.textInputPassword.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textInputPassword.Title = "Пароль";
            this.textInputPassword.UseSystemPasswordChar = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.checkBoxShowPassword, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonSavePassword, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(262, 290);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(233, 74);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // checkBoxShowPassword
            // 
            this.checkBoxShowPassword.AutoSize = true;
            this.checkBoxShowPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxShowPassword.Location = new System.Drawing.Point(3, 3);
            this.checkBoxShowPassword.Name = "checkBoxShowPassword";
            this.checkBoxShowPassword.Size = new System.Drawing.Size(227, 31);
            this.checkBoxShowPassword.TabIndex = 1;
            this.checkBoxShowPassword.Text = "Показывать пароль";
            this.checkBoxShowPassword.UseVisualStyleBackColor = true;
            this.checkBoxShowPassword.CheckedChanged += new System.EventHandler(this.checkBoxShowPassword_CheckedChanged);
            // 
            // buttonSavePassword
            // 
            this.buttonSavePassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSavePassword.Location = new System.Drawing.Point(3, 40);
            this.buttonSavePassword.Name = "buttonSavePassword";
            this.buttonSavePassword.Size = new System.Drawing.Size(227, 31);
            this.buttonSavePassword.TabIndex = 2;
            this.buttonSavePassword.Text = "Сохранить пароль";
            this.buttonSavePassword.UseVisualStyleBackColor = true;
            this.buttonSavePassword.Click += new System.EventHandler(this.buttonSavePassword_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelete.Location = new System.Drawing.Point(518, 307);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(20);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(199, 40);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Удалить аккаунт";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonClearFIO
            // 
            this.buttonClearFIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClearFIO.Location = new System.Drawing.Point(23, 141);
            this.buttonClearFIO.Name = "buttonClearFIO";
            this.buttonClearFIO.Size = new System.Drawing.Size(233, 43);
            this.buttonClearFIO.TabIndex = 4;
            this.buttonClearFIO.Text = "Сбросить ФИО";
            this.buttonClearFIO.UseVisualStyleBackColor = true;
            this.buttonClearFIO.Click += new System.EventHandler(this.buttonClearFIO_Click);
            // 
            // buttonSaveFIO
            // 
            this.buttonSaveFIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSaveFIO.Location = new System.Drawing.Point(501, 141);
            this.buttonSaveFIO.Name = "buttonSaveFIO";
            this.buttonSaveFIO.Size = new System.Drawing.Size(233, 43);
            this.buttonSaveFIO.TabIndex = 5;
            this.buttonSaveFIO.Text = "Сохранить ФИО";
            this.buttonSaveFIO.UseVisualStyleBackColor = true;
            this.buttonSaveFIO.Click += new System.EventHandler(this.buttonSaveFIO_Click);
            // 
            // textInputFamily
            // 
            this.textInputFamily.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputFamily.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputFamily.InputText = "";
            this.textInputFamily.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputFamily.Location = new System.Drawing.Point(24, 23);
            this.textInputFamily.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textInputFamily.MinimumSize = new System.Drawing.Size(124, 53);
            this.textInputFamily.MultiLine = false;
            this.textInputFamily.Name = "textInputFamily";
            this.textInputFamily.PasswordChar = '\0';
            this.textInputFamily.Size = new System.Drawing.Size(231, 112);
            this.textInputFamily.TabIndex = 6;
            this.textInputFamily.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textInputFamily.Title = "Фамилия";
            this.textInputFamily.UseSystemPasswordChar = false;
            // 
            // textInputName
            // 
            this.textInputName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputName.InputText = "";
            this.textInputName.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputName.Location = new System.Drawing.Point(263, 23);
            this.textInputName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textInputName.MinimumSize = new System.Drawing.Size(124, 53);
            this.textInputName.MultiLine = false;
            this.textInputName.Name = "textInputName";
            this.textInputName.PasswordChar = '\0';
            this.textInputName.Size = new System.Drawing.Size(231, 112);
            this.textInputName.TabIndex = 7;
            this.textInputName.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textInputName.Title = "Имя";
            this.textInputName.UseSystemPasswordChar = false;
            // 
            // textInputLastName
            // 
            this.textInputLastName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputLastName.Dock = System.Windows.Forms.DockStyle.Right;
            this.textInputLastName.InputText = "";
            this.textInputLastName.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputLastName.Location = new System.Drawing.Point(503, 23);
            this.textInputLastName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textInputLastName.MinimumSize = new System.Drawing.Size(124, 53);
            this.textInputLastName.MultiLine = false;
            this.textInputLastName.Name = "textInputLastName";
            this.textInputLastName.PasswordChar = '\0';
            this.textInputLastName.Size = new System.Drawing.Size(230, 112);
            this.textInputLastName.TabIndex = 8;
            this.textInputLastName.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textInputLastName.Title = "Отчество";
            this.textInputLastName.UseSystemPasswordChar = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.textInputEmail, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.menuStrip1, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(23, 190);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(233, 94);
            this.tableLayoutPanel4.TabIndex = 9;
            // 
            // textInputEmail
            // 
            this.textInputEmail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputEmail.InputText = "";
            this.textInputEmail.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputEmail.Location = new System.Drawing.Point(4, 3);
            this.textInputEmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textInputEmail.MinimumSize = new System.Drawing.Size(124, 53);
            this.textInputEmail.MultiLine = false;
            this.textInputEmail.Name = "textInputEmail";
            this.textInputEmail.PasswordChar = '\0';
            this.textInputEmail.Size = new System.Drawing.Size(225, 56);
            this.textInputEmail.TabIndex = 0;
            this.textInputEmail.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textInputEmail.Title = "E-mail";
            this.textInputEmail.UseSystemPasswordChar = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emailToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 62);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(233, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddEmail,
            this.RemoveEmail});
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(192, 21);
            this.emailToolStripMenuItem.Text = "Действия с E-mail";
            // 
            // AddEmail
            // 
            this.AddEmail.Name = "AddEmail";
            this.AddEmail.Size = new System.Drawing.Size(170, 26);
            this.AddEmail.Text = "Добавить";
            this.AddEmail.Click += new System.EventHandler(this.AddEmail_Click);
            // 
            // RemoveEmail
            // 
            this.RemoveEmail.Name = "RemoveEmail";
            this.RemoveEmail.Size = new System.Drawing.Size(170, 26);
            this.RemoveEmail.Text = "Удалить";
            this.RemoveEmail.Click += new System.EventHandler(this.RemoveEmail_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.textInputTelephone, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.menuStrip2, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(501, 190);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(233, 94);
            this.tableLayoutPanel5.TabIndex = 10;
            // 
            // textInputTelephone
            // 
            this.textInputTelephone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputTelephone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputTelephone.InputText = "";
            this.textInputTelephone.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputTelephone.Location = new System.Drawing.Point(4, 3);
            this.textInputTelephone.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textInputTelephone.MinimumSize = new System.Drawing.Size(124, 53);
            this.textInputTelephone.MultiLine = false;
            this.textInputTelephone.Name = "textInputTelephone";
            this.textInputTelephone.PasswordChar = '\0';
            this.textInputTelephone.Size = new System.Drawing.Size(225, 56);
            this.textInputTelephone.TabIndex = 0;
            this.textInputTelephone.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textInputTelephone.Title = "Телефон";
            this.textInputTelephone.UseSystemPasswordChar = false;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.действияВТелефономToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 62);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(233, 25);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // действияВТелефономToolStripMenuItem
            // 
            this.действияВТелефономToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTelephone,
            this.DeleteTelephone});
            this.действияВТелефономToolStripMenuItem.Name = "действияВТелефономToolStripMenuItem";
            this.действияВТелефономToolStripMenuItem.Size = new System.Drawing.Size(222, 21);
            this.действияВТелефономToolStripMenuItem.Text = "Действия в телефоном";
            // 
            // AddTelephone
            // 
            this.AddTelephone.Name = "AddTelephone";
            this.AddTelephone.Size = new System.Drawing.Size(170, 26);
            this.AddTelephone.Text = "Добавить";
            this.AddTelephone.Click += new System.EventHandler(this.AddTelephone_Click);
            // 
            // DeleteTelephone
            // 
            this.DeleteTelephone.Name = "DeleteTelephone";
            this.DeleteTelephone.Size = new System.Drawing.Size(170, 26);
            this.DeleteTelephone.Text = "Удалить";
            this.DeleteTelephone.Click += new System.EventHandler(this.DeleteTelephone_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Controls.Add(this.comboBoxTelephone, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.comboBoxEmail, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(262, 190);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(233, 94);
            this.tableLayoutPanel6.TabIndex = 11;
            // 
            // comboBoxTelephone
            // 
            this.comboBoxTelephone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTelephone.FormattingEnabled = true;
            this.comboBoxTelephone.Location = new System.Drawing.Point(3, 50);
            this.comboBoxTelephone.Name = "comboBoxTelephone";
            this.comboBoxTelephone.Size = new System.Drawing.Size(227, 25);
            this.comboBoxTelephone.TabIndex = 1;
            this.comboBoxTelephone.SelectedIndexChanged += new System.EventHandler(this.comboBoxTelephone_SelectedIndexChanged);
            this.comboBoxTelephone.EnabledChanged += new System.EventHandler(this.comboBoxTelephone_EnabledChanged);
            // 
            // comboBoxEmail
            // 
            this.comboBoxEmail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEmail.FormattingEnabled = true;
            this.comboBoxEmail.Location = new System.Drawing.Point(3, 3);
            this.comboBoxEmail.Name = "comboBoxEmail";
            this.comboBoxEmail.Size = new System.Drawing.Size(227, 25);
            this.comboBoxEmail.TabIndex = 0;
            this.comboBoxEmail.SelectedIndexChanged += new System.EventHandler(this.comboBoxEmail_SelectedIndexChanged);
            this.comboBoxEmail.EnabledChanged += new System.EventHandler(this.comboBoxEmail_EnabledChanged);
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(798, 557);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panelVault);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Pattern_Load);
            this.panelTitle.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogotip)).EndInit();
            this.panelVault.ResumeLayout(false);
            this.panelVault.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
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
        private TextInput textInputPassword;
        private System.Windows.Forms.CheckBox checkBoxShowPassword;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonSavePassword;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonClearFIO;
        private System.Windows.Forms.Button buttonSaveFIO;
        private TextInput textInputFamily;
        private TextInput textInputName;
        private TextInput textInputLastName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private TextInput textInputEmail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private TextInput textInputTelephone;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddEmail;
        private System.Windows.Forms.ToolStripMenuItem RemoveEmail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.ComboBox comboBoxEmail;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem действияВТелефономToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddTelephone;
        private System.Windows.Forms.ToolStripMenuItem DeleteTelephone;
        private System.Windows.Forms.ComboBox comboBoxTelephone;
    }
}

