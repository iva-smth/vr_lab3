using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject assempledPref;
    public GameObject disassempledPref;
    public Transform spawnPoint;

    [SerializeField] CheckCompletion check;
    [SerializeField] ScoreKeeper scoreKeeper;
    public GameObject startMenu;
    public GameObject pauseMenu;

    public void Assemblly()
    {
        disassempledPref.SetActive(true);
        check.SetAssemblyMode(true);
        startMenu.SetActive(false);
        pauseMenu.SetActive(true);
        scoreKeeper.pause = false;
    }

    public void Disassembly()
    {
        assempledPref.SetActive(true);
        check.SetAssemblyMode(false);
        startMenu.SetActive(false);
        pauseMenu.SetActive(true);
        scoreKeeper.pause = false;
    }

    public void Pause()
    {
        
        scoreKeeper.pause = !scoreKeeper.pause;
    }
    
    public void Stop()
    {
        SceneManager.LoadScene("Lab 5");
        //scoreKeeper.playerTime = 0;
        //scoreKeeper.pause = true;
        //startMenu.SetActive(true);
        //pauseMenu.SetActive(false);
    }
}
