using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelKonsol
{
    class Otel
    {
        //3 Ayrı Tipte Odamızı Oluşturuyoruz.
        internal List<TekYatakliOda> tek { get; }       
        internal List<IkizYatakliOda> ikiz { get; }
        internal List<CiftYatakliOda> cift { get; }


        public Otel()
        {
            //Tek Yatakli Odamız
            this.tek = new List<TekYatakliOda>(12);
            for (int i = 0; i < tek.Capacity; i++)
            {
                tek.Add(new TekYatakliOda(100 + i));
                if (i >= 0 && i <= 3) tek[i].manzara("Orman");   //4 tanesi orman manzaralı
                else if (i >= 4 && i <= 7) tek[i].manzara("Deniz");//4 tanesi deniz manzaralı
                else if (i >= 8 && i <= 11) tek[i].manzara("Havuz");//4 tanesi havuz manzaralı
            }

            //Çift Yatakli Odamız
            this.cift = new List<CiftYatakliOda>(12);
            for (int i = 0; i < cift.Capacity; i++)
            {
                cift.Add(new CiftYatakliOda(200 + i));
                if (i >= 0 && i <= 3) cift[i].manzara("Orman");//4 tanesi orman manzaralı
                else if (i >= 4 && i <= 7) cift[i].manzara("Deniz");//4 tanesi deniz manzaralı
                else if (i >= 8 && i <= 11) cift[i].manzara("Havuz");//4 tanesi havuz manzaralı

            }
            //İkiz Yatakli Odamız
            this.ikiz = new List<IkizYatakliOda>(12);
            for (int i = 0; i < ikiz.Capacity; i++)
            {
                ikiz.Add(new IkizYatakliOda(300 + i));
                if (i >= 0 && i <= 3) ikiz[i].manzara("Orman");//4 tanesi orman manzaralı
                else if (i >= 4 && i <= 7) ikiz[i].manzara("Deniz");//4 tanesi deniz manzaralı
                else if (i >= 8 && i <= 11) ikiz[i].manzara("Havuz");//4 tanesi havuz manzaralı

            }

        }
        //Doluluk oranımıza günlük olarak baktık.
        public void dolulukOranı()
        {
            //Tek Yataklarımızın Odalarımızın Günlük Doluluk Oranı
            Console.WriteLine("Bugun için doluluk orani");
            double sum = 0;
            double total = 0;
            for (int i = 0; i < tek.Count; i++)
            {
                if (tek[i].takvim[0].rezeverMi) sum++;

            }
            Console.WriteLine("Tekliler icin doluluk oranı = " + sum + "/" + 12 + "= > " + (sum / 12).ToString());


            //Çift Yataklı Odalarımızın Günlük Doluluk Oranı
            total += sum;
            sum = 0;
            for (int i = 0; i < cift.Count; i++)
            {
                if (cift[i].takvim[0].rezeverMi) sum++;

            }          
            Console.WriteLine("\nCiftliler icin doluluk oranı = " + sum + "/" + 12 + "= > " + (sum / 12).ToString());


            //İkiz Yataklı Odalarımızın Günlük Doluluk Oranı
            total += sum;
            sum = 0;
            for (int i = 0; i < ikiz.Count; i++)
            {
                if (ikiz[i].takvim[0].rezeverMi) sum++;

            }

            Console.WriteLine("\nIkizler icin doluluk oranı = " + sum + "/" + 12 + "= > " + (sum / 12).ToString());

            //total diye bir değişken tuttuk.Bunu otelin genel ortalamasında kullandık.
            total += sum;


            //Otelimizin Genel Doluluk Oranı
            Console.WriteLine("\nGenel doluluk oranı = " + total + "/" + 36 + "= > " + (total / 36).ToString());

        }






    }
}

