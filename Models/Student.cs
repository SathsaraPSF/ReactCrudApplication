using System.ComponentModel.DataAnnotations;

namespace ReactCrudApplication.Models
{
    public class Student
    {

        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string course { get; set; }
       

    }
}
