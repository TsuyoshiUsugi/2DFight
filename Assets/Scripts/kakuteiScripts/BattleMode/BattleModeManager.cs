using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleModeManager : MonoBehaviour
{
    float _player1Hp;
    float _player2Hp;      
    [SerializeField] TextMeshProUGUI playerWinText;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip sound1;

    /// <summary>演出を表示するまでの時間</summary>
    [SerializeField] float _passedTime;

    /// <summary>戦闘が続いているかを判定する</summary>
    public bool isPlaying = false;


    private void Awake()
    {
        isPlaying = true;
    }

    public void Player1Die()
    {
        
        GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2controller>().isPlaying = false;

        StartCoroutine(P2Win());
    }

    public void Player2Die()
    {
        
        GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1controller>().isPlaying = false;

        StartCoroutine(P1Win());
    }

    /// <summary>プレイヤー１が勝った時の演出</summary>
    IEnumerator P1Win()
    {
        yield return new WaitForSeconds(_passedTime);
        if (isPlaying == true)
        {
            playerWinText.text = "PLAYER1 WIN!";
            audioSource.PlayOneShot(sound1);
            isPlaying = false;
        }
        yield return new WaitForSeconds(_passedTime);
        GameObject.Find("Buttons").GetComponent<SelectButton2>().isPlaying = false;
    }

    /// <summary>プレイヤー２が勝った時の演出</summary>
    IEnumerator P2Win()
    {
        yield return new WaitForSeconds(_passedTime);
        if (isPlaying == true)
        {
            playerWinText.text = "PLAYER2 WIN!";
            audioSource.PlayOneShot(sound1);
            isPlaying = false;
        }
        yield return new WaitForSeconds(_passedTime);
        GameObject.Find("Buttons").GetComponent<SelectButton2>().isPlaying = false;
    }

    /// <summary>時間切れになった時の判定</summary>
    public void Judge()
    {
        if (isPlaying == true)
        {
            _player1Hp = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1controller>()._hp;
            _player2Hp = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2controller>()._hp;
            GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1controller>().isPlaying = false;
            GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2controller>().isPlaying = false;
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
