using System.ComponentModel.DataAnnotations;

namespace UniversityWebApiBackend.Models.DataModels
{
    public class IndexClass :BaseEntity
    {
        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = new Course();
        [Required]
        public string Chapters { get; set; } = string.Empty;
    }
}
