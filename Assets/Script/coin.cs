using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coin : MonoBehaviour
{
    public static int Diem;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        Diem = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Diem <0)
            Diem = 0;
        text.text = "" + Diem;
    }
    public static void ThemDiem(int s)
    {
        Diem += s;
    }
    public static void reset()
    {
        Diem = 0;
    }
    public static int diem()
    {
       return Diem;
    }
}
