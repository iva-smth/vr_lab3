using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIZone : MonoBehaviour
{
    public GameObject ui;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("enter");
            ui.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("exit");
            ui.SetActive(false);
        }

    }
}
