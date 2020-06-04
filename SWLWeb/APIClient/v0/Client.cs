using System.IO;
using System.Net;
using System.Xml;
using Newtonsoft.Json;

namespace APIClient.v0
{
    public class Client : ClientBase
    {
        public Client(string host, string appKey) : base("v0", host, appKey)
        {
        }

        private struct LoginData
        {
            public string Email;
        }

        public HttpStatusCode LoginByEmail(string email)
        {
            var retHttpStatusCode = HttpStatusCode.OK;

            var request = WebRequest.CreateHttp(_uri + "/auth");
            request.Headers.Add("AppKey", _appKey);
            request.MediaType = "application/json";
            request.ContentType = "application/json";
            request.Method = WebRequestMethods.Http.Post;
            var requestStream = request.GetRequestStream();
            TextWriter requestBody = new StreamWriter(requestStream);
            requestBody.Write(JsonConvert.SerializeObject(new LoginData {Email = email}));
            requestBody.Close();
            requestStream.Close();

            var response = (HttpWebResponse) request.GetResponse();

            retHttpStatusCode = response.StatusCode;

            return retHttpStatusCode;
        }
    }
}