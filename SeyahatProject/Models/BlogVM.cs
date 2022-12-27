using System.ComponentModel.DataAnnotations;

namespace SeyahatProject.Models
{
    public class BlogVM
    {

        public string Baslik { get; set; }
        public string Tarih { get; set; }
        public string Aciklama { get; set; }
        public string BlogImage { get; set; }

    }
}
