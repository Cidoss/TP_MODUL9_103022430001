using System;
using System.IO;
using System.Text.Json;

namespace TP_Modul9_103022430001
{
    public class CovidConfig
    {
        // Variabel untuk menampung konfigurasi (Poin 1 & 2)
        public string satuan_suhu { get; set; }
        public int batas_hari_deman { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        private const string path = "covid_config.json";

        public CovidConfig()
        {
            try
            {
                ReadConfig();
            }
            catch
            {
                SetDefault(); // Poin 3: Jika gagal baca/file belum ada
                WriteConfig(); // Buat filenya
            }
        }

        private void ReadConfig()
        {
            string jsonString = File.ReadAllText(path);
            CovidConfig temp = JsonSerializer.Deserialize<CovidConfig>(jsonString);
            this.satuan_suhu = temp.satuan_suhu;
            this.batas_hari_deman = temp.batas_hari_deman;
            this.pesan_ditolak = temp.pesan_ditolak;
            this.pesan_diterima = temp.pesan_diterima;
        }

        private void SetDefault()
        {
            satuan_suhu = "celcius";
            batas_hari_deman = 14;
            pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }

        // Poin 6: Method UbahSatuan
        public void UbahSatuan()
        {
            if (satuan_suhu == "celcius")
            {
                satuan_suhu = "fahrenheit";
            }
            else
            {
                satuan_suhu = "celcius";
            }
        }

        private void WriteConfig()
        {
            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText(path, jsonString);
        }
    }
