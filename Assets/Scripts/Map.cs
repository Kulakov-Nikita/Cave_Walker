using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private int sizeX = 16, sizeY = 8;
    [SerializeField] private int mapShiftX = 8, mapShiftY = 4;
    [SerializeField] private GameObject defaultCell, moverRight, moverLeft, portal;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[,] cells;
    [SerializeField] private int playerStartPosX = 3, playerStartPosY = 3;
    void Start()
    {
        cells = new GameObject[sizeY, sizeX];
        List<Portal> portals = new List<Portal>();
        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                switch(Random.Range(0, 4))
                {
                    case 0: cells[y, x] = Instantiate(defaultCell, new Vector3(x - mapShiftX, y - mapShiftY, 0), new Quaternion(0, 0, 0, 0)); break;
                    case 1: 
                        cells[y, x] = Instantiate(moverRight, new Vector3(x - mapShiftX, y - mapShiftY, 0), new Quaternion(0, 0, 0, 0));
                        cells[y, x].GetComponent<Mover>().onMoverCreated(true);
                        break;
                    case 2: 
                        cells[y, x] = Instantiate(moverLeft, new Vector3(x - mapShiftX, y - mapShiftY, 0), new Quaternion(0, 0, 0, 0));
                        cells[y, x].GetComponent<Mover>().onMoverCreated(false);
                        break;
                    case 3:
                        if (portals.Count <= 18)
                        {
                            cells[y, x] = Instantiate(portal, new Vector3(x - mapShiftX, y - mapShiftY, 0), new Quaternion(0, 0, 0, 0));
                            portals.Add(cells[y, x].GetComponent<Portal>());
                        }
                        else cells[y, x] = Instantiate(defaultCell, new Vector3(x - mapShiftX, y - mapShiftY, 0), new Quaternion(0, 0, 0, 0));
                        break;
                }
            }
        }
        player = Instantiate(player, new Vector3(playerStartPosX, playerStartPosY, 0), new Quaternion(0, 0, 0, 0));
        player.GetComponent<Player>().onPlayerCreated(this);

        // Перемешиваем порталы
        for (int i = 0; i <= portals.Count; i++)
        {
            Portal tmp = portals[0];
            portals.RemoveAt(0);
            portals.Insert(Random.Range(0, portals.Count), tmp);
        }

        // Оставляем только 18 порталов
        for(int i=18; i< portals.Count; i++)
        {
            portals.RemoveAt(i);
        }

        Debug.Log(portals.Count);

        // Связываем порталы попарно
        for (int i = 0; i < portals.Count && i<18; i+=2)
        {
            Color color;
            switch(i/2)
            {
                case 0: color = Color.blue; break;
                case 1: color = Color.cyan; break;
                case 2: color = Color.gray; break;
                case 3: color = Color.green; break;
                case 4: color = Color.grey; break;
                case 5: color = Color.magenta; break;
                case 6: color = Color.red; break;
                case 7: color = Color.white; break;
                case 8: color = Color.yellow; break;
                default: color = Color.white; break;
            }
            portals[i].onPortalCreated(portals[i + 1], color);
            portals[i + 1].onPortalCreated(portals[i], color);
        }

            InvokeRepeating("callMover", 0, 1);
    }

    private void callMover()
    {
        Mover mover = cells[(int)player.transform.position.y + mapShiftY, (int)player.transform.position.x + mapShiftX].GetComponent<Mover>();
        if (mover) mover.movePlayer(player);

        Portal portal = cells[(int)player.transform.position.y + mapShiftY, (int)player.transform.position.x + mapShiftX].GetComponent<Portal>();
        if (portal) portal.teleportPlayer(player);
    }
}
