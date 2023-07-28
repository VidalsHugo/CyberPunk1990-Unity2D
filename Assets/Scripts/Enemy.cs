using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    public bool isAlive = true;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        if(isAlive){
            currentHealth -= damage;
            // Play hurt animation
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

        // Play death animation
        animator.SetBool("IsDead", true);

        GetComponent<BoxCollider2D>().enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;

        // Disable the script after a short delay (enough to let the death animation finish)
        StartCoroutine(DisableAfterDeathAnimation());
    }

    IEnumerator DisableAfterDeathAnimation()
    {
        // Wait for the death animation to finish playing
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length+3);

        // Disable the script and the enemy object
        this.enabled = false;
        gameObject.SetActive(false);
    }
}
