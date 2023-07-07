using System.ComponentModel.DataAnnotations;

namespace UniversityWebApiBackend.Models.DataModels
{
    public enum Level
    {
        basic,
        intermediate,
        advanced,
        expert
    }
    public class Course : BaseEntity
    {
        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [StringLength(280)]
        public string? DescriptionShort { get; set; } = string.Empty;
        public string? DescriptionLong { get; set; } = string.Empty;
        [Required]
        public string PublicObjective { get; set; } = string.Empty;
        public string? Objectives { get; set; } = string.Empty;
        [Required]
        public string Requirements { get; set; } = string.Empty ;
        public Level Level { get; set; } = Level.basic;
        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        [Required]
        public ICollection<Student> Students { get; set; } = new List<Student>();
        [Required]
        public IndexClass IndexClass { get; set; } = new IndexClass();
    }
}
