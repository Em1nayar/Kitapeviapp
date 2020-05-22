using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kitap;
namespace Kitapeviapp
{
   
    class Program
    {


         
        static void Main(string[] args)
        {
            Kitap[] liste = new Kitap[1];
            while (true)
            {
                Console.WriteLine("1.Kitap ekle");
                Console.WriteLine("2.Kitapları listele");
                Console.WriteLine("Yapmak istediğiniz işlemi seçin(1 veya 2 yazın):");
                String secim = Console.ReadLine();
                if (secim == "1")
                {
                    try
                    {
                        Console.WriteLine("Kaç tane kitap kaydedeceksiniz:");
                        int sayi = int.Parse(Console.ReadLine());
                        liste = new Kitap[sayi];
                        int i = 0;
                        while ( i < liste.Length) {
                            Console.WriteLine("Eklemek istediğiniz kitabın ismi:");
                            String isim = Console.ReadLine();
                            Console.WriteLine("Eklemek istediğiniz kitabın yazarın ismi:"); 
                            String yazar = Console.ReadLine();
                            Console.WriteLine("Eklemek istediğiniz kitabın basım gününü girin:");
                            int gun = int.Parse(Console.ReadLine());
                            Console.WriteLine("Eklemek istediğiniz kitabın basım ayını girin:");
                            if(gun > 31)
                            {
                                Console.WriteLine("Lütfen geçerli bir tarih girin.");
                                continue;
                            }
                            int ay = int.Parse(Console.ReadLine());
                            if(ay > 12)
                            {
                                Console.WriteLine("Lütfen geçerli bir tarih girin.");
                                continue;
                            }
                            Console.WriteLine("Eklemek istediğiniz kitabın basım yılını girin:");
                            int yil = int.Parse(Console.ReadLine());
                            DateTime tarih = new DateTime(yil, ay, gun);
                            if(tarih > DateTime.Today)
                            {
                                Console.WriteLine("Lütfen geçerli bir tarih girin.");
                                continue;
                            }
                            Console.WriteLine("Eklemek istediğiniz kitabın türünü girin:");
                            String türü = Console.ReadLine();
                            Kitap kitap = new Kitap(isim, yazar, tarih, türü);
                            liste[i] = kitap;
                            
                            i ++;
                        }
                        if(i != 0)
                        {
                            kaydet(liste);
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Hatalı türde girdiniz lütfen tekrar giriş yapın.");
                    }


                }
                else if (secim == "2")
                {
                    StreamReader sr = new StreamReader("kitap.txt");
                    String yazi = sr.ReadLine();
                    while (yazi != null)
                    {
                        Console.WriteLine(yazi);
                        yazi = sr.ReadLine();
                    }
                    sr.Close();
                }
                else
                {
                    Console.WriteLine("Lütfen geçerli bir komut girin...");
                }
                
            }


        }



        public static void kaydet(Kitap[] liste)
        {

            FileStream fs = new FileStream("kitap.txt", FileMode.Create,FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < liste.Length; i++)
            {
                sw.WriteLine("Kitabın adı : " + liste[i].Kitap_ad);
                sw.WriteLine("Kitabın yazarı : " + liste[i].Yazar);
                sw.WriteLine("Kitabın basım tarihi : " + liste[i].Tarih);
                sw.WriteLine("Kitabın türü : " + liste[i].Türü);
                sw.WriteLine("--------------------------");
            }

            sw.Flush();
            sw.Close();
            fs.Close();

        }



    }
}

