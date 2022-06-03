using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBattleMode : MonoBehaviour
{
    public void OncliclkStartButton()
    {
        SceneManager.LoadScene("CharacterSelect");
    }
}

