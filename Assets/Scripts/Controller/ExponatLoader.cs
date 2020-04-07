using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class ExponatLoader : MonoBehaviour
{
    public static string bundleUrl = "http://localhost/api/assets/";
    public string bundleName = "testbundle";
    public string assetName = "BundledSpritObject";

    public int id;
    public string key;

    public API.ExponatObject exponatData;

    private string GetKey()
    {
        return PlayerPrefs.GetString("key");
    }

    void Start()
    {
        this.key = GetKey();
        StartCoroutine(GetRequest());
    }

    private void BuildExponat()
    {
        DataObjectController cntrlr = DataObjectController.GetInstance();
        GameObject obj = cntrlr.assetLoader.GetComponent<AssetLoader>().GetBuildIn(this.exponatData.tag);
        if ( obj == null )
        {
            Debug.LogError("failed to get asset as buildin");
            return;
        }

        GameObject objInstance = Instantiate(obj);
        objInstance.transform.SetParent(transform);
        objInstance.transform.position = transform.position;
        objInstance.transform.rotation = transform.rotation;
        Debug.Log("New Position: " + objInstance.transform.position.ToString());
    }

    IEnumerator GetImageAsset()
    {
        string uri = string.Format("http://localhost/api/exponat.php?key={0}&id={1}&type=png", key, id.ToString());

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                byte[] rawImageAsset = webRequest.downloadHandler.data;
            }
        }
    }

    IEnumerator GetRequest()
    {
        string uri = string.Format("http://localhost/api/exponat.php?key={0}&id={1}", key, id.ToString());

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                this.exponatData = JsonConvert.DeserializeObject<API.ExponatObject>(webRequest.downloadHandler.text);
                this.BuildExponat();
            }
        }
    }
}
