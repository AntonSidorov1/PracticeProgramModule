using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OOO_Rythm;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// После авторизации пользователя открывается окно со списком товаров
        /// </summary>
        [TestMethod]
        public void AfterUserAuthorizationAWindowWithAListOfProductsOpens()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.InitialCatalog = "MusicShop";

            //Открыть подключение к базе данных
            SqlConnection connection = new SqlConnection();
            try
            {
                builder.DataSource = "DESKTOP-OLHVHM0\\SQLEXPRESS";
                builder.IntegratedSecurity = true;
                builder.PersistSecurityInfo = false;
                connection.Open();
            }
            catch
            {
                builder.DataSource = "sql.vm";
                builder.IntegratedSecurity = false;
                builder.PersistSecurityInfo = true;
                builder.UserID = "User";
                builder.Password = "Password";
                connection.Open();
            }
            Helper.Connection = connection;

            

            Autorization autorization = new Autorization(withIcon: false); //Открытие формы авторизации, не создавая иконку рядом с панелью задач
            autorization.Show();

            // Ввод аутотификационных параметров
            autorization.Login = "AntonSidorov";
            autorization.Password = "password";

            autorization.LogIn(systemConnection: false); //Вход в систему без отображения окна об успешности с введённой строкой подключения

            //Получение окна со списком товаров
            Form form = Application.OpenForms["ProductForm"];
            bool productListVisible = form.Visible; // Отображается ли окно

            Application.OpenForms[0].Close(); // Закрыть все окна
            connection.Close(); //Закрыть подключение к базе данных

            Assert.AreEqual(true, productListVisible);
        }


    }
}
