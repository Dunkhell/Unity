using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jednostka : MonoBehaviour
{
    public float ZdrowieMax;
    public int atak;
    public int obrona;
    public bool isalive;
    public float ZdrowieTeraz;
    public float MoveSpeed;
    public string nazwa;
   public void Bitwa (Jednostka atakujący, Jednostka obrońca)//Funkcja zadająca obrażenia
    {
        obrońca.ZdrowieTeraz = obrońca.ZdrowieTeraz - atakujący.atak + obrońca.obrona;
    }
   public void Bronienie (Jednostka unit) //Funkcja kiedy się bronimy
    {
        unit.obrona = unit.obrona+1;
    }
    public int obrażenia (Jednostka atakujący, Jednostka obrońca) //Ile zadaliśmy obrażeń
    {
        return atakujący.atak - obrońca.obrona;
    }
    public void leczenie(Jednostka unit, int ile) //Funkcja leczenia
    {
        unit.ZdrowieTeraz = unit.ZdrowieTeraz + ile;
      
        if(unit.ZdrowieTeraz>=unit.ZdrowieMax)
        {
            unit.ZdrowieTeraz = unit.ZdrowieMax;
        }
    }
    
}
