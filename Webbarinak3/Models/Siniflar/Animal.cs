using System.ComponentModel.DataAnnotations;


namespace Webbarinak3.Models.Siniflar
{
    public class Animal
    {
        [Key]
        public int AnimalID { get; set; }
        [Required]
        public string Turu { get; set; }
        [Required]
        public string Cinsi { get; set; }
        [Required]
        public string Yasi { get; set; }
        [Required]
        public string SaglikDurumu { get; set; }







    }
}

