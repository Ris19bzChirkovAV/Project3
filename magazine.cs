using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class magazine : MonoBehaviour
{
    public Image magaz;
    public Text money;
    public Text price1;
    public Text price2;
    public Text price3;
    public Text price4;
    public Text price5;
    public int moneyInt, price1Int, price2Int, price3Int = 50, price4Int = 50, price5Int = 50;

    void Start()
    {
        money = GameObject.Find("Money").GetComponent<Text>();
        price1 = GameObject.Find("price1").GetComponent<Text>();
        price2 = GameObject.Find("price2").GetComponent<Text>();
        price3 = GameObject.Find("price3").GetComponent<Text>();
        price4 = GameObject.Find("price4").GetComponent<Text>();
        price5 = GameObject.Find("price5").GetComponent<Text>();

        if (PlayerPrefs.GetInt("FirstOn") != 1)
        {
            PlayerPrefs.SetInt("FirstOn", 1);
            PlayerPrefs.SetFloat("Bomb1Radius", 3.0F);
            PlayerPrefs.SetInt("Bomb1RadiusLevel", 0);
            PlayerPrefs.SetFloat("Bomb2Radius", 6.0F);
            PlayerPrefs.SetInt("Bomb2RadiusLevel", 0);
            PlayerPrefs.SetFloat("DelHealthCount", -0.005F);
            PlayerPrefs.SetInt("DelHealthLevel", 0);
            PlayerPrefs.SetFloat("TimeWaitBombs", 0.05F);
            PlayerPrefs.SetInt("TimeWaitBombsLevel", 0);
            PlayerPrefs.SetFloat("MaxSpeed", 0.05F);
            PlayerPrefs.SetInt("MaxSpeedLevel", 0);
            PlayerPrefs.SetInt("Money", 0);
        }
        moneyInt = PlayerPrefs.GetInt("Money");
        if (PlayerPrefs.GetInt("Bomb1RadiusLevel") < 9)
        {
            price1Int = (int)(50 * Math.Pow(2, PlayerPrefs.GetInt("Bomb1RadiusLevel")));
            price1.text = "" + price1Int;
        }
        else
            price1.text = "Max Level";

        if (PlayerPrefs.GetInt("Bomb2RadiusLevel") < 9)
        {
            price2Int = (int)(50 * Math.Pow(2, PlayerPrefs.GetInt("Bomb2RadiusLevel")));
            price2.text = "" + price2Int;
        }
        else
            price2.text = "Max Level";

        if (PlayerPrefs.GetInt("DelHealthLevel") < 9)
        {
            price3Int = (int)(50 * Math.Pow(2, PlayerPrefs.GetInt("DelHealthLevel")));
            price3.text = "" + price3Int;
        }
        else
            price3.text = "Max Level";

        if (PlayerPrefs.GetInt("TimeWaitBombsLevel") < 9)
        {
            price4Int = (int)(50 * Math.Pow(2, PlayerPrefs.GetInt("TimeWaitBombsLevel")));
            price4.text = "" + price4Int;
        }
        else
            price4.text = "Max Level";

        if (PlayerPrefs.GetInt("MaxSpeedLevel") < 9)
        {
            price5Int = (int)(50 * Math.Pow(2, PlayerPrefs.GetInt("MaxSpeedLevel")));
            price5.text = "" + price5Int;
        }
        else
            price5.text = "Max Level";


        money.text = "" + moneyInt;
        magaz.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void magazOn()
    {
        if (!magaz.IsActive())
            magaz.gameObject.SetActive(true);
    }

    public void buy1()
    {
        if (moneyInt >= price1Int)
        {
            if (PlayerPrefs.GetInt("Bomb1RadiusLevel") < 9)
            {
                moneyInt -= price1Int;
                price1Int *= 2;
                money.text = "" + moneyInt;
                price1.text = "" + price1Int;
                PlayerPrefs.SetFloat("Bomb1Radius", PlayerPrefs.GetFloat("Bomb1Radius") + 0.2F);
                PlayerPrefs.SetInt("Bomb1RadiusLevel", PlayerPrefs.GetInt("Bomb1RadiusLevel") + 1);
                PlayerPrefs.SetInt("Money", moneyInt);
            }
            else
            {
                price1.text = "Max Level";
            }

        }
        else
        {
            // noMoney audio
        }
    }

    public void buy2()
    {
        if (moneyInt >= price2Int)
        {
            if (PlayerPrefs.GetInt("Bomb2RadiusLevel") < 9)
            {
                moneyInt -= price2Int;
                price2Int *= 2;
                money.text = "" + moneyInt;
                price2.text = "" + price2Int;
                PlayerPrefs.SetFloat("Bomb2Radius", PlayerPrefs.GetFloat("Bomb2Radius") + 0.2F);
                PlayerPrefs.SetInt("Bomb2RadiusLevel", PlayerPrefs.GetInt("Bomb2RadiusLevel") + 1);
                PlayerPrefs.SetInt("Money", moneyInt);
            }
            else
            {
                price2.text = "Max Level";
            }

        }
        else
        {
            // noMoney audio
        }
    }

    public void buy3()
    {
        if (moneyInt >= price3Int)
        {
            if (PlayerPrefs.GetInt("DelHealthLevel") < 9)
            {
                moneyInt -= price3Int;
                price3Int *= 2;
                money.text = "" + moneyInt;
                price3.text = "" + price3Int;
                PlayerPrefs.SetFloat("DelHealthCount", PlayerPrefs.GetFloat("DelHealthCount") + 0.0002F);
                PlayerPrefs.SetInt("DelHealthLevel", PlayerPrefs.GetInt("DelHealthLevel") + 1);
                PlayerPrefs.SetInt("Money", moneyInt);
            }
            else
            {
                price3.text = "Max Level";
            }

        }
        else
        {
            // noMoney audio
        }
    }

    public void buy4()
    {
        if (moneyInt >= price4Int)
        {
            if (PlayerPrefs.GetInt("TimeWaitBombsLevel") < 9)
            {
                moneyInt -= price4Int;
                price4Int *= 2;
                money.text = "" + moneyInt;
                price4.text = "" + price4Int;
                PlayerPrefs.SetFloat("TimeWaitBombs", PlayerPrefs.GetFloat("TimeWaitBombs") - 0.002F);
                PlayerPrefs.SetInt("TimeWaitBombsLevel", PlayerPrefs.GetInt("TimeWaitBombsLevel") + 1);
                PlayerPrefs.SetInt("Money", moneyInt);
            }
            else
            {
                price4.text = "Max Level";
            }

        }
        else
        {
            // noMoney audio
        }
    }

    public void buy5()
    {
        if (moneyInt >= price5Int)
        {
            if (PlayerPrefs.GetInt("MaxSpeedLevel") < 9)
            {
                moneyInt -= price5Int;
                price5Int *= 2;
                money.text = "" + moneyInt;
                price5.text = "" + price5Int;
                PlayerPrefs.SetFloat("MaxSpeed", PlayerPrefs.GetFloat("MaxSpeed") + 0.0025F);
                PlayerPrefs.SetInt("MaxSpeedLevel", PlayerPrefs.GetInt("MaxSpeedLevel") + 1);
                PlayerPrefs.SetInt("Money", moneyInt);
            }
            else
            {
                price5.text = "Max Level";
            }

        }
        else
        {
            // noMoney audio
        }
    }

    public void Ads()
    {
        moneyInt += 10000;
        money.text = "" + moneyInt;
    }

    public void DeletePrefs()
    {
        PlayerPrefs.SetInt("FirstOn", 0);
    }
}
