using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task1.Model
{
    internal class Address
    {
        [Column("address_id")]
        public int Id { get; set; }
        [Required]
        public string FullAddress { get; set; }
        public HashSet<Student> Students { get; set; } = new HashSet<Student>();
        public HashSet<Course> Courses { get; set; } = new HashSet<Course>();
        public override string ToString()
        {
            return $"Id: {Id}, Address: {FullAddress}, Sudents count: {Students.Count}, Courses count: {Courses.Count}";
        }
    }
}