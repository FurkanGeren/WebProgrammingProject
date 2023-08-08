using System.ComponentModel.DataAnnotations;

namespace Webbarinak3.Models.Siniflar
{
    public class AnimalType
    {
        [Key]
        public int AnimalTypeID { get; set; }
        public string AnimalTur { get; set; }
    }
}
