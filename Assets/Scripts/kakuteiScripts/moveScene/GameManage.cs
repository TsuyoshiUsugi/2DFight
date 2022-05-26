using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public int enemyCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount == 0)
        {
            win();
        }
       
    }

    void win()
    {
        {
            WinText.instance.Win();

        }
    }
}
