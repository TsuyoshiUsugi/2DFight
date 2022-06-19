using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{

    public GameObject player1;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");

        if (player1.transform.localScale.x == 1)
        {
            rb.velocity = new Vector2(10, 0);
        }
        else if(player1.transform.localScale.x == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            rb.velocity = new Vector2(-10, 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < -8 || transform.position.x > 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float x = transform.localScale.x;

        if (collision.gameObject.tag == "Player2")
        {
            collision.gameObject.GetComponent<Player2controller>().Ondamage(10);
            Destroy(gameObject);
            if (x > 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 1000);
            }
            else if (x < 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * -1000);

            }
        }
        

    }

}