using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleModeManager : MonoBehaviour
{
    //player1の情報を読み取る変数
    private GameObject player1Object;
    private float player1Hp;

    //player2の情報を読み取る変数
    private float player2Hp;      

    //timeの情報を読み取る変数
    private int time;

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
            player1Hp = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1controller>().hp;
            player2Hp = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2controller>().hp;
            GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1controller>().isPlaying = false;
            GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2controller>().isPlaying = false;
        }

        if (player1Hp > player2Hp && isPlaying == true)
        {
            playerWinText.text = "PLAYER1 WIN!";
            isPlaying = false;
            GameObject.Find("Buttons").GetComponent<SelectButton2>().isPlaying = false;
        }
        else if (player1Hp < player2Hp && isPlaying == true)
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
