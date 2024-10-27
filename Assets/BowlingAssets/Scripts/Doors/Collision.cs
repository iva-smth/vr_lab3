using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {

        if (collision.tag != "Player")
        {
            Physics.IgnoreCollision(collision.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        }

    }
}
