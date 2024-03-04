using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Portal anotherPortal;
    public void onPortalCreated(Portal anotherPortal, Color color)
    {
        this.anotherPortal = anotherPortal;
        GetComponent<SpriteRenderer>().color = color;
    }

    public void teleportPlayer(GameObject player)
    {
        player.transform.position = anotherPortal.transform.position;
    }
}
