using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dichmove : MonoBehaviour
{
    public float speedDich;

    Rigidbody2D bodyDich;
    Animator animDich;

    public GameObject enemyGraphic;
    bool facingRight = false;
    float facingTime = 5f;
    float NextFlip = 0;
    bool canFlip = true;

    private void Awake()
    {
        bodyDich = GetComponent<Rigidbody2D>();
        animDich = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > NextFlip)
        {
            NextFlip = Time.time + facingTime; // neu tg hien tai lon h 5s thi se lat
            Flip();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(facingRight && other.transform.position.x < transform.position.x)
            {
                Flip();
            }else if(!facingRight && other.transform.position.x > transform.position.x)
            {
                Flip();
            }

            canFlip = false;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (!facingRight)
                bodyDich.AddForce (new Vector2(-1, 0) * speedDich);
            else
                bodyDich.AddForce (new Vector2(1, 1) * speedDich);
            animDich.SetBool("Run", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canFlip = true;
            bodyDich.velocity = new Vector2(0, 0);
            animDich.SetBool("Run", false);
        }
    }
    void Flip()
    {
        if (!canFlip) //canFlip tuong duong <=> false
            return;
        facingRight = !facingRight;
        Vector3 theScale = enemyGraphic.transform.localScale;
        theScale.x *= -1;
        enemyGraphic.transform.localScale = theScale;
    }
}
