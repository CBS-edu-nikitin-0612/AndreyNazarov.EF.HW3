using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task1.Model
{
    internal class Student
    {
        [Column("user_id")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public HashSet<Course> Courses { get; set; } = new HashSet<Course>();
        public int AddressId { get; set; }
        [Required]
        public Address Address { get; set; }

        public Student()
        {
            Courses = new HashSet<Course>();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Courses count: {Courses.Count}, Address: {Address?.FullAddress}, AddressId: {AddressId}";
        }
    }
}