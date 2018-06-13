using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour {

    [Header("Ad identifier")]
    [Tooltip("The placement indentifier of the ad")]
    public string adID = "video";

    //ShowResult adViewResult;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //show ad logic
    public void ShowAd()
    {
        //check if ad is ready to play
        if (Advertisement.IsReady())
        {
            //get show options
            var showOptions = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show(adID, showOptions);
        }
    }

    //handle video callback
    private void HandleShowResult(ShowResult result)
    {
        //based on result of playback
        switch (result)
        {
            case ShowResult.Finished:

                break;
            case ShowResult.Skipped:

                break;
            case ShowResult.Failed:

                break;
            default:

                break;
        }
    }
}
