using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private int sizeX = 16, sizeY = 8;
    [SerializeField] private GameObject defaultCell, moverRight, moverLeft;
    [SerializeField] private GameObject player;
    [SerializeField] private int playerPosX = 3, playerPosY = 3;
    void Start()
    {
        for (int y = 0; y <= sizeY; y++)
        {
            for (int x = 0; x <= sizeX; x++)
            {
                switch(Random.Range(0, 3))
                {
                    case 0: Instantiate(defaultCell, new Vector3(x - sizeX / 2, y - sizeY / 2, 0), new Quaternion(0, 0, 0, 0)); break;
                    case 1: Instantiate(moverRight, new Vector3(x - sizeX / 2, y - sizeY / 2, 0), new Quaternion(0, 0, 0, 0)); break;
                    case 2: Instantiate(moverLeft, new Vector3(x - sizeX / 2, y - sizeY / 2, 0), new Quaternion(0, 0, 0, 0)); break;
                }
            }
        }
        Instantiate(player, new Vector3(playerPosX, playerPosY, 0), new Quaternion(0, 0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
