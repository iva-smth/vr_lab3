using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2Controller : MonoBehaviour
{
    public Transform posOpen;
    public Transform posClose;
    bool open = false;
    bool open2 = false;
    // Start is called before the first frame update

    public void Door2()
    {
        if (open && open2)
        {
            OpenDoor();   
        }
        else
            Invoke("CloseDoor", 5f);   
    }

    public void enableFirst() { 
        open = !open;
        Door2();
    }

    public void enableSecond() { 
        open2 = !open2;
        Door2();
    }

    public void OpenDoor()
    {
        transform.position = posOpen.transform.position;
    }

    public void CloseDoor()
    {
        transform.position = posClose.transform.position;
    }
}
