using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectButton2 : MonoBehaviour
{

    
    public Text restartText;
    public Text charaSelect;
    public Text quitText;

    public float state = 0;

    public bool isPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        restartText.enabled = false;
        charaSelect.enabled = false;
        quitText.enabled = false;
}

    // Update is called once per frame
    void Update()
    {
        Button();

        Decide();
    }

    private void Button()
    {
        if (isPlaying == false)
        {
            restartText.enabled = true;
            charaSelect.enabled = true;
            quitText.enabled = true;

            if (state == 0 && Input.GetButtonDown("Down1"))
            {
                restartText.color = new Color(0f, 0f, 0f, 0.46f);
                charaSelect.color = new Color(255f, 255f, 255f, 255f);
                state = 1;
            }
            else if (state == 1)
            {
                if (Input.GetButtonDown("Down1"))
                {
                    charaSelect.color = new Color(0f, 0f, 0f, 0.46f);
                    quitText.color = new Color(255f, 255f, 255f, 255f);
                    state = 2;
                }
                else if (Input.GetButtonDown("Up1"))
                {
                    charaSelect.color = new Color(0f, 0f, 0f, 0.46f);
                    restartText.color = new Color(255f, 255f, 255f, 255f);
                    state = 0;
                }

            }
            else if (state == 2 && Input.GetButtonDown("Up1"))
            {
                quitText.color = new Color(0f, 0f, 0f, 0.46f);
                charaSelect.color = new Color(255f, 255f, 255f, 255f);
                state = 1;
            }
        }

    }

    void Decide()
    {
        if (isPlaying == false)
        {
            if (state == 0 && Input.GetAxisRaw("Attack1") == 1)
            {
                SceneManager.LoadScene("BattleMode");
            }
            else if (state == 1 && Input.GetAxisRaw("Attack1") == 1)
            {
                SceneManager.LoadScene("CharacterSelect");
            }
            else if (state == 2 && Input.GetAxisRaw("Attack1") == 1)
            {
                SceneManager.LoadScene("Opening");
            }
        }
    }
}
