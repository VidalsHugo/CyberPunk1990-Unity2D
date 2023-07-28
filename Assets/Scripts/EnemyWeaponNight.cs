using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponNight : MonoBehaviour
{
    public int attackDamage = 20;
    public int enragedAttackDamage = 40;

    public Vector3 attackOffset;
    public float attackRange = 7.5f;
    public LayerMask attackMask;

    public float attackInterval = 2f; // Intervalo de tempo entre os ataques normais
    private bool isEnraged = false;

    private EnemyNightBorne enemy;

    public void Start()
    {
        enemy = GetComponent<EnemyNightBorne>();
        // Inicia ataques normais repetidamente com o intervalo especificado
        InvokeRepeating("NormalAttack", 0f, attackInterval);
    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null && enemy.isAlive == true)
        {
            colInfo.GetComponent<PlayerHP>().TakeDamage(isEnraged ? enragedAttackDamage : attackDamage);
        }
    }

    void NormalAttack()
    {
        Attack();
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
