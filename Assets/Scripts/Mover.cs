using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public bool isRightMover;
    public void onMoverCreated(bool isRightMover)
    {
        this.isRightMover = isRightMover;
    }
    public void movePlayer(GameObject player)
    {
        Debug.Log("movePlayer");
        if (isRightMover) player.transform.position += new Vector3(1, 0, 0);
        else player.transform.position += new Vector3(-1, 0, 0);
    }
}
