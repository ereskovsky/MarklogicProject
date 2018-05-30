using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


namespace MarklogicProject.Models
{
    
    public class SearchResponse
    {
        
        [JsonProperty("snippet-format")]
        public string SnippetFormat { get; set; }
        [JsonProperty("total")]
        public string Total { get; set; }
        [JsonProperty("start")]
        public string Start { get; set; }
        [JsonProperty("page-length")]
        public string PageLength { get; set; }
        [JsonProperty("results")]
        public List<SearchResult> SearchResult { get; set; }
        [JsonProperty("qtext")]
        public string QueryText { get; set; }
        [JsonProperty("metrics")]
        public SearchMetrics SearchMetrics { get; set; }


    }
    public class SearchResult
    {
        [JsonProperty("index")]
        public int Index { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("score")]
        public int Score { get; set; }
        [JsonProperty("confidence")]
        public double Confidence { get; set; }
        [JsonProperty("fitness")]
        public double Fitness { get; set; }
        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("mimetype")]
        public string MimeType { get; set; }
        [JsonProperty("format")]
        public string Format { get; set; }
        [JsonProperty("matches")]
        public List<SearchMatch> Matches { get; set; }

    }
    public class SearchMatch
    {
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("match-text")]
        public object MatchText { get; set; }

    }
    //public class MatchText{


    //}
    public class SearchMetrics
    {
        [JsonProperty("query-resolution-time")]
        public string QueryResolutionTime { get; set; }
        [JsonProperty("snippet-resolution-time")]
        public string SnippetResolutionTime { get; set; }
        [JsonProperty("total-time")]
        public string TotalTime { get; set; }
    }
}