using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject canvas4;
    public GameObject canvas5;

    public AudioSource audioSource;
    public AudioClip sound1;

    public float state = 0;
    float buttonTrigger;
    // Start is called before the first frame update
    void Start()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(false);
        canvas5.SetActive(false);
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
        else if (state == 4)
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
        switch (state)
        {
            case 0:
                canvas1.SetActive(true);
                canvas2.SetActive(false);
                canvas3.SetActive(false);
                canvas4.SetActive(false);
                canvas5.SetActive(false);
                break;
            case 1:
                canvas1.SetActive(false);
                canvas2.SetActive(true);
                canvas3.SetActive(false);
                canvas4.SetActive(false);
                canvas5.SetActive(false);
                break;
            case 2:
                canvas1.SetActive(false);
                canvas2.SetActive(false);
                canvas3.SetActive(true);
                canvas4.SetActive(false);
                canvas5.SetActive(false);
                break;
            case 3:
                canvas1.SetActive(false);
                canvas2.SetActive(false);
                canvas3.SetActive(false);
                canvas4.SetActive(true);
                canvas5.SetActive(false);
                break;
            case 4:
                canvas1.SetActive(false);
                canvas2.SetActive(false);
                canvas3.SetActive(false);
                canvas4.SetActive(false);
                canvas5.SetActive(true);
                break;
           

        }

    }
}
