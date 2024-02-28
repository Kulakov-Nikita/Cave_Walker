using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    Map map;
    public void onPlayerCreated(Map map)
    {
        this.map = map;
    }
    void Update()
    {
        Vector3 moveDir = new Vector3(0, 0, 0);

        // ”правление на WASD
        if (Input.GetKeyDown(KeyCode.W)) moveDir = new Vector3(0, 1, 0);
        if (Input.GetKeyDown(KeyCode.S)) moveDir = new Vector3(0, -1, 0);

        // ”правление на стрелочках
        if (Input.GetKeyDown(KeyCode.UpArrow)) moveDir = new Vector3(0, 1, 0);
        if (Input.GetKeyDown(KeyCode.DownArrow)) moveDir = new Vector3(0, -1, 0);

        if (moveDir != new Vector3(0, 0, 0))
        {
            transform.position += moveDir;
        }
    }

    public void onPlayerMoved(bool isDirectionRight)
    {
        if(isDirectionRight) transform.position += new Vector3(1, 0, 0);
        else transform.position += new Vector3(-1, 0, 0);
    }
}
