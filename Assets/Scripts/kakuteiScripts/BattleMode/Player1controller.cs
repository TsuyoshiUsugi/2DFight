using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1controller : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    AudioSource audioSource;

    //当たり判定を格納する変数を用意
    [SerializeField] public Transform _attackPoint;
    [SerializeField] float _attackRadius;
    [SerializeField] LayerMask _player2Layer;

    [Header("ステータス")]
    [SerializeField] public float _hp = 3;
    [SerializeField] public float _mp = 10;
    [SerializeField] float _moveSpeed = 3;
    [SerializeField] float _at = 1;
    [SerializeField] float _jumpForce = 250f;
    [SerializeField] int _jumpCount = 0;
    //[SerializeField] float _playerNumber = 1;

    [Header("ノックバック")]
    [SerializeField] float _force3 = 0;

    [Header("サウンド")]
    [SerializeField] AudioClip _attack1;
    [SerializeField] AudioClip _jump;
    [SerializeField] AudioClip _Ability1;

    public bool isPlaying = true;
    private Player1UI player1UIscript;
    float passedTime = 0;

    [Header("アビリティ")]
    public GameObject spark;
    public GameObject arrowPrefab;


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
        player1UIscript = GameObject.Find("Player1UI").GetComponent<Player1UI>();
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

        else if (isPlaying == false)
        {
            animator.SetFloat("Speed", 0);
        }

    }

    void FixedUpdate()
    {
        if (isPlaying == true)
            Move();

    }

    void Move()
    {
        if (_hp > 0)
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
            rb.velocity = new Vector2(x * _moveSpeed, rb.velocity.y);
        }

    }

    //攻撃アニメーションをする
    void Attack()
    {
        if (Input.GetButtonDown("Attack1"))
            
        {
            animator.SetTrigger("isAttack");
            //animator.SetBool("isAttack", false);
        }
    }

    //当たり判定をonにする
    void AttackDamage()
    {
        audioSource.PlayOneShot(_attack1);
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius, _player2Layer);

        foreach (Collider2D hitEnemy in hitEnemys)
        {
            float x = transform.localScale.x;

            
            hitEnemy.GetComponent<Player2controller>().Ondamage(_at);

            if (x > 0)
            {

                hitEnemy.GetComponent<Rigidbody2D>().AddForce(transform.right * -_force3);

            }
            else if (x < 0)
            {
                hitEnemy.GetComponent<Rigidbody2D>().AddForce(transform.right * _force3);

            }

        }
    }

    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRadius);
    }

    public void Ondamage(float damage)
    {
        _hp -= damage;
        player1UIscript.ReadHp(damage);

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
        if (Input.GetButtonDown("Vertical1") && _hp > 0 && _jumpCount == 0)
        {
            rb.AddForce(transform.up * _jumpForce);
            _jumpCount++;
            audioSource.PlayOneShot(_jump);
            
            animator.CrossFadeInFixedTime("jump", 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor") || gameObject.transform.position.y <= -3)
        {
            _jumpCount = 0;
            if(_hp > 0)
            animator.CrossFadeInFixedTime("Battle_WomanHeroIdle", 0);

        }


    }

    void Ability()
    {
        if (Input.GetButtonDown("Ability1") && _mp > 0)
        {
            if (_mp > 0)
            {

                animator.SetTrigger("Ability");
                
                //audioSource.PlayOneShot(Ability1);
            }
           
        }
    }

    private void Die()
    {

        if (_hp <= 0)
        {
            animator.SetTrigger("Die");
            //audioSource.PlayOneShot(sound4);
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
      
            _mp -= 2;
            player1UIscript.ReadMp(_mp);
            gameObject.layer = 12;

            audioSource.PlayOneShot(_Ability1);
    }
    
    void HeroAbility2()
    {
            gameObject.layer = 11;
            
    }

    void SamuraiAbilityMove()
    {
        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");

        _mp -= 2;
        player1UIscript.ReadMp(_mp);
        audioSource.PlayOneShot(_Ability1);

        if (player2.transform.position.x < -3.5f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            this.transform.position = new Vector3(player2.transform.position.x + 1f, transform.position.y, player2.transform.position.z);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            this.transform.position = new Vector3(player2.transform.position.x - 1f, transform.position.y, player2.transform.position.z);
        }
    }

    void Monk()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius, _player2Layer);
        _mp -= 1;
        player1UIscript.ReadMp(_mp);
        audioSource.PlayOneShot(_Ability1);

        foreach (Collider2D hitEnemy in hitEnemys)
        {
            float x = transform.localScale.x;


            hitEnemy.GetComponent<Player2controller>().Ondamage(70);

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

    void WomanHero()
    {
        if (_mp >= 5)
        {
            GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
            _mp -= 5;
            player1UIscript.ReadMp(_mp);

            Instantiate(spark, new Vector3(player2.transform.position.x, player2.transform.position.y + 0.1f, 0), player2.transform.rotation);
            audioSource.PlayOneShot(_Ability1);
        }
    }

    void Hunter()
    {
        Instantiate(arrowPrefab, _attackPoint.position, _attackPoint.rotation);
        audioSource.PlayOneShot(_attack1);
    }

}
