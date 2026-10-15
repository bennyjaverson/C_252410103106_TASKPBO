using System;
using System.Collections.Generic;

public class Karyawan
{
    public string nama { get; set; }
    public double gaji { get; set; }

    public Karyawan(string nama, double gaji)
    {
        this.nama = nama;
        this.gaji = gaji;
    }

    public virtual void Kerja()
    {
        Console.WriteLine($"{nama} Sedang Bekerja");
    }
    public virtual void InfoKaryawan()
    {
        Console.WriteLine($"Nama: {nama}, Gaji: {gaji}");
    }
}

public class Tetap : Karyawan 
{
    public double tunjangan { get; set; }
    public Tetap (string nama, double gaji, double tunjangan) : base (nama, gaji)
    {
        this.tunjangan = tunjangan;
    }
    public double HitungGajiTotal()
    {
        return gaji + tunjangan;
    }
    public override void InfoKaryawan()
    {
        base.InfoKaryawan();
        Console.WriteLine($"Tunjangan: {tunjangan}, Gaji Total: {HitungGajiTotal()}");
    }
}
public class Kontrak : Karyawan
{
    public int durasi { get; set; }
    public Kontrak(string nama, double gaji, int durasi) : base(nama, gaji)
    {
        this.durasi = durasi;
    }
    public void CekKontrak()
    {
        Console.WriteLine($"Kontrak {nama} berdurasi {durasi} bulan");
    }       
    public override void InfoKaryawan()
    {
        base.InfoKaryawan();
        Console.WriteLine($"Status: Kontrak | Durasi Kontrak: {durasi} bulan");
    }

}

public class Manager : Tetap
{
    public Manager (string nama, double gaji, double tunjangan) : base (nama, gaji, tunjangan) { }
    public void Memimpin()
    {
        Console.WriteLine($"{nama} sedang memimpin rapat");
    }
    public override void Kerja()
    {
        Console.WriteLine($"{nama} sedang mengawasi kinerja tim");
    }
}

public class Staff : Tetap
{
    public Staff (string nama, double gaji, double tunjangan) : base (nama, gaji, tunjangan) { }
    public void KerjakanTugas()
    {
        Console.WriteLine($"{nama} sedang mengerjakan tugas");
    }
    public override void Kerja()
    {
        Console.WriteLine($"{nama} sedang bekerja");
    }
}

public class Magang : Kontrak
{
    public Magang(string nama, double gaji, int durasi) : base(nama, gaji, durasi) { }
    public void Belajar()
    {
        Console.WriteLine($"{nama} sedang belajar dan mengamati");
    }
    public override void Kerja()
    {
        Console.WriteLine($"{nama} membantu pekerjaan");
    }
}

public class Freelancer : Kontrak
{
    public Freelancer(string nama, double gaji, int durasi) : base(nama, gaji, durasi) { }
    public void AmbilProyek()
    {
        Console.WriteLine($"{nama} mengambil proyek");
    }
    public override void Kerja()
    {
        Console.WriteLine($"{nama} sedang mengerjakan proyek");
    }
}

public class Perusahaan
{
    private List<Karyawan> daftarKaryawan = new List<Karyawan>();
    public void TambahKaryawan (Karyawan karyawan)
    {
        daftarKaryawan.Add(karyawan);
        Console.WriteLine($"{karyawan.nama} berhasil ditambah");
    }
    public void DaftarKaryawan()
    {
        foreach (Karyawan k in daftarKaryawan)
        {
            k.InfoKaryawan();
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Perusahaan perusahaan = new Perusahaan();

        Manager mgr = new Manager("Alex", 15000000, 5000000);
        Staff stf = new Staff("Asep", 5000000, 100000);
        Magang mgg = new Magang("Adit", 1500000, 6);
        Freelancer frl = new Freelancer("Aji", 4000000, 12);

        perusahaan.TambahKaryawan(mgr);
        perusahaan.TambahKaryawan(stf);
        perusahaan.TambahKaryawan(mgg);
        perusahaan.TambahKaryawan(frl);
        Console.WriteLine();

        perusahaan.DaftarKaryawan();
        Console.WriteLine();

        Console.WriteLine("Polymorphism: Kerja()");
        List<Karyawan> listKaryawan = new List<Karyawan> { mgr, stf, mgg, frl };
        foreach (var k in listKaryawan)
        {
            k.Kerja();
        }
        Console.WriteLine();

        Console.WriteLine("Method Khusus");
        mgr.Memimpin();
        stf.KerjakanTugas();
        mgg.Belajar();
        frl.AmbilProyek();
        mgg.CekKontrak();
        frl.CekKontrak();
        Console.WriteLine();

        Console.WriteLine("Variabel Karyawan berisi objek Staff");
        Karyawan kar = new Staff("Andi", 5500000, 800000);
        kar.Kerja();
        ((Staff)kar).KerjakanTugas();
    }
}