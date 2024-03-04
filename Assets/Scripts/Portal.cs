using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Portal anotherPortal;
    public void onPortalCreated(Portal anotherPortal)
    {
        this.anotherPortal = anotherPortal;
    }

    public void teleportPlayer(GameObject player)
    {
        player.transform.position = anotherPortal.transform.position;
    }
}
