using Firebase.Analytics;
using Firebase;
using UnityEngine;
 
namespace Analytics
{
    public class FirebaseAnalitics : MonoBehaviour
    {
        public static FirebaseAnalitics gameAnalytics;
        public bool _canUseAnalytics;
 
        void Awake()
        {
            if (gameAnalytics == null)
            {
                gameAnalytics = this;
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
            
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
                var dependencyStatus = task.Result;
                if (dependencyStatus == Firebase.DependencyStatus.Available) {
                    // Create and hold a reference to your FirebaseApp,
                    // where app is a Firebase.FirebaseApp property of your application class.
                    _canUseAnalytics = true;
                  //  var app = FirebaseApp.DefaultInstance;
                    // Set a flag here to indicate whether Firebase is ready to use by your app.
                } else {
                    Debug.LogError(System.String.Format(
                        "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                    // Firebase Unity SDK is not safe to use here.
                }
            });
        }
        
        public void BeginTutorial()
        {
            Firebase.Analytics.FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventTutorialBegin);
        }
        public void CompleteTutorial()
        {
            Firebase.Analytics.FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventTutorialComplete);
        }
        public void Ivent_Drugs()
        {
            FirebaseAnalytics.LogEvent("Event_Drugs", new Parameter ("Event_Drugs", "Event_Drugs"));
        }
        public void Ivent_School()
        {
            FirebaseAnalytics.LogEvent("Event_School", new Parameter ("Event_School", "Event_School"));
        }
        public void Ivent_Police()
        {
            FirebaseAnalytics.LogEvent("Event_Police", new Parameter ("Event_Police", "Event_Police"));
        }
        public void Ivent_Gopnik()
        {
            FirebaseAnalytics.LogEvent("Event_Omon", new Parameter ("Event_Omon", "Event_Omon"));
        }
        public void Ivent_Omon()
        {
            FirebaseAnalytics.LogEvent("Event_Omon", new Parameter ("Event_Omon", "Event_Omon"));
        }
        public void Ivent_Phone()
        {
            FirebaseAnalytics.LogEvent("Event_Phone", new Parameter ("Event_Phone", "Event_Phone"));
        }
        public void Ivent_Military()
        {
            FirebaseAnalytics.LogEvent("Event_Military", new Parameter ("Event_Military", "Event_Military"));
        }
    }
}