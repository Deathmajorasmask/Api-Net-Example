using System.ComponentModel.DataAnnotations;

namespace UniversityWebApiBackend.Models.DataModels
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        //public int UserID { get; set; }
        //public virtual Users CreateBy { get; set; } = new Users();
        public string CreateBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //public Users UpdateBy { get; set; } = new Users();
        public string UpdateBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        //public Users DeleteBy { get; set; } = new Users();
        public string DeleteBy { get; set; } = string.Empty;
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
