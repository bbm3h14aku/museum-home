using System;
using System.Net;
using System.IO;
using System.Text;

public class APIClient 
{
    private HttpWebRequest request;
    private HttpWebResponse response;

    private string target_url;
    private string api_key;

    public APIClient(string target_url) 
    {
        this.target_url = target_url;
        this.api_key = api_key;
    }

    public string Post(API.APIObject data)
    {
        string raw = data.Get();

        byte[] byteArray = Encoding.UTF8.GetBytes(raw);

        this.request = (HttpWebRequest)WebRequest.Create(this.target_url);
        this.request.Method = "POST";
        this.request.ContentType = "application/json";
        this.request.ContentLength = byteArray.Length;

        Stream dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();

        this.response = (HttpWebResponse) request.GetResponse();

        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        return jsonResponse;
    }

    public string Get() 
    {
        this.request = (HttpWebRequest)WebRequest.Create(this.target_url);
        this.response = (HttpWebResponse)request.GetResponse();

        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();

        if ( jsonResponse != null)
        {
            return jsonResponse;
        }
        else
        {
            throw new Exception("Failed to connect with api endpoint. so sad, worst api endpoint ever.");
            return null;
        }
    }
}
