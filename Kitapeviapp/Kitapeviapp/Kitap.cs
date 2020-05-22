using System;
using System.IO;
using Kitapeviapp;
namespace kitap
{
	public class Kitap
	{
		private String kitap_ad;
		private String yazar;
		private DateTime tarih;
		private String türü;
		


		public Kitap()
		{
			Console.WriteLine("Nesne oluşturuldu.");
		}


		public Kitap(String kitap_ad, String yazar, DateTime tarih, String türü)
		{
			this.Kitap_ad = kitap_ad;
			this.Yazar = yazar;
			this.Tarih = tarih;
			this.Türü = türü;
		}

		public string Kitap_ad { get => kitap_ad; set => kitap_ad = value; }
		public string Yazar { get => yazar; set => yazar = value; }
		public DateTime Tarih { get => tarih; set => tarih = value; }
		public string Türü { get => türü; set => türü = value; }


	}
}

