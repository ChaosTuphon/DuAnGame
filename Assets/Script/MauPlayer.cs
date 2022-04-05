using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MauPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    public float currenHeath;

    public Slider PlayerHealthSlider;
    // Start is called before the first frame update
    void Start()
    {
        currenHeath = maxHealth;
        PlayerHealthSlider.maxValue = maxHealth;
        PlayerHealthSlider.value = maxHealth;//update dame
    }

    // Update is called once per frame
    public void addDame(float dame)
    {
        if (dame <= 0)
            return;
        currenHeath -= dame;
        PlayerHealthSlider.value = currenHeath;
        if (currenHeath <= 0)
            chet();

    }

    // hoi mau khi an Health

    public void addHealth(float Soluongmau)
    {
        currenHeath += Soluongmau;
        if (currenHeath > maxHealth) 
            currenHeath = maxHealth;
        PlayerHealthSlider.value = currenHeath;
    }
    void chet()
    {
        SceneManager.LoadScene("GameOver");
    }
    


}
