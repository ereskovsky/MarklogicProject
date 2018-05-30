using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


namespace MarklogicProject.Models
{
    public class Response{
        [JsonProperty("search:response")]
        public SearchResponse Resp { get; set; }
    }
    public class SearchResponse
    {
        [JsonProperty("@xmlns:search")]
        public string XMLNS { get; set; }
        [JsonProperty("@snippet-format")]
        public string SnippetFormat { get; set; }
        [JsonProperty("@total")]
        public string Total { get; set; }
        [JsonProperty("@start")]
        public string Start { get; set; }
        [JsonProperty("@page-length")]
        public string PageLength { get; set; }
        [JsonProperty("search:result")]
        public SearchResult SearchResult { get; set; }
        [JsonProperty("search:qtext")]
        public string QueryText { get; set; }
        [JsonProperty("search:metrics")]
        public SearchMetrics SearchMetrics { get; set; }


    }
    public class SearchResult
    {
        [JsonProperty("@index")]
        public int Index { get; set; }
        [JsonProperty("@uri")]
        public string Uri { get; set; }
        [JsonProperty("@path")]
        public string Path { get; set; }
        [JsonProperty("@score")]
        public int Score { get; set; }
        [JsonProperty("@confidence")]
        public double Confidence { get; set; }
        [JsonProperty("@fitness")]
        public double Fitness { get; set; }
        [JsonProperty("@href")]
        public string Href { get; set; }
        [JsonProperty("@mimetype")]
        public string MimeType { get; set; }
        [JsonProperty("@format")]
        public string Format { get; set; }
        [JsonProperty("search:snippet")]
        public SearchSnippet Snippet { get; set; }

    }
    public class SearchSnippet
    {
        [JsonProperty("search:match")]
        public List<SearchMatch> Matches { get; set; }
    }
    public class SearchMatch
    {
        [JsonProperty("@path")]
        public string Path { get; set; }
        [JsonProperty("#text")]
        public List<string> Total { get; set; }
        [JsonProperty("search:highlighted")]
        public string Highlighted { get; set; }

    }
    public class SearchMetrics
    {
        [JsonProperty("search:query-resolution-time")]
        public string QueryResolutionTime { get; set; }
        [JsonProperty("search:snippet-resolution-time")]
        public string SnippetResolutionTime { get; set; }
        [JsonProperty("search:total-time")]
        public string TotalTime { get; set; }
    }
}