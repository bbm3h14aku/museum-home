using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections;

public class APIClient 
{
    private class URIParam
    {
        private string key;
        private string val;

        public URIParam(string key, string val)
        {
            this.key = key;
            this.val = val;
        }

        public override string ToString()
        {
            return String.Format("{0}={1}", this.key, this.val);
        }
    }

    private HttpWebRequest request;

    private string target_url;
    private string api_key;
    private string contentType;

    private ArrayList _params;

    public APIClient(string target_url) 
    {
        this.target_url = target_url;
        this.contentType = "application/json";
        this._params = new ArrayList();
    }

    public void SetContentType(string contentType)
    {
        this.contentType = contentType;
    }

    public void SetKey(string api_key)
    {
        this.SetParam("key", api_key);
    }

    public void SetParam(string key, string val)
    {
        this._params.Add(new URIParam(key, val));
    }

    private string URIBuilder()
    {
        string uri = "";
        string param_str = "?";

        for ( int i = 0; i < this._params.Count; i++)
        {
            param_str = String.Concat(param_str, this._params[i].ToString());
            if (i != this._params.Count)
            {
                param_str = String.Concat(param_str, "&");
            }
        }
        uri = String.Format("{0}{1}", this.target_url, param_str);
        return uri;
    }

    public string Post(API.APIObject data)
    {
        string raw = data.Get();

        byte[] byteArray = Encoding.UTF8.GetBytes(raw);

        this.request = (HttpWebRequest)WebRequest.Create(this.URIBuilder());
        this.request.Method = "POST";
        this.request.ContentType = this.contentType;
        this.request.ContentLength = byteArray.Length;

        Stream dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        return reader.ReadToEnd();
    }

    public string Get() 
    {
        this.request = (HttpWebRequest)WebRequest.Create(this.URIBuilder());
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        return reader.ReadToEnd();
    }
}
