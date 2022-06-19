using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRender : MonoBehaviour
{
    [Header("p1の強さの変数")]
    public int chara1;
    public int chara2;
    public int chara3;
    public int chara4;
    public int chara5;
    public int chara6;
    public int chara7;
    [Header("p2の強さの変数")]
    public int p2chara1;
    public int p2chara2;
    public int p2chara3;
    public int p2chara4;
    public int p2chara5;
    public int p2chara6;
    public int p2chara7;
    [Header("p1とp2のゲームオブジェクト")]
    public GameObject p1Select;
    public GameObject p2Select;

    Player1Select p1SelectScript1;
    Player2Select p2SelectScript2;

    [Header("p1とp2の星のゲームオブジェクト")]
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject p2Star1;
    public GameObject p2Star2;
    public GameObject p2Star3;

    // Start is called before the first frame update
    void Start()
    {
        p1SelectScript1 = p1Select.GetComponent<Player1Select>();
        p2SelectScript2 = p1Select.GetComponent<Player2Select>();
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        p2Star1.SetActive(false);
        p2Star2.SetActive(false);
        p2Star3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int charaNumber = Player1Select.chara;
        int charaNumber2 = Player2Select.chara2;

        switch (charaNumber)
        {
            case 0:
                StarRend(chara1);
                break;
            case 1:
                StarRend(chara2);
                break;
            case 2:
                StarRend(chara3);
                break;
            case 3:
                StarRend(chara4);
                break;
            case 4:
                StarRend(chara5);
                break;
            case 5:
                StarRend(chara6);
                break;
            case 6:
                StarRend(chara7);
                break;
            

        }

        switch (charaNumber2)
        {
            case 0:
                StarRend2(p2chara1);
                break;
            case 1:
                StarRend2(p2chara2);
                break;
            case 2:
                StarRend2(p2chara3);
                break;
            case 3:
                StarRend2(p2chara4);
                break;
            case 4:
                StarRend2(p2chara5);
                break;
            case 5:
                StarRend2(p2chara6);
                break;
            case 6:
                StarRend2(p2chara7);
                break;
           

        }
    }

    void StarRend(int number)
    {
        if (number == 1)
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        }
        else if (number == 2)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }
        else if (number == 3)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
    }

    void StarRend2(int number)
    {
        if (number == 1)
        {
            p2Star1.SetActive(true);
            p2Star2.SetActive(false);
            p2Star3.SetActive(false);
        }
        else if (number == 2)
        {
            p2Star1.SetActive(true);
            p2Star2.SetActive(true);
            p2Star3.SetActive(false);
        }
        else if (number == 3)
        {
            p2Star1.SetActive(true);
            p2Star2.SetActive(true);
            p2Star3.SetActive(true);
        }
    }


}
