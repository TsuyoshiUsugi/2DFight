using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeManager : MonoBehaviour
{
    //player1の情報を読み取る変数
    private GameObject _player1Object;
    private float _player1Hp;

    //timeの情報を読み取る変数
    private int _time;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _player1Hp = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1controller>().hp;

        _time = GameObject.Find("Second").GetComponent<TimerScript>().second;

        Judge();
        
    }

    void Judge()
    {
        if (_player1Hp <= 0 || _time <= 0)
        {
            Debug.Log("end");
        }
        else if (_player1Hp >= 0 && _time >= 0)
        {

        }
    }
        
}
