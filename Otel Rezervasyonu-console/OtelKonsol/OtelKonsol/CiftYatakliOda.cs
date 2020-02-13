using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelKonsol
{
    class CiftYatakliOda : Oda
    {

        public CiftYatakliOda(int odano)
        {
            this.manzaraTipi = null;
            this.odaNumaralari = odano;
            this.yatakCesidi = "Cift Yatakli Oda";
            this.takvim = new List<Day>(365); //Takvimimizi 365 günlük aldık.

            DateTime date = DateTime.Today;
            Random random = new Random();
            int price;
            for (int i = 0; i < this.takvim.Capacity; i++)
            {
                price = random.Next(200, 301);  // 200-300;
                this.takvim.Add(new Day(date, false, price));
                // day sınıfı içeren bir liste oluşturmuştum takvim için
                // bu takvimin içine hergünü programın çalıştığı günden itibaren 
                // rastgele günlük ücretler ile ekliyorum
                // ilk oluştuğunda da rezerve olamayacağından rezervesini false ediyorum
                date = date.AddDays(1);

            }

        }
        public bool manzara(string manzara)
        {

            if (manzara.Equals("Orman") || manzara.Equals("Deniz") || manzara.Equals("Havuz"))
            {
                this.manzaraTipi = manzara;
                return true;
            }

            return false;
        }
        // rezervasyon kaydı yapıp toplam ucreti geri döndürür
        public double rezervasyonYap(DateTime start, DateTime end, string musteriTc)
        {
            //TİMESPAN 2 DATE ARASI ZAMAN FARKINI BULUR
            TimeSpan fark;
            //08.04.2019 - 05.04.2019 > 0 hata

            fark = this.takvim[0].date - start;

            if (fark.Days > 0)
            {
                Console.WriteLine("Geçersiz Giriş Zamanı");
                return 0.0;
            }
            //08.04.2020 - 09.04.2020 < 0 hata
            //fark = takvim[takvim.Count - 1].date - end;

            //if (fark.Days < 0)
            //{
            //    Console.WriteLine("Geçersiz Çıkış Zamanı");
            //    return 0.0;
            //}


            int esit;
            // odanın gereken tarih aralığını buldum.
            //bulduğum tarih aralığınada müsterinin adını ve rezerve olduğuna dair bilgisini işledim
            double totalPrice = 0;
            for (int i = 0; i < this.takvim.Count; i++)
            {
                fark = takvim[i].date - start;
                esit = Math.Abs(fark.Days);

                if (esit == 0)
                {
                    fark = start - end;

                    for (int j = i; j < i + Math.Abs(fark.Days); j++)
                    {
                        if (takvim[j].musteriTc != null)
                        {
                            return 0.0;
                        }
                        takvim[j].rezeverMi = true;
                        takvim[j].musteriTc = musteriTc;
                        totalPrice += takvim[j].ucret;
                    }
                    break;
                }

            }
            return totalPrice;
        }

        public bool rezervasyonIptal(DateTime start, DateTime end, string musteriTc)
        {
            //TİMESPAN 2 DATE ARASI ZAMAN FARKINI BULUR
            TimeSpan fark;
            //08.04.2019 - 05.04.2019 > 0 hata
            fark = this.takvim[0].date - start;
            if (fark.Days > 0)
            {
                Console.WriteLine("Geçersiz Giriş Zamanı");
                return false;
            }
            //08.04.2020 - 09.04.2020 < 0 hata
            //fark = takvim[takvim.Count - 1].date - end;
            //if (fark.Days < 0)
            //{
            //    Console.WriteLine("Geçersiz Giriş Zamanı");
            //    return false;
            //}


            int esit;
            // odanın gereken tarih aralığını buldum.
            //bulduğum tarih aralığınada müsterinin adını ve rezerve olduğuna dair bilgisini iptal ettim

            for (int i = 0; i < this.takvim.Count; i++)
            {
                fark = takvim[i].date - start;
                esit = Math.Abs(fark.Days);
                if (esit == 0)
                {
                    fark = start - end;
                    for (int j = i; j < i + Math.Abs(fark.Days); j++)
                    {
                        if (takvim[j].musteriTc.Equals(musteriTc))
                        {
                            takvim[j].rezeverMi = false;
                            takvim[j].musteriTc = null;

                        }

                    }
                    break;
                }

            }
            return true;

        }




        public bool rezervasyonSorgu(DateTime start, DateTime end)
        {
            //TİMESPAN 2 DATE ARASI ZAMAN FARKINI BULUR
            TimeSpan fark;
            //08.04.2019 - 05.04.2019 > 0 hata
            fark = this.takvim[0].date - start;
            if (fark.Days > 0)
            {
                Console.WriteLine("Geçersiz Giriş Zamanı");
                return false;
            }
            //08.04.2020 - 09.04.2020 < 0 hata
            //fark = takvim[takvim.Count - 1].date - end;
            //if (fark.Days < 0)
            //{
            //    Console.WriteLine("Geçersiz Çıkış Zamanı");
            //    return false;
            //}


            int esit;
            // odanın gereken tarih aralığını buldum.
            //bulduğum tarih aralığınada sorgu yaptım

            for (int i = 0; i < this.takvim.Count; i++)
            {
                fark = takvim[i].date - start;

                esit = Math.Abs(fark.Days);
                if (esit == 0)
                {
                    fark = start - end;
                    for (int j = i; j < i + Math.Abs(fark.Days); j++)
                    {
                        if (takvim[j].musteriTc != null) return false;
                        // müsait değil

                    }
                    break;
                }

            }
            return true;  // müsait

        }


    }
}
