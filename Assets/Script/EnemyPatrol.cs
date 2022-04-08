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

    private void Awake()
    {
        intScale = enemy.localScale;
    }
    private void MoveInDirection(int _direction)
    {
        enemy.localScale = new Vector3(Mathf.Abs( intScale.x) * _direction, intScale.y, intScale.z);

        enemy.position = new Vector3(enemy.position.x+ Time.deltaTime* _direction * speed, enemy.position.y, enemy.position.z);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveInDirection(-1);
    }
}
