using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperMiniShovel : Helper {

	// Use this for initialization
	void Start () {
        CostText.text = "Cost: " + Cost.ToString("F2");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
