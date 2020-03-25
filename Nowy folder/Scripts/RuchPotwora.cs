using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RuchPotwora : MonoBehaviour
{
    public GameObject Klatka;
    public int Goni = 0;
    public GameObject Wróg;
    public Rigidbody2D rb;
    Jednostka Potwór;
    Vector2 move;
    int iloscKroków = 5;
    public Transform PozycjaGracza;
    Transform PozycjaWrogaBieg;
    public float timeLeft;
    int OdlegloscPion = 10;
    int OdlegloscSkos = 7;
    public Text text;
    public float X;
    public float Y;
    public void Start()
    {
        Potwór = Wróg.GetComponent<Jednostka>();
    }
   
    public void Update()
    {
        PozycjaWrogaBieg = Wróg.GetComponent<Transform>();
        if (Goni == 0)
        {
            Strona();//Chodź normalnie
        }
        else if (Goni == 1)
        {
            Klatka.SetActive(false);
            Gdzie(PozycjaWrogaBieg, PozycjaGracza);//Goń gracza           
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                timeLeft = 5.0f;
                Goni = 2;//Wracaj na początek                
            }
        }
        if (Goni == 2)//Wraca w początkowe miejsce
        {
            Gdzie(PozycjaWrogaBieg, X, Y);
            Vector3 position = new Vector3(X, Y, 0);
            if (PozycjaWrogaBieg.position.x <= position.x + 1 && PozycjaWrogaBieg.position.x > position.x - 1 && PozycjaWrogaBieg.position.y <= position.y + 1 && PozycjaWrogaBieg.position.y > position.y - 1)
            {
                Klatka.SetActive(true);
                Goni = 0;//chodź normalnie
            }
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * Potwór.MoveSpeed * Time.fixedDeltaTime);
        Debug.Log("STOP");
    }
    public void Strona()
    {
        if (iloscKroków == 10)
        {
            iloscKroków = 0;
            int num = Random.Range(1, 25);
            switch (num)
            {
                case 1:
                    {
                        move = new Vector2(OdlegloscPion, 0);
                        break;
                    }
                case 2:
                    {
                        move = new Vector2(-OdlegloscPion, 0);
                        break;
                    }
                case 3:
                    {
                        move = new Vector2(0, OdlegloscPion);
                        break;
                    }
                case 4:
                    {
                        move = new Vector2(0, -OdlegloscPion);
                        break;
                    }
                case 5:
                    {
                        move = new Vector2(OdlegloscSkos, OdlegloscSkos);
                        break;
                    }
                case 6:
                    {
                        move = new Vector2(-OdlegloscSkos, -OdlegloscSkos);
                        break;
                    }
                case 7:
                    {
                        move = new Vector2(-OdlegloscSkos, OdlegloscSkos);
                        break;
                    }
                case 8:
                    {
                        move = new Vector2(OdlegloscSkos, -OdlegloscSkos);
                        break;
                    }
                default:
                    {
                        move = new Vector2(0, 0);
                        break;
                    }
            }
        }
        else
        {
            iloscKroków++;
        }
    }
    public void Gdzie(Transform Start, Transform Koniec)
    {
        float Xcoord = Koniec.position.x - Start.position.x;
        float Ycoord = Koniec.position.y - Start.position.y;
        if (Mathf.Abs(Xcoord) - Mathf.Abs(Ycoord) < OdlegloscSkos)
        {
            if (Xcoord < 0)
            {
                if (Ycoord < 0)
                {
                    move = new Vector2(-OdlegloscPion, -OdlegloscPion);
                }
                if (Ycoord >= 0)
                {
                    move = new Vector2(-OdlegloscPion, OdlegloscPion);
                }
            }
            if (Xcoord >= 0)
            {
                if (Ycoord < 0)
                {
                    move = new Vector2(OdlegloscPion, -OdlegloscPion);
                }
                if (Ycoord >= 0)
                {
                    move = new Vector2(OdlegloscPion, OdlegloscPion);
                }
            }
        }
        else if (Mathf.Abs(Xcoord) > Mathf.Abs(Ycoord))
        {
            if (Xcoord < 0)
            {
                move = new Vector2(-OdlegloscPion, 0);
            }
            if (Xcoord >= 0)
            {
                move = new Vector2(OdlegloscPion, 0);
            }
        }
        else if (Mathf.Abs(Xcoord) < Mathf.Abs(Ycoord))
        {
            if (Ycoord < 0)
            {
                move = new Vector2(0, -OdlegloscPion);
            }
            if (Ycoord >= 0)
            {
                move = new Vector2(0, OdlegloscPion);
            }
        }
    }
    public void Gdzie(Transform Start, float x, float y)
    {
        float Xcoord = x - Start.position.x;
        float Ycoord = y - Start.position.y;
        if (Mathf.Abs(Xcoord) - Mathf.Abs(Ycoord) < OdlegloscSkos)
        {
            if (Xcoord < 0)
            {
                if (Ycoord < 0)
                {
                    move = new Vector2(-OdlegloscPion, -OdlegloscPion);
                }
                if (Ycoord >= 0)
                {
                    move = new Vector2(-OdlegloscPion, OdlegloscPion);
                }
            }
            if (Xcoord >= 0)
            {
                if (Ycoord < 0)
                {
                    move = new Vector2(OdlegloscPion, -OdlegloscPion);
                }
                if (Ycoord >= 0)
                {
                    move = new Vector2(OdlegloscPion, OdlegloscPion);
                }
            }
        }
        else if (Mathf.Abs(Xcoord) > Mathf.Abs(Ycoord))
        {
            if (Xcoord < 0)
            {
                move = new Vector2(-OdlegloscPion, 0);
            }
            if (Xcoord >= 0)
            {
                move = new Vector2(OdlegloscPion, 0);
            }
        }
        else if (Mathf.Abs(Xcoord) < Mathf.Abs(Ycoord))
        {
            if (Ycoord < 0)
            {
                move = new Vector2(0, -OdlegloscPion);
            }
            if (Ycoord >= 0)
            {
                move = new Vector2(0, OdlegloscPion);
            }
        }
    }  
}
