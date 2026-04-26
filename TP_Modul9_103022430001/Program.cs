using TP_Modul9_103022430001;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig();

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman? ");
        int hari = Convert.ToInt32(Console.ReadLine());

        bool kondisiSuhu = false;

        if (config.satuan_suhu == "celcius")
        {
            if (suhu >= 36.5 && suhu <= 37.5) kondisiSuhu = true;
        }
        else if (config.satuan_suhu == "fahrenheit")
        {
            if (suhu >= 97.7 && suhu <= 99.5) kondisiSuhu = true;
        }

        bool kondisiHari = hari < config.batas_hari_deman;

        if (kondisiSuhu && kondisiHari)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }
    }
}