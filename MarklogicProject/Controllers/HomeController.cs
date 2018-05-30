using MarkLogic.REST;
using MarklogicProject.Models;
using MimeTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace MarklogicProject.Controllers
{
    public class HomeController : Controller
    {
        static string host = ConfigurationManager.AppSettings["host"];
        static string port = ConfigurationManager.AppSettings["port"];
        static string username = ConfigurationManager.AppSettings["username"];
        static string password = ConfigurationManager.AppSettings["password"];
        static string realm = ConfigurationManager.AppSettings["realm"];

        DatabaseClient dbClient = DatabaseClientFactory.NewClient(host, port, username, password, realm, AuthType.Digest);
        [HttpGet]
        public ActionResult Index(string extension = null, string mimeType = null, string results = null )
        {
            ViewBag.Ext = extension;
            ViewBag.Mime = mimeType;
            ViewBag.Res = results;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string uri, HttpPostedFileBase Picture)
        {
            string path = null;
            if (Picture != null)
            {
                 path = System.IO.Path.GetFileName(Picture.FileName);
            }
            string content = path;
            DocumentManager mgr = dbClient.NewDocumentManager();
            GenericDocument doc = new GenericDocument();
            string mimetype = MimeTypeMap.GetMimeType(Path.GetExtension(path));
            var extension = Path.GetExtension(path);
            var mimeType = mimetype;
            doc.SetMimetype(mimetype);
            doc.SetContent(content);
            var results = mgr.Write(uri, doc);
            return View();
        }
        public ActionResult SearchResult(string search)
        {
            var query = search;
            QueryManager mgr = dbClient.NewQueryManager();
            var searchResult = mgr.SearchJson(query);
            Regex regexp = new Regex("(\",\\s{\"highlight\":)(\\w*\\W)(\\w+)(\"},\\s\")");
            string str = " <mark>" + search + "</mark> ";
            var trying = regexp.Replace(searchResult, str);
            var resp = JsonConvert.DeserializeObject<SearchResponse>(trying);
            ViewBag.Response = resp;
            return View();
        }

    }
}