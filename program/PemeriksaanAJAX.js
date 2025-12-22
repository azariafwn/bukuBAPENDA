function loadDetail(jenisPajak, tahun) {
  $.ajax({
      url: '/PemeriksaanPajak/Detail',
      type: 'GET',
      data: {jenisPajak:jenisPajak, tahun:tahun},
      beforeSend: function () {
        $('#loading2-Detail').show(); // Menampilkan spinner
        $('#Detail').hide();
      },
      success: function (result) {
        $('#loading2-Detail').hide();
        $('#Detail').html(result).show(); // Merender Partial View secara dinamis
      }
  });
}