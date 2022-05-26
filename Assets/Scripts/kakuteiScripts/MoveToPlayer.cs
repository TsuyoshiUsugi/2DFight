using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    

    private GameObject playerObject;
    private Vector3 PlayerPosition;
    private Vector3 EnemyPosition;
    Animator animator;
    Rigidbody2D rb;
    public float moveSpeed;

    private Vector3 _prevPosition;
    private GameObject EnemyManager;
    EnemyManager enemyScript;

    // Start is called before the first frame update
    void Start()
    {


        EnemyManager = GameObject.Find("Enemy") ;
        enemyScript = EnemyManager.GetComponent<EnemyManager>();
        animator = GetComponent<Animator>();
        playerObject = GameObject.FindWithTag("Player");
        PlayerPosition = playerObject.transform.position;
        EnemyPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        float hp = enemyScript.hp;
        //float hp = this.GameObject.GetComponent<EnemyManager>().hp;


        float x = 0;

        playerObject = GameObject.FindWithTag("Player");
        PlayerPosition = playerObject.transform.position;
        EnemyPosition = transform.position;

        if (PlayerPosition.x - 0.5f > EnemyPosition.x && hp != 0)
        {
            x = 1;
            
            this.rb.AddForce(transform.right * moveSpeed);
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetFloat("speed", Mathf.Abs(x));

          

        }
        else if (PlayerPosition.x < EnemyPosition.x - 0.5f && hp !=0)
        {
            x = 1;
 
            this.rb.AddForce(transform.right * (-moveSpeed));
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetFloat("speed", Mathf.Abs(x));
        }
        else
        {
            x = 0;
            animator.SetFloat("speed", Mathf.Abs(x));
        }


    }
}
