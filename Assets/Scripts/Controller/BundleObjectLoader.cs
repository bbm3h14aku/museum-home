using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BundleObjectLoader : MonoBehaviour
{
    //public string assetName = "BundledSpritObject";
    //public string bundleName = "testbundle";

    // Start is called before the first frame update
    public static GameObject LoadSync(string bundleName, string assetName)
    {
        AssetBundle localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));

        if ( localAssetBundle == null)
        {
            Debug.LogError("failed to load local AssetBundle");
            return null;
        }

        GameObject asset = localAssetBundle.LoadAsset<GameObject>(assetName);
        asset.transform.Translate(1, 1, 1);
        asset = Instantiate(asset);
        localAssetBundle.Unload(false);
        return asset;
    }

    public IEnumerator LoadAsync(string bundleName, string assetName)
    {
        AssetBundleCreateRequest asyncBundleRequest = AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, bundleName));
        yield return asyncBundleRequest;

        AssetBundle localAssetBundle = asyncBundleRequest.assetBundle;
        if (localAssetBundle == null)
        {
            Debug.LogError("failed to load local AssetBundle");
            yield break;
        }

        AssetBundleRequest assetRequest = localAssetBundle.LoadAssetAsync<GameObject>(assetName);
        yield return assetRequest;

        GameObject prefab = assetRequest.asset as GameObject;
        Instantiate(prefab);
        prefab.transform.Translate(0, 1, 1);
        localAssetBundle.Unload(false);
    }

    /*
    void Start()
    {
        //LoadSync();
        LoadAsync();
    }
    */
}
