using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOver;
    [SerializeField] private Text t_stars, t_time, t_steps, t_score;
    private int stars = 0, time = 0, steps = 0;
    void Start()
    {
        GameOver.SetActive(false);
        InvokeRepeating("ScoreUpdate", 0, 1);
    }
    private void ScoreUpdate()
    {
        t_stars.text = "Stars: " + stars.ToString();
        t_time.text = "Time: " + time.ToString();
        t_steps.text = "Steps: " + steps.ToString();
        time++;
    }
    public void onPlayerStep()
    {
        steps++;
    }
    public void onStarCollected()
    {
        stars++;
    }

    public void onGameOver() 
    {
        t_score.text = "Your score: " + Mathf.Max(stars * 100 - time - steps * 3, 0).ToString();
        GameOver.SetActive(true);
        CancelInvoke("ScoreUpdate");
    }
}
