using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExponatLoader : MonoBehaviour
{
    public static string bundleUrl = "http://localhost/api/assets/";
    public string bundleName = "testbundle";
    public string assetName = "BundledSpritObject";

    public API.ExponatObject exponatData;
 
    // Start is called before the first frame update
    public IEnumerator Start()
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
