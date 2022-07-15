using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1controller : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    AudioSource audioSource;

    //当たり判定を格納する変数を用意
    [SerializeField] public Transform attackPoint;
    [SerializeField] float _attackRadius;
    [SerializeField] LayerMask _player2Layer;

    [Header("ステータス")]
    [SerializeField] float _hp;
    [SerializeField] float _mp;
    [SerializeField] float _moveSpeed = 3;
    [SerializeField] float _at = 1;
    [SerializeField] float _jumpForce = 250f;
    [SerializeField] int _jumpCount = 0;


    [Header("ノックバック")]
    [SerializeField] float _force3 = 0;

    [Header("サウンド")]
    [SerializeField] AudioClip _attack1;
    [SerializeField] AudioClip _jump;
    [SerializeField] AudioClip _Ability1;

    public bool isPlaying = true;
    Player1UI _player1UIscript;
    float _passedTime = 0;

    [Header("アビリティ")]
    [SerializeField] GameObject _spark;
    [SerializeField] GameObject _arrowPrefab;


    private const string clip_KEY = "Action";

    public float Mp
    {
        get { return _mp; }
        set { _mp = value; }
    }

    public float Hp
    {
        get { return _hp; }
        set { _hp = value; }
    }

    /*
    //FSMつかう予定
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
    */

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _player1UIscript = GameObject.Find("Player1UI").GetComponent<Player1UI>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying == true && Hp > 0)
        {
            Attack();

            Jump();

            Ability();
        }

        if (Hp <= 0)
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
        {
            Move();
        }
    }

    /// <summary>
    /// 移動を行う関数
    /// </summary>
    void Move()
    {
        if (Hp > 0)
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

    /// <summary>
    /// 攻撃を行う関数
    /// </summary>
    void Attack()
    {
        if (Input.GetButtonDown("Attack1"))
        {
            animator.SetTrigger("isAttack");
        }
    }

    /// <summary>
    /// 攻撃時当たり判定を行う関数
    /// </summary>
    void AttackDamage()
    {
        audioSource.PlayOneShot(_attack1);
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, _attackRadius, _player2Layer);

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

    /// <summary>
    /// 当たり判定の範囲を表示
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, _attackRadius);
    }

    /// <summary>
    /// 被ダメ時の関数
    /// </summary>
    /// <param name="damage"></param>
    public void Ondamage(float damage)
    {
        Hp -= damage;
        animator.SetTrigger("isHurt");
    }

    /// <summary>
    /// ジャンプの関数
    /// </summary>
    void Jump()
    {
        if (Input.GetButtonDown("Vertical1") && Hp > 0 && _jumpCount == 0)
        {
            rb.AddForce(transform.up * _jumpForce);
            _jumpCount++;
            audioSource.PlayOneShot(_jump);
            animator.CrossFadeInFixedTime("jump", 0);
        }
    }

    /// <summary>
    /// 着地時の関数
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor") || gameObject.transform.position.y <= -3)
        {
            _jumpCount = 0;
            if(Hp > 0)
            animator.CrossFadeInFixedTime("Battle_WomanHeroIdle", 0);
        }
    }

    /// <summary>
    /// アビリティの関数
    /// </summary>
    void Ability()
    {
        if (Input.GetButtonDown("Ability1") && Mp > 0)
        {
            if (Mp > 0)
            {
                animator.SetTrigger("Ability");
            }
           
        }
    }

    /// <summary>
    /// 死亡時の関数
    /// </summary>
    private void Die()
    {
        if (Hp <= 0)
        {
            animator.SetTrigger("Die");
            //audioSource.PlayOneShot(sound4);
            _passedTime += Time.deltaTime;

            if (_passedTime > 0.5f)
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
    // スキルは全てアニメーションイベントから呼ぶ

    /// <summary>
    /// Heroのアビリティ
    /// Layerを変えて当たり判定を一時的になくす
    /// </summary>
    void HeroAbility()
    {
            Mp -= 2;
            _player1UIscript.ReadMp(Mp);
            gameObject.layer = 12;

            audioSource.PlayOneShot(_Ability1);
    }
    
    /// <summary>
    /// Heroのアビリティ２レイヤを元に戻す
    /// </summary>
    void HeroAbility2()
    {
            gameObject.layer = 11;
    }

    /// <summary>
    /// 侍のアビリティ
    /// 相手の近くに瞬間移動
    /// 相手が右側にいる時は相手の左側にワープ
    /// 相手が左側にいる時は相手の右側にワープ
    /// </summary>
    void SamuraiAbilityMove()
    {
        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");

        Mp -= 2;
        _player1UIscript.ReadMp(Mp);
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

    /// <summary>
    /// Monkのアビリティ
    /// 大ダメージを与え、相手を吹っ飛ばす
    /// </summary>
    void Monk()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, _attackRadius, _player2Layer);
        Mp -= 1;
        _player1UIscript.ReadMp(Mp);
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

    /// <summary>
    /// 女戦士のアビリティ
    /// 相手の位置に雷を落とす
    /// </summary>
    void WomanHero()
    {
        if (Mp >= 5)
        {
            GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
            Mp -= 5;
            _player1UIscript.ReadMp(Mp);

            Instantiate(_spark, new Vector3(player2.transform.position.x, player2.transform.position.y + 0.1f, 0), player2.transform.rotation);
            audioSource.PlayOneShot(_Ability1);
        }
    }

    /// <summary>
    ///矢を発射する
    ///通常攻撃のアニメーションに追加する
    /// </summary>
    void Hunter()
    {
        Instantiate(_arrowPrefab, attackPoint.position, attackPoint.rotation);
        audioSource.PlayOneShot(_attack1);
    }

}
