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
    public partial class NumericControlWithName : UserControl
    {
        public NumericControlWithName()
        {
            InitializeComponent();
        }

        public event Action<object, EventArgs> ValueChanged;

        private void NumericControlWithName_Load(object sender, EventArgs e)
        {

            width = tableLayoutPanelPole.ColumnStyles[1].Width;
            textBoxInput.ValueChanged += (s, ea) => ValueChanged?.Invoke(s, ea);
        }

        float width;
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

        public void Clear()
        {
            textBoxInput.Value = 0;
        }

        public decimal Value
        {
            get => textBoxInput.Value;
            set => textBoxInput.Value = value;
        }

        public decimal Minimum
        {
            get => textBoxInput.Minimum;
            set => textBoxInput.Minimum = value;
        }

        public decimal Maximum
        {
            get => textBoxInput.Maximum;
            set => textBoxInput.Maximum = value;
        }

        public int DecimalPlaces
        {
            get => textBoxInput.DecimalPlaces;
            set => textBoxInput.DecimalPlaces = value;
        }

        public bool ReadOnly
        {
            get => !textBoxInput.Enabled;
            set
            {
                textBoxInput.Enabled = !value;
            }
        }


        public bool NoReadOnly
        {
            get => !ReadOnly;
            set => ReadOnly = !value;
        }

        public Color InputBackColor
        {
            get => textBoxInput.BackColor;
            set => textBoxInput.BackColor = value;
        }

        public Color InputForeColor
        {
            get => textBoxInput.ForeColor;
            set => textBoxInput.ForeColor = value;
        }

        public void SetReadOnlyOrNoReadOnly()
        {
            bool readOnly = ReadOnly;
            NoReadOnly = readOnly;
            readOnly = ReadOnly;
            NoReadOnly = readOnly;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {

            Clear();

        }

        private void textBoxInput_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void textBoxInput_EnabledChanged(object sender, EventArgs e)
        {
            buttonClear.Visible = NoReadOnly;
        }

        private void buttonClear_VisibleChanged(object sender, EventArgs e)
        {
            bool visible = (sender as Button).Visible;
            float width = this.width;
            if (!visible)
                width = 5;
            tableLayoutPanelPole.ColumnStyles[1].Width = width;
            
        }

        public decimal Incriment
        {
            get => textBoxInput.Increment;
            set => textBoxInput.Increment = value;
        }

    }
}
