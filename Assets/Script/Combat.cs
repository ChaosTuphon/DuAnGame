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

    public void start_combo()// khai b�o bi?n b?t ??u ?�nh ??t bi?n trong animation
    {
        attack = false;
        if (combo < 3)
        {
            combo++;
        }
    }
    public void Finish()// khai b�o bi?n k?t th�c ?�nh ??t bi?n trong animation
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

        // t?m ?�nh c?a t?n c�ng
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        //G�y dame l�n qu�i
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
