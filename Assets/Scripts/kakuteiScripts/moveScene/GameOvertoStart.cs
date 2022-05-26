using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOvertoStart : MonoBehaviour
{
    public void OncliclkStartButton()
    {
        SceneManager.LoadScene("Opening");
    }
}