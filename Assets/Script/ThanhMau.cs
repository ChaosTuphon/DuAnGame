using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThanhMau : MonoBehaviour
{
    public Slider ThanhTruoc;
    public Gradient gradient;//thay doi mau heath
    // Start is called before the first frame update
   public void ThanhMauFull(int TraiTim)
    {
        ThanhTruoc.maxValue = TraiTim;
        ThanhTruoc.value = TraiTim; //100
    }

    // Update is called once per frame
   public void SetHeath(int heath)
    {
        ThanhTruoc.value = heath;
    }
}
