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

    public bool isPlaying = false;

    float passedTime;
    // Start is called before the first frame update
    private void Awake()
    {
        isPlaying = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(passedTime);
    }

    public void Player1Die()
    {
        passedTime += Time.deltaTime * 1;

        if (passedTime > 3)
        {
            if (isPlaying == true)
            {
                playerWinText.text = "PLAYER2 WIN!";
                isPlaying = false;
            }

            if (passedTime > 10)
            {
                GameObject.Find("Buttons").GetComponent<SelectButton2>().isPlaying = false;

            }
        }

        }

    public void Player2Die()
    {
        passedTime = 0;

        if (passedTime > 3)
        {
            if (isPlaying == true)
            {
                playerWinText.text = "PLAYER1 WIN!";
                isPlaying = false;
            }

            if (passedTime > 10)
            {

                GameObject.Find("Buttons").GetComponent<SelectButton2>().isPlaying = false;
            }

        }

    }

    public void Judge()
    {
        if (isPlaying == true)
        {
            _player1Hp = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1controller>().hp;
            _player2Hp = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2controller>().hp;

        }

        if (_player1Hp > _player2Hp && isPlaying == true)
        {
            playerWinText.text = "PLAYER1 WIN!";
            isPlaying = false;
            GameObject.Find("Buttons").GetComponent<SelectButton2>().isPlaying = false;
        }
        else if (_player1Hp < _player2Hp && isPlaying == true)
        {
            playerWinText.text = "PLAYER2 WIN!";
            isPlaying = false;
            GameObject.Find("Buttons").GetComponent<SelectButton2>().isPlaying = false;
        }
        else
        {
            if (isPlaying == true)
            {
                playerWinText.text = "DRAW GAME";
                isPlaying = false;
                GameObject.Find("Buttons").GetComponent<SelectButton2>().isPlaying = false;
            }
        }
    }
        
}
