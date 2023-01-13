namespace Gestion_note.Models
{
    public class Matiere
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Coefficent { get; set; }
        public List<Filier> FilierMatier { get; set; }
        public List<Teacher> TeacherMatier { get; set; }
    }
}
