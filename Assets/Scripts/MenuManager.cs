using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOver;
    void Start()
    {
        GameOver.SetActive(false);
    }

    public void onGameOver() 
    {
        GameOver.SetActive(true);
    }
}
