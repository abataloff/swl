using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace APIClient
{
    public abstract class ClientBase
    {
        protected readonly Uri _uri;
        protected readonly string _appKey;


        protected ClientBase(string version, string host, string appKey)
        {
            _uri = new Uri(new Uri(host), version);
            _appKey = appKey;
        }
        
    }
}