using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Spawn : MonoBehaviour
{
    [Header("生成キャラ")]
    public GameObject prefab0;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;

    public int charaNumber2 = 0;

    // Start is called before the first frame update
    void Awake()
    {
        charaNumber2 = Player2Select.chara2;
        Player2();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Player2()
    {
        switch (charaNumber2)
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
            case 5:
                Instantiate(prefab5);
                break;
            case 6:
                Instantiate(prefab6);
                break;
        }

    }
}
