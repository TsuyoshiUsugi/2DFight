using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Spawn : MonoBehaviour
{
    [Header("生成キャラ")]
    public GameObject prefab0;
    public GameObject prefab1;
    public GameObject prefab2;

    public int _charaNumber = 0;

    // Start is called before the first frame update
    void Start()
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
        }

    }
}
