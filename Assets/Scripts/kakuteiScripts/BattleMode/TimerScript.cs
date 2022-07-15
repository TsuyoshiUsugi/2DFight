using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 現在の時間を表示するコンポーネント
/// </summary>
public class TimerScript : MonoBehaviour
{
    [Header("参照一覧")]
    public TextMeshProUGUI timerText;
    public float totalTime;
    public static int second { get; private set; }

    public bool isPlaying;

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