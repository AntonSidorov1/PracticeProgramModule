using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace OOO_Rythm
{
    /// <summary>
    /// Запрос к базе данных
    /// </summary>
    public class DataBaseQuery : ConnectionDataBase
    {
        

        public DataBaseQuery()
        {
        }

        public DataBaseQuery(SqlConnectionStringBuilder builder) : base(builder)
        {
        }

        public DataBaseQuery(string connectionString) : base(connectionString)
        {
        }

        public DataBaseQuery(ConnectionDataBase bulder) : base(bulder)
        {
        }

        public DataBaseQuery(string DataSource, string InitialCatalog, bool IntegratedSecurity, bool PersistSecurityInfo, string UserID, string Password, bool LocalServer = true) : base(DataSource, InitialCatalog, IntegratedSecurity, PersistSecurityInfo, UserID, Password, LocalServer)
        {
        }

        TableDataBaseRowsCollection conditions = new TableDataBaseRowsCollection();

        /// <summary>
        /// Условия (по горизонтале - and, по вертикале - or)
        /// </summary>
        public TableDataBaseRowsCollection Conditions => conditions;

        public TableDataBaseRowsCollection Conditions1
        {
            get
            {
                TableDataBaseRow inputs = InputValues1;
                TableDataBaseRowsCollection table = new TableDataBaseRowsCollection();

                for(int i =0; i < Conditions.Count; i++)
                {
                    TableDataBaseRow row1 = Conditions[i];
                    TableDataBaseRow row = new TableDataBaseRow();
                    for(int j =0; j < row1.Count; j++)
                    {
                        TableDataBaseCell cell = new TableDataBaseCell(Conditions[i][j]);
                        string name = cell.Name;
                        string name1 = name;
                        int index = 0;
                        while (table.Contains(name1, true) || inputs.Contains(name1, true))
                        {
                            name1 = name + $"{index}";
                            index++;
                        }
                        cell.Name1 = name1;
                        row.Add(cell);
                    }
                    table.Add(row);
                }


                return table;
            }
        }




        public TableDataBaseRow inputValues = new TableDataBaseRow();

        /// <summary>
        /// Входные данные для запросов на добавление и удаление, а также, названия столбцов для запросов на выборку
        /// </summary>
        public TableDataBaseRow InputValues => inputValues;

        public TableDataBaseRow InputValues1
        {
            get
            {
                TableDataBaseRow row = new TableDataBaseRow();


                for(int i =0; i < InputValues.Count; i++)
                {
                    TableDataBaseCell cell = new TableDataBaseCell(InputValues[i]);
                    string name = cell.Name;
                    string name1 = name;
                    int index = 0;
                    while(row.Contains(name1, true))
                    {
                        name1 = name + $"{index}";
                        index++;
                    }
                    cell.Name1 = name1;
                    row.Add(cell);
                }


                return row;
            }
        }


        /// <summary>
        /// Входные данные для запросов на добавление и обновление, а также, названия столбцов для запросов на выборку. То же самое, что и InputValues, значение которго данным свойством возвращается
        /// </summary>
        public TableDataBaseRow Columns => InputValues;


        /// <summary>
        /// Входные данные для запросов на добавление и обновление, а также, названия столбцов для запросов на выборку. То же самое, что и InputValues, значение которго данным свойством возвращается
        /// </summary>
        public TableDataBaseRow Columns1 => InputValues1;

        string table = "";

        public string Table
        {
            get => table;
            set => table = value;
        }

        List<SortParameter> sort = new List<SortParameter>();

        /// <summary>
        /// Параметры сортировки
        /// </summary>
        public List<SortParameter> Sort => sort;


        public void Update()
        {
            //TableDataBaseGrid table = new TableDataBaseGrid(Table);
            //if (Columns.Count > 0)
            //    for (int i = 0; i < Columns.Count; i++)
            //    {
            //        table.AddColumn(Columns[i]);
            //    }
            SqlConnection connection = SqlConnection;
            connection.Open();
            try
            {
                string column = "*";
                List<string> columns = new List<string>();
                TableDataBaseRow InputValues = InputValues1;
                bool haveColumns = InputValues.Count > 0;
                for (int i = 0; i < InputValues.Count; i++)
                {
                    columns.Add(InputValues[i].Condition1);
                }

                    column = "set " + String.Join(", ", columns);

                TableDataBaseRowsCollection Conditions = Conditions1;
                List<string> conditions = new List<string>();
                if (Conditions.Count > 0)
                    for (int i = 0; i < Conditions.Count; i++)
                    {
                        List<string> conditions1 = new List<string>();
                        for (int j = 0; j < Conditions[i].Count; j++)
                        {
                            conditions1.Add(Conditions[i][j].Condition1);
                        }
                        conditions.Add(String.Join(" and ", conditions1));
                    }
                string condition = " where (" + String.Join(") or (", conditions) + ")";



                string commandText = $"Update [{Table}] {column}";
                if (Conditions.Count > 0)
                {
                    commandText += $"{condition}";
                }
                

                SqlCommand command = new SqlCommand(commandText, connection);
                SqlParameterCollection parameters = command.Parameters;
                parameters.Clear();
                for (int i = 0; i < InputValues.Count; i++)
                {
                    parameters.AddWithValue(InputValues[i].ParamName1, InputValues[i].Value);
                }

                if (Conditions.Count > 0)
                    for (int i = 0; i < Conditions.Count; i++)
                    {
                        for (int j = 0; j < Conditions[i].Count; j++)
                        {
                            parameters.AddWithValue(Conditions[i][j].ParamName1, Conditions[i][j].Value);
                        }
                    }

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                throw ex;
            }
            }


        public void Delete()
        {
            //TableDataBaseGrid table = new TableDataBaseGrid(Table);
            //if (Columns.Count > 0)
            //    for (int i = 0; i < Columns.Count; i++)
            //    {
            //        table.AddColumn(Columns[i]);
            //    }
            SqlConnection connection = SqlConnection;
            connection.Open();
            try
            {
                TableDataBaseRowsCollection Conditions = Conditions1;
                List<string> conditions = new List<string>();
                if (Conditions.Count > 0)
                    for (int i = 0; i < Conditions.Count; i++)
                    {
                        List<string> conditions1 = new List<string>();
                        for (int j = 0; j < Conditions[i].Count; j++)
                        {
                            conditions1.Add(Conditions[i][j].Condition1);
                        }
                        conditions.Add(String.Join(" and ", conditions1));
                    }
                string condition = " where (" + String.Join(") or (", conditions) + ")";



                string commandText = $"Delete from [{Table}]";
                if (Conditions.Count > 0)
                {
                    commandText += $"{condition}";
                }


                SqlCommand command = new SqlCommand(commandText, connection);
                SqlParameterCollection parameters = command.Parameters;
                parameters.Clear();
                

                if (Conditions.Count > 0)
                    for (int i = 0; i < Conditions.Count; i++)
                    {
                        for (int j = 0; j < Conditions[i].Count; j++)
                        {
                            parameters.AddWithValue(Conditions[i][j].ParamName1, Conditions[i][j].Value);
                        }
                    }

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                throw ex;
            }
        }


        public void Insert()
        {
            List<string> columns = new List<string>();
            List<string> columnParams = new List<string>();
            TableDataBaseRow InputValues = InputValues1;
            for (int i = 0; i < InputValues.Count; i++)
            {
                columns.Add(InputValues[i].Name);
                columnParams.Add(InputValues[i].ParamName1);
            }

            string column = $"[{table}] (" + string.Join(", ", columns) + ")";
            string columnParam = $"Values(" + string.Join(", ", columnParams) + ")";


            SqlConnection connection = SqlConnection;
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = connection,
                    CommandText = $"Insert into {column} {columnParam}"
                };
                SqlParameterCollection parameters = command.Parameters;
                for(int i = 0; i < InputValues.Count; i++)
                {
                    parameters.AddWithValue(InputValues[i].ParamName1, InputValues[i].Value);
                }
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                throw ex;
            }
        }

        public TableDataBaseGrid GetCells()
        {
            TableDataBaseGrid table = new TableDataBaseGrid(Table);
            if(Columns.Count > 0)
            for(int i = 0; i < Columns.Count; i++)
            {
                table.AddColumn(Columns[i]);
            }
            SqlConnection connection = SqlConnection;
            connection.Open();
            try
            {
                
                string column = "*";
                List<string> columns = new List<string>();
                bool haveColumns = Columns.Count > 0;
                if (haveColumns)
                {
                    for (int i = 0; i < Columns.Count; i++)
                    {
                        columns.Add(Columns[i].Name);
                    }

                    column = String.Join(", ", columns);
                }

                TableDataBaseRowsCollection Conditions = Conditions1;
                List<string> conditions = new List<string>();
                if(Conditions.Count > 0)
                for(int i = 0; i < Conditions.Count; i++)
                {
                    List<string> conditions1 = new List<string>();
                    for (int j = 0; j < Conditions[i].Count; j++)
                    {
                        conditions1.Add(Conditions[i][j].Condition1);
                    }
                    conditions.Add(String.Join(" and ", conditions1));
                }
                string condition = " where (" + String.Join(") or (", conditions) + ")";

                List<string> sorts = new List<string>();
                string sort = "";
                List<SortParameter> sort1 = Sort.FindAll(p => p.SortText != "no");
                if(sort1.Count > 0)
                {
                    for(int i = 0; i < sort1.Count; i++)
                    {
                        sorts.Add(sort1[i].OrderBy);

                    }
                    sort = " Order by " + String.Join(", ", sorts);
                }


                string commandText = $"Select {column} from [{table.Name}]";
                if(Conditions.Count > 0)
                {
                    commandText += $"{condition}";
                }
                if (sort1.Count > 0)
                {
                    commandText += $"{sort}";
                }

                SqlCommand command = new SqlCommand(commandText, connection);
                SqlParameterCollection parameters = command.Parameters;
                
                if(Conditions.Count > 0)
                for (int i = 0; i < Conditions.Count; i++)
                {
                    for (int j = 0; j < Conditions[i].Count; j++)
                    {
                        parameters.AddWithValue(Conditions[i][j].ParamName1, Conditions[i][j].Value);
                    }
                }

                SqlDataReader reader = command.ExecuteReader();
                if(!reader.HasRows)
                {
                    reader.Close();
                    connection.Close();
                    return table;
                }

                try
                {
                    while (reader.Read())
                    {
                        if(!haveColumns)
                        {
                            for(int i = 0; i < reader.FieldCount; i++)
                            {
                                table.AddColumn(reader.GetName(i));
                            }
                            haveColumns = true;
                        }
                        TableDataBaseRow row = table.Add();
                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            string name = table.Columns[i].Name;
                            row[name] = reader[name];
                        }
                    }
                }
                catch(Exception ex)
                {
                    reader.Close();
                    connection.Close();
                    throw ex;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                connection.Close();
                throw ex;
            }
            connection.Close();

            return table;
        }
    }
}
