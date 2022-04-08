using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    public float maxmau = 100;
    float thanhMau;

    public Slider EnemyHealthSlider;
    // Start is called before the first frame update
    void Start()
    {
        thanhMau = maxmau;

        EnemyHealthSlider.maxValue = thanhMau;
        EnemyHealthSlider.value = thanhMau;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
