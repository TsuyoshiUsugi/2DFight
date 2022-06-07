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

    static float time = 0;

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
        player1Ready = player1.ready;
        player2Ready = player2.ready;
        if (player1Ready == true && player2Ready == true)
        {
            BattleStart();
        }
        
    }

    

    void BattleStart()
    {
        SelectedText2();
        Invoke("Scene", 3.0f);

    }
    void Scene()
    {

        SceneManager.LoadScene("BattleMode");
    }

    void SelectedText()
    {
        
        Debug.Log(time);
        ready1And2.enabled = true;
        time += Time.deltaTime;
        if (time > 0.3)
        {
            ready1And2.enabled = false;
            time = 0;
        }
        
    }

    void SelectedText2()
    {
        ready1And2.enabled = true;
        ready1And2.color = Color.Lerp(new Color(1, 1, 1, 1), new Color(0, 0, 0, 1), 1.0f);

    }
}
