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
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (spriteRenderer.sprite == sprite2)
        {
            spriteRenderer.sprite = sprite;
            Debug.Log("change");
            chara = 0;
        }
        else if (spriteRenderer.sprite == sprite)
        {
            spriteRenderer.sprite = sprite1;
            Debug.Log("change1");
            chara = 1;
        }
        else if (spriteRenderer.sprite == sprite1)
        {
            spriteRenderer.sprite = sprite2;
            Debug.Log("change2");
            chara = 2;
        }
    }
}
