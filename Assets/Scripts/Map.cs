using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private int sizeX = 10, sizeY = 10;
    [SerializeField] private GameObject defaultCell, moverRight, moverLeft;
    void Start()
    {
        for (int y = -sizeY / 2; y <= sizeY / 2; y++)
        {
            for (int x = -sizeX / 2; x <= sizeX / 2; x++)
            {
                switch(Random.Range(0, 3))
                {
                    case 0: Instantiate(defaultCell, new Vector3(x, y, 0), new Quaternion(0, 0, 0, 0)); break;
                    case 1: Instantiate(moverRight, new Vector3(x, y, 0), new Quaternion(0, 0, 0, 0)); break;
                    case 2: Instantiate(moverLeft, new Vector3(x, y, 0), new Quaternion(0, 0, 0, 0)); break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
