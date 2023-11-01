using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TranstionScript : MonoBehaviour 
{
    [Header("Настройка перехода")]
    public GameObject Transtion_Panel;
    public Animation Transtion_Animation;

    public string String_Transtion;
    public bool Bool_Transtion;

    [Header("Панели для перехода")]
    public GameObject MarketObject;
    public bool BoolMarket;

    public GameObject UpgradeObject;
    public bool BoolUpgrade;

    public GameObject SettingObject;
    public bool BoolSetting;

    public GameObject StartObject;
    public bool BoolStart;

    private float Timer;

    // - Переход по панелям
    public void OpenMarket ()
    {   
        if (BoolMarket == false)
        {
            Transtion_Panel.SetActive(true);
            Transtion_Animation.Play("anim_transtion");

            String_Transtion = "Market";
            Bool_Transtion = true;
        }

        else

        if (BoolMarket == true)
        {
            AllClosed();
        }
    }

    public void OpenUpgrade ()
    {
        if (BoolUpgrade == false)
        {
            Transtion_Panel.SetActive(true);
            Transtion_Animation.Play("anim_transtion");

            String_Transtion = "Upgrade";
            Bool_Transtion = true;
        }

        else

        if (BoolUpgrade == true)
        {
            AllClosed();
        }
    }

    public void OpenSetting ()
    {
        if (BoolSetting == false)
        {
            Transtion_Panel.SetActive(true);
            Transtion_Animation.Play("anim_transtion");

            String_Transtion = "Setting";
            Bool_Transtion = true;
        }

        else

        if (BoolSetting == true)
        {
            AllClosed();
        }
    }

    public void AllClosed ()
    {
        Transtion_Panel.SetActive(true);
        Transtion_Animation.Play("anim_transtion");

        String_Transtion = "Closed";
        Bool_Transtion = true;
    }

    private void Update ()
    {
        if (Bool_Transtion == true){
        Timer += Time.deltaTime;
        if (Timer >= 0.50)
        {
            // - Переход по панелям
            if (String_Transtion == "Market")
            {   
                BoolMarket = true;
                BoolUpgrade = false;
                BoolSetting = false;

                MarketObject.SetActive(true);
                UpgradeObject.SetActive(false);
                SettingObject.SetActive(false);
            }

            if (String_Transtion == "Upgrade")
            {
                BoolMarket = false;
                BoolUpgrade = true;
                BoolSetting = false;

                MarketObject.SetActive(false);
                UpgradeObject.SetActive(true);
                SettingObject.SetActive(false);
            }

            if (String_Transtion == "Setting")
            {
                BoolMarket = false;
                BoolUpgrade = false;
                BoolSetting = true;

                MarketObject.SetActive(false);
                UpgradeObject.SetActive(false);
                SettingObject.SetActive(true);
            }

            if (String_Transtion == "Closed")
            {
                BoolMarket = false;
                BoolUpgrade = false;
                BoolSetting = false;
                BoolStart = false;
                
                MarketObject.SetActive(false);
                UpgradeObject.SetActive(false);
                SettingObject.SetActive(false);
                StartObject.SetActive(false);
            }
        }

        if (Timer >= 1)
        {
            Bool_Transtion = false;
            Transtion_Panel.SetActive(false);
            Timer = 0;
        }
        }
    }

}
