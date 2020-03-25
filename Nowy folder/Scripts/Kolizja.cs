using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Kolizja : MonoBehaviour
{
    public GameObject Wróg;
    public string ktoś;
    Jednostka Wroga;
    Transform TrWroga;
    Rigidbody2D RbWroga;
    RuchPotwora nazwa; 
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            nazwa = Wróg.GetComponent<RuchPotwora>();
            nazwa.enabled = false;
            RbWroga = Wróg.GetComponent<Rigidbody2D>();     
            RbWroga.isKinematic = false;
            RbWroga.constraints = RigidbodyConstraints2D.FreezeAll;
            Wroga = Wróg.GetComponent<Jednostka>();
            TrWroga = Wróg.GetComponent<Transform>();
            TrWroga.position = new Vector3(25, -15, 0);
            TrWroga.rotation = new Quaternion(0f,180f,0f,1f);           
            DontDestroyOnLoad(Wróg);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);     
            Debug.Log(Wroga.nazwa);

            
        }
    }
}
