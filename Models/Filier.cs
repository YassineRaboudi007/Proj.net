using Gestion_note.Data.StudentRepo;
using System.ComponentModel.DataAnnotations;

namespace Gestion_note.Models
{
    public class Filier
    {
        [Key]
        public int Id { get; set; }            
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<Matiere> Matieres { get; set; }


    }
}
