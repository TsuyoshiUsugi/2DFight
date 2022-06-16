using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Spawn : MonoBehaviour
{
    [Header("ê∂ê¨ÉLÉÉÉâ")]
    public GameObject prefab0;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;

    public int _charaNumber = 0;

    // Start is called before the first frame update
    void Awake()
    {
        _charaNumber = Player1Select.chara;
        Player1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Player1()
    {
        switch (_charaNumber)
        {
            case 0:
                Instantiate(prefab0);
                break;
            case 1:
                Instantiate(prefab1);
                break;
            case 2:
                Instantiate(prefab2);
                break;
            case 3:
                Instantiate(prefab3);
                break;
            case 4:
                Instantiate(prefab4);
                break;
        }

    }
}
