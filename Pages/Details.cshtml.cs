using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using RazorPages_CRUD_NO_EntityFramework.Models;
using MySql.Data.MySqlClient;


namespace RazorPages_CRUD_NO_EntityFramework.Pages
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public Student ListStudents { get; set; }
        public void OnGet(int _id)
        {
            Student ec = new Student();
            string cs = "server=localhost;user=root;database=searchdb;port=3306;password=root;sslmode=none";
            using (MySqlConnection con = new MySqlConnection(cs))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from student where id='" + _id + "'", con))
                {
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            ec.id = Convert.ToInt32(reader["id"]);
                            ec.name = Convert.ToString(reader["name"]);
                            ec.email = Convert.ToString(reader["email"]);
                            ec.datebirth = Convert.ToString(reader["datebirth"]);
                            ec.sex = Convert.ToString(reader["sex"]);

                        }
                    }
                    ListStudents = ec;
                }
            }
        }
    }
}
