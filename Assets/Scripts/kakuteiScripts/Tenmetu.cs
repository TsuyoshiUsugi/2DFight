using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tenmetu : MonoBehaviour
{
    public float speed = 1f;
    private float time;
    private Text flash;


    // Start is called before the first frame update
    void Start()
    {
        flash = this.gameObject.GetComponent<Text>();
        speed = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
       // flash.color = GetColor(flash.color);
    }

    Color GetColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }
}
