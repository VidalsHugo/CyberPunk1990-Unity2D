using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyNightBorne : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    public bool isAlive = true;
    private Rigidbody2D rb;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        if(isAlive){
            currentHealth -= damage;
            animator.SetTrigger("Hurt");
        }
        

        if (currentHealth <= 0)
        {
            isAlive = false;
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        animator.SetBool("IsDead", true);

        GetComponent<BoxCollider2D>().enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;

        StartCoroutine(DisableAfterDeathAnimation());
    }

    IEnumerator DisableAfterDeathAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length+3);

        this.enabled = false;
        gameObject.SetActive(false);
        SceneManager.LoadScene(4);
    }
}
