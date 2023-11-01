using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Analytics;

public class IventScript : MonoBehaviour 
{
	private float DistanceKilometr;
    private float DistanceMetr;
    private float Timer;

    public List<GameObject> All_Objects;
    public GameObject Ivent_Panel;
    public TextMeshProUGUI Text_Explantion;
    public Animator Animator_Text_Explantion;
    public GameObject Dead_GameObject;

    [Header("Переходная панель")]
    public GameObject Transtion_Panel;
    public Animation Transtion_Animation;

    public bool Bool_Transtion;
    public string String_Transtion;

    [Header("Скрипты")]
    public AudioSorceScript AudioScript;
    public ParallaxScript ParalaxScript;
    public SettingNumbersScript SNumberScript;
    public AmbulanceMoveScript AmbulanceScript;
    public EventSystem EventFunction;

	[Header("Ивент по счету")]
	public int EventScore;

	[Header("Психоделический Ивент (0)")]
	public bool Bool_Drugs;
	public IventMoveScript IMS_Drugs;

	public GameObject Character_Drugs;
	public GameObject Panel_Psyhodelic;
	public GameObject Music_Psyhodelic;

	[Header("Школьный ивент (1)")]
	public bool Bool_School;
	public IventMoveScript IMS_School;
	private int IntSelectionSchool;

	public GameObject Bleack_Panel;
	public Animation Bleack_Animation;

	public List<Image> ListImg_SchoolChildren;
	public Image Img_SchoolChilden;
	public Sprite Sprite_SchoolChilden_Sad;
    public Sprite Sprite_SchoolChilden_Very_Sad;

	public GameObject Character_School;
	public GameObject Sound_SchoolChildren;
	public AudioSource Sound_PunchFirst;
	public AudioSource Sound_PunchSecond;

	[Header("Полицеский Ивент (2)")]
	public bool Bool_Policy;
	public IventMoveScript IMS_Policy;

	public GameObject Character_Policy;
	public GameObject Sound_MoneyFuckyPolicy;
	public TextMeshProUGUI Text_Police_Money_Hand;
	public GameObject GameObject_Police_Money_Hand;

	[Header("Гопник Ивент (3)")]
	public bool Bool_Gopnik;
	public IventMoveScript IMS_Gopnik;

	public GameObject Character_Gopnik;
	public GameObject Sound_Gopnik;

	[Header("Омон Ивент (4)")]
	public bool Bool_Omon;
	public PoliceMoveScript IMS_Omon;

	public GameObject Character_Omon;

	[Header("Телефон Ивент (5)")]
	public bool Bool_Phone;
	public IventMoveScript IMS_Phone;

	public Image Img_Phone;
	public Sprite Sprite_Phone_Answer;
	public GameObject Character_Phone;
	public GameObject Sound_Zirinovsky;
	public GameObject Sound_PhoneCalling;

	[Header("Армейский Ивент (6)")]
	public bool Bool_Military;
	public MilitaryMoveScript IMS_Military;

	private int Int_End;
	private bool Bool_Infection;
	public Animation HandAnimation;
	public Animator ShockAnimator;
	public TextMeshProUGUI Text_End;
	public GameObject Start_Panel;
	public GameObject End_GameObject;
	public GameObject TransPlot_Panel;
	public GameObject Drugs_Panel;
	public GameObject Hand_Panel;
	public GameObject End_Music;
	public GameObject Character_Military;

	public void Bool_System ()
	{
		Transtion_Panel.SetActive(true);
		Transtion_Animation.Play("Resurrect");
		Bool_Transtion = true;
	}

	IEnumerator Text_System () 
	{
	    var originalString = Text_Explantion.text;
	    Text_Explantion.text = "";

	    var numCharsRevealed = 0;
	    while (numCharsRevealed < originalString.Length)
	    {
	        ++numCharsRevealed;
	        Text_Explantion.text = originalString.Substring(0, numCharsRevealed);
	        if (Text_Explantion.text == originalString){
	        Animator_Text_Explantion.enabled = true;
	    	}

	        yield return new WaitForSeconds(0.07f);
        }
    }

    IEnumerator Speed_Text_System () 
	{
	    var originalString = Text_Explantion.text;
	    Text_Explantion.text = "";

	    var numCharsRevealed = 0;
	    while (numCharsRevealed < originalString.Length)
	    {
	        ++numCharsRevealed;
	        Text_Explantion.text = originalString.Substring(0, numCharsRevealed);
	        if (Text_Explantion.text == originalString){
	        SchoolTextSystem();
	    	}

	        yield return new WaitForSeconds(0.04f);
        }
    }

    IEnumerator End_Text_System () 
	{
	    var originalString = Text_End.text;
	    Text_End.text = "";

	    var numCharsRevealed = 0;
	    while (numCharsRevealed < originalString.Length)
	    {
	        ++numCharsRevealed;
	        Text_End.text = originalString.Substring(0, numCharsRevealed);
	        if (Text_End.text == originalString){
	        yield return new WaitForSeconds(1f);
	        EventFunction.enabled = true;
	    	}

	        yield return new WaitForSeconds(0.07f);
        }
    }

	// --------- Психоделический Ивент --------- (0)
	private void Event_Drugs ()
	{
		Character_Drugs.SetActive(true);
		IMS_Drugs.Launch();
		Bool_Drugs = true;
	}

	public void Start_Drugs ()
	{
		// Выключение панели, и запуск таймера
		String_Transtion = "Closed";
		StartCoroutine(Timer_Drugs());
		Bool_System();

		// Запуск психоделического эффекта, и обратного бега
		Panel_Psyhodelic.SetActive(true);
		ParalaxScript.PsyhodelicEffect();

		// Настройка реверс музыки
		Music_Psyhodelic.SetActive(true);
		AudioScript.ReverseMusic_On();
		AudioScript.Music_Off();
	}

	IEnumerator Timer_Drugs () 
	{
		yield return new WaitForSeconds(35f);
		String_Transtion = "White Transtion";
		Bool_System();
	}

	// --------- Гопник Ивент --------- (1)
	private void Event_Gopnik ()
	{
		Character_Gopnik.SetActive(true);
		IMS_Gopnik.Launch();
		Bool_Gopnik = true;
	}

	public void Start_Gopnik ()
	{
		// Выключение панели
		String_Transtion = "Closed";
		Bool_System();

		// Настройка смеха, и обнуления денег
		Sound_Gopnik.SetActive(true);
		SNumberScript.ChangequQantityMoney();
	}

	// --------- Полицеский Ивент --------- (2)
	private void Event_Policy ()
	{
		Character_Policy.SetActive(true);
		IMS_Policy.Launch();
		Bool_Policy = true;
	}

	public void Money_Policy ()
	{
		// Выключение панели
		String_Transtion = "Closed";
		Bool_System();

		// Настройка смеха, и обнуления денег
		Sound_MoneyFuckyPolicy.SetActive(true);
		SNumberScript.ChangequQantityMoney();
	}

	public void Fuck_Policy ()
	{
		// Выключение панели
		String_Transtion = "Closed";
		Bool_System();

		// Настройка смеха, и обнуления денег
		Dead_GameObject.SetActive(true);
		AmbulanceScript.PoliceVariantCar();
		AmbulanceScript.PoliceVariantTable();
	}

	// --------- Школьный ивент --------- (3)
	private void Event_School ()
	{
		Character_School.SetActive(true);
		IMS_School.Launch();
		Bool_School = true;

		// Включить звук школоты
		Sound_SchoolChildren.SetActive(true);
	}

	public void Punch ()
	{
		if (IntSelectionSchool < 15)
		{
			// Удари
			int IntSoundPunch = Random.Range(1, 3);
			IntSelectionSchool += 1;

			if (IntSoundPunch == 1){
				Sound_PunchFirst.Play();
			}
			if (IntSoundPunch == 2){
				Sound_PunchSecond.Play();
			}

			// Блик
			if (IntSelectionSchool < 15){
				Bleack_Panel.SetActive(true);
				Bleack_Animation.Play();
				StartCoroutine(DelaySchoolTranstion());
			}
			
			if (IntSelectionSchool >= 15)
			{
				String_Transtion = "Closed";
				Bool_System();
			}
		}
	}

	IEnumerator DelaySchoolTranstion () 
	{
		yield return new WaitForSeconds(0.15f);
		Bleack_Panel.SetActive(false);
	}

	private void SchoolTextSystem ()
	{
		if (Bool_School == true){
		int IntSchool = Random.Range(1, 5);

		if (IntSelectionSchool == 0){
			if (IntSchool == 1){
				Text_Explantion.text = "Иди нам водочки купи";
	        	StartCoroutine(Speed_Text_System());
			}
			if (IntSchool == 2){
				Text_Explantion.text = "Ты куришь ашкудишку";
	        	StartCoroutine(Speed_Text_System());
			}
			if (IntSchool == 3){
				Text_Explantion.text = "ВАХВАХВА скибиди туалеты";
	        	StartCoroutine(Speed_Text_System());
			}
			if (IntSchool == 4){
				Text_Explantion.text = "Сейчас на атомы разорвусь";
	        	StartCoroutine(Speed_Text_System());
			}
		}

		if (IntSelectionSchool > 0 && IntSelectionSchool <= 5){

		// Сделать школьника злым
		Img_SchoolChilden.sprite = Sprite_SchoolChilden_Sad;

			if (IntSchool == 1){
				Text_Explantion.text = "Ты знаешь кто мой батя";
	        	StartCoroutine(Speed_Text_System());
			}
			if (IntSchool == 2){
				Text_Explantion.text = "Тебе конец, копай могилу";
	        	StartCoroutine(Speed_Text_System());
			}
			if (IntSchool == 3){
				Text_Explantion.text = "АААААААААААА";
	        	StartCoroutine(Speed_Text_System());
			}
			if (IntSchool == 4){
				Text_Explantion.text = "Та я твою маму!";
	        	StartCoroutine(Speed_Text_System());
			}
		}

		if (IntSelectionSchool > 5 && IntSelectionSchool <= 15){

		// Сделать школьника, и его компанию очень грустной
		Img_SchoolChilden.sprite = Sprite_SchoolChilden_Very_Sad;
		for(int x = 0;x < ListImg_SchoolChildren.Count;x++){
        ListImg_SchoolChildren[x].sprite = Sprite_SchoolChilden_Very_Sad;;
        }

			if (IntSchool == 1){
				Text_Explantion.text = "ААААУАУАУАУАА";
	        	StartCoroutine(Speed_Text_System());
			}
			if (IntSchool == 2){
				Text_Explantion.text = "НЕ БЕЙ";
	        	StartCoroutine(Speed_Text_System());
			}
			if (IntSchool == 3){
				Text_Explantion.text = "АААААА";
	        	StartCoroutine(Speed_Text_System());
			}
			if (IntSchool == 4){
				Text_Explantion.text = "ПРОСТИ, ПРОСТИ";
	        	StartCoroutine(Speed_Text_System());
			}
		}
		}
	}

	// --------- Омон Ивент --------- (4)
	private void Event_Omon ()
	{
		Character_Omon.SetActive(true);
		IMS_Omon.LaunchPolice_Come();
		Bool_Omon = true;
	}

	// --------- Телефон Ивент --------- (5)
	private void Event_Phone ()
	{
		Character_Phone.SetActive(true);
		IMS_Phone.Launch();
		Bool_Phone = true;
	}

	public void Answer_Phone ()
	{
		// Звонок
		Img_Phone.sprite = Sprite_Phone_Answer;

		// Система звуков
		Sound_PhoneCalling.SetActive(false);
		Sound_Zirinovsky.SetActive(true);

		// Запуск таймера
		StartCoroutine(TimeAnswer());
	}

	IEnumerator TimeAnswer () 
	{
		yield return new WaitForSeconds(12f);

		// Включение музыки назад
		AudioScript.Music_On();

		// Выключение панели
		String_Transtion = "Closed";
		Bool_System();
	}

	// --------- Армейский Ивент --------- (6)
	private void Event_Military ()
	{
		Character_Military.SetActive(true);
		IMS_Military.Launch();
		Bool_Military = true;
	}

	public void Open_Syringle_Panel ()
	{
		String_Transtion = "Military";
		Bool_System();
	}

	public void Change_Text ()
	{
		Int_End += 1;
		EventFunction.enabled = false;

		if (Int_End == 1){
			Text_End.text = "Поздравляю!";
			StartCoroutine(End_Text_System());
		}

		if (Int_End == 2){
			Text_End.text = "Вы смогли сбежать";
			StartCoroutine(End_Text_System());
		}

		if (Int_End == 3){
			Text_End.text = "В 4D пространство";
			StartCoroutine(End_Text_System());
		}

		if (Int_End == 4){
			Text_End.text = "Это ли вы хотели?";
			StartCoroutine(End_Text_System());
		}

		if (Int_End == 5){
			AudioScript.EndMusic_Off();
			StartCoroutine(IEnumerator_Again());
			Transtion_Panel.SetActive(true);
			Transtion_Animation.Play("Resurrect");
		}
	}

	public void GiveInjection ()
	{
		if (Bool_Infection == false)
		{
			HandAnimation.Play();
			StartCoroutine(Wait_End());

			Bool_Infection = true;
		}
	}

	IEnumerator Wait_End () 
	{
		yield return new WaitForSeconds(3f);
		String_Transtion = "End Transtion";
		Bool_System();
	}

	IEnumerator Wait_4D () 
	{
		yield return new WaitForSeconds(11f);
		TransPlot_Panel.SetActive(true);
		Drugs_Panel.SetActive(true);
		Hand_Panel.SetActive(false);
	}

	IEnumerator IEnumerator_Again () 
	{
		yield return new WaitForSeconds(2f);
		Start_Panel.SetActive(true);
		End_GameObject.SetActive(false);
		Ivent_Panel.SetActive(false);

		yield return new WaitForSeconds(2f);
		PlayerPrefs.DeleteAll();
		int Int_Tutorial = 1;
        PlayerPrefs.SetInt("Int_Tutorial", Int_Tutorial);
        SNumberScript.ChangeIndicatorsSlider();

        SceneManager.LoadScene("GameScene");
	}

	private void Update ()
	{
		DistanceMetr = PlayerPrefs.GetFloat("DistanceMetr");
        DistanceKilometr = PlayerPrefs.GetFloat("DistanceKilometr");
        EventScore = PlayerPrefs.GetInt("EventScore");

		// Система переходов
		if (Bool_Transtion == true){
        Timer += Time.deltaTime;
        if (Timer >= 2)
        {
        	if (String_Transtion == "Drugs"){
        		Ivent_Panel.SetActive(true);
        		All_Objects[0].SetActive(true);
        	}

        	if (String_Transtion == "Gopnik"){
        		Ivent_Panel.SetActive(true);
        		All_Objects[1].SetActive(true);
        	}

        	if (String_Transtion == "Policy"){
        		Ivent_Panel.SetActive(true);
        		All_Objects[2].SetActive(true);

        		// Узнаем достаточно ли у нас денег
        		float Money = PlayerPrefs.GetFloat("Money");
        		if (Money < 100)
        		{
        			GameObject_Police_Money_Hand.SetActive(false);
        		}

        		// Изменить показатели текста
        		if (Money >= 100 && Money < 500)
        		{
        			Text_Police_Money_Hand.text = "Промолчать и дать 100 рублей";
			    }
			    if (Money >= 500 && Money < 1000)
			    {
			    	Text_Police_Money_Hand.text = "Промолчать и дать 250 рублей";
			    }
			    if (Money >= 1000)
			    {
			    	Text_Police_Money_Hand.text = "Промолчать и дать 1000 рублей";
			    }
        	}

        	if (String_Transtion == "School"){
        		Ivent_Panel.SetActive(true);
        		All_Objects[3].SetActive(true);
        	}

        	if (String_Transtion == "Omon"){
        	}

        	if (String_Transtion == "Phone"){
        		Ivent_Panel.SetActive(true);
        		All_Objects[4].SetActive(true);
        	}

        	if (String_Transtion == "Military"){
        		All_Objects[5].SetActive(true);
        		Ivent_Panel.SetActive(true);
        	}

        	if (String_Transtion == "White Transtion")
        	{
        		// Отключить психоделический эффект
        		Panel_Psyhodelic.SetActive(false);
				ParalaxScript.ClasicEffect();

				Music_Psyhodelic.SetActive(false);
				AudioScript.ReverseMusic_Off();
				AudioScript.Music_On();
        	}

        	if (String_Transtion == "End Transtion")
        	{
        		// Включить концовку
        		End_GameObject.SetActive(true);
				End_Music.SetActive(true);
				StartCoroutine(Wait_4D());

				AudioScript.EndMusic_On();
				AudioScript.Music_Off();
        	}

        	if (String_Transtion == "Closed")
        	{
        		for(int x = 0;x < All_Objects.Count;x++){
        		Animator_Text_Explantion.enabled = false;
		        All_Objects[x].SetActive(false);
		        Ivent_Panel.SetActive(false);
		        Text_Explantion.text = "";
		        }

		        if (Bool_Drugs == true){
		        IMS_Drugs.Launch();
		        Bool_Drugs = false;
		    	}
		    	if (Bool_Gopnik == true){
		        IMS_Gopnik.Launch();
		        Bool_Gopnik = false;
		    	}
		    	if (Bool_Policy == true){
		        IMS_Policy.Launch();
		        Bool_Policy = false;
		    	}
		    	if (Bool_School == true){
		        IMS_School.Launch();
		        Bool_School = false;
		    	}
		    	if (Bool_Omon == true){
		        Bool_Omon = false;
		    	}
		    	if (Bool_Phone == true){
		        IMS_Phone.Launch();
		        Bool_Phone = false;
		    	}
		    	if (Bool_Military == true){
		        IMS_Military.Launch();
		        Bool_Military = false;
		    	}
        	}
        }
        if (Timer >= 4)
        {
            if (Bool_Drugs == true){
            	Text_Explantion.text = "Вы нашли таблетки!";
        		StartCoroutine(Text_System());
            }

            if (Bool_Gopnik == true){
            	Text_Explantion.text = "Вас хотят гопнуть!";
        		StartCoroutine(Text_System());
            }

            if (Bool_Policy == true){
            	Text_Explantion.text = "Куда идешь, шалапай?";
        		StartCoroutine(Text_System());
            }

            if (Bool_School == true){
            	SchoolTextSystem();
            }

            if (Bool_Phone == true){
            	AudioScript.Music_Off();
            	Sound_PhoneCalling.SetActive(true);
            	Text_Explantion.text = "Вас хотят переубедить!";
        		StartCoroutine(Text_System());
            }

            if (Bool_Military == true){
            	ShockAnimator.enabled = true;
            }

            Bool_Transtion = false;
            Transtion_Panel.SetActive(false);
            Timer = 0;
        }
        }

		// Первый ивент
		if (DistanceKilometr >= 1 && DistanceMetr >= 100 && EventScore == 0)
		{
			Event_Drugs();
			String_Transtion = "Drugs";
			EventScore = 1;
			PlayerPrefs.SetInt("EventScore",EventScore);
		}

		// Второй ивент
		if (DistanceKilometr >= 4 && DistanceMetr >= 700 && EventScore == 1)
		{
			Event_School();
			String_Transtion = "School";
			EventScore = 2;
			PlayerPrefs.SetInt("EventScore",EventScore);
		}

		// Трейтий ивент
		if (DistanceKilometr >= 11 && DistanceMetr >= 500 && EventScore == 2)
		{
			Event_Policy();
			String_Transtion = "Policy";
			EventScore = 3;
			PlayerPrefs.SetInt("EventScore",EventScore);
		}

		// Четвертый ивент
		if (DistanceKilometr >= 31 && DistanceMetr >= 400 && EventScore == 3)
		{
			Event_Gopnik();
			String_Transtion = "Gopnik";
			EventScore = 4;
			PlayerPrefs.SetInt("EventScore",EventScore);
		}

		// Пятый ивент
		if (DistanceKilometr >= 52 && DistanceMetr >= 200 && EventScore == 4)
		{
			Event_Omon();
			String_Transtion = "Omon";
			EventScore = 5;
			PlayerPrefs.SetInt("EventScore",EventScore);
		}

		// Шестой ивент
		if (DistanceKilometr >= 80 && DistanceMetr >= 150 && EventScore == 5)
		{
			Event_Phone();
			String_Transtion = "Phone";
			EventScore = 6;
			PlayerPrefs.SetInt("EventScore",EventScore);
		}

		// Седьмой ивент
		if (DistanceKilometr >= 102 && DistanceMetr >= 50 && EventScore == 6)
		{
			Event_Military();
			String_Transtion = "Military";
			EventScore = 7;
			PlayerPrefs.SetInt("EventScore",EventScore);
		}
	}
}