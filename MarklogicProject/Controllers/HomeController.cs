using MarkLogic.REST;
using MarklogicProject.Models;
using MimeTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
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

            // Get the desired document to write to the MarkLogic
            //  "Documents" database.
            
            string content = path;

            // Get a Document URI. If the URI does not already
            //  exist in the "Documents" database, the document
            //  is inserted as a new document. If the URI does exist,
            //  the existing document in the "Documents" database is 
            //  updated.
            

            // Create a DocumentManager to act as our interface for
            //  reading and writing to/from the database.
            DocumentManager mgr = dbClient.NewDocumentManager();

            // Create a GenericDocument object to write the
            //  content from the desired file to the MarkLogic
            //  database. The connection from the Database Client
            //  is used to write to the database.
            GenericDocument doc = new GenericDocument();
            // set the mime type.
            string mimetype = MimeTypeMap.GetMimeType(Path.GetExtension(path));
            var extension = Path.GetExtension(path);
            var mimeType = mimetype;

            doc.SetMimetype(mimetype);
            // set the contents from the file that was read.
            doc.SetContent(content);

            // write the document to the database with the
            //  specified URI.
            var results = mgr.Write(uri, doc);
            

            return View();
        }
        public ActionResult SearchResult(string search)
        {
            var query = search;

            // Create a QueryManager to act as our interface for
            //  searching the database.
            QueryManager mgr = dbClient.NewQueryManager();

            // Search results are retuned in a SearchResult object.
            // 
            var searchResult = mgr.SearchJson(query);


            //List<ResultOutput> list = new List<ResultOutput>();
            //// Each search result is returned in a MatchDocSummary object.
            ////  GetMatchResults() returns a list of these, if any.
            //foreach (MatchDocSummary result in searchResult.GetMatchResults())
            //{
            //    list.Add(new ResultOutput { Result = "---Result " + result.GetIndex() + "---------", Uri = result.GetUri(), Mime = result.GetMimetype(), Relevance = result.GetScore(), Text = result.GetFirstSnippetText() });
            //}
            //ViewBag.Result = list;
            //ViewBag.SearchRes = searchResult.ToString();
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(searchResult.ToString());
            //string jsonText = JsonConvert.SerializeXmlNode(doc);
            var resp = JsonConvert.DeserializeObject<SearchResponse>(searchResult);
             ViewBag.Response = resp;
            
            
            // return all search results as a string
            // string results = searchResult.ToString();

            return View();
        }

    }
}