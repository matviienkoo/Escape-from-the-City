using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class AdsScript : MonoBehaviour 
{	
	public GameObject Ads_Panel;
	private float DistanceKilometr;
	private float Money;
	private int Int_Ads;

    [Header("Балтика")]
    public BaltikaMoveScript BaltikaMove;
    public GameObject Baltika_GameObject;
    public bool BaltikaBool;

    [Header("Казино")]
    public CasinoMoveScript CasinoMove;
    public GameObject Casino_GameObject;
    public TextMeshProUGUI Text_Win_Price;
    private int Int_Win_Price;
    public bool CasinoBool;

    [Header("Реклама Балтики")]
	public GameObject Baltika_Panel;
	public GameObject Baltika_Sound;
	public bool Baltika_Bool;

    [Header("Реклама Казино")]
	public GameObject Casino_Panel;
	public GameObject CasinoWin_Sound;
	public GameObject CasinoLose_Sound;
	public GameObject Casino_Button;
	public GameObject TextMoney_Panel;
	public bool Casino_Bool;

	public GameObject BallFirst_Panel;
	public Animation CupFirst_Anim;

	public GameObject BallSecond_Panel;
	public Animation CupSecond_Anim;

	public GameObject BallThirt_Panel;
	public Animation CupThirt_Anim;

	[Header("Система перехода")]
	public GameObject Transtion_Panel;
    public Animation Transtion_Animation;

	[Header("Скрипты")]
	public EventSystem EventFunction;
	public AudioSorceScript AudioScript;
	public ParallaxScript Parallax_Script;
	public PlayerScript Player_Script;
	public ObjectMoveScript ObjectMove_Script;
	public BaltikaMoveScript BaltikaMove_Script;
	public CasinoMoveScript CasinoMove_Script;
	public AmbulanceMoveScript Ambulance_Script;
	public PoliceMoveScript Police_Script;
	public IventMoveScript Drugs_Script;
	public IventMoveScript School_Script;
	public IventMoveScript Policy_Script;
	public IventMoveScript Gopnik_Script;
	public OmonMoveScript Omon_Script;
	public IventMoveScript Phone_Script;
	public MilitaryMoveScript Military_Script;

	// Автоматитечкая система демонстрации рекламы
	private void Start ()
	{
		StartCoroutine(WaitAndPrint());
	}

	private void Update ()
	{
		Money = PlayerPrefs.GetFloat("Money");
	}

	IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(90f);
        int RandomAds = Random.Range(1, 3);

        if (RandomAds == 1){   
        Baltika_GameObject.SetActive(true);
        BaltikaMove.LaunchBaltika();
        }

        if (RandomAds == 2){
        Casino_GameObject.SetActive(true);
        CasinoMove.LaunchCasino();
        }

        // Возобновить таймер
        StartCoroutine(WaitAndPrint());
    }

    // БУСТ СКОРОСТИ
	public void OpenBaltika ()
	{
		Transtion_Panel.SetActive(true);
		Transtion_Animation.Play("Resurrect");
		Baltika_Bool = true;
		StartCoroutine(AdsTranstion());
	}
    public void DrinkAlcohol ()
    {
    	Baltika_Sound.SetActive(true);
    	EventFunction.enabled = false;
    	StartCoroutine(EffectTranstion_Alcohol());
    	StartCoroutine(EnableBonus());
    	AudioScript.Music_Pitch_On();
    	Parallax_Script.AdsBonus();

    	// Изменить показатели в других скриптах
    	Player_Script.AdsBonus();
    	ObjectMove_Script.AdsBonus();
    	BaltikaMove_Script.AdsBonus();
    	CasinoMove_Script.AdsBonus();
    	Ambulance_Script.AdsBonus();
    	Police_Script.AdsBonus();
    	Drugs_Script.AdsBonus();
    	School_Script.AdsBonus();
    	Policy_Script.AdsBonus();
    	Gopnik_Script.AdsBonus();
    	Omon_Script.AdsBonus();
    	Phone_Script.AdsBonus();
    	Military_Script.AdsBonus();
    }

    IEnumerator EnableBonus()
    {
        yield return new WaitForSeconds(60);
        AudioScript.Music_Pitch_Off();
    }

    IEnumerator EffectTranstion_Alcohol()
    {
    	yield return new WaitForSeconds(1f);
    	Transtion_Panel.SetActive(true);
		Transtion_Animation.Play("Resurrect");

    	yield return new WaitForSeconds(2f);
    	Ads_Panel.SetActive(false);
    	Casino_Panel.SetActive(false);
    	Baltika_Panel.SetActive(false);
    	Baltika_Sound.SetActive(false);
    	EventFunction.enabled = true;

    	yield return new WaitForSeconds(2f);
    	Transtion_Panel.SetActive(false);
    }

    // ЛОТЕРЕЙНАЯ СИСТЕМА
    public void OpenCasino ()
	{
		Transtion_Panel.SetActive(true);
		Transtion_Animation.Play("Resurrect");
		Casino_Bool = true;
		StartCoroutine(AdsTranstion());

		// Цено образование 
		DistanceKilometr = PlayerPrefs.GetFloat("DistanceKilometr");

		if (DistanceKilometr <= 1){
			Int_Win_Price = 50;
			Text_Win_Price.text = "Приз за победу " + Int_Win_Price.ToString("n0");
		}
		if (DistanceKilometr <= 5 && DistanceKilometr > 1){
			Int_Win_Price = 100;
			Text_Win_Price.text = "Приз за победу " + Int_Win_Price.ToString("n0");
		}
		if (DistanceKilometr <= 20 && DistanceKilometr > 5){
			Int_Win_Price = 1250;
			Text_Win_Price.text = "Приз за победу " + Int_Win_Price.ToString("n0");
		}
		if (DistanceKilometr <= 50 && DistanceKilometr > 20){
			Int_Win_Price = 4500;
			Text_Win_Price.text = "Приз за победу " + Int_Win_Price.ToString("n0");
		}
		if (DistanceKilometr <= 150 && DistanceKilometr > 50){
			Int_Win_Price = 10000;
			Text_Win_Price.text = "Приз за победу " + Int_Win_Price.ToString("n0");
		}
	}

	// Запустить прокрутку стаканчика
	public void AnimCups ()
	{
		CupFirst_Anim.Play();
		CupSecond_Anim.Play();
		CupThirt_Anim.Play();

		StartCoroutine(WaitCups());
		EventFunction.enabled = false;
	}
	IEnumerator WaitCups()
    {
    	yield return new WaitForSeconds(2f);
    	Casino_Button.SetActive(false);
    	Int_Ads = Random.Range(1, 4);

    	EventFunction.enabled = true;
    }

    // Выбор нужного стаканчика
    public void Cup_First (){
		EventFunction.enabled = false;
		if (Int_Ads == 1){
		BallFirst_Panel.SetActive(true);
		TextMoney_Panel.SetActive(true);
		CasinoWin_Sound.SetActive(true);

			Money += Int_Win_Price;
			PlayerPrefs.SetFloat("Money",Money);
		}
		else
		CasinoLose_Sound.SetActive(true);
		StartCoroutine(EffectTranstion_Casino());

		CupFirst_Anim.Play("CupFirstUpAnim");
	}
	public void Cup_Second (){
		EventFunction.enabled = false;
		if (Int_Ads == 2){
		BallSecond_Panel.SetActive(true);
		TextMoney_Panel.SetActive(true);
		CasinoWin_Sound.SetActive(true);

			Money += Int_Win_Price;
			PlayerPrefs.SetFloat("Money",Money);
		}
		else
		CasinoLose_Sound.SetActive(true);
		StartCoroutine(EffectTranstion_Casino());

		CupSecond_Anim.Play("CupSecondUpAnim");
	}
	public void Cup_Thirt (){
		EventFunction.enabled = false;
		if (Int_Ads == 3){
		BallThirt_Panel.SetActive(true);
		TextMoney_Panel.SetActive(true);
		CasinoWin_Sound.SetActive(true);

			Money += Int_Win_Price;
			PlayerPrefs.SetFloat("Money",Money);
		}
		else
		CasinoLose_Sound.SetActive(true);
		StartCoroutine(EffectTranstion_Casino());

		CupThirt_Anim.Play("CupThirtUpAnim");
	}

	IEnumerator EffectTranstion_Casino()
    {
    	yield return new WaitForSeconds(2f);
    	Transtion_Panel.SetActive(true);
		Transtion_Animation.Play("Resurrect");

    	yield return new WaitForSeconds(2f);
    	Ads_Panel.SetActive(false);
    	Casino_Panel.SetActive(false);
    	Baltika_Panel.SetActive(false);
    	TextMoney_Panel.SetActive(false);
    	BallFirst_Panel.SetActive(false);
    	BallSecond_Panel.SetActive(false);
    	BallThirt_Panel.SetActive(false);
    	Casino_Button.SetActive(true);

    	CupFirst_Anim.Play("CupFirstDownAnim");
    	CupSecond_Anim.Play("CupSecondDownAnim");
    	CupThirt_Anim.Play("CupThirtDownAnim");

    	EventFunction.enabled = true;

    	yield return new WaitForSeconds(2f);
    	Transtion_Panel.SetActive(false);

    	yield return new WaitForSeconds(4f);
    	CasinoLose_Sound.SetActive(false);
    	Baltika_Sound.SetActive(false);
    	CasinoWin_Sound.SetActive(false);
    }

	// СИСТЕМА ПЕРЕХОДА
	IEnumerator AdsTranstion()
    {
    	yield return new WaitForSeconds(2f);
    	Ads_Panel.SetActive(true);
    	if (Casino_Bool == true){
    		Casino_Panel.SetActive(true);
    	}
    	if (Baltika_Bool == true){
    		Baltika_Panel.SetActive(true);
    	}

    	yield return new WaitForSeconds(2f);
    	Transtion_Panel.SetActive(false);
    	Casino_Bool = false;
    	Baltika_Bool = false;
    }
}