using Gestion_note.Models;

namespace Gestion_note.DTO
{
    public class StudentAddDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FilierId{ get; set; }
    }
}
