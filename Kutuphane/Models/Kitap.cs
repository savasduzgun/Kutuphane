using System.ComponentModel;

namespace Kutuphane.Models
{
    public class Kitap
    {
        [DisplayName("Kitap No")]
        public int Id { get; set; }
        [DisplayName("Adı")]
        public string Name { get; set; }
        [DisplayName("Yazar")]
        public string Author { get; set; }
        [DisplayName("Yayın Evi")]
        public string Publisher { get; set; }
        [DisplayName("Tür")]
        public Turler Tur { get; set; }
        [DisplayName("Stok")]
        public bool Stock { get; set; }
    }

    public enum Turler
    {
        Roman,
        Hikaye,
        Şiir
    }
}
