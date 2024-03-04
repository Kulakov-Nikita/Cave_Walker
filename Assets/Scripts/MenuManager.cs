using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOver;
    [SerializeField] private Text t_score, t_time, t_steps;
    private int score = 0, time = 0, steps = 0;
    void Start()
    {
        GameOver.SetActive(false);
        InvokeRepeating("ScoreUpdate", 0, 1);
    }
    private void ScoreUpdate()
    {
        t_score.text = "Score: " + score.ToString();
        t_time.text = "Time: " + time.ToString();
        t_steps.text = "Steps: " + steps.ToString();
        time++;
    }
    public void onPlayerStep()
    {
        steps++;
    }

    public void onGameOver() 
    {
        GameOver.SetActive(true);
        CancelInvoke("ScoreUpdate");
    }
}
