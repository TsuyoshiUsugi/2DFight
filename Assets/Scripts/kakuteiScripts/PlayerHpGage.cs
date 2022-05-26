using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpGage : MonoBehaviour
{
    public float t;
    private float maxValue;
    private RectTransform rt;

    private GameObject playerObject;
    PlayerManager playerScript;

    

    void Awake()
    {
        playerObject = GameObject.Find("Player");
        playerScript = playerObject.GetComponent<PlayerManager>();
        

        rt = transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        maxValue = rt.sizeDelta.x;
        
        
            
    }
    
    public void UpdateValue (float t)
    {
        //float x = Mathf.Lerp(maxValue, 0f, t);
        rt.sizeDelta = new Vector2(t, rt.sizeDelta.y);
    }

    // Update is called once per frame
    void Update()
    {

        //t -= 0.02f *  Time.deltaTime;
        //UpdateValue(t);
       


    }
}
