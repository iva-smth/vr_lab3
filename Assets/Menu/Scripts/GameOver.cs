using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Transform player;
    public GameObject Menu;

    bool flag = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y < -10 && flag)
        {
            Menu.SetActive(true);
            flag = false;
        }
    }
}
