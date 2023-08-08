using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webbarinak3.Models.Siniflar
{
    public class Request
    {
        [Key]
        public int RequestID { get; set; }
        public int AnimalID { get; set; }
        public string Turu { get; set; }
        public string Cinsi { get; set; }
        public string Yasi { get; set; }
        public string SaglikDurumu { get; set; }
        public DateTime CreatedTime { get; set; }
      
    }
}
