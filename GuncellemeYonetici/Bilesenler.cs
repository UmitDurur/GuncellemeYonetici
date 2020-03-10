using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GuncellemeYonetici
{
    static class Bilesenler
    {
        static Dictionary<string, object> ayarlar;

        static Bilesenler()
        {
            ayarlar = (Dictionary<string, object>)new JavaScriptSerializer().DeserializeObject(new StreamReader("Ayarlar.json").ReadToEnd());
        }

        public static string AyarAl(string ayarAdi)
        {
            return ayarlar.Where(ayar => ayar.Key.Contains(ayarAdi)).FirstOrDefault().Value.ToString();
        }

        public static void logKaydiEkle(this Exception hataMesaji)
        {
            string konum = AyarAl("errorLog_konumu");
            File.AppendAllText(konum, "[" + DateTime.Now + "] - " + hataMesaji.ToString() + Environment.NewLine);
        }

        public static string DESCoz(string strGiris)
        {
            string strSonuc = "";
            if (strGiris == "" || strGiris == null)
            {
                throw new ArgumentNullException("Şifrelenecek veri yok.");
            }
            else
            {
                byte[] aryKey = Byte8("16365082");
                byte[] aryIV = Byte8("16365082");
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream(Convert.FromBase64String(strGiris));
                CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(aryKey, aryIV), CryptoStreamMode.Read);
                StreamReader reader = new StreamReader(cs);
                strSonuc = reader.ReadToEnd();
                reader.Dispose();
                cs.Dispose();
                ms.Dispose();
            }
            return strSonuc;
        }

        private static byte[] ByteDonustur(string deger)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            return ByteConverter.GetBytes(deger);
        }

        private static byte[] Byte8(string deger)
        {
            char[] arrayChar = deger.ToCharArray();
            byte[] arrayByte = new byte[arrayChar.Length];
            for (int i = 0; i < arrayByte.Length; i++)
            {
                arrayByte[i] = Convert.ToByte(arrayChar[i]);
            }
            return arrayByte;
        }
    }

    public class VersiyonBilgisi
    {
        private int id;
        public int ID
        { get { return id; } set { id = value; } }

        private string uygNamespace;
        public string Namespace
        { get { return uygNamespace; } set { uygNamespace = value; } }

        private string versiyon;
        public string Versiyon
        { get { return versiyon; } set { versiyon = value; } }

        private int paketSayisi;
        public int PaketSayisi
        { get { return paketSayisi; } set { paketSayisi = value; } }

        private byte zorunlu;
        public byte Zorunlu
        { get { return zorunlu; } set { zorunlu = value; } }

        private string guncellemeNotu;
        public string GuncellemeNotu
        { get { return guncellemeNotu; } set { guncellemeNotu = value; } }

        private short guncellemeDurumu;
        public short GuncellemeDurumu
        { get { return guncellemeDurumu; } set { guncellemeDurumu = value; } }

    }

    public class UygulamaBilgisi
    {
        private int id;
        public int ID
        { get { return id; } set { id = value; } }

        private string uygNamespace;
        public string Namespace
        { get { return uygNamespace; } set { uygNamespace = value; } }

        private string uygulamaAdi;
        public string UygulamaAdi
        { get { return uygulamaAdi; } set { uygulamaAdi = value; } }

        //public VersiyonBilgisi[] versiyonlar;

    }

    public class UygulamaPaketi {
        private int paketNo;

        public int PaketNo
        {
            get { return paketNo; }
            set { paketNo = value; }
        }

        private string konum;

        public string Konum
        {
            get { return konum; }
            set { konum = value; }
        }


    }
}
