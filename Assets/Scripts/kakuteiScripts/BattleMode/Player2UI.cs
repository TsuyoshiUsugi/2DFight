using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2UI : MonoBehaviour
{
    private GameObject player2Object;    //Player2�I�u�W�F�N�g
    private Player2controller player2Script;    //Player2�X�N���v�g

    //Player2��HP���

    private float player2Hp;    //Player2�̗̑�
    private float gageRateHp;    //�̗͂ƃQ�[�W�̃T�C�Y�̔�
    public RectTransform rtHp;

    //Player1��MP���

    private float player2Mp;
    private float gageRateMp;
    private RectTransform rtMp;

    // Start is called before the first frame update
    void Start()
    {
        //Player2�̏���ǂݎ��
        player2Object = GameObject.FindGameObjectWithTag("Player2");
        player2Script = player2Object.GetComponent<Player2controller>();
        rtHp = transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        rtMp = transform.GetChild(1).gameObject.GetComponent<RectTransform>();

        player2Hp = player2Script.hp;
        gageRateHp = rtHp.sizeDelta.x / player2Hp;

        player2Mp = player2Script.mp;
        gageRateMp = rtMp.sizeDelta.x / player2Mp;
    }

    // Update is called once per frame
    void Update()
    {
            
        if (rtHp.sizeDelta.x <= 0)
        {
            GameObject.Find("BattleModeManager").GetComponent<BattleModeManager>().Player2Die();
        }
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
