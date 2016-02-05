using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace VideoTech.Controllers
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    // Access via ADO and display on UI
    public class AuthorController : Controller
    {
        public ActionResult Index()
        {
            var list = new List<Author>();
            //list.Add(new Author {AuthorID = 1, FirstName = "Dave", LastName = "Mateer"});
            //list.Add(new Author {AuthorID = 2, FirstName = "Alice", LastName = "Smith"});
            //list.Add(new Author {AuthorID = 3, FirstName = "Bob", LastName = "Gates"});

            string connectionString = @"data source=.\SQLEXPRESS;initial catalog=VideoTech;integrated security=True;MultipleActiveResultSets=True;";
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("SELECT * FROM Author", connection))
                {
                    connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string authorID = reader["AuthorID"].ToString();
                            string firstName = reader["FirstName"].ToString();
                            string lastName = reader["LastName"].ToString();

                            int authorIDInt;
                            Int32.TryParse(authorID, out authorIDInt);

                            list.Add(new Author { AuthorID = authorIDInt, FirstName = firstName, LastName = lastName});
                        }
                    }
                }
            }
            return View(list);
        }
    }
}