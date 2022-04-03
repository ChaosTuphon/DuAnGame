using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    public bool attack;
    public int combo;

    public int attackDame = 40;

    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    public void start_combo()// khai báo bi?n b?t ??u ?ánh ??t bi?n trong animation
    {
        attack = false;
        if (combo < 3)
        {
            combo++;
        }
    }
    public void Finish()// khai báo bi?n k?t thúc ?ánh ??t bi?n trong animation
    {
        attack = false;
        combo = 0;
    }
    void Update()
    {
        Compos_();
    }

    public void Compos_()
    {
        if (Input.GetKeyDown(KeyCode.J) && !attack)
        {
            attack = true;
            animator.SetTrigger("" + combo);
            
        }
        if (attack)
        {
            Attack();

        }
    }
    void Attack()
    {

        // t?m ?ánh c?a t?n công
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        //Gây dame lên quái
        foreach (Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<Dich>().TakeDame(20);
        }

    }
    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
