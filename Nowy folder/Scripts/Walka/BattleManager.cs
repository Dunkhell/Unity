using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum StanWalki {Start,TuraGracza,TuraWroga,Wygrana,Przegrana}
public class BattleManager : MonoBehaviour
{
    public StanWalki stan;

    public GameObject Bohater, Potwór; //Obiekty jakie będą walczyć
    //GameObject Potwór;
    public Vector3 PozycjaGracza, SkalaGracza, RotacjaGracza; //Jak postawić Gracza

    public Vector3 PozycjaWroga, SkalaWroga, RotacjaWroga; //Jak postawic Wroga

    Jednostka Wróg, Gracz;

    public HUDWalki HUDGracza, HUDWroga;

    public Button Atak, Obrona, Leczenie;

    public Text Tura;
    public Przyciski WszystkiePrzyciski;
    
    void Start()
    {
        stan = StanWalki.Start;       
        Potwór = GameObject.FindGameObjectWithTag("Wróg");
        SpawnPlayers();
        // KtoTo = Potwór.GetComponent<ZKimWalka>();
        // Potwór = GameObject.Find(ZKim);
        //Potwór1 = PotwórGetComponent<ZKimWalka>();
    }
    void SpawnPlayers()
    {

        //Tworzenie klonów
        GameObject KlonGracza = Instantiate(Bohater);        
        //GameObject KlonWroga = Instantiate(Potwór);
        //Pobieranie wiadomości o nich
        Gracz = KlonGracza.GetComponent<Jednostka>();
        Wróg = Potwór.GetComponent<Jednostka>();
        //Ustalenie pozycji
        Pozycje(KlonGracza, PozycjaGracza, SkalaGracza, RotacjaGracza);
        Pozycje(Potwór, PozycjaWroga, SkalaWroga, RotacjaWroga);
        //Wyświetlenie HUDu początkującego rozgrywki
        OpisWalkiStart();
    }
    void OpisWalkiStart ()
    {
        HUDGracza.Wyświetl(Gracz);
        HUDWroga.Wyświetl(Wróg);
        WszystkiePrzyciski.Turn(false);
        Tura.gameObject.SetActive(false);

        stan = StanWalki.TuraGracza;
        StartCoroutine(TuraGracza());
    }

    IEnumerator TuraGracza()
    {                   
            yield return new WaitForSeconds(2f);
            Tura.gameObject.SetActive(true);
            Tura.text = "Twoja Tura";

            yield return new WaitForSeconds(1f);
            Tura.gameObject.SetActive(false);
            WszystkiePrzyciski.Turn(true);
        //Czekanie na wciśnięcie przycisku
            Atak.onClick.AddListener(Atakowanie);
            Obrona.onClick.AddListener(Bronienie);
            Leczenie.onClick.AddListener(Lecz);            
    }

    

    void TuraPotwora()
    {
        //Sprawdzenie Zdrowia Potwora
        if (Wróg.ZdrowieTeraz <= 0)
        {
            stan = StanWalki.Wygrana;
            Wygrana();
        }        
        //Ruch potwora
        else if (Wróg.ZdrowieTeraz > 0)
        {

            int num = Random.Range(1, 4);            
            switch (num)
            {
                case 1:
                    {
                        Gracz.Bitwa(Wróg, Gracz);
                        HUDGracza.Wyświetl(Gracz);
                        Tura.text = "atak";
                        break;
                    }
                case 2:
                    {
                        Wróg.Bronienie(Wróg);
                        Tura.text = "bron";
                        break;
                    }
                case 3:
                    {
                        Tura.text = "Leczenie";
                        Wróg.leczenie(Wróg, 6);
                        HUDWroga.Wyświetl(Wróg);
                        break;
                    }
            }
            //Sprawdzenie Zdrowia Gracza
            if (Gracz.ZdrowieTeraz <= 0)
            {
                stan = StanWalki.Przegrana;
                Przegrana();
            }

            stan = StanWalki.TuraGracza;
            TuraGracza();
        }
        
    }
    //Po wciśnięciu ataku
    void Atakowanie()
    {
        StartCoroutine(AAAAAA());
        stan = StanWalki.TuraWroga;
        TuraPotwora();
    }
    IEnumerator AAAAAA()
    {
        Gracz.Bitwa(Gracz, Wróg);
        HUDWroga.Wyświetl(Wróg);
        Tura.gameObject.SetActive(true);
        Tura.text = "Zaatakowałeś za " + Gracz.obrażenia(Gracz, Wróg).ToString() + " obrażeń";
        yield return new WaitForSeconds(1f);
        Tura.gameObject.SetActive(false);
    }
    //Po wciśnięciu Obrony
    void Bronienie()
      {
         StartCoroutine(BBBBBB());
        stan = StanWalki.TuraWroga;
        TuraPotwora();
    }
    IEnumerator BBBBBB()
    {
        Gracz.Bronienie(Gracz);
        Tura.gameObject.SetActive(true);
        Tura.text = "Bronisz się";
        yield return new WaitForSeconds(1f);
        Tura.gameObject.SetActive(false);
    }
    //Po wciśnięciu leczenia
    void Lecz()
     {
        StartCoroutine(CCCCCC());
        stan = StanWalki.TuraWroga;
        TuraPotwora();
     }  
    IEnumerator CCCCCC()
    {
        Gracz.leczenie(Gracz, 5);
        HUDGracza.Wyświetl(Gracz);
        Tura.gameObject.SetActive(true);
        Tura.text = "Uzdrowiłeś się za 5 punktów życia";
        yield return new WaitForSeconds(1f);
        Tura.gameObject.SetActive(false);        
    }
  
    public void Wygrana()
    {
        //Scena wygranej
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Przegrana()
    {
        //Scena Przegranej
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    
    public void Pozycje(GameObject obiekt, Vector3 poz, Vector3 skal, Vector3 rot) //Funkcja to ustawienia obiektu na scenie
    {
        obiekt.transform.position = poz;
        obiekt.transform.localScale = skal;
        obiekt.transform.Rotate(rot);
    }
}
