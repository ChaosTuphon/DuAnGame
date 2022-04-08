using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    //private int maxCombo = 3;
    public bool attack;
    public int attackDame;
    //public int combo;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Compos()
    {
        if(Input.GetKeyDown(KeyCode.J) && !attack)
        {

            Attack();
            //combo = maxCombo;
            // anim.SetTrigger("Attack");

        }
        //if (attack) {
        //    Attack();
           
        //}
            
    }
    void Update()
    {
        Compos();
       
        
    }
    void Attack()
    {
        anim.SetTrigger("Attack");
        // t?m ?�nh c?a t?n c�ng
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        //G�y dame l�n qu�i
        foreach(Collider2D enemy in hitEnemy)
        {
            //enemy.GetComponent<Dich>().TakeDame(attackDame);
        }

    }
    private void OnDrawGizmos()
    {
        if(attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

//    public void start_combo()
//    {
//        if (Input.GetKeyDown(KeyCode.J))
//        {
//            if (combo < 3)
//            {
//                combo++;
//            }
//        }
//    }
//    public void Finish()
//    {
//        attack = false;
//        combo = 0;
//    }
    
}
