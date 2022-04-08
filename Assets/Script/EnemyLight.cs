using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLight : MonoBehaviour
{
   [SerializeField] private float attackCoolDown;
    [SerializeField] private float range;
    [SerializeField] private float coliderDistance;
    [SerializeField] private int dame;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask PlayerMask;
    private float coolDownTimer = Mathf.Infinity;
    
    private Animator animator;

    private MauPlayer playerHealth;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }
    void Update()
    {
        coolDownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if(coolDownTimer >= attackCoolDown)
            {
                //attack
                coolDownTimer = 0;
                animator.SetTrigger("attack");
            }
        }
    }
    bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x 
            * coliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y,
            boxCollider.bounds.size.z),0,Vector2.left,0, PlayerMask);
        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<MauPlayer>();
        }
        return hit.collider !=null;

        
        
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * coliderDistance,
            new
            Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    void DamagePlayer()
    {
        if (PlayerInSight()) {

            playerHealth.addDame(dame);
                }
    }
}
