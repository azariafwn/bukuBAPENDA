namespace MonPDReborn.Models
{
  public class PemeriksaanVM
  {
    public static List<DataDetailPemeriksaan> GetDetailPemeriksaanList(int jenisPajak, int tahun)
    {
      var context = DBClass.GetContext();
      
      // Ambil data pemeriksaan berdasarkan filter
      var pemeriksaan=context.TPemeriksaan
          .Where(x=>x.PajakId==jenisPajak && x.TahunPajak==tahun)
          .ToList();
      // Mapping data dari database ke Entity VM
      if (jenisPajak == 1) // Kategori Pajak Resto
      {
        // GroupBy untuk memastikan tidak ada NOP duplikat saat konversi ke Dictionary
        var dbMamin=context.DbOpRestos
          .GroupBy(x=>x.Nop)
          .ToDictionary(g=>g.Key, g=>g.First());
        return pemeriksaan.Select(x=>new DataDetailPemeriksaan {
          JenisPajak = ((EnumFactory.EPajak)x.PajakId).GetDescription(),
          WajibPajak = dbMamin.ContainsKey(x.Nop) ? dbMamin[x.Nop].NpwpdNama : "-",
          NOP = x.Nop ?? "-",
          JumlahKB = x.JumlahKb ?? 0
        }).ToList();
      }
      return new List<DataDetailPemeriksaan>();
    }
  }
}