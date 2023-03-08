using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace OOO_Rythm
{
    /// <summary>
    /// Ячейка таблицы
    /// </summary>
    public class TableDataBaseCell
    {
        public TableDataBaseCell()
        {
        }

        public TableDataBaseCell(string name) : this()
        {
            Name = name;
        }

        public TableDataBaseCell(TableDataBaseColumn column) : this(column.Name)
        {
            
        }

        public TableDataBaseCell(string name, object valueCell, Comparison comparison = Comparison.Equals) : this(name)
        {
            Value = valueCell;
            Comparison = comparison;
        }

        public TableDataBaseCell(TableDataBaseCell cell) : this(cell.Name, cell.Value, cell.Comparison)
        {

        }

        Comparison comparison = Comparison.Equals;

        public Comparison Comparison
        {
            get => comparison;
            set => comparison = value;
        }


        public string ParamName => $"@{Name}";
        public string ParamName1 => $"@{Name1}";


        public string ComparisonText()
        {
            if (Comparison == Comparison.Equals)
                return " = ";
            if (Comparison == Comparison.NoEquals)
                return " <> ";
            if(Comparison == Comparison.More)
                return " > ";
            if (Comparison == Comparison.Less)
                return " < ";
            if (Comparison == Comparison.MoreOrEqual)
                return " >= ";
            if (Comparison == Comparison.LessOrEqual)
                return " <= ";
            if (Comparison == Comparison.Like)
                return " Like ";
            if (Comparison == Comparison.NotLike)
                return " Not Like ";
            if (Comparison == Comparison.Is)
            {
                return " is ";
            }
            return "";

        }

        public string Condition
        {
            get
            {
                if(Comparison == Comparison.Like || Comparison == Comparison.NotLike)
                {
                    return Name + ComparisonText() + "'%'+" + ParamName + "+'%'";
                }
                return Name + ComparisonText() + ParamName;
            }
        }

        public string Condition1
        {
            get
            {
                if (Comparison == Comparison.Like || Comparison == Comparison.NotLike)
                {
                    return Name + ComparisonText() + "'%'+" + ParamName1 + "+'%'";
                }
                return Name + ComparisonText() + ParamName1;
            }
        }


        string name = "";
        public string Name
        {
            get => name;
            set => name = value;
        }

        string name1 = "";
        public string Name1
        {
            get => name1;
            set => name1 = value;
        }



        object valueCell = "";

        public object Value
        {
            get => valueCell;
            set => valueCell = value;
        }

        public string GetString()
        {
            return (string)Value;
        }

        public void SetString(string text)
        {
             Value = text;
        }

        public string TextValue
        {
            get => GetString();
            set => SetString(value);
        }

        public bool GetBoolean()
        {
            return (bool)Value;
        }

        public void SetBoolean(bool text)
        {
            Value = text;
        }

        public bool BooleanValue
        {
            get => GetBoolean();
            set => SetBoolean(value);
        }

        public int GetInt32()
        {
            return (int)Value;
        }

        public void SetInt32(int text)
        {
            Value = text;
        }

        public int Int32Value
        {
            get => GetInt32();
            set => SetInt32(value);
        }

        public float GetFloat()
        {
            return (float)Value;
        }

        public void SetFloat(float text)
        {
            Value = text;
        }

        public float FloatValue
        {
            get => GetFloat();
            set => SetFloat(value);
        }

        public double GetDouble()
        {
            return (double)Value;
        }

        public void SetDouble(double text)
        {
            Value = text;
        }

        public double DoubleValue
        {
            get => GetDouble();
            set => SetDouble(value);
        }

        public decimal GetDecimal()
        {
            return (decimal)Value;
        }

        public void SetDecimal(decimal text)
        {
            Value = text;
        }

        public decimal DecimalValue
        {
            get => GetDecimal();
            set => SetDecimal(value);
        }

        public DateTime GetDateTime()
        {
            return (DateTime)Value;
        }

        public void SetDateTime(DateTime text)
        {
            Value = text;
        }

        public DateTime DateTimeValue
        {
            get => GetDateTime();
            set => SetDateTime(value);
        }

        public byte GetByte()
        {
            return (byte)Value;
        }

        public void SetByte(byte text)
        {
            Value = text;
        }

        public byte ByteValue
        {
            get => GetByte();
            set => SetByte(value);
        }

        public byte[] GetBytes()
        {
            return (byte[])Value;
        }

        public void SetBytes(byte[] text)
        {
            Value = text;
        }

        public byte[] BytesValue
        {
            get => GetBytes();
            set => SetBytes(value);
        }

        public Bitmap GetImage()
        {
            MemoryStream memory = new MemoryStream(GetBytes());
            Bitmap bit = new Bitmap(memory);
            memory.Close();
            return bit;
        }

        public void SetImage(Bitmap text)
        {
            MemoryStream memory = new MemoryStream();
            text.Save(memory, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] result = memory.ToArray();
            memory.Close();
            Value = result;
        }

        public Bitmap ImageValue
        {
            get => GetImage();
            set => SetImage(value);
        }

        public char GetChar()
        {
            return (char)Value;
        }

        public void SetChar(char text)
        {
            Value = text;
        }

        public char CharValue
        {
            get => GetChar();
            set => SetChar(value);
        }

        

    }

    /// <summary>
    /// Сравнение
    /// </summary>
    public enum Comparison
    {
        /// <summary>
        /// = (Равно)
        /// </summary>
        Equals,
        /// <summary>
        ///  Не равно 
        /// </summary>
        NoEquals,
        /// <summary>
        /// > (Больше)
        /// </summary>
        More,
        /// <summary>
        /// Меньше
        /// </summary>
        Less,
        /// <summary>
        /// Менбше или равно
        /// </summary>
        LessOrEqual,
        /// <summary>
        /// >= (Больше или равно)
        /// </summary>
        MoreOrEqual,
        /// <summary>
        /// Like
        /// </summary>
        Like,
        /// <summary>
        /// Not Like
        /// </summary>
        NotLike,
        /// <summary>
        /// is
        /// </summary>
        Is,
        /// <summary>
        /// Is null
        /// </summary>
        IsNull,
        /// <summary>
        /// Is Not Null
        /// </summary>
        IsNotNull
    }
}
