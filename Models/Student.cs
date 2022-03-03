using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RazorPages_CRUD_NO_EntityFramework.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string datebirth { get; set; }
        public string sex { get; set; }
    }
}
