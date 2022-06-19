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
    float buttonTrigger;
    public bool isPlaying = true;
    AudioSource audioSource;
    public AudioClip sound1;
    public AudioClip sound2;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        float downButton = Input.GetAxis("Menu1");
        

        if (isPlaying == false)
        {
            restartText.enabled = true;
            charaSelect.enabled = true;
            quitText.enabled = true;
            Time.timeScale = 1f;
        }

        if (state == 0 && downButton < 0 && buttonTrigger == 0.0f && isPlaying == false)
        {
            restartText.color = new Color(0f, 0f, 0f, 0.46f);
            charaSelect.color = new Color(255f, 255f, 255f, 255f);
            state = 1;
            audioSource.PlayOneShot(sound1);
        }
        else if (state == 1)
        {
            if (downButton < 0 && buttonTrigger == 0.0f && isPlaying == false)
            {
                charaSelect.color = new Color(0f, 0f, 0f, 0.46f);
                quitText.color = new Color(255f, 255f, 255f, 255f);
                state = 2;
                audioSource.PlayOneShot(sound1);
            }
            else if (downButton > 0 && buttonTrigger == 0.0f && isPlaying == false)
            {
                charaSelect.color = new Color(0f, 0f, 0f, 0.46f);
                restartText.color = new Color(255f, 255f, 255f, 255f);
                state = 0;
                audioSource.PlayOneShot(sound1);
            }

        }
        else if (state == 2 && downButton > 0 && buttonTrigger == 0.0f && isPlaying == false)
        {
            quitText.color = new Color(0f, 0f, 0f, 0.46f);
            charaSelect.color = new Color(255f, 255f, 255f, 255f);
            state = 1;
            audioSource.PlayOneShot(sound1);
        }

            buttonTrigger = downButton;
        

    }


    void Decide()
    {
        if (isPlaying == false)
        {
            if (state == 0 && Input.GetButtonDown("Attack1"))
            {
                
                FadeManager.Instance.LoadScene("BattleMode", 1.0f);
                audioSource.PlayOneShot(sound2);
            }
            else if (state == 1 && Input.GetButtonDown("Attack1"))
            {
                
                FadeManager.Instance.LoadScene("CharacterSelect", 1.0f);
                audioSource.PlayOneShot(sound2);
            }
            else if (state == 2 && Input.GetButtonDown("Attack1"))
            {
                
                FadeManager.Instance.LoadScene("Opening", 1.0f);
                audioSource.PlayOneShot(sound2);
            }
        }
    }
}
