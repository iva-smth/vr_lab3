using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBall : MonoBehaviour
{
    public Transform Teleport;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "BallTeleport")
        {
            Debug.Log("hi");
            transform.position = Teleport.transform.position;
        }
    }
}
