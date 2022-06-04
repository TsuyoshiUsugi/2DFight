using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float totalTime;
    public int second;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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