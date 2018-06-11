﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour {

    double DepthFound;

    double GoldAmount;

    public Sprite TreasureSprite;

	// Use this for initialization
	void Start () {
		
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
    public void SetDepthFound(double _Depth) { DepthFound = _Depth; }
    public double GetGoldAmount() { return GoldAmount; }
    public void SetGoldAmount(double _Gold) { GoldAmount = _Gold; }
    public Sprite GetTreasureSprite() { return TreasureSprite; }
    public void SetTreasureSprite(Sprite _NewSprite) { TreasureSprite = _NewSprite; }
}
