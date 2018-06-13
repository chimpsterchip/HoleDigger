using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperReverseShovel : Helper {

	// Use this for initialization
	void Start () {
        CostText.text = "Cost: " + Cost.ToString("F2");
        PowerText.text = "Dig Strength: " + DigPower.ToString("F2");
        UpdateButton();
    }

    public override void BuyHelper(int _Amount)
    {
        base.BuyHelper(_Amount);
        PlayerPrefs.SetInt("ReverseShovelQuantity", HelperQuantity);
    }
}
