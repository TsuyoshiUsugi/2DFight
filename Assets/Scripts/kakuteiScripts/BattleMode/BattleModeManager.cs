using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleModeManager : MonoBehaviour
{
    //player1�̏���ǂݎ��ϐ�
    private GameObject _player1Object;
    private float _player1Hp;

    //player2�̏���ǂݎ��ϐ�
    private float _player2Hp;      

    //time�̏���ǂݎ��ϐ�
    private int _time;

    //�����e�L�X�g�\��
    public TextMeshProUGUI playerWinText;

    public bool isPlaying = false;


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
        
    }

    public void Player1Die()
    {
        if (isPlaying == true)
        {
            playerWinText.text = "PLAYER2 WIN!";
            isPlaying = false;

        }
    }

    public void Player2Die()
    {
        if (isPlaying == true)
        {
            playerWinText.text = "PLAYER1 WIN!";
            isPlaying = false;
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
        }
        else if (_player1Hp < _player2Hp && isPlaying == true)
        {
            playerWinText.text = "PLAYER2 WIN!";
            isPlaying = false;
        }
        else
        {
            if (isPlaying == true)
            {
                playerWinText.text = "DRAW GAME";
                isPlaying = false;

            }
        }
    }
        
}
