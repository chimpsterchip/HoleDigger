using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Helps the player dig the hole
public class Helper : MonoBehaviour
{

    [Tooltip("How much the helper costs.")]
    public float Cost;
    [Tooltip("The amount of helpers purchased.")]
    public int HelperQuantity;
    [Tooltip("How much the helper can dig a second.")]
    public double DigPower;
    public Text CostText;

    // Use this for initialization
    void Start()
    {

    }

    public void Dig()
    {
        HoleManager.GetInstance().DigHole((HelperQuantity * DigPower) * Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {
        Dig();
    }

    public void BuyHelper(int _Amount)
    {
        if (ProgressionManager.GetInstance().GetGoldAmount() >= Cost)
        {
            HelperQuantity += _Amount;
            ProgressionManager.GetInstance().RemoveGold(Cost);
            Cost *= 1.1f;
            Cost = Mathf.Round(Cost);
            CostText.text = Cost.ToString();
        }
    }
}
