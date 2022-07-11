using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task1.Model
{
    internal class Course
    {
        [Column("course_id")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public HashSet<Student> Students { get; set; } = new HashSet<Student>();
        [Required]
        public HashSet<Address> Addresses { get; set; } = new HashSet<Address>();

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Students count: {Students.Count}, Adsresses count: {Addresses.Count}";
        }
    }
}