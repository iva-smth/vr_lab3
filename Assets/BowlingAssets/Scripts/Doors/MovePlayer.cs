using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    private bool playerOnPlatform = false;

    public Transform player;
    private BoxCollider platformCollider;

    public Transform teleport;

    // Start is called before the first frame update
    void Start()
    {
        platformCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerOnPlatform();
        if (playerOnPlatform)
        {
            player.SetParent(this.transform);
        }
        else
        {
            player.SetParent((GameObject.Find("XR Interaction Setup").transform));
        }

        if(player.position.y < -10)
        {
            player.position = teleport.position;
        }
    }

    private void CheckPlayerOnPlatform()
    {
        Transform gaze = player.transform.Find("Camera Offset").Find("Gaze Interactor");
        Vector3 platformCenter = platformCollider.bounds.center;
        Vector3 platformSize = platformCollider.bounds.size;

        if (platformCollider != null)
        {
            if (gaze.position.x >= platformCenter.x - platformSize.x / 2 && gaze.position.x <= platformCenter.x + platformSize.x / 2 &&
            gaze.position.y >= platformCenter.y - platformSize.y / 2 && gaze.position.y <= platformCenter.y + platformSize.y / 2 &&
            gaze.position.z >= platformCenter.z - platformSize.z / 2 && gaze.position.z <= platformCenter.z + platformSize.z / 2)
            {
                playerOnPlatform = true;
            }
            else
            {
                playerOnPlatform = false;
            }
        }
        else
        {
            Debug.Log("null");
        }
    }
}
