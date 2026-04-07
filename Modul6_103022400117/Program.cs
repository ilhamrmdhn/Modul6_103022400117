using System.Diagnostics;

class SayaMusicUser
{
    private int id;
    public string Username;
    private List<SayaMusicTrack> uploadedTracks;

    public SayaMusicUser(string Username)
    {
        Debug.Assert(Username.Length <= 100, "Panjang maksimal 100 karakter");
        Debug.Assert(Username != null, "Username tidak boleh kosong!");
        this.Username = Username;
        this.uploadedTracks = new List<SayaMusicTrack>();
    }

    public int GetTotalPlayCount()
    {
        return uploadedTracks.Count;
    }

    public void AddTrack(SayaMusicTrack track)
    {
        Debug.Assert(track != null, "Track tidak boleh kosong!");
        Debug.Assert(track.getPlayCount() == int.MaxValue, "Tidak boleh kurang dari batas maksimum");

        uploadedTracks.Add(track);
    }

    public void PrintAllTracks()
    {
        int number = 1;
        foreach(var item in uploadedTracks)
        {
            Console.WriteLine($"Username: {Username}");
            Console.WriteLine($"Track: {number++} : {item.title}");
        }
    }
}

class SayaMusicTrack
{
    private int id;
    public string title;
    private int playCount;

    public SayaMusicTrack(string title)
    {
        Debug.Assert(title != null, "Judul track tidak boleh kosong!");
        Debug.Assert(title.Length <= 200, "Judul track maksimal 200 karakter!");

        this.title = title;
        Random random = new Random();
        this.id = random.Next(10000, 100000);
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        Debug.Assert(count <= 25000000, "Penambahan maksimal 25.000.000 per pemanggilan");
        Debug.Assert(count >= 0, "Tidak boleh bilangan negatif");
        this.playCount += count;
    }

    public void PrintTrackDetails()
    {
        Console.WriteLine($"ID Lagu: {this.id}");
        Console.WriteLine($"Judul Lagu: {this.title}");
        Console.WriteLine($"Total Play: {this.playCount}");
    }

    public int getPlayCount()
    {
        return playCount;
    }
}

class Program
{
    public static void Main(string [] args)
    {
        SayaMusicUser user1 = new SayaMusicUser("ilhamrmdhn");

        SayaMusicTrack track1 = new SayaMusicTrack("Payung Teduh");
        SayaMusicTrack track2 = new SayaMusicTrack("Mati-Matian");
        SayaMusicTrack track3 = new SayaMusicTrack("Lagu Sunday");
        SayaMusicTrack track4 = new SayaMusicTrack("Lagu Monday");
        SayaMusicTrack track5 = new SayaMusicTrack("Lagu Tuesday");
        SayaMusicTrack track6 = new SayaMusicTrack("Lagu Wednesday");
        SayaMusicTrack track7 = new SayaMusicTrack("Lagu Thursday");
        SayaMusicTrack track8 = new SayaMusicTrack("Lagu Friday");
        SayaMusicTrack track9 = new SayaMusicTrack("Lagu Laguan");
        SayaMusicTrack track10 = new SayaMusicTrack("Kereta Malam");

        track1.IncreasePlayCount(10);
        track2.IncreasePlayCount(20);
        track3.IncreasePlayCount(30);
        track4.IncreasePlayCount(40);
        track5.IncreasePlayCount(50);
        track6.IncreasePlayCount(60);
        track7.IncreasePlayCount(70);
        track8.IncreasePlayCount(80);
        track9.IncreasePlayCount(90);
        track10.IncreasePlayCount(100);


        user1.AddTrack(track1);
        user1.AddTrack(track2);
        user1.AddTrack(track3);
        user1.AddTrack(track4);
        user1.AddTrack(track5);
        user1.AddTrack(track6);
        user1.AddTrack(track7);
        user1.AddTrack(track8);
        user1.AddTrack(track9);
        user1.AddTrack(track10);

        user1.PrintAllTracks();

        Console.WriteLine("Total Play Count: " + user1.GetTotalPlayCount());
    }
}