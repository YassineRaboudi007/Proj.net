using System.ComponentModel.DataAnnotations;

namespace Gestion_note.Models
{
    public class Filier
    {
        [Key]
        public int Id { get; set; }            
        public string Name { get; set; }
        public Class StudentClass { get; set; }


    }
}
