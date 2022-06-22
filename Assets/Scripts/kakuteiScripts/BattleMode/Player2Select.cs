using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Select : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public static int chara2 = 0;


    [Header("•\Ž¦‰æ‘œˆê——")]
    public Sprite sprite;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;

    public bool ready = false;
    public AudioSource audioSource;
    public AudioClip sound1;
    public AudioClip sound2;

    public Text ready2;
    public Text ready1;

    private int state;
    float buttonTrigger;
    // Start is called before the first frame update
    void Start()
    {
        chara2 = 0;
        spriteRenderer.sprite = sprite;

        ready2.enabled = false;

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        SelectButton();

        
        ReadyButton();
    }

 
    public void ReadyButton()
    {
        if (Input.GetButtonDown("Attack2") && ready == false)
        {
            audioSource.PlayOneShot(sound2);
            ready = true;
            ready2.enabled = true;
        }
        else if (Input.GetButtonDown("Attack2") && ready == true && ready1.enabled == false)
        {
            audioSource.PlayOneShot(sound2);
            ready = false;
            ready2.enabled = false;
        }
    }

    public void SelectButton()
    {
        float downButton = Input.GetAxis("Horizontal2");



        if (ready == false)
        {


            if (state == 0)
            {
                if (downButton > 0 && buttonTrigger == 0.0f)
                {
                    state++;
                    ImageState();
                    audioSource.PlayOneShot(sound1);
                }

            }
            else if (state == 6)
            {
                if (downButton < 0 && buttonTrigger == 0.0f)
                {
                    state--;
                    ImageState();
                    audioSource.PlayOneShot(sound1);
                }
            }
            else
            {
                if (downButton > 0 && buttonTrigger == 0.0f)
                {
                    state++;
                    ImageState();
                    audioSource.PlayOneShot(sound1);
                }
                else if (downButton < 0 && buttonTrigger == 0.0f)
                {
                    state--;
                    ImageState();
                    audioSource.PlayOneShot(sound1);
                }
            }

            buttonTrigger = downButton;
        }
    }

    public void ImageState()
    {
        switch (state)
        {
            case 0:
                spriteRenderer.sprite = sprite;
                transform.position = new Vector3(5, -2.5f, 32.92f);
                chara2 = 0;
                break;
            case 1:
                spriteRenderer.sprite = sprite1;
                transform.position = new Vector3(5, -2.5f, 32.92f);
                chara2 = 1;
                break;
            case 2:
                spriteRenderer.sprite = sprite2;
                transform.position = new Vector3(5, -2.5f, 32.92f);
                chara2 = 2;
                break;
            case 3:
                spriteRenderer.sprite = sprite3;
                transform.position = new Vector3(5.22f, -0.35f, 32.92f);
                chara2 = 3;
                break;
            case 4:
                spriteRenderer.sprite = sprite4;
                transform.position = new Vector3(5.22f, -0.35f, 32.92f);
                chara2 = 4;
                break;
            case 5:
                spriteRenderer.sprite = sprite5;
                transform.position = new Vector3(4.46f, -0.02f, 32.92f);
                chara2 = 5;
                break;
            case 6:
                spriteRenderer.sprite = sprite6;
                transform.position = new Vector3(4.88f, -0.75f, 32.92f);
                chara2 = 6;
                break;
        }

    }

}