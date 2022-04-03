using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dich : MonoBehaviour
{
    public Animator animator;

    public int maxmau = 100;
    int thanhMau;
    // Start is called before the first frame update
    void Start()
    {
        thanhMau = maxmau;
    }
    public void TakeDame(int dame)
    {
        thanhMau -= dame;
        animator.SetTrigger("Hurt");// kích ho?t anim b? th??ng
        if(thanhMau <= 0)
        {
            Die();
        }    
    }
    void Die()
    {
        Debug.Log("Dich da chet");

        animator.SetBool("Dead", true);//kích ho?t anim khi ch?t

        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;  
        this.enabled = false;
    }

    // Update is called once per frame
    
}
