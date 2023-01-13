namespace Gestion_note.Models
{
    public class Note
    {
        public int Id { get; set; }
        public double NoteDevoir { get; set; }
        public string TypeExam { get; set; }
        public Student Student { get; set; }
        public Matiere Matiere { get; set; }
    }
}
