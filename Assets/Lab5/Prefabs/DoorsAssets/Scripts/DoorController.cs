using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform posOpen;
    public Transform posClose;
    bool open = false;
    // Start is called before the first frame update

    public void Door1()
    {
        if (!open)
        {
            OpenDoor();

            Invoke("CloseDoor", 10.0f);
        }
    }

    public void OpenDoor()
    {
        transform.position = posOpen.transform.position;
        open = true;
    }

    public void CloseDoor()
    {
        transform.position = posClose.transform.position;
        open = false;
    }
}
