using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GokuCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    public bool attack;
    public int combo;

    public int attackDame;

    public Animator animator;
    private object x;

    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    public void start_combo()// khai b�o bi?n b?t ??u ?�nh ??t bi?n trong animation
    {
        attack = false;
        if (combo < 2)
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

            //enemy.GetComponent<Dich>().TakeDame(attackDame);
            //var Dich = enemy.GetComponent<Dich>();
            //if (Dich == null)
            //    continue;
            //Dich.TakeDame(attackDame);
        }

    }
    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
