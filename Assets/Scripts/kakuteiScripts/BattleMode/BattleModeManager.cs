using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleModeManager : MonoBehaviour
{
    /// <summary>player1のHPを読み取る</summary>
    float _player1Hp;

    /// <summary>player2のHPを読み取る</summary>
    float _player2Hp;      

    //勝利テキスト表示
    public TextMeshProUGUI playerWinText;

    public bool isPlaying = false;

    float passedTime;

    public AudioSource audioSource;
    public AudioClip sound1;
    // Start is called before the first frame update
    private void Awake()
    {
        isPlaying = true;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void Player1Die()
    {

        passedTime += Time.deltaTime * 1;
        GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2controller>().isPlaying = false;

        if (passedTime > 3)
        {
            if (isPlaying == true)
            {
                playerWinText.text = "PLAYER2 WIN!";
                audioSource.PlayOneShot(sound1);
                isPlaying = false;
            }

            if (passedTime > 6)
            {
                GameObject.Find("Buttons").GetComponent<SelectButton2>().isPlaying = false;

            }
        }

        }

    public void Player2Die()
    {
        passedTime += Time.deltaTime * 1;
        GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1controller>().isPlaying = false;

        IEnumerator P1Win()
        {
            yield return new WaitForSeconds(3); 
        }

        if (passedTime > 3)
        {
            if (isPlaying == true)
            {
                playerWinText.text = "PLAYER1 WIN!";
                audioSource.PlayOneShot(sound1);
                isPlaying = false;
            }

            if (passedTime > 6)
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
