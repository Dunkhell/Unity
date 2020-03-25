using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Przyciski : MonoBehaviour
{
    public Button A;
    public Button O;
    public Button L;

    public void Turn(bool OnOff)
    {
        A.interactable = OnOff;
        O.interactable = OnOff;
        L.interactable = OnOff;
    }
}
