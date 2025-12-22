namespace MonPDReborn.Controllers
{
 public class PemeriksaanController : Controller
 {
  public IActionResult Detail(int jenisPajak, int tahun)
  {
    try
    {
      var model = new Models.AktivitasOP.PemeriksaanVM.Detail(jenisPajak, tahun);
      return PartialView($"{URLView}_{actionName}", model);
    }
    catch (Exception ex)
    {
      response.Status = StatusEnum.Error;
      response.Message = "Server Error: Internal Server Error";
      return Json(response);
    }
  }
 }
}