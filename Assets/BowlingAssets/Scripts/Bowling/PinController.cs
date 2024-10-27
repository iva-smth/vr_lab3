using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : MonoBehaviour
{
    bool scored = false;
    //public static List<GameObject> PinsList = new List<GameObject>();

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent == gameObject.transform.parent && !scored)
        {
            scored = true;
            GameManager.scoredPins++;
        }
    }
}
