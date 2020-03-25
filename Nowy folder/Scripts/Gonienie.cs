using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gonienie : MonoBehaviour
{
    public GameObject SiatkaLewo;
    public GameObject SiatkaPrawo;
    public GameObject SiatkaGóra;
    public GameObject SiatkaDół;
    public GameObject Pudełko;

    BoxCollider2D Lewo;
    BoxCollider2D Prawo;
    BoxCollider2D Góra;
    BoxCollider2D Dół;

    public void Start()
    {
        Prawo = SiatkaPrawo.GetComponent<BoxCollider2D>();
        Dół = SiatkaDół.GetComponent<BoxCollider2D>();
        Góra = SiatkaGóra.GetComponent<BoxCollider2D>();
        Lewo = SiatkaLewo.GetComponent<BoxCollider2D>();
    }
    

}
