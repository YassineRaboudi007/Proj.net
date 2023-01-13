using System.ComponentModel.DataAnnotations;

namespace Gestion_note.Models
{
    public class Studnet
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Class StudentClass { get; set; }

    }
}
