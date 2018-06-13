using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour {

    [Header("Ad identifier")]
    [Tooltip("The placement indentifier of the ad")]
    public string adID = "video";

    [Header("Reward amounts")]
    [Tooltip("Reward for full video")]
    public float fullReward = 100.0f;
    [Tooltip("Reward for skip")]
    public float skipReward = 50.0f;

    //script ref
    ProgressionManager progMan;

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
                //give player gold
                progMan.AddGold(fullReward);
                break;
            case ShowResult.Skipped:
                //give player less gold
                progMan.AddGold(skipReward);
                break;
            case ShowResult.Failed:
                //take the money ad should have earned
                Debug.Log("The ad couldn't load. Check that internet connection by attaching to cable you unearthed in that hole of yours");
                break;
            default:

                break;
        }
    }
}
