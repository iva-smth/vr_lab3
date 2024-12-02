using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsBehavior : MonoBehaviour
{
    public List<GameObject> Slots = new List<GameObject>();

    public void TurnOffSlot()
    {
        foreach (GameObject slot in Slots)
        {
            slot.GetComponent<BoxCollider>().enabled = false;
        }
    }   
    public void TurnOnSlot() 
    {
        foreach (GameObject slot in Slots)
        {
            slot.GetComponent<BoxCollider>().enabled = true;
        }
    }
}

