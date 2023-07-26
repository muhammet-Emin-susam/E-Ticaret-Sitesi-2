using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_TicaretOtomasyonu.Models
{
    public class Sepet
    {
        private List<SepetDetay> _kartdetay = new List<SepetDetay>();
        public List<SepetDetay> Sepetdetay
        {
            get { return _kartdetay; }
        }
        public void UrunEkle(TBLURUNLER urunler,int adet)
        {
            var satır = _kartdetay.Where(x => x.Urunler.ID == urunler.ID).FirstOrDefault();
            if (satır == null)
            {
                _kartdetay.Add(new SepetDetay() { Urunler = urunler, Adet = adet });
            }
            else
            {
                satır.Adet += adet;
            }
        }
        public void UrunSil(TBLURUNLER urunler)
        {
            _kartdetay.RemoveAll(i => i.Urunler.ID == urunler.ID);
        }
        public double Toplam()
        {
            return (double)_kartdetay.Sum(x => x.Urunler.Fiyat * x.Adet);
        }
        public void Temizle()
        {
            _kartdetay.Clear();
        }
    }
    public class SepetDetay
    {
        public TBLURUNLER Urunler { get; set; }
        public int Adet { get; set; }
    }
}