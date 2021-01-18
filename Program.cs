using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace BigparaApp
{
    class Program
    {
        private static string dovizXpath = "//div[@class='dovizBar mBot20']//a";
        
        static void Main(string[] args)
        {
            List<Bigpara> dovizler = new List<Bigpara>();

            HtmlWeb web = new HtmlWeb();

            HtmlDocument document = web.Load("https://bigpara.hurriyet.com.tr/doviz/");

            var dovizSayisi = document.DocumentNode.SelectNodes(dovizXpath);

            foreach (var doviz in dovizSayisi)
            {
                string dovizTitle = doviz.SelectSingleNode(".//span[1]//span[1]").InnerText;
                string dovizAlis = doviz.SelectSingleNode(".//span[2]//span[2]").InnerText;
                string dovizSatis = doviz.SelectSingleNode(".//span[3]//span[2]").InnerText;
                
                dovizler.Add(new Bigpara()
                {
                    alisFiyati = dovizAlis,
                    satisFiyati = dovizSatis,
                    dovizTuru = dovizTitle
                });
            }

            foreach (var bigpara in dovizler)
            {
                Console.WriteLine($"Doviz Türü {bigpara.dovizTuru} , Alış Fiyatı = {bigpara.alisFiyati} , Satış Fiyatı = {bigpara.satisFiyati}");
            }
        }
    }
}