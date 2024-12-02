using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene("Bowling");
    }
    public void LoadScene2()
    {
        SceneManager.LoadScene("Rooms");
    }
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
