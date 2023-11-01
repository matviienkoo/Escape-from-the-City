using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingNumbersScript : MonoBehaviour 
{
    private int EventScore;

    [Header("Деньги")]
    public float Money;
    public TextMeshProUGUI Text_Money;

    [Header("Дистанция")]
    public float DistanceMetr;
    public float DistanceKilometr;
    public TextMeshProUGUI Distance_Money;

    [Header("Жизненные показатели")]
    public float Current_Life;
    public float Current_Food;
    public float Current_Water;

    public void ChangeIndicatorsSlider ()
    {
        Current_Life = 100;
        Current_Food = 100;
        Current_Water = 100;
        PlayerPrefs.SetFloat("Current_Life",Current_Life);
        PlayerPrefs.SetFloat("Current_Food",Current_Food);
        PlayerPrefs.SetFloat("Current_Water",Current_Water);
    }

    public void ChangequQantityMoney ()
    {
        // Узнать какой ивент по счету
        EventScore = PlayerPrefs.GetInt("EventScore");

        // Полицейский ивент
        if (EventScore == 3)
        {
            if (Money >= 100 && Money < 500){
            Money -= 100;
            PlayerPrefs.SetFloat("Money",Money);
            }

            if (Money >= 500 && Money < 1000){
            Money -= 250;
            PlayerPrefs.SetFloat("Money",Money);
            }

            if (Money >= 1000){
            Money -= 1000;
            PlayerPrefs.SetFloat("Money",Money);
            }
        }

        // Гопник ивент
        if (EventScore == 4)
        {
            Money = 0;
            PlayerPrefs.SetFloat("Money",Money);
        }
    }

    private void Update ()
    {   
        // Деньги
        Money = PlayerPrefs.GetFloat("Money");
        Text_Money.text = Money.ToString("n0") + " рублей";

        // Пройденное расстаяние
        DistanceMetr = PlayerPrefs.GetFloat("DistanceMetr");
        DistanceKilometr = PlayerPrefs.GetFloat("DistanceKilometr");
        Distance_Money.text = DistanceKilometr.ToString() + "км " + DistanceMetr.ToString() + "м";

        // Жизненные показатели
        Current_Life = PlayerPrefs.GetFloat("Current_Life");
        Current_Food = PlayerPrefs.GetFloat("Current_Food");
        Current_Water = PlayerPrefs.GetFloat("Current_Water");
    }
}