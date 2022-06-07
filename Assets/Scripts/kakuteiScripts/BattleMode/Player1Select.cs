using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Select : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public static int chara = 0;
  

    [Header("•\Ž¦‰æ‘œˆê——")]
    public Sprite sprite;
    public Sprite sprite1;
    public Sprite sprite2;
    

    private int state;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        SelectButton();
    }

    private void OnMouseDown()
    {
        if (spriteRenderer.sprite == sprite2)
        {
            spriteRenderer.sprite = sprite;
            chara = 0;
        }
        else if (spriteRenderer.sprite == sprite)
        {
            spriteRenderer.sprite = sprite1;
            chara = 1;
        }
        else if (spriteRenderer.sprite == sprite1)
        {
            spriteRenderer.sprite = sprite2;
            chara = 2;
        }
    }

    public void SelectButton()
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
            if(Input.GetButtonDown("Right1") == true)
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
