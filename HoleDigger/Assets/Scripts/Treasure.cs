using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour {

    double DepthFound;

    double GoldAmount;

    private SpriteRenderer Renderer;

	// Use this for initialization
	void Start () {
        Renderer = GetComponent<SpriteRenderer>();

    }

    public void Initialise(double _DepthFound, double _GoldAmount)
    {
        DepthFound = _DepthFound;
        GoldAmount = _GoldAmount;
    } 

    // Update is called once per frame
    void Update () {
		
	}

    public double GetDepthFound() { return DepthFound; }
    public double GetGoldAmount() { return GoldAmount; }

    public void HideSprite() { Renderer.enabled = false; }
    public void ShowSprite() { Renderer.enabled = true; }
}
