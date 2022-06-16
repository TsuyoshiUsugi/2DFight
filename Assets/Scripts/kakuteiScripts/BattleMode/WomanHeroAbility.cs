using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanHeroAbility : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound1;
    public GameObject Player2;

    Player2controller player2Controller;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
            audioSource.PlayOneShot(sound1);
        if (other.gameObject.CompareTag("Player2") == true)
        {
            other.gameObject.GetComponent<Player2controller>().Ondamage(90);;
        }


    }

    void End()
    {
        Destroy(this.gameObject);
    }
}
