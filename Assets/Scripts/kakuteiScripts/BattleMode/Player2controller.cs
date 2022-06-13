using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2controller : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    //当たり判定を格納する変数を用意
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask player1Layer;

    [Header("ステータス")]
    public float moveSpeed = 3;
    public float hp = 3;
    public float at = 1;
    public float mp = 10;
    public float jumpForce = 2500f;
    private int jumpCount = 0;

    [Header("ノックバック")]
    public float force3 = 0;

    private Player2UI player2UIscript;
    float passedTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player2UIscript = GameObject.Find("Player2UI").GetComponent<Player2UI>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();

        Jump();

        Ability();

        DieBeta();
    }

    void FixedUpdate()
    {
        Move();

    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal2");

        if (x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        animator.SetFloat("Speed", Mathf.Abs(x));
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);

    }

    //攻撃アニメーションをする
    void Attack()
    {
        if (Input.GetButtonDown("Attack2"))
        {
            animator.SetTrigger("isAttack");

        }
    }

    //当たり判定をonにする
    void AttackDamage()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, player1Layer);
        foreach (Collider2D hitEnemy in hitEnemys)
        {
            float x = transform.localScale.x;

            
            hitEnemy.GetComponent<Player1controller>().Ondamage(at);
            if (x > 0)
            {
                hitEnemy.GetComponent<Rigidbody2D>().AddForce(transform.right * -force3);
            }
            else if (x < 0)
            {
                hitEnemy.GetComponent<Rigidbody2D>().AddForce(transform.right * force3);

            }
        }
    
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    public void Ondamage(float damage)
    {
        hp -= damage;
        player2UIscript.ReadHp(damage);

        if (hp <= 0)
        {
            //Die();
        }
        else
        {
            animator.SetTrigger("isHurt");
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Vertical2") && hp != 0 && jumpCount == 0)
        {
            rb.AddForce(transform.up * jumpForce);
            jumpCount++;
            

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor") || gameObject.transform.position.y <= -3)
        {
            jumpCount = 0;
            
        }


    }

    void Ability()
    {
        if (Input.GetButtonDown("Ability2"))
        {
            if (mp > 0)
            {

                animator.SetTrigger("Ability");
                mp--;
                player2UIscript.ReadMp(1);
            }
        }
    }

    void DieBeta()
    {
        

        if (hp <= 0)
        {
            passedTime += Time.deltaTime;

            if (passedTime > 0.5f)
            {
                Time.timeScale = 1;
            }
            else
            {

                Time.timeScale = 0.1f;
            }

            
        }

    }

    

    // ここからアビリティ一覧

    void HeroAbility()
    {

        gameObject.layer = 13;

    }

    void HeroAbility2()
    {

        gameObject.layer = 10;

    }
}