using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToBattlestage : MonoBehaviour
{
    Player1Select player1;
    Player2Select player2;

    public bool player1Ready;
    public bool player2Ready;

    public Text ready1And2;
   

    float time = 0;
    AudioSource audioSource;
    public AudioClip sound1;
    bool go = false;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1").GetComponent<Player1Select>();
        player2 = GameObject.Find("Player2").GetComponent<Player2Select>();
        ready1And2.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 2f)
        {
            time = 0;
        }

        ///緊急用バトルモード遷移ボタン
        /*if (Input.GetButtonDown("Attack1"))
        {
            SceneManager.LoadScene("BattleMode");
        }*/
        ///

        if(go == true)
        {
            FadeManager.Instance.LoadScene("BattleMode", 1.0f);
        }


    }

    void FixedUpdate()
    {
        player1Ready = player1.ready;
        player2Ready = player2.ready;
        if (player1Ready == true && player2Ready == true)
        {
            BattleStart();

            if (audioSource.isPlaying == false)
            {
                audioSource.PlayOneShot(sound1);

            }
            
        }
        
    }



    void BattleStart()
    {
        
        SelectedText();

        
        //FadeManager.Instance.LoadScene("BattleMode", 1.0f);
        go = true;
    }
   

    void SelectedText()
    {
        
        
        time += Time.deltaTime;

        if (time < 1f)
        {
            ready1And2.enabled = true;
        }
        else
        {
            ready1And2.enabled = false;
        }

    }


 

}
