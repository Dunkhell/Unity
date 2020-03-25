using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDWalki : MonoBehaviour
{
    public Slider SliderHp;
    public Text Hp;
 
    public void Wyświetl (Jednostka unit)
    {
        SliderHp.interactable = true;
        Hp.text = unit.ZdrowieTeraz.ToString() + "/" + unit.ZdrowieMax.ToString();
        SliderHp.maxValue = unit.ZdrowieMax;        
        SliderHp.value = unit.ZdrowieTeraz;
        SliderHp.interactable = false;
    }



}
