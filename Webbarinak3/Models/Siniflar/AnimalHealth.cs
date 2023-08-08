using System.ComponentModel.DataAnnotations;

namespace Webbarinak3.Models.Siniflar
{
    public class AnimalHealth
    {
        [Key]
        public int AnimalHealthID { get; set; }
        public string health { get; set; }
    }
}
