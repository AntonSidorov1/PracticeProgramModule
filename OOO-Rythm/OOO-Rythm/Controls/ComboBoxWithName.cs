using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOO_Rythm.Controls
{
    public partial class ComboBoxWithName : UserControl
    {
        public ComboBoxWithName()
        {
            InitializeComponent();
        }


        public event Action<object, EventArgs> SelectedIndexChanged;


        private void ComboBoxWithName_Load(object sender, EventArgs e)
        {


            comboBoxValues.SelectedIndexChanged += (s, ea) => SelectedIndexChanged?.Invoke(s, ea);
        }

        public new BorderStyle BorderStyle
        {
            get => panelBorder.BorderStyle;
            set => panelBorder.BorderStyle = value;
        }

        public string Title
        {
            get => groupBoxTitle.Text;
            set => groupBoxTitle.Text = value;
        }

        public bool ReadOnly
        {
            get => !comboBoxValues.Enabled;
            set => comboBoxValues.Enabled = !value;
        }

        public ComboBox.ObjectCollection Items => comboBoxValues.Items;

        public int SelectedIndex
        {
            get => comboBoxValues.SelectedIndex;
            set => comboBoxValues.SelectedIndex = value;
        }

        public bool NoReadOnly
        {
            get => !ReadOnly;
            set => ReadOnly = !value;
        }

        public ComboBoxStyle DropDownStyle
        {
            get => comboBoxValues.DropDownStyle;
            set => comboBoxValues.DropDownStyle = value;
        }
    }
}
