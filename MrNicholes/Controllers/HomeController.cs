using System;
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

    public ActionResult GetHostEntry(string hostname, string dnsServer)
    {
      var response = NsLookup(hostname, dnsServer);
      return Json(response, JsonRequestBehavior.AllowGet);
    }

    private static IEnumerable<string> NsLookup(string host, string dnsServer, string recordType = "A")
    {
      var text = new List<string>();
      var process = new Process();
      var startInfo = new ProcessStartInfo("nslookup");

      startInfo.Arguments = "-q=" + recordType + " " + host + " " + dnsServer;
      startInfo.RedirectStandardOutput = true;
      startInfo.UseShellExecute = false;
      startInfo.CreateNoWindow = true;
      
      process.StartInfo = startInfo;
      process.OutputDataReceived += (sender, args) => text.Add(FormatString(args.Data));

      process.Start();
      process.BeginOutputReadLine();
      process.WaitForExit();

      return text;
    }

    private static string FormatString(string input)
    {
      return input;
    }
  }
}