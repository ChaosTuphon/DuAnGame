using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDame : MonoBehaviour
{
    public float damege;
    float dameRate = 0.5f;
    public float pushBackForce;
    float nextdame;
    // Start is called before the first frame update
    void Start()
    {
        nextdame = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && nextdame <Time.time) 
            // neu enemy cham vao doi tuong ten tag Player luot gay dame tiep theo nho hon hien tai chung ta se goi ham nhan sat thuong
            
        {
            MauPlayer PlayerHealth = other.gameObject.GetComponent<MauPlayer>();
            PlayerHealth.addDame(nextdame);
            nextdame = dameRate + Time.time;
            pushBack(other.transform);
        }
    }
    void pushBack(Transform NhanVat)
    {
        Vector2 HuongLucDay = new Vector2(NhanVat.position.x - transform.position.x, (NhanVat.position.y - transform.position.y)).normalized;
        HuongLucDay *= pushBackForce;

        Rigidbody2D body = NhanVat.gameObject.GetComponent<Rigidbody2D>();
        body.velocity = Vector2.zero;
        body.AddForce(HuongLucDay, ForceMode2D.Impulse);//them ngay cai xung luc lam vat bay len

        // tra ngay ve vecter cos gia tri la 1
    }//luc tac dong len nv 
}
