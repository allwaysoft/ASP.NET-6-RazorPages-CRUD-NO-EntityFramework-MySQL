using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using RazorPages_CRUD_NO_EntityFramework.Models;
using MySql.Data.MySqlClient;



namespace RazorPages_CRUD_NO_EntityFramework.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Student> ListStudents { get; set; }
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        public void OnGet()
        {
            ListStudents = AfficherListstudents();
        }

        public static List<Student> AfficherListstudents()
        {
            List<Student> ListStud = new List<Student>();
            string cs = "server=localhost;user=root;database=searchdb;port=3306;password=root;sslmode=none";
            using (MySqlConnection con = new MySqlConnection(cs))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from student", con))
                {
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student ec = new Student();
                            ec.id = Convert.ToInt32(reader["id"]);
                            ec.name = Convert.ToString(reader["name"]);
                            ec.email = Convert.ToString(reader["email"]);
                            ec.datebirth = Convert.ToString(reader["datebirth"]);
                            ec.sex = Convert.ToString(reader["sex"]);
                            ListStud.Add(ec);
                        }
                    }
                    return ListStud;
                }
            }
        }

        public IActionResult OnPostAsync(Student ec)
        {
            string cs = "server=localhost;user=root;database=searchdb;port=3306;password=root;sslmode=none";
            using (MySqlConnection con = new MySqlConnection(cs))
            {
                string req = "insert into student(name,email,datebirth,sex) values ('" + ec.name + "','" + ec.email + "','" + ec.datebirth + "','" + ec.sex + "')";
                using (MySqlCommand cmd = new MySqlCommand(req, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return RedirectToPage("Index");
        }

    }
}
