using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rythm
{
    /// <summary>
    /// Параметр сортировки
    /// </summary>
    public class SortParameter
    {
        public SortParameter()
        {
        }

        public SortParameter(string column)
        {
            Column = column;
        }

        public SortParameter(string column, Sort sort) : this(column)
        {
            Sort = sort;
        }

        string column = "";

        /// <summary>
        /// Сортируемый столбец таблицы
        /// </summary>
        public string Column
        {
            get => column;
            set => column = value;
        }

        Sort sort = Sort.no;

        /// <summary>
        /// Параметр сортировки
        /// </summary>
        public Sort Sort
        {
            get => sort;
            set => sort = value;
        }

        /// <summary>
        /// Параметр сортировки
        /// </summary>
        public string SortText => $"{Sort}";

        /// <summary>
        /// Текст параметра сортировки
        /// </summary>
        public string OrderBy => Column + " " + SortText;
    }

    public enum Sort
    {
        no,
        asc,
        desc
    }
}
