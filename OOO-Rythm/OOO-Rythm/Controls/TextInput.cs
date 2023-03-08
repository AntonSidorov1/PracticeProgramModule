﻿using System;
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
    public partial class TextInput : UserControl
    {
        public TextInput()
        {
            InitializeComponent();
            PasswordChar = '\0';
        }

        public static bool NullText(string text)
        {
            return text == "" || text.Equals("") || text is null || text == null;
        }

        public bool NullValue => NullText(Value);

        private void TextInput_Load(object sender, EventArgs e)
        {
            textBoxInput.TextChanged += (s, ea) => InputText_Changed?.Invoke(this, ea);
        }

        public bool ReadOnly
        {
            get => textBoxInput.ReadOnly;
            set => textBoxInput.ReadOnly = value;
        }

        public string Title
        {
            get => groupBoxTitle.Text;
            set => groupBoxTitle.Text = value;
        }

        public override string Text { get => textBoxInput.Text; set => textBoxInput.Text = value; }

        public string Value { get => Text; set => Text = value; }

        public string InputText { get => Text; set => Text = value; }

        public event Action<object, EventArgs> InputText_Changed;
        

        public bool MultiLine
        {
            get => textBoxInput.Multiline;
            set => textBoxInput.Multiline = value;
        }

        public ScrollBars TextScrollBar
        {
            get => textBoxInput.ScrollBars;
            set => textBoxInput.ScrollBars = value;

        }

        public HorizontalAlignment InputTextAlign
        {
            get => textBoxInput.TextAlign;
            set => textBoxInput.TextAlign = value;
        }
        

        public void Clear()
        {
            textBoxInput.Text = "";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {

            Clear();
            
        }

        public bool UseSystemPasswordChar
        {
            get => textBoxInput.UseSystemPasswordChar;
            set => textBoxInput.UseSystemPasswordChar = value;
        }

        public char PasswordChar
        {
            get => textBoxInput.PasswordChar;
            set => textBoxInput.PasswordChar = value;
        }


        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBoxTitle_Enter(object sender, EventArgs e)
        {

        }
    }
}
