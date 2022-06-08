using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectBotton : MonoBehaviour
{
    public GameObject arcadeMode;
    public GameObject battleMode;
    public GameObject quit;

    Text arcadeText;
    Text battleText;
    Text quitText;

    float buttonTrigger;
   

    public float state = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        arcadeText = arcadeMode.GetComponent<Text>();
        battleText = battleMode.GetComponent<Text>();
        quitText = quit.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Button();

        
        Decide();
    }

    private void FixedUpdate()
    {
        //InvokeRepeating("Button", 1, 1);
        
    }

    private void Button()
    {
        float downButton = Input.GetAxis("Menu1");
        





        if (state == 0 && downButton < 0 && buttonTrigger == 0.0f)
        {
            arcadeText.color = new Color(0f, 0f, 0f, 0.46f);
            battleText.color = new Color(255f, 255f, 255f, 255f);
            state = 1;
            
        }
        else if (state == 1)
        {
            if (downButton < 0 && buttonTrigger == 0.0f)
            {
                battleText.color = new Color(0f, 0f, 0f, 0.46f);
                quitText.color = new Color(255f, 255f, 255f, 255f);
                state = 2;
               
            }
            else if (downButton > 0 && buttonTrigger == 0.0f)
            {
                battleText.color = new Color(0f, 0f, 0f, 0.46f);
                arcadeText.color = new Color(255f, 255f, 255f, 255f);
                state = 0;
                
            }

        } 
        else if (state == 2 && downButton > 0 && buttonTrigger == 0.0f)
        {
            quitText.color = new Color(0f, 0f, 0f, 0.46f);
            battleText.color = new Color(255f, 255f, 255f, 255f);
            state = 1;
        }

        buttonTrigger = downButton;
    }

    void Decide()
    {
        if (state == 0 && Input.GetAxisRaw("Attack1") == 1)
        {
            SceneManager.LoadScene("openingTo1");
        }
        else if (state == 1 && Input.GetAxisRaw("Attack1") == 1)
        {
            SceneManager.LoadScene("CharacterSelect");
        }
        else if (state == 2 && Input.GetAxisRaw("Attack1") == 1)
        {
            UnityEditor.EditorApplication.isPlaying = false;

            Application.Quit();
        }
    }
}
