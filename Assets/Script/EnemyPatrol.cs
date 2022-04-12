using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Point")]
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;


    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Move paramenter")]
    [SerializeField] private float speed;
    private Vector3 intScale;
    private bool movingLeft;

    [Header("Idle")]
    [SerializeField] private float idleDuration;//tg nghi cua enemy
    private float idleTimer;

    [Header("Animation")]
    [SerializeField] private Animator anim;
    private void Awake()
    {
        intScale = enemy.localScale;
    }
    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("Run", true);
        

        enemy.localScale = new Vector3(Mathf.Abs( intScale.x) * _direction, intScale.y, intScale.z);

        enemy.position = new Vector3(enemy.position.x+ Time.deltaTime* _direction * speed, enemy.position.y, enemy.position.z);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   private void Update()
    {
        if (movingLeft)
        {
            if(enemy.position.x >= left.position.x)
            MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if(enemy.position.x <= right.position.x)
            MoveInDirection(1);
            else
            {
                DirectionChange();
            }
        }

    }
    private void DirectionChange()
    {
        anim.SetBool("Run", false);
        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }
}
