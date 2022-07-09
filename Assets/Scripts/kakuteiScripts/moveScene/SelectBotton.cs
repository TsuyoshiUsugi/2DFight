using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SelectBotton : MonoBehaviour
{
    public GameObject arcadeMode;
    public GameObject battleMode;
    public GameObject quit;
    public AudioClip sound1;
    public AudioClip sound2;


    Text arcadeText;
    Text battleText;
    Text quitText;

    float buttonTrigger;
    float buttonTriggerPC;

    AudioSource audioSource;

    public float state = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        arcadeText = arcadeMode.GetComponent<Text>();
        battleText = battleMode.GetComponent<Text>();
        quitText = quit.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Button();

        ButtonForPC();

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
            audioSource.PlayOneShot(sound1);


        }
        if (state == 1)
        {


            if (downButton > 0 && buttonTrigger == 0.0f)
            {
                battleText.color = new Color(0f, 0f, 0f, 0.46f);
                arcadeText.color = new Color(255f, 255f, 255f, 255f);
                state = 0;
                audioSource.PlayOneShot(sound1);

            }



            buttonTrigger = downButton;

        }
    }
        void Decide()
        {
            if (state == 0 && Input.GetButtonDown("Attack1"))
            {
                audioSource.PlayOneShot(sound2);
                FadeManager.Instance.LoadScene("Tutorial", 1.0f);
            }
            else if (state == 1 && Input.GetButtonDown("Attack1"))
            {
                audioSource.PlayOneShot(sound2);
                FadeManager.Instance.LoadScene("CharacterSelect", 1.0f);
            }
            else if (state == 2 && Input.GetButtonDown("Attack1"))
            {
                audioSource.PlayOneShot(sound2);

                //UnityEditor.EditorApplication.isPlaying = false;

                Application.Quit();
            }
        }

        void ButtonForPC()
        {
        
        float downButtonPC = Input.GetAxisRaw("PCMenu1");

        if (state == 0 && Input.GetAxisRaw("PCMenu1") == -1 && buttonTriggerPC == 0)
        {
            arcadeText.DOColor(new Color(0f, 0f, 0f, 0.46f), 0f);
            battleText.DOColor(Color.white, 0f);
            state = 1;
            audioSource.PlayOneShot(sound1);
        }
        else if (state == 1)
        {


            if (Input.GetAxisRaw("PCMenu1") == 1 && buttonTriggerPC == 0)
            {

                battleText.DOColor(new Color(0f, 0f, 0f, 0.46f), 0f);
                arcadeText.DOColor(Color.white, 0f);
                state = 0;
                audioSource.PlayOneShot(sound1);

            }

        }
       
        buttonTriggerPC = downButtonPC;
    }

    

}
