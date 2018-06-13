using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameManager : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //save game logic
    void SaveGame()
    {
        //set hole depth
        PlayerPrefs.SetFloat("Hole Depth", (float)HoleManager.GetInstance().GetHoleData());
        //set gold
        PlayerPrefs.SetFloat("Gold Collected", (float)ProgressionManager.GetInstance().GetGoldAmount());
    }
}
