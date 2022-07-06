using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1UI : MonoBehaviour
{
    private GameObject player1Object;    //Player1�I�u�W�F�N�g
    private Player1controller player1Script;    //Player1�X�N���v�g

    //Player1��HP���
    
    private float player1Hp;    //Player1�̗̑�
    private float gageRateHp;    //�̗͂ƃQ�[�W�̃T�C�Y�̔�
    public RectTransform rtHp;

    //Player1��MP���

    private float player1Mp;
    private float gageRateMp;
    private RectTransform rtMp;

    // Start is called before the first frame update
    void Start()
    {
        //Player1�̏���ǂݎ��
        player1Object = GameObject.FindGameObjectWithTag("Player1");
        player1Script = player1Object.GetComponent<Player1controller>();
        rtHp = transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        rtMp = transform.GetChild(1).gameObject.GetComponent<RectTransform>();

        player1Hp = player1Script.Hp;
        gageRateHp = rtHp.sizeDelta.x / player1Hp;

        player1Mp = player1Script.Mp;
        gageRateMp = rtMp.sizeDelta.x / player1Mp;
    }

    // Update is called once per frame
    void Update()
    {
        if (rtHp.sizeDelta.x <= 0)
        {
            GameObject.Find("BattleModeManager").GetComponent<BattleModeManager>().Player1Die();
        }
    }

    public void ReadHp(float damage)
    {
        
         rtHp.sizeDelta = new Vector2(rtHp.sizeDelta.x - (damage * gageRateHp), rtHp.sizeDelta.y);
    }

    public void ReadMp(float mp)
    {
        
         rtMp.sizeDelta = new Vector2((mp * gageRateMp), rtMp.sizeDelta.y);
        
    }
}
