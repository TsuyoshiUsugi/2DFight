using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleModeManager : MonoBehaviour
{
    //player1の情報を読み取る変数
    private GameObject _player1Object;
    private float _player1Hp;

    //player2の情報を読み取る変数
    private float _player2Hp;      

    //timeの情報を読み取る変数
    private int _time;

    //勝利テキスト表示
    public TextMeshProUGUI playerWinText;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Player1Die()
    {
        
        playerWinText.text = "PLAYER2 WIN!";
    }

    public void Player2Die()
    {
        playerWinText.text = "PLAYER1 WIN!";

    }

    public void Judge()
    {
        _player1Hp = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1controller>().hp;
        _player2Hp = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2controller>().hp;

        if (_player1Hp > _player2Hp)
        {
            playerWinText.text = "PLAYER1 WIN!";
        }
        else if (_player1Hp < _player2Hp)
        {
            playerWinText.text = "PLAYER2 WIN!";
        }
        else
        {
            playerWinText.text = "DRAW GAME";

        }
    }
        
}
