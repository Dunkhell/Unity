using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTrigger : MonoBehaviour
{
    public Text tekst;
    public GameObject potwór;    
    RuchPotwora Movement;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Movement = potwór.GetComponent<RuchPotwora>();
            Movement.Goni = 1;
            tekst.text = "You entered the wrong neighborhood";
        }
    }
}
