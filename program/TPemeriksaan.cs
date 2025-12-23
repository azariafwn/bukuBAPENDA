namespace MonPDLib.EF
{
  // Pemetaan entitas C# ke tabel Oracle T_PEMERIKSAAN
  [Table("T_PEMERIKSAAN")]
  public partial class TPemeriksaan
  {
    [Key]
    [Column("NOP")]
    public string Nop { get; set; } = null!;  
    [Key]
    [Column("TAHUN_PAJAK")]
    public int TahunPajak { get; set; }  
    [Column("PAJAK_ID", TypeName="NUMBER(38)")]
    public decimal PajakId { get; set; }  
    [Column("JUMLAH_KB", TypeName="NUMBER(15,2)")]
    public decimal? JumlahKb { get; set; }  
    [Column("TGL_LHP", TypeName="DATE")]
    public DateTime? TglLhp { get; set; }
  }
}