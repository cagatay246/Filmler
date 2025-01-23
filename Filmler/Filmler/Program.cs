class Film
{
    // Film sınıfının property'leri
    public string Isim { get; set; }
    public double ImdbPuani { get; set; }
}

class Program
{
    static void Main()
    {
        List<Film> filmListesi = new List<Film>(); // Film listesi
        bool devamEt = true;

        Console.WriteLine("IMDB - Film Listesi Uygulamasına Hoşgeldiniz!");

        while (devamEt)
        {
            
            Console.Write("Film İsmi: ");
            string filmIsmi = Console.ReadLine();

            double imdbPuani;
            while (true)
            {
                Console.Write("IMDB Puanı: ");
                if (double.TryParse(Console.ReadLine(), out imdbPuani) && imdbPuani >= 0 && imdbPuani <= 10)
                {
                    break; // Geçerli bir puan girilirse döngüden çık
                }
                else
                {
                    Console.WriteLine("Lütfen 0 ile 10 arasında geçerli bir IMDB puanı giriniz!");
                }
            }

            
            filmListesi.Add(new Film { Isim = filmIsmi, ImdbPuani = imdbPuani });

            
            Console.Write("Yeni bir film eklemek istiyor musunuz? (Evet/Hayır): ");
            string cevap = Console.ReadLine()?.Trim().ToLower();

            devamEt = cevap == "evet";
        }

        // Uygulama sonunda istenen çıktılar
        Console.WriteLine("\nTüm Filmler:");
        foreach (var film in filmListesi)
        {
            Console.WriteLine($"Film: {film.Isim}, IMDB Puanı: {film.ImdbPuani}");
        }

        Console.WriteLine("\nIMDB Puanı 4 ile 9 arasında olan Filmler:");
        foreach (var film in filmListesi.Where(f => f.ImdbPuani >= 4 && f.ImdbPuani <= 9))
        {
            Console.WriteLine($"Film: {film.Isim}, IMDB Puanı: {film.ImdbPuani}");
        }

        Console.WriteLine("\nİsmi 'A' harfi ile başlayan Filmler:");
        foreach (var film in filmListesi.Where(f => f.Isim.StartsWith("A", StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"Film: {film.Isim}, IMDB Puanı: {film.ImdbPuani}");
        }
    }
}