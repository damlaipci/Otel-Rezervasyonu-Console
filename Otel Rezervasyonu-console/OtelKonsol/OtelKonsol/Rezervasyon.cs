using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelKonsol
{
    class Rezervasyon
    {
        //Rezerve methodumuz için alınan parametrelerimiz.
        public static bool rezerve(Otel otel, string musteriTC, string odaTipi, string manzarası
            , DateTime start, DateTime end)
        {

            double price = 0;  //Ücret için double türünde bir değişken tanımladık.
            int sec = sorgu(otel, musteriTC, odaTipi, manzarası, start, end, true);
            if (sec < 0) return false;
            else
            {
                if (odaTipi.Equals("Tek Yatakli Oda"))   //Oda tipimiz Tek Yatakli Oda şeklinde girilmişse 
                    price = otel.tek[sec].rezervasyonYap(start, end, musteriTC);//başlangıç,bitiş tarihleri ve müsteriTc parametrelerini alıp rezerve işlemini yapar.
                else if (odaTipi.Equals("Cift Yatakli Oda"))//Oda tipimiz Cift Yatakli Oda şeklinde girilmişse yine aynı şekilde
                    price = otel.cift[sec].rezervasyonYap(start, end, musteriTC);//başlangıç,bitiş tarihleri ve müsteriTc parametrelerini alıp rezerve işlemini yapar.
                else if (odaTipi.Equals("Ikiz Yatakli Oda"))//Oda tipimiz Ikiz Yatakli Oda şeklinde girilmişse yine aynı şekilde
                    price = otel.ikiz[sec].rezervasyonYap(start, end, musteriTC);//başlangıç,bitiş tarihleri ve müsteriTc parametrelerini alıp rezerve işlemini yapar.
                //Ucret hesaplama kısmı
                Console.WriteLine("Toplam ucret = " + price);
                return true;
            }

        }



        //Rezervasyon İptal methodumuz için alınan parametrelerimiz.
        public static bool iptal(Otel otel, string musteriTC, string odaTipi, string manzarası
           , DateTime start, DateTime end)
        {


            int sec = sorgu(otel, musteriTC, odaTipi, manzarası, start, end, false);
            if (sec < 0) return false;
            else
            {
                if (odaTipi.Equals("Tek Yatakli Oda")) //Oda tipimiz Tek Yatakli Oda şeklinde girilmişse 
                    otel.tek[sec].rezervasyonIptal(start, end, musteriTC);//başlangıç,bitiş tarihleri ve müsteriTc parametrelerini alıp rezervasyon işlemini iptel eder.
                else if (odaTipi.Equals("Cift Yatakli Oda"))//Oda tipimiz Cift Yatakli Oda şeklinde girilmişse yine aynı şekilde
                    otel.cift[sec].rezervasyonIptal(start, end, musteriTC);//başlangıç,bitiş tarihleri ve müsteriTc parametrelerini alıp rezervasyon işlemini iptel eder.
                else if (odaTipi.Equals("Ikiz Yatakli Oda"))//Oda tipimiz Ikiz Yatakli Oda şeklinde girilmişse yine aynı şekilde
                    otel.ikiz[sec].rezervasyonIptal(start, end, musteriTC);//başlangıç,bitiş tarihleri ve müsteriTc parametrelerini alıp rezervasyon işlemini iptel eder.
                return true;
            }

        }



        // Sorgu tipi ekleme ise true döner; iptal ise false döner.
        public static int sorgu(Otel otel, string musteriTC, string odaTipi, string manzarası
         , DateTime start, DateTime end, bool sorguTipi)
        {
            //Yatak tipi ve manzarasına göre oda müsaitlik sorgusu 

            //Tek Yatakli Oda için sorgu.
            //Daha sonra "Tek Yatakli Oda" nın Orman,Deniz ve Havuz manzara sorgusu.
            if (odaTipi.Equals("Tek Yatakli Oda"))
            {
                if (manzarası.Equals("Orman"))
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        if (otel.tek[i].rezervasyonSorgu(start, end)) return i;
                        else if (!otel.tek[i].rezervasyonSorgu(start, end) && !sorguTipi)
                            return i;

                    }
                }
                else if (manzarası.Equals("Deniz"))
                {
                    for (int i = 4; i <= 7; i++)
                    {
                        if (otel.tek[i].rezervasyonSorgu(start, end)) return i;
                        else if (!otel.tek[i].rezervasyonSorgu(start, end) && !sorguTipi)
                            return i;


                    }

                }
                else if (manzarası.Equals("Havuz"))
                {
                    for (int i = 8; i <= 11; i++)
                    {
                        if (otel.tek[i].rezervasyonSorgu(start, end)) return i;
                        else if (!otel.tek[i].rezervasyonSorgu(start, end) && !sorguTipi)
                            return i;


                    }

                }
            }

            //Ikiz Yatakli Oda için sorgu.
            //Daha sonra "Ikiz Yatakli Oda" nın Orman,Deniz ve Havuz manzara sorgusu.
            else if (odaTipi.Equals("Ikiz Yatakli Oda"))
            {
                if (manzarası.Equals("Orman"))
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        if (otel.ikiz[i].rezervasyonSorgu(start, end)) return i;
                        else if (!otel.ikiz[i].rezervasyonSorgu(start, end) && !sorguTipi)
                            return i;


                    }
                }
                else if (manzarası.Equals("Deniz"))
                {
                    for (int i = 4; i <= 7; i++)
                    {
                        if (otel.ikiz[i].rezervasyonSorgu(start, end)) return i;
                        else if (!otel.ikiz[i].rezervasyonSorgu(start, end) && !sorguTipi)
                            return i;


                    }

                }
                else if (manzarası.Equals("Havuz"))
                {
                    for (int i = 8; i <= 11; i++)
                    {
                        if (otel.ikiz[i].rezervasyonSorgu(start, end)) return i;
                        else if (!otel.ikiz[i].rezervasyonSorgu(start, end) && !sorguTipi)
                            return i;


                    }

                }
            }

            //Cift Yatakli Oda için sorgu.
            //Daha sonra "Cift Yatakli Oda" nın Orman,Deniz ve Havuz manzara sorgusu.
            else if (odaTipi.Equals("Cift Yatakli Oda"))
            {
                if (manzarası.Equals("Orman"))
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        if (otel.cift[i].rezervasyonSorgu(start, end)) return i;
                        else if (!otel.cift[i].rezervasyonSorgu(start, end) && !sorguTipi)
                            return i;


                    }
                }
                else if (manzarası.Equals("Deniz"))
                {
                    for (int i = 4; i <= 7; i++)
                    {
                        if (otel.cift[i].rezervasyonSorgu(start, end)) return i;
                        else if (!otel.cift[i].rezervasyonSorgu(start, end) && !sorguTipi)
                            return i;
                    }

                }
                else if (manzarası.Equals("Havuz"))
                {
                    for (int i = 8; i <= 11; i++)
                    {
                        if (otel.cift[i].rezervasyonSorgu(start, end)) return i;
                        else if (!otel.cift[i].rezervasyonSorgu(start, end) && !sorguTipi)
                            return i;
                    }

                }
            }
            return -1;
        }



        //İstatiksel Sorgu ile otelimizin doluluk oranına bakıyoruz.
        public static void istatistikSorgu(Otel otel)  
        {
            otel.dolulukOranı();
        }
    }


}
