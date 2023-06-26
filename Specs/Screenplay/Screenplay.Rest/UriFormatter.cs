﻿using Screenplay.Core.Utilities;

namespace Screenplay.Rest
{
    internal class UriFormatter
    {
        private Dictionary<string, string> _queryParameters = new Dictionary<string, string>();
        private string _baseUrl;
        private string _resourceName;
        public void SetBaseUrl(string baseUrl)
        {
            this._baseUrl = baseUrl;
        }
        public void SetResourceName(string resourceName)
        {
            var queryParameters = QueryStringUtil.ExtractParameters(resourceName);
            queryParameters.ForEach(a => this.AddQueryParameter(a.Key, a.Value));

            if (resourceName.Contains("?"))
                resourceName = resourceName.Substring(0, resourceName.IndexOf("?", StringComparison.Ordinal));

            this._resourceName = resourceName;
        }
        public void AddQueryParameter(string key, string value)
        {
            _queryParameters.AddOrUpdate(key,value);
        }
        public Uri ToUri()
        {
            var baseUri = new Uri(this._baseUrl, UriKind.Absolute);
            var url = this._resourceName;
            if (_queryParameters.Any())
            {
                var query = string.Join("&", this._queryParameters.Select(a => a.Key + "=" + a.Value).ToList());
                url += "?" + query;
            }
            return new Uri(baseUri, url);
        }
    }
}
