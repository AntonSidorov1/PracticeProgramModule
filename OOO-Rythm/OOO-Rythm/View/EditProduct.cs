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
        }

        public EditProduct(Role role) : this()
        {
            Role = role;

            
        }

        public EditProduct(Role role, Product product) : this(role)
        {

        }

        Role role;

        public Role Role
        {
            get => role;
            set => role = value;
        }

        private void Pattern_Load(object sender, EventArgs e)
        {

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
    }
}
