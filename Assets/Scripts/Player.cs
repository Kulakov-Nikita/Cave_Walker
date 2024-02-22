using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    void Update()
    {
        // ”правление на WASD
        if (Input.GetKeyDown(KeyCode.W)) transform.position += new Vector3(0, 1, 0);
        if (Input.GetKeyDown(KeyCode.S)) transform.position += new Vector3(0, -1, 0);

        // ”правление на стрелочках
        if (Input.GetKeyDown(KeyCode.UpArrow)) transform.position += new Vector3(0, 1, 0);
        if (Input.GetKeyDown(KeyCode.DownArrow)) transform.position += new Vector3(0, -1, 0);
    }

    public void onPlayerMoved(bool isDirectionRight)
    {
        if(isDirectionRight) transform.position += new Vector3(1, 0, 0);
        else transform.position += new Vector3(-1, 0, 0);
    }
}
