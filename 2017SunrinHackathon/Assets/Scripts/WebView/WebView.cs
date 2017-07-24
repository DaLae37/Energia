using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebView : MonoBehaviour
{
    private bool once;
    private WebViewObject webViewObject;

    // Use this for initialization
    void Start()
    {
        once = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(gameObject.active == true && !once)
        {
            StartWebView();
            once = true;
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Destroy(webViewObject);
                PlayerControl2.instance.isWeb = true;
                return;
            }
        }

    }

    public void StartWebView()
    {
        string strUrl = "http://soylatte.kr:8989/";

        webViewObject =
            (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init((msg) => {
            Debug.Log(string.Format("CallFromJS[{0}]", msg));
        });

        webViewObject.LoadURL(strUrl);
        webViewObject.SetVisibility(true);
    }
}