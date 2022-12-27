using System.ComponentModel.DataAnnotations;

namespace SeyahatProject.Models
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }
        public string Baslik { get; set; }
        public DateOnly Tarih { get; set; }
        public string Aciklama { get; set; }
        public string BlogImage { get; set; }
        public ICollection<Yorumlar> Yorumlars { get; set; }
    }
}
