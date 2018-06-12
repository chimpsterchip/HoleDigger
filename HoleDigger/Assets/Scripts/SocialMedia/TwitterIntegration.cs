using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitterIntegration : MonoBehaviour {

    [Header("Twitter stuff")]
    public string url = "http://twitter.com/intent/tweet";
    public string tweetMessage = "Sup fellas.";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //attach to where twitter is called <- button or something
    public void OpenTwitter()
    {
        Application.OpenURL(url + "?text=" + WWW.EscapeURL(tweetMessage));
    }
}
