using System.ComponentModel.DataAnnotations;
namespace Webbarinak3.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }


    }
}
