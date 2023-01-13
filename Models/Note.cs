namespace Gestion_note.Models
{
    public class Note
    {
        public int Id { get; set; }
        public double NoteDevoir { get; set; }
        
        public Student student { get; set; }
        public Matiere matiere { get; set; }
    }
}
