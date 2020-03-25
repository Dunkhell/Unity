using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pauza : MonoBehaviour
{
    public GameObject PauzaHUD;
    public bool CzyZapauzowane;

    public void Start()
    {
        CzyZapauzowane = true;
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Zapauz(CzyZapauzowane);
        }
    }
    public void Zapauz(bool Czy)
    {
        PauzaHUD.SetActive(Czy);
        AudioListener.pause = Czy;
        if (Czy == true)
        {            
            Time.timeScale = 0;
            Czy = false;
        }
        else
        {
            Time.timeScale = 1;            
        }
         
    }
}
