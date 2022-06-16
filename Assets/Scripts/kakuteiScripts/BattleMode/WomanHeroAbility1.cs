using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanHeroAbility1 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound1;
    public Player2controller Player2;
    public LayerMask player1Layer;
   

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void SparkKai2()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapBoxAll(transform.position, new Vector2(1.33f, 1.83f), 0, player1Layer);


        audioSource.PlayOneShot(sound1);
        foreach (Collider2D hitEnemy in hitEnemys)
        {
            Debug.Log(hitEnemy);


            hitEnemy.GetComponent<Player1controller>().Ondamage(90);

            hitEnemy.GetComponent<Rigidbody2D>().AddForce(transform.up * 1000);

       

        }
    }

    void End()
    {
        Destroy(this.gameObject);
    }
}
