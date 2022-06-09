using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1controller : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    //当たり判定を格納する変数を用意
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask player2Layer;

    [Header("ステータス")]
    public float moveSpeed = 3;
    public float hp = 3;
    public float at = 1;
    public float mp = 10;
    public float jumpForce = 250f;
    public int jumpCount = 0;

    [Header("ノックバック")]
    public Vector3 force1 = new Vector3(100f, 1000f, 0f);
    public Vector3 force2 = new Vector3(-100f, 1000f , 0f);

    private Player1UI player1UIscript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player1UIscript = GameObject.Find("Player1UI").GetComponent<Player1UI>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();

        Jump();

        Ability();

        DieBata();
    }

    void FixedUpdate()
    {
        Move();

    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal1");
        
        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        animator.SetFloat("Speed", Mathf.Abs(x));
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);

    }

    //攻撃アニメーションをする
    void Attack()
    {
        if (Input.GetButtonDown("Attack1"))
        {
            animator.SetTrigger("isAttack");

        }
    }

    //当たり判定をonにする
    void AttackDamage()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, player2Layer);
        foreach (Collider2D hitEnemy in hitEnemys)
        {
            float x = transform.localScale.x;

            Debug.Log(hitEnemy.gameObject.name + "に攻撃");
            hitEnemy.GetComponent<Player2controller>().Ondamage(at);

            if (x > 0)
            {
                hitEnemy.GetComponent<Rigidbody2D>().AddForce(force1);
            }
            else if (x < 0)
            {
                hitEnemy.GetComponent<Rigidbody2D>().AddForce(force2);
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
        player1UIscript.ReadHp(damage);

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
        if (Input.GetButtonDown("Vertical1") && hp != 0 && jumpCount == 0)
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
        if (Input.GetButtonDown("Ability1"))
        {
            if (mp > 0)
            {
                
                animator.SetTrigger("Ability");
                mp--;
                player1UIscript.ReadMp(1);
            }
        }
    }

    private void DieBata()
    {
        if (hp <= 0)
        Destroy(gameObject);

    }

    // ここからアビリティ一覧

    void HeroAbility()
    {

        gameObject.layer = 12;

    }
    
    void HeroAbility2()
    {
        
        gameObject.layer = 11;
     
    }

}
