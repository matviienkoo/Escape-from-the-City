using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityLevelPlay : MonoBehaviour 
{   
    [Header("Балтика")]
    public Button BaltikaButton;
    public bool BaltikaBool;

    [Header("Казино")]
    public Button CasinoButton;
    public bool CasinoBool;

    [Header("Возрождение")]
    public Button ReanimationButton;
    public bool ReanimationBool;

    [Header("Быстрая реклама")]
    public int Interstitial_Int;

    [Header("Скрипты")]
    public AdsScript Ads_Script;
    public DeadScript Dead_Script;

    private void Start ()
    {
        IronSource.Agent.init ("1ba491885");
        IronSource.Agent.validateIntegration();
        LoadInterstitial();
    }

    private void OnEnable ()
    {
        IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;

        //Add AdInfo Rewarded Video Events
        IronSourceRewardedVideoEvents.onAdOpenedEvent += RewardedVideoOnAdOpenedEvent;
        IronSourceRewardedVideoEvents.onAdClosedEvent += RewardedVideoOnAdClosedEvent;
        IronSourceRewardedVideoEvents.onAdAvailableEvent += RewardedVideoOnAdAvailable;
        IronSourceRewardedVideoEvents.onAdUnavailableEvent += RewardedVideoOnAdUnavailable;
        IronSourceRewardedVideoEvents.onAdShowFailedEvent += RewardedVideoOnAdShowFailedEvent;
        IronSourceRewardedVideoEvents.onAdRewardedEvent += RewardedVideoOnAdRewardedEvent;
        IronSourceRewardedVideoEvents.onAdClickedEvent += RewardedVideoOnAdClickedEvent;

        //Add AdInfo Interstitial Events
        IronSourceInterstitialEvents.onAdReadyEvent += InterstitialOnAdReadyEvent;
        IronSourceInterstitialEvents.onAdLoadFailedEvent += InterstitialOnAdLoadFailed;
        IronSourceInterstitialEvents.onAdOpenedEvent += InterstitialOnAdOpenedEvent;
        IronSourceInterstitialEvents.onAdClickedEvent += InterstitialOnAdClickedEvent;
        IronSourceInterstitialEvents.onAdShowSucceededEvent += InterstitialOnAdShowSucceededEvent;
        IronSourceInterstitialEvents.onAdShowFailedEvent += InterstitialOnAdShowFailedEvent;
        IronSourceInterstitialEvents.onAdClosedEvent += InterstitialOnAdClosedEvent;
    }

    void OnApplicationPause(bool isPaused){                 
        IronSource.Agent.onApplicationPause(isPaused);
    }

    public void Baltika_Advertising ()
    {
        BaltikaBool = true;
        ShowReward();
    }

    public void Casino_Advertising ()
    {
        CasinoBool = true;
        ShowReward();
    }

    public void Reanimation_Advertising ()
    {
        ReanimationBool = true;
        ShowReward();
    }

    public void Interstitial_Advertising ()
    {
        Interstitial_Int += 1;
        if (Interstitial_Int >= 9){
            ShowInterstitial();
            Interstitial_Int = 0;
        }
    }

    /************* Reward *************/
    public void ShowReward ()
    {
        if (IronSource.Agent.isRewardedVideoAvailable())
        {
            IronSource.Agent.showRewardedVideo();
        }
        else
        Debug.Log("Reward Video Not Work");
    }
    void RewardedVideoOnAdRewardedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo)
    {   
        if (BaltikaBool == true){
            Ads_Script.OpenBaltika();
        	BaltikaButton.enabled = false;
        }
        BaltikaBool = false;

        if (CasinoBool == true){
            Ads_Script.OpenCasino();
            CasinoButton.enabled = false;
        }
        CasinoBool = false;

        if (ReanimationBool == true){
            Dead_Script.Reanimation_Button();
        }
        ReanimationBool = false;
    }

    void RewardedVideoOnAdAvailable(IronSourceAdInfo adInfo){
    }
    void RewardedVideoOnAdUnavailable() {
    }
    void RewardedVideoOnAdOpenedEvent(IronSourceAdInfo adInfo){
    }
    void RewardedVideoOnAdClosedEvent(IronSourceAdInfo adInfo){
    }
    void RewardedVideoOnAdShowFailedEvent(IronSourceError error, IronSourceAdInfo adInfo){
    }
    void RewardedVideoOnAdClickedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo){
    }

    /************* Interstitial *************/
    public void LoadInterstitial ()
    {
        IronSource.Agent.loadInterstitial();
    }
    public void ShowInterstitial ()
    {
        if (IronSource.Agent.isInterstitialReady())
        {
            IronSource.Agent.showInterstitial();
        }
        else
        Debug.Log("Ads not ready");
    }

    void InterstitialOnAdReadyEvent(IronSourceAdInfo adInfo){
    }
    void InterstitialOnAdLoadFailed(IronSourceError ironSourceError){
    }
    void InterstitialOnAdOpenedEvent(IronSourceAdInfo adInfo){
    }
    void InterstitialOnAdClickedEvent(IronSourceAdInfo adInfo){
    }
    void InterstitialOnAdShowFailedEvent(IronSourceError ironSourceError, IronSourceAdInfo adInfo){
    }
    void InterstitialOnAdClosedEvent(IronSourceAdInfo adInfo){
    }
    void InterstitialOnAdShowSucceededEvent(IronSourceAdInfo adInfo){
    }
    void SdkInitializationCompletedEvent(){
    }
}