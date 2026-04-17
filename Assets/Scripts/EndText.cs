using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndText : MonoBehaviour
{
    public static EndText instance;
    [SerializeField] TMP_Text scoreText1;
    float counter1 = 0f;
    public int enemiesKilled;
    public int applesCollected;
    public int cherrysCollected;
    public int bonusesCollected;
    public bool isFinished = false;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    void Update()
    {
        if (!isFinished)
        {
            counter1 += Time.deltaTime;
        }
        int minutes = Mathf.FloorToInt(counter1 / 60);
        int seconds = Mathf.FloorToInt(counter1 % 60);
        scoreText1.text = "ВАША СТАТИСТИКА: \n" +
            "Время: " + minutes + ":" + seconds.ToString("00") + "\n" +
            "Врагов убито: " + enemiesKilled + "\n" +
            "Яблок подобрано: " + applesCollected + "\n" +
            "Вишенок подобрано: " + cherrysCollected + "\n" +
            "Бонусов собрано: " + bonusesCollected + "\n";
    }
   
}
