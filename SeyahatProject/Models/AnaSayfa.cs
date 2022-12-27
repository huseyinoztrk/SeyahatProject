using System.ComponentModel.DataAnnotations;

namespace SeyahatProject.Models
{
    public class AnaSayfa
    {
        [Key]
        public int ID { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
    }
}