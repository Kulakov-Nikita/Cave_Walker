using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public bool isRightMover;
    public bool isPlayerInside;
    public void onMoverCreated(bool isRightMover, bool isPlayerInside)
    {
        this.isRightMover = isRightMover;
        this.isPlayerInside = isPlayerInside;
    }
    public void onPlayerEnter(Vector3 playerPos)
    {
        if (isRightMover) playerPos += new Vector3(1, 0, 0);
        else playerPos += new Vector3(-1, 0, 0);
    }
}
