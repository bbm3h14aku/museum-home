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

    public string description;
    public string label;
    public string imageurl;

    public API.ExponatObject exponatData;

    private string GetKey()
    {
        return PlayerPrefs.GetString("key");
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
                API.ExponatObject expObj = JsonConvert.DeserializeObject<API.ExponatObject>(webRequest.downloadHandler.text);
            }
        }
    }

    void Start()
    {
        this.key = GetKey();
        StartCoroutine(GetRequest());
    }

    // Start is called before the first frame update
    public IEnumerator OldGetRequest()
    {
        Debug.Log("sending request to " + bundleUrl + exponatData.exponat);
        using (WWW web = new WWW(bundleUrl + bundleName))
        {
            yield return web;
            AssetBundle remoteAssetBundle = web.assetBundle;
            if (remoteAssetBundle == null)
            {
                Debug.LogError("failed to download asset bundle");
                yield break;
            }
            Debug.Log("instantiate " + assetName + " from " + bundleName);
            GameObject _object = Instantiate(remoteAssetBundle.LoadAsset(assetName)) as GameObject;
            ///AddComponent(remoteAssetBundle.LoadAsset(assetName));
            remoteAssetBundle.Unload(false);
            _object.transform.position = new Vector3(exponatData.pos_x, exponatData.pos_y, exponatData.pos_z);
            _object.transform.rotation = Quaternion.Euler(exponatData.rot_x, exponatData.rot_y, exponatData.rot_z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
