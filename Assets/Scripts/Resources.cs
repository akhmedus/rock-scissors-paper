using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Resources : MonoBehaviour
{

    public int coinNumber = 50;
    [SerializeField]
    TextMeshProUGUI coinText;

    private void Start()
    {
        UpdateText();
    }
    public bool Buy(int price) 
    {
        if (coinNumber >= price)
        {
            coinNumber -= price;

            UpdateText();
            return true;
        }
        else 
        {
            return false;

        }
    }

    public void AddCoin(int value) 
    {
        coinNumber += value;
        UpdateText();
    }

    void UpdateText() 
    {
        coinText.text = coinNumber.ToString();
    }


}
