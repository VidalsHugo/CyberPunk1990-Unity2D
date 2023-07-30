using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public Animator animator;
	public int health = 175;
    public bool isDead = false;


	public void TakeDamage(int damage)
	{
		health -= damage;
        if(!isDead){
            Debug.Log("HIT");
            animator.SetTrigger("Hit");
        }

		if (health <= 0 && !isDead)
		{  
            isDead = true;
			Die();
		}
	}

	void Die()
	{
        Debug.Log("I died!");
        
        animator.SetBool("IsDead", true);
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine(DisableAfterDeathAnimation());

	}
    IEnumerator DisableAfterDeathAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length+3);
        this.enabled = false;
        gameObject.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
