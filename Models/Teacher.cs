namespace Gestion_note.Models
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Matiere> Matieres { get; set; }
        public List<Filier> Filiers { get; set; }
    }
}
