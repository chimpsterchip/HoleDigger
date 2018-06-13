using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using System.Linq;

public class fbManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init();
        }
        else
        {
            FB.ActivateApp();
        }
    }

    public void FBShare()
    {
        //check that fb is logged in
        if (FB.IsLoggedIn)
        {
            //get share link
            FB.ShareLink(contentTitle: "Streaking Reindeers", contentURL: new System.Uri("http://www.streakingreindeers.com"), contentDescription: "Like and Share my page", callback: OnShare);
        }
        else
        {
            Debug.Log("Not logged into fb");
            FB.LogInWithReadPermissions(null, callback: OnLogin);
        }
    }

    void OnLogin(ILoginResult result)
    {
        if (result.Cancelled)
        {
            Debug.Log("User cancelled login because fb sucks");
        }
        else
        {
            FBShare();
        }
    }

    void OnShare(IShareResult result)
    {
        if(result.Cancelled || !string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Sharelink erro: " + result.Error);
        }
        else if(!string.IsNullOrEmpty(result.PostId)){
            Debug.Log("Link shared");
        }
    }
}
