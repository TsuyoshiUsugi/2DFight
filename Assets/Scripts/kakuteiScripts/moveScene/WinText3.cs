using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinText3 : MonoBehaviour
{
    public Text textUI;
    public static WinText3 instance;
    // Start is called before the first frame update
    void Start()
    {
        textUI.text = "";
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Win()
    {
        textUI.text = "YOU WIN";
        Invoke("NextScene", 3f);

    }

    public void NextScene()
    {
        SceneManager.LoadScene("Stage3to4");
    }

}

