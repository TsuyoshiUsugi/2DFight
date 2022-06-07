using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Select : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public static int chara = 0;
  

    [Header("•\Ž¦‰æ‘œˆê——")]
    public Sprite sprite;
    public Sprite sprite1;
    public Sprite sprite2;

    public bool ready = false;

    public Text ready1; 

    private int state;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = sprite;
        ready1.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        SelectButton();

        ReadyButton();
    }

  

    public void ReadyButton()
    {
        if (Input.GetButtonDown("Attack1") && ready == false)
        {
            ready = true;
            ready1.enabled = true;
        }
        else if (Input.GetButtonDown("Attack1") && ready == true)
        {
            ready = false;
            ready1.enabled = false;
        }
    }

    public void SelectButton()
    {
        if (ready == false)
        {


            if (state == 0)
            {
                if (Input.GetButtonDown("Right1") == true)
                {
                    state++;
                    ImageState();
                }

            }
            else if (state == 2)
            {
                if (Input.GetButtonDown("Left1") == true)
                {
                    state--;
                    ImageState();
                }
            }
            else
            {
                if (Input.GetButtonDown("Right1") == true)
                {
                    state++;
                    ImageState();
                }
                else if (Input.GetButtonDown("Left1") == true)
                {
                    state--;
                    ImageState();
                }
            }
        }
    }

    public void ImageState()
    {
        switch (state)
        {
            case 0:
                spriteRenderer.sprite = sprite;
                chara = 0;
                break;
            case 1:
                spriteRenderer.sprite = sprite1;
                chara = 1;
                break;
            case 2:
                spriteRenderer.sprite = sprite2;
                chara = 2;
                break;


        }

    }
}
