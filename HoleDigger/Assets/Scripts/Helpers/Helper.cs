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
    public Text PowerText;
    public Button BuyButton;
    public GameObject Representor;

    // Use this for initialization
    void Start()
    {
      
    }

    private void OnEnable()
    {
        ProgressionManager.OnGold += UpdateButton;
    }

    private void OnDisable()
    {
        ProgressionManager.OnGold -= UpdateButton;
    }


    public void Dig()
    {
        HoleManager.GetInstance().DigHole((HelperQuantity * DigPower) * Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {
        Dig();
    }

    public virtual void BuyHelper(int _Amount)
    {
        if (ProgressionManager.GetInstance().GetGoldAmount() >= Cost)
        {
            HelperQuantity += _Amount;
            ProgressionManager.GetInstance().RemoveGold(Cost);
            Cost *= Mathf.Pow(1.1f, HelperQuantity);
            CostText.text = "Cost: " + Cost.ToString("F2");
        }
        UpdateButton();
    }

    public void SetQuantity(int _Amount) {    
        HelperQuantity = _Amount;
        Cost *= Mathf.Pow(1.1f, HelperQuantity);
        UpdateButton();
    }

    

    public void UpdateButton()
    {
        if(ProgressionManager.GetInstance().GetGoldAmount() > Cost)
        {
            BuyButton.interactable = true;
        }
        else
        {
            BuyButton.interactable = false;
        }
        if (!Representor.activeInHierarchy && HelperQuantity >= 1) Representor.SetActive(true);
        else if (HelperQuantity <= 0) Representor.SetActive(false);
    }
}
