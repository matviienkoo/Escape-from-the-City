using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Analytics;

public class TutorialScript : MonoBehaviour 
{
    public int Int_Tutorial;
    public int IntNextTutorial;

    [Header("Иные панели")]
    public GameObject Market_Panel;
    public GameObject Upgrade_Panel;
    public GameObject Setting_Panel;

    [Header("Переходная панель")]
    public GameObject Transtion_Panel;
    public Animation Transtion_Animation;

    [Header("Графический туториал")]
    public GameObject Plot_Panel;
    public TextMeshProUGUI Text_Plot;
    private int Int_Plot;

    [Header("Текстовый туториал")]
    public GameObject Tutorial_Panel;
    public Animation Tutorial_Anim;

    public Image Tutorial_Img;
    public Sprite Tutorial_Indicators_Sprite;
    public Sprite Tutorial_MoneyDistance_Sprite;
    public Sprite Tutorial_Shop_Sprite;
    public Sprite Tutorial_Upgrade_Sprite;
    public Sprite Tutorial_Setting_Sprite;

    [Header("Анимации текстового туториала")]
    public Animation AnimText_Health;
    public Animation AnimText_Food;
    public Animation AnimText_Water;
    public Animation AnimText_Money;
    public Animation AnimText_Distance;
    public Animation AnimText_Shop;
    public Animation AnimText_Upgrade;
    public Animation AnimText_Setting;

    [Header("Скрипты")]
    public TranstionScript TrnScript;
    public FirebaseAnalitics FirebaseScript;
    public EventSystem EventFunction;

    // Графический туториал
    IEnumerator IEnumerator_Text () 
    {
        var originalString = Text_Plot.text;
        Text_Plot.text = "";

        var numCharsRevealed = 0;
        while (numCharsRevealed < originalString.Length)
        {
            ++numCharsRevealed;
            Text_Plot.text = originalString.Substring(0, numCharsRevealed);
            if (Text_Plot.text == originalString){
                yield return new WaitForSeconds(0.5f);
                EventFunction.enabled = true;
            }
            yield return new WaitForSeconds(0.07f);
        }
    }

    public void GraphicPlot ()
    {
        Int_Plot += 1;
        EventFunction.enabled = false;

        if (Int_Plot == 5){
            Transtion_Panel.SetActive(true);
            Transtion_Animation.Play("Resurrect");
            EventFunction.enabled = true;
            StartCoroutine(WaitGraphicPlot());
        }

        if (Int_Plot == 4){
            Text_Plot.text = "Нужно бежать от сюда";
            StartCoroutine(IEnumerator_Text());
        }

        if (Int_Plot == 3){
            Text_Plot.text = "Этот город напоминание о всем плохом";
            StartCoroutine(IEnumerator_Text());
        }

        if (Int_Plot == 2){
            Text_Plot.text = "Я погряз в уныние";
            StartCoroutine(IEnumerator_Text());
        }

        if (Int_Plot == 1){
            Text_Plot.text = "После того, как меня бросила девушка";
            StartCoroutine(IEnumerator_Text());

            // Firebase Analitics
            FirebaseScript.BeginTutorial();
        }
    }

    IEnumerator WaitGraphicPlot () 
    {
        yield return new WaitForSeconds(2f);
        Plot_Panel.SetActive(false);

        yield return new WaitForSeconds(2f);
        Transtion_Panel.SetActive(false);
    }

    // Текстовый туториал
    public void NextScene ()
    {
        EventFunction.enabled = false;
        StartCoroutine(WaitNextSystem());

        if (IntNextTutorial == 0){
            Tutorial_Img.sprite = Tutorial_MoneyDistance_Sprite;
            AnimText_Health.Play("OffText");
            AnimText_Food.Play("OffText");
            AnimText_Water.Play("OffText");
        }

        if (IntNextTutorial == 1){
            Tutorial_Img.sprite = Tutorial_Shop_Sprite;
            AnimText_Money.Play("OffText");
            AnimText_Distance.Play("OffText");
        }

        if (IntNextTutorial == 2){
            Tutorial_Img.sprite = Tutorial_Upgrade_Sprite;
            AnimText_Shop.Play("OffText");
        }

        if (IntNextTutorial == 3){
            Tutorial_Img.sprite = Tutorial_Setting_Sprite;
            AnimText_Upgrade.Play("OffText");
        }

        if (IntNextTutorial == 4){
            AnimText_Setting.Play("OffText");
            Tutorial_Anim.Play("OffPanel");

            // Firebase Analitics
            FirebaseScript.CompleteTutorial();
        }
    }

    IEnumerator WaitNextSystem () 
    {
        yield return new WaitForSeconds(1f);
        if (IntNextTutorial == 0){
            AnimText_Money.Play("OnText");
            AnimText_Distance.Play("OnText");
        }

        if (IntNextTutorial == 1){
            AnimText_Shop.Play("OnText");
            Market_Panel.SetActive(true);
            Upgrade_Panel.SetActive(false);
            Setting_Panel.SetActive(false);
        }

        if (IntNextTutorial == 2){
            AnimText_Upgrade.Play("OnText");
            Market_Panel.SetActive(false);
            Upgrade_Panel.SetActive(true);
            Setting_Panel.SetActive(false);
        }

        if (IntNextTutorial == 3){
            AnimText_Setting.Play("OnText");
            Market_Panel.SetActive(false);
            Upgrade_Panel.SetActive(false);
            Setting_Panel.SetActive(true);
        }

        if (IntNextTutorial == 4){
            Int_Tutorial = 1;
            PlayerPrefs.SetInt("Int_Tutorial", Int_Tutorial);


            Tutorial_Panel.SetActive(false);
            TrnScript.AllClosed();
        }

        yield return new WaitForSeconds(2f);
        IntNextTutorial += 1;
        EventFunction.enabled = true;
    }
}