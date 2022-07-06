using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float totalTime;
    public static int second { get; private set; }

    public bool isPlaying;
    
    // Start is called before the first frame update
    void Start()
    {
        isPlaying = GameObject.Find("BattleModeManager").GetComponent<BattleModeManager>().isPlaying;
    }

    // Update is called once per frame
    void Update()
    {
        isPlaying = GameObject.Find("BattleModeManager").GetComponent<BattleModeManager>().isPlaying;
        
        if (isPlaying == true)
        {
            totalTime -= Time.deltaTime;
            second = (int)totalTime;
            if (second >= 0)
            {
                timerText.text = second.ToString();
            }
            else
            {
                GameObject.Find("BattleModeManager").GetComponent<BattleModeManager>().Judge();
            }
        }
    }
}