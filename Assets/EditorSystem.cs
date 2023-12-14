using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections.Generic; 

[CustomEditor(typeof(AdministartorScript))]
public class EditorSystem : Editor 
{
    // Деньги
    private int Money;

    // Жизненные показатели
    private int Current_Life;
    private int Current_Food;
    private int Current_Water;

    // Ивент по счету
    private int EventScore;
    private string myString;

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Удалить все"))
        {
            PlayerPrefs.DeleteAll();

            Current_Life = 100;
            PlayerPrefs.SetFloat("Current_Life",Current_Life);

            Current_Food = 100;
            PlayerPrefs.SetFloat("Current_Food",Current_Food);

            Current_Water = 100;
            PlayerPrefs.SetFloat("Current_Water",Current_Water);
        }

        if (GUILayout.Button("Добавить денег"))
        {
            Money += 10000;
            PlayerPrefs.SetFloat("Money",Money);
        }

        if (GUILayout.Button("Обновить жизненные показатели"))
        {
            Current_Life = 100;
            PlayerPrefs.SetFloat("Current_Life",Current_Life);

            Current_Food = 100;
            PlayerPrefs.SetFloat("Current_Food",Current_Food);

            Current_Water = 100;
            PlayerPrefs.SetFloat("Current_Water",Current_Water);
        }

        if (GUILayout.Button("Убить персонажа"))
        {
            Current_Life = 0;
            PlayerPrefs.SetFloat("Current_Life",Current_Life);
        }

        GUILayout.Label("Выбрать ивент", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField(myString);
        if (GUILayout.Button("Нажать")){
            int.TryParse(myString, out EventScore);
            PlayerPrefs.SetInt("EventScore",EventScore);
        }
    }
}