using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main ;
    public Transform startPoint;
    public Transform[] path;
    public int currency;

    private void Awake()
    {
        main = this;

    }
    private void Start()
    {
        currency = 100;
    }

    public void IncreaseCurrency(int ammount)
    {
        currency += ammount;
    }
    public bool  SpendCurrency(int amount)
    {
        if(amount <= currency)
        {
           currency-=amount;
           return true;
        }
        return false;
    }
}
