using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanHeroAbility : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound1;
    public GameObject Player2;
    public LayerMask player2Layer;
   

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void SparkKai()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapBoxAll(transform.position, new Vector2(1.33f, 1.83f), 0, player2Layer);


        audioSource.PlayOneShot(sound1);
        foreach (Collider2D hitEnemy in hitEnemys)
        {
            


            hitEnemy.GetComponent<Player2controller>().Ondamage(90);

            hitEnemy.GetComponent<Rigidbody2D>().AddForce(transform.up * 1000);

       

        }
    }

    void End()
    {
        Destroy(this.gameObject);
    }
}
