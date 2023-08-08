using System.ComponentModel.DataAnnotations;

namespace Webbarinak3.Models.Siniflar
{
    public class Request2
    {
        [Key]
        public int Request2ID { get; set; }

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
