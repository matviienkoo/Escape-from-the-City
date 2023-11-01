using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour 
{
    private float DistanceKilometr;
    private float DistanceMetr;

    private float PerSecondTimer;
    private float lerpSpeed;
    private bool BoolAdsBonus;

    [Header("Деньги и Скорость")]
    public float Money;
    public float clicksPerSecond;

    [Header("Показатель жизней")]
    public Image LifeBar;
    public float Current_Life, Max_Life = 100;

    [Header("Показатель еды")]
    public Image FoodBar;
    private float FoodTimer;
    public float Current_Food, Max_Food = 100;

    [Header("Показатель воды")]
    public Image WaterBar;
    private float WaterTimer;
    public float Current_Water, Max_Water = 100;

    [Header("Покатель смерти")]
    public GameObject Dead_GameObject;

    [Header("Количетсво шагов для получения денег")]
    public float ClasicDistance_Money;
    public float RandomDistance_Money;

    [Header("Количетсво шагов до уменьшения жизненных показателей")]
    public float ClasicDistance_Vital;
    public float RandomDistance_Vital;

    [Header("Сумма которая получит игрок за пройденное расстояние")]
    public float RewardForDistance;

    private void Start ()
    {
        RewardForDistance = PlayerPrefs.GetFloat("RewardForDistance");

        // получение денег после рандомно пройденных шагов
        RandomDistance_Money = Random.Range(20, 65);

        // уменьшение жизненных после рандомно пройденных шагов
        RandomDistance_Vital = Random.Range(75, 85);

        // настройка минимального дохода
        if (RewardForDistance == 0)
        {
            RewardForDistance = 1;
            PlayerPrefs.SetFloat("RewardForDistance",RewardForDistance);
        }
    }

    public void AdsBonus ()
    {
        BoolAdsBonus = true;
        StartCoroutine(EnableBonus());
    }

    IEnumerator EnableBonus()
    {
        yield return new WaitForSeconds(60);
        BoolAdsBonus = false;
    }

    public void RunButton ()
    {
        if(Input.touchCount < 6)
        {
            // Добавляет скорость
            clicksPerSecond += 1;
            PlayerPrefs.SetFloat("clicksPerSecond",clicksPerSecond);

            if (clicksPerSecond >= 2)
            {
                if (BoolAdsBonus == false)
                {
                    // Добавляет дистанцию
                    DistanceMetr += 1;

                    // Добавляет шаги для получения денег
                    ClasicDistance_Money += 1;

                    // Добавляет шаги для уменьшения жизненных показателей
                    ClasicDistance_Vital += 1;
                }

                if (BoolAdsBonus == true)
                {
                    DistanceMetr += 2;

                    ClasicDistance_Money += 2;

                    ClasicDistance_Vital += 2;
                }

                PlayerPrefs.SetFloat("DistanceMetr",DistanceMetr);
                PlayerPrefs.SetFloat ("ClasicDistance_Money", ClasicDistance_Money);
                PlayerPrefs.SetFloat ("ClasicDistance_Vital", ClasicDistance_Vital);
            }

            if (ClasicDistance_Money >= RandomDistance_Money)
            {
                Money += RewardForDistance;
                PlayerPrefs.SetFloat("Money",Money);

                ClasicDistance_Money = 0;
                RandomDistance_Money = Random.Range(20, 65);
                PlayerPrefs.SetFloat("ClasicDistance_Money",ClasicDistance_Money);
            }

            if (ClasicDistance_Vital >= RandomDistance_Vital) 
            {
                Current_Water -= 8;
                Current_Food -= 4;
                PlayerPrefs.SetFloat ("Current_Food", Current_Food);
                PlayerPrefs.SetFloat ("Current_Water", Current_Water);

                ClasicDistance_Vital = 0;
                RandomDistance_Vital = Random.Range(75, 85);
                PlayerPrefs.SetFloat("ClasicDistance_Vital",ClasicDistance_Vital);
            }

            if (DistanceMetr >= 1000)
            {
                DistanceMetr = 0;
                PlayerPrefs.SetFloat ("DistanceMetr", DistanceMetr);

                DistanceKilometr += 1;
                PlayerPrefs.SetFloat ("DistanceKilometr", DistanceKilometr);
            }
        }
    }

    private void Update ()
    {
        ClasicDistance_Money = PlayerPrefs.GetFloat("ClasicDistance_Money");
        ClasicDistance_Vital = PlayerPrefs.GetFloat("ClasicDistance_Vital");

        DistanceKilometr = PlayerPrefs.GetFloat("DistanceKilometr");
        DistanceMetr = PlayerPrefs.GetFloat("DistanceMetr");

        RewardForDistance = PlayerPrefs.GetFloat("RewardForDistance");
        clicksPerSecond = PlayerPrefs.GetFloat("clicksPerSecond");
        Money = PlayerPrefs.GetFloat("Money");
        lerpSpeed = 2f * Time.deltaTime;

        // Настройка показателся жизней
        Current_Life = PlayerPrefs.GetFloat("Current_Life");
        LifeBar.fillAmount = Mathf.Lerp(LifeBar.fillAmount, (Current_Life / Max_Life), lerpSpeed);
        if (Current_Life <= 0){
        Current_Life = 0;
        PlayerPrefs.SetFloat ("Current_Life", Current_Life);

        Dead_GameObject.SetActive(true);
        }
        if (Current_Life > Max_Life){
        Current_Life = 100;
        PlayerPrefs.SetFloat ("Current_Life", Current_Life);
        }

         // Настройка показателся еди
        Current_Food = PlayerPrefs.GetFloat("Current_Food");
        FoodBar.fillAmount = Mathf.Lerp(FoodBar.fillAmount, (Current_Food / Max_Food), lerpSpeed);
        if (Current_Food < 0){
        Current_Food = 0;
        PlayerPrefs.SetFloat ("Current_Food", Current_Food);
        }
        if (Current_Food > Max_Food){
        Current_Food = 100;
        PlayerPrefs.SetFloat ("Current_Food", Current_Food);
        }

        if (Current_Food <= 0)
        {
            FoodTimer += Time.deltaTime; 
            if (FoodTimer >= 3)
            {
                Current_Life -= 8;
                FoodTimer = 0;
                PlayerPrefs.SetFloat ("Current_Life", Current_Life);
            }
        }

         // Настройка показателся воды
        Current_Water = PlayerPrefs.GetFloat("Current_Water");
        WaterBar.fillAmount = Mathf.Lerp(WaterBar.fillAmount, (Current_Water / Max_Water), lerpSpeed);
        if (Current_Water < 0){
        Current_Water = 0;
        PlayerPrefs.SetFloat ("Current_Water", Current_Water);
        }
        if (Current_Water > Max_Water){
        Current_Water = 100;
        PlayerPrefs.SetFloat ("Current_Water", Current_Water);
        }

        if (Current_Water <= 0)
        {
            WaterTimer += Time.deltaTime; 
            if (WaterTimer >= 3)
            {
                Current_Life -= 8;
                WaterTimer = 0;
                PlayerPrefs.SetFloat ("Current_Life", Current_Life);
            }
        }

        // Система контроля скорости бега
        PerSecondTimer += Time.deltaTime; 
        if (clicksPerSecond >= 1){ 
        if (PerSecondTimer >= 0.12)
        {
            clicksPerSecond -= 1;
            PerSecondTimer = 0;
            PlayerPrefs.SetFloat("clicksPerSecond",clicksPerSecond);
        }
        }

        if (clicksPerSecond >= 5)
        {
            clicksPerSecond = 4;
            PlayerPrefs.SetFloat("clicksPerSecond",clicksPerSecond);
        }
    }
}