namespace Gestion_note.Models
{
    public class Matiere
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Coefficent { get; set; }
        public Filier FilierMatier { get; set; }
        public List<Teacher> TeacherMatier { get; set; }
    }
}
