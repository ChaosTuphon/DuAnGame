using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GokuMove : MonoBehaviour
{

    public float speed;
    public float jump;
    bool facingright;
    bool grounded;


    Rigidbody2D body;
    Animator anim;
    public int Diem;
    public int DiemL;

    public int capdo = 0;
    public bool BienHinh = false;
    // Start is called before the first frame update

    void Update()
    {
        if (BienHinh == true)
        {
            switch (capdo)
            {

                case 0:
                    {
                        StartCoroutine(GokuBinhThuong());
                        BienHinh = false;
                        break;
                    }
                case 1:
                    {
                        StartCoroutine(GokuBienHinh());
                        BienHinh = false;
                        break;
                    }


                default: BienHinh = false; break;
            }
        }
    }

    

    void Start()
    {

        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingright = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = (Input.GetAxisRaw("Horizontal"));
        body.velocity = new Vector2(move * speed, body.velocity.y);
        anim.SetFloat("RUn", Mathf.Abs(move));

        if (move > 0 && !facingright)
            Flip();
        if (move < 0 && facingright)
            Flip();

        if (Input.GetKey(KeyCode.K))
        {
            if (grounded)
            {
                grounded = false;
                body.velocity = new Vector2(body.velocity.x, jump);
                anim.SetBool("Nhay", true);
            }
        }
        
    }


    void Flip()
    {
        facingright = !facingright;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "grounded")
        {

            anim.SetBool("Nhay", false);
            grounded = true;

        }
        
        

        if (other.gameObject.tag == "dich")
        {
            //coin.ThemDiem(-Diem);
            
           // Application.LoadLevel("GameOver");
            Destroy(other.gameObject);
            if (coin.diem() <=0)
            {
                Destroy(other.gameObject);
            }

        }
        if(other.gameObject.tag == "Trap")
        {
            //Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }

        if(other.gameObject.tag == "Enemy")
        {
            coin.ThemDiem(-20);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            coin.ThemDiem(Diem);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("coinL"))
        {
            coin.ThemDiem(DiemL);
            Destroy(other.gameObject);
        }
    }
    IEnumerator GokuBienHinh()
    {
        float dotre = 0.1f;
        anim.SetLayerWeight(anim.GetLayerIndex("GokuBinhThuong"), 0);
        anim.SetLayerWeight(anim.GetLayerIndex("GokuBienHinh"), 1);
        yield return new WaitForSeconds(dotre);

        
        anim.SetLayerWeight(anim.GetLayerIndex("GokuBinhThuong"), 1);
        anim.SetLayerWeight(anim.GetLayerIndex("GokuBienHinh"), 0);
        yield return new WaitForSeconds(dotre);

        anim.SetLayerWeight(anim.GetLayerIndex("GokuBinhThuong"), 0);
        anim.SetLayerWeight(anim.GetLayerIndex("GokuBienHinh"), 1);
        yield return new WaitForSeconds(dotre);

    }

    IEnumerator GokuBinhThuong()
    {
        float dotre = 0.1f;
        anim.SetLayerWeight(anim.GetLayerIndex("GokuBinhThuong"), 1);
        anim.SetLayerWeight(anim.GetLayerIndex("GokuBienHinh"), 0);
        yield return new WaitForSeconds(dotre);
        
        
        anim.SetLayerWeight(anim.GetLayerIndex("GokuBinhThuong"), 0);
        anim.SetLayerWeight(anim.GetLayerIndex("GokuBienHinh"), 1);
        yield return new WaitForSeconds(dotre);

        anim.SetLayerWeight(anim.GetLayerIndex("GokuBinhThuong"), 1);
        anim.SetLayerWeight(anim.GetLayerIndex("GokuBienHinh"), 0);
        yield return new WaitForSeconds(dotre);
    }

}