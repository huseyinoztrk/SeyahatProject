namespace SeyahatProject.Models.VievModels
{
    public class YorumlarVM
    {
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
        public string Yorum { get; set; }
        public int Blogid { get; set; }
        public Blog Blog { get; set; }

    }
}
