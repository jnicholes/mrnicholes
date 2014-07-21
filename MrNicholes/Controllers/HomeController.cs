using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MrNicholes.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }

    public ActionResult GetHostEntry(string hostname)
    {
      var response = GetText(hostname, "8.8.8.8");
      var parsedResponse = response.Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Replace("\t", "").Replace(" ", "")).ToList();
      return Json(parsedResponse, JsonRequestBehavior.AllowGet);
    }

    private List<string> GetText(string host, string dnsServer)
    {
      var info = new ProcessStartInfo("nslookup");
      info.Arguments = host + " " + dnsServer;
      var text = new List<string>();
      info.RedirectStandardOutput = true;
      info.UseShellExecute = false;
      info.CreateNoWindow = true;
      var process = System.Diagnostics.Process.Start(info);
      process.OutputDataReceived += (sender, args) => { text.Add(args.Data); };
      process.Start();
      process.BeginOutputReadLine();
      process.WaitForExit();
      return text;
    }
  }
}