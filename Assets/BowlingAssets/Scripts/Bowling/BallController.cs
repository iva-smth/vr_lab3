using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionStay(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Out" || collision.gameObject.tag == "Pin")
        {
            Invoke("DestroyBall", 5);
        }
    }

    public void DestroyBall()
    {
        Destroy(gameObject);
        gameManager.EndFrame();
    }
}