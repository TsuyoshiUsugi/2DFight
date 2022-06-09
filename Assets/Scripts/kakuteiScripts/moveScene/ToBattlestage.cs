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
    public Text ready1And22;

    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1").GetComponent<Player1Select>();
        player2 = GameObject.Find("Player2").GetComponent<Player2Select>();
        ready1And2.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 2f)
        {
            time = 0;
        }
        

        player1Ready = player1.ready;
        player2Ready = player2.ready;
        if (player1Ready == true && player2Ready == true)
        {
            BattleStart();
        }
        
    }

    

    void BattleStart()
    {
        SelectedText();

        //Invoke("Scene", 3.0f);
        
        FadeManager.Instance.LoadScene("BattleMode", 1f);

    }
    void Scene()
    {

        //SceneManager.LoadScene("BattleMode");
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


    void SelectedText2()
    {
        ready1And2.enabled = true;
        ready1And22.enabled = false;
    }

    void SelectedText3()
    {
        ready1And2.enabled = false;
        ready1And22.enabled = true;
    }


}
