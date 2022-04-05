using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dich : MonoBehaviour
{
    public Animator animator;

    public int maxmau = 100;
    int thanhMau;

    public Slider EnemyHealthSlider;//thanh mau

    // kb bien drop item
    public bool drop;
    public GameObject TheDrop;
    // Start is called before the first frame update
    void Start()
    {
        thanhMau = maxmau;

        EnemyHealthSlider.maxValue = maxmau;
        EnemyHealthSlider.value = maxmau;
    }
    public void TakeDame(int dame)
    {
        thanhMau -= dame;
        EnemyHealthSlider.value = thanhMau;
        animator.SetTrigger("Hurt");// kích ho?t anim b? th??ng
        if(thanhMau <= 0)
        {
            Die();
        }    
    }
    void Die()
    {
        Debug.Log("Dich da chet");
        
        gameObject.SetActive(false);
        animator.SetBool("Dead", true);//kích ho?t anim khi ch?t

        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;  
        this.enabled = false;

        if(drop)
            Instantiate(TheDrop, transform.position , transform.rotation);
    }

    // Update is called once per frame
    
}
