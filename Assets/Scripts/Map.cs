using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private int sizeX = 16, sizeY = 8;
    [SerializeField] private GameObject defaultCell, moverRight, moverLeft;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[,] cells;
    [SerializeField] private int playerStartPosX = 3, playerStartPosY = 3;
    void Start()
    {
        cells = new GameObject[sizeY, sizeX];
        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                switch(Random.Range(0, 3))
                {
                    case 0: cells[y, x] = Instantiate(defaultCell, new Vector3(x - sizeX / 2, y - sizeY / 2, 0), new Quaternion(0, 0, 0, 0)); break;
                    case 1: cells[y, x] = Instantiate(moverRight, new Vector3(x - sizeX / 2, y - sizeY / 2, 0), new Quaternion(0, 0, 0, 0)); break;
                    case 2: cells[y, x] = Instantiate(moverLeft, new Vector3(x - sizeX / 2, y - sizeY / 2, 0), new Quaternion(0, 0, 0, 0)); break;
                }
            }
        }
        player = Instantiate(player, new Vector3(playerStartPosX, playerStartPosY, 0), new Quaternion(0, 0, 0, 0));
        player.GetComponent<Player>().onPlayerCreated(this);
    }

    
}
