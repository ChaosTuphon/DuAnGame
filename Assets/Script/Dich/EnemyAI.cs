using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAI : MonoBehaviour
{
    #region public Variables
    public Transform raycast;
    public LayerMask raycastMask;
    public float raycastLength;
    public float attackDistance;
    public float moving;
    public float timer;
    public Transform RightMove;
    public Transform LeftMove;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private Transform target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;

    #endregion
    // Start is called before the first frame update
    
     void Awake()
    {
        SelectTarget();
        intTimer = timer;
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (!attackMode)
        {
            Move();
        }
        if(!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            SelectTarget();
        }

        if (inRange)
        {
            hit = Physics2D.Raycast(raycast.position, transform.right, raycastLength, raycastMask);
            RayCastDebugger();
        }

        if (hit.collider != null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }
        if (inRange == false)
        {
            //anim.SetBool("Run", false);
            StopAttack();
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
            inRange = true;
            Flip();
        }
    }

     void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);
        if (distance > attackDistance)
        {
            
            StopAttack();

        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            anim.SetBool("Attack1", false);
        }

    }

     void Move()
    {
        anim.SetBool("Run", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x,
                transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition,
                moving * Time.deltaTime);
        }
    }
     void Attack()
        {
            timer = intTimer;
            attackMode = true;

            anim.SetBool("Run", false);
            anim.SetBool("Attack1", true);
        }

     void StopAttack()
        {
         cooling = false;
        attackMode = false;
        anim.SetBool("Attack1", false);
        }

     void RayCastDebugger()
        {
            if (distance > attackDistance)
            {
                Debug.DrawRay(raycast.position, transform.right * raycastLength, Color.red);

            }
            else if (attackDistance > distance)
            {
                Debug.DrawRay(raycast.position, transform.right * raycastLength, Color.green);
            }
        }

    public void TriggerCooling()
    {
        cooling = true;
    }

    private bool InsideofLimits()
    {
        return transform.position.x > LeftMove.position.x && transform.position.x < RightMove.position.x;
    }
    
    void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, LeftMove.position);
        float distanceToRight = Vector2.Distance(transform.position, RightMove.position);

        if(distanceToLeft > distanceToRight)
        {
            target = LeftMove;
        }
        else
        {
            target = RightMove;
        }
        Flip();
    }
    private void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if(transform.position.x > target.position.x)
        {
            rotation.y = 0f;
        }
        else
        {
            rotation.y = 180f;
        }
        transform.eulerAngles = rotation;
    }
}   
