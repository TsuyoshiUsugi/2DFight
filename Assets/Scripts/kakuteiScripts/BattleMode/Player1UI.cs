using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1UI : MonoBehaviour
{
    private GameObject player1Object;    //Player1オブジェクト
    private Player1controller player1Script;    //Player1スクリプト

    //Player1のHP情報
    
    private float player1Hp;    //Player1の体力
    private float gageRateHp;    //体力とゲージのサイズの比
    private RectTransform rtHp;

    //Player1のMP情報

    private float player1Mp;
    private float gageRateMp;
    private RectTransform rtMp;

    // Start is called before the first frame update
    void Start()
    {
        //Player1の情報を読み取る
        player1Object = GameObject.FindGameObjectWithTag("Player1");
        player1Script = player1Object.GetComponent<Player1controller>();
        rtHp = transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        rtMp = transform.GetChild(1).gameObject.GetComponent<RectTransform>();

        player1Hp = player1Script.hp;
        gageRateHp = rtHp.sizeDelta.x / player1Hp;

        player1Mp = player1Script.mp;
        gageRateMp = rtMp.sizeDelta.x / player1Mp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadHp(float damage)
    {
        
        rtHp.sizeDelta = new Vector2(rtHp.sizeDelta.x - (damage * gageRateHp), rtHp.sizeDelta.y);
    }

    public void ReadMp(float mp)
    {
        
        rtMp.sizeDelta = new Vector2(rtMp.sizeDelta.x - (mp * gageRateMp), rtMp.sizeDelta.y);
    }
}
