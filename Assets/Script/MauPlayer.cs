using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MauPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    public int currenHeath;

    public ThanhMau heathBar;
    // Start is called before the first frame update
    void Start()
    {
        currenHeath = maxHealth;
        heathBar.ThanhMauFull(maxHealth);//update dame
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Takedame(50);

            if(currenHeath <= 0)
            {
                chet();
            }
        }
    }
    void chet()
    {
        SceneManager.LoadScene("GameOver");
    }
    void Takedame(int dame)
    {
        currenHeath -= dame;
        heathBar.SetHeath(currenHeath);
    }


}
