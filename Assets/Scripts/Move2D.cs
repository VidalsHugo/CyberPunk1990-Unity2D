using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    public Rigidbody2D rb;
    public int moveSpeed;
    private float direction;

    public Animator animator;

    private Vector3 facingRight;
    private Vector3 facingLeft;

    public bool taNoChao;
    public Transform detectaChao;
    public LayerMask oQueEhChao;

    public int pulosExtras = 1;

    [Header("Attack variabels")]
    public Transform attackCheck;
    public float radiusAttack = 1.2f;
    public LayerMask layerEnemy;
    float timeNextAttack;

    public int attackDamage = 40;

    public PlayerHP player;

    // Start is called before the first frame update
    void Start()
    {

        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerHP>();
    }

    // Update is called once per frame
    void Update()
    {   

        if(Input.GetAxis("Horizontal") != 0){
            //esta correndo
            animator.SetBool("taCorrendo", true);
        }else{
            //esta parado
            animator.SetBool("taCorrendo", false);
        }

        taNoChao = Physics2D.OverlapCircle(detectaChao.position, 0.2f, oQueEhChao);

        if(Input.GetButtonDown("Jump") && taNoChao == true && player.isDead == false){
            rb.velocity = Vector2.up * 12;
            //ativar animacao do pulo
            animator.SetBool("taPulando", true);
        }
        if(Input.GetButtonDown("Jump") && taNoChao == false && pulosExtras > 0){
            rb.velocity = Vector2.up * 12;
            pulosExtras--;
            //ativar animacao do pulo duplo
            animator.SetBool("puloDuplo", true);
        }
        if(taNoChao){
            pulosExtras = 1;
            animator.SetBool("taPulando", false);
            animator.SetBool("puloDuplo", false);
        }

        direction = Input.GetAxis("Horizontal");

        if(direction > 0){
            //olhando para a direita
            transform.localScale = facingRight;
        }
        if(direction < 0){
            //olhando para a esquerda
            transform.localScale = facingLeft;
        }
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

        // if (Input.GetButtonDown("Fire1")){
        //     animator.SetTrigger("Attack");
        // }

        if(timeNextAttack <= 0){
            if(Input.GetButtonDown("Fire1") && rb.velocity == new Vector2 (0,0) && player.isDead == false){
                animator.SetTrigger("Attack");
                timeNextAttack = 0.8f;
                PlayerAttack();
            }
        }else{
            timeNextAttack -= Time.deltaTime;
        }

    }
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackCheck.position, radiusAttack);
    }
void PlayerAttack()
{
    Collider2D[] enemiesAttack = Physics2D.OverlapCircleAll(attackCheck.position, radiusAttack, layerEnemy);
    for (int i = 0; i < enemiesAttack.Length; i++)
    {
        Enemy enemy = enemiesAttack[i].GetComponent<Enemy>();
        EnemyNightBorne enemyNightBorne = enemiesAttack[i].GetComponent<EnemyNightBorne>();

        if (enemy != null)
        {
            // O inimigo é do tipo Enemy, chama o método TakeDamage de Enemy.
            enemy.TakeDamage(attackDamage);
            Debug.Log(enemiesAttack[i].name);
        }
        else if (enemyNightBorne != null)
        {
            // O inimigo é do tipo EnemyNightBorne, chama o método TakeDamage de EnemyNightBorne.
            enemyNightBorne.TakeDamage(attackDamage);
            Debug.Log(enemiesAttack[i].name);
        }
    }
}


}
