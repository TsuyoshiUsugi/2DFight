using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public List<GameObject> canvasList = new List<GameObject>();
    //public GameObject canvas7;

    public AudioSource audioSource;
    public AudioClip sound1;

    public float state = 0;
    float buttonTrigger;
    // Start is called before the first frame update
    void Start()
    {
        /*
        canvas1.SetActive(true);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(false);
        canvas5.SetActive(false);
        canvas6.SetActive(false);
        canvas7.SetActive(false);
        */

        foreach (var canvas in canvasList)
        {
            canvas.SetActive(false);
        }

        canvasList[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Button();
    }

    private void Button()
    {
        float downButton = Input.GetAxis("Horizontal1");

        if (state == 0)
        {
            if (downButton > 0 && buttonTrigger == 0.0f)
            {
                state++;
                ImageState();
                audioSource.PlayOneShot(sound1);
            }

        }
        else if (state == 6)
        {
            if (downButton < 0 && buttonTrigger == 0.0f)
            {
                state--;
                ImageState();
                audioSource.PlayOneShot(sound1);
            }
        }
        else
        {
            if (downButton > 0 && buttonTrigger == 0.0f)
            {
                state++;
                ImageState();
                audioSource.PlayOneShot(sound1);
            }
            else if (downButton < 0 && buttonTrigger == 0.0f)
            {
                state--;
                ImageState();
                audioSource.PlayOneShot(sound1);
            }
        }

        buttonTrigger = downButton;
    }

    public void ImageState()
    {
        foreach (var canvas in canvasList)
        {
            canvas.SetActive(false);
        }

        switch (state)
        {
            case 0:
                canvasList[0].SetActive(true);
                break;
            case 1:
                canvasList[1].SetActive(true);
                break;
            case 2:
                canvasList[2].SetActive(true);
                break;
            case 3:
                canvasList[3].SetActive(true);
                break;
            case 4:
                canvasList[4].SetActive(true);
                break;
            case 5:
                canvasList[5].SetActive(true);
                break;
            case 6:
                canvasList[6].SetActive(true);
                break;
            case 7:
                canvasList[7].SetActive(true);
                break;
        }

    }
}
