using System.ComponentModel.DataAnnotations;

namespace UniversityWebApiBackend.Models.DataModels
{
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
        public enum Level
        {
            basic,
            intermediate,
            expert
        }
    }
}
