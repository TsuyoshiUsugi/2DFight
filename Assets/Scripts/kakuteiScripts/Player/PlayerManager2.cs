using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager2 : MonoBehaviour
{
    public float moveSpeed = 3;
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask enemyLayer;
    Rigidbody2D rb;
    Animator animator;
    float at = 1;
    private float jumpForce = 250f;
    private int jumpCount = 0;

    public float hp = 3;
    //float x = 0;

    GameObject playerHpObject;
    PlayerHpGage playerhp;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerHpObject = GameObject.Find("Bar");
        playerhp = playerHpObject.GetComponent<PlayerHpGage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("isAttack");
        }
        if (hp != 0)
        {
            Movement();
        }

        if (Input.GetKeyDown(KeyCode.Space) && hp != 0 && jumpCount == 0)
        {
            this.rb.AddForce(transform.up * jumpForce);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            jumpCount = 0;
        }
    }

    public void Attack()
    {

        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);
        foreach (Collider2D hitEnemy in hitEnemys)
        {

            Debug.Log(hitEnemy.gameObject.name + "Ç…çUåÇ");
            hitEnemy.GetComponent<EnemyManager>().OnDamage(at);


        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    public void OnDamage(float damage)
    {
        hp -= damage * 10;

        float t = hp;

        playerhp.UpdateValue(t);

        if (hp <= 0)
        {
            Die();
        }
        else
        {
            animator.SetTrigger("isHurt");

        }
    }

    void Die()
    {
        animator.SetFloat("Speed", 0);
        hp = 0;
        animator.SetTrigger("Die");
        Invoke("afterDie", 3);

    }

    void Movement()
    {


        float x = Input.GetAxisRaw("Horizontal");   //ï˚å¸ÉLÅ[ÇÃâ°ì¸óÕ
        if (x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        animator.SetFloat("Speed", Mathf.Abs(x));
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);

    }

    void afterDie()
    {
        SceneManager.LoadScene("GameOver");
    }
}

