using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2controller : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    AudioSource audioSource;

    //当たり判定を格納する変数を用意
    [SerializeField] public Transform attackPoint;
    [SerializeField] float _attackRadius;
    [SerializeField] LayerMask player1Layer;

    [Header("ステータス")]
    [SerializeField] float moveSpeed = 3;
    [SerializeField] public float _hp = 3;
    [SerializeField] float at = 1;
    [SerializeField] public float mp = 10;
    [SerializeField] float jumpForce = 2500f;
    [SerializeField] int jumpCount = 0;
    public float playerNumber = 2;

    [Header("ノックバック")]
    public float force3 = 0;

    [Header("サウンド")]
    public AudioClip attack1;
    public AudioClip jump;
    public AudioClip Ability1;

   
    
   

    [Header("アビリティ")]
    public GameObject spark;
    public GameObject arrowPrefab;

    public bool isPlaying = true;
    
    private Player2UI player2UIscript;
    float passedTime = 0;

    private const string clip_KEY = "Action";
    private enum actionNum
    {
        Battle_WomanHeroIdle = 0,
        run = 1,
        jump = 2,
        fall = 3,
        sliding = 4,
        wallAttach = 5,
        wallJump = 6,
    }

    // Start is called before the first frame update
    void Start()
    {
   

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player2UIscript = GameObject.Find("Player2UI").GetComponent<Player2UI>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying == true && _hp > 0)
        {

            Attack();

            Jump();

            Ability();

        }

        if (_hp <= 0)
        {
            Die();

        }

        if (isPlaying == false)
        {
            animator.SetFloat("Speed", 0);
        }

    }

    void FixedUpdate()
    {
        if(isPlaying == true)
        Move();
      

    }

    void Move()
    {
        if (_hp > 0)
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
        audioSource.PlayOneShot(attack1);
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, _attackRadius, player1Layer);
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
        Gizmos.DrawWireSphere(attackPoint.position, _attackRadius);
    }

    public void Ondamage(float damage)
    {
        _hp -= damage;
        player2UIscript.ReadHp(damage);

        if (_hp <= 0)
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
        if (Input.GetButtonDown("Vertical2") && _hp != 0 && jumpCount == 0)
        {
            rb.AddForce(transform.up * jumpForce);
            jumpCount++;
            audioSource.PlayOneShot(jump);
            animator.CrossFadeInFixedTime("jump", 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor") || gameObject.transform.position.y <= -3)
        {
            jumpCount = 0;
            animator.CrossFadeInFixedTime("Battle_WomanHeroIdle", 0);
        }


    }

    void Ability()
    {
        if (Input.GetButtonDown("Ability2") && mp > 0)
        {
            if (mp > 0)
            {

                animator.SetTrigger("Ability");
               
                
            }
        }
    }

    void Die()
    {
        

        if (_hp <= 0)
        {
            animator.SetBool("Die", true);
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

    void HeroAbility21()
    {
        if (playerNumber == 2)
        {
            
            mp -= 2;
            player2UIscript.ReadMp(2);
            gameObject.layer = 13;
            audioSource.PlayOneShot(Ability1);
        }
    }

    void HeroAbility22()
    {
        if (playerNumber == 2)
        {

           
            gameObject.layer = 10;
        }

    }

    void SamuraiAbilityMove()
    {
        GameObject player2 = GameObject.FindGameObjectWithTag("Player1");
        audioSource.PlayOneShot(Ability1);
        mp -= 2;
        player2UIscript.ReadMp(2);

        if (player2.transform.position.x < -3.5f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            this.transform.position = new Vector3(player2.transform.position.x + 1f, transform.position.y, player2.transform.position.z);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
            this.transform.position = new Vector3(player2.transform.position.x - 1f, transform.position.y, player2.transform.position.z);
        }
    }

    void Monk()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, _attackRadius, player1Layer);
        mp -= 1;
        player2UIscript.ReadMp(1);
        audioSource.PlayOneShot(Ability1);

        foreach (Collider2D hitEnemy in hitEnemys)
        {
            float x = transform.localScale.x;


            hitEnemy.GetComponent<Player1controller>().Ondamage(70);

            if (x > 0)
            {

                hitEnemy.GetComponent<Rigidbody2D>().AddForce(transform.right * 4000);

            }
            else if (x < 0)
            {
                hitEnemy.GetComponent<Rigidbody2D>().AddForce(transform.right * -4000);

            }

        }
        
    }

    void WomanHero2()
    {
        if (mp >= 5)
        {
            GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
            mp -= 5;
            player2UIscript.ReadMp(5);

            Instantiate(spark, new Vector3(player1.transform.position.x, player1.transform.position.y + 0.1f, 0), player1.transform.rotation);
            audioSource.PlayOneShot(Ability1);
        }
    }

    void Hunter()
    {
        Instantiate(arrowPrefab, attackPoint.position, attackPoint.rotation);
        audioSource.PlayOneShot(attack1);
    }

}