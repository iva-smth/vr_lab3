using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.EventTrigger;
using System.Net.Sockets;

public class ScoreKeeper : MonoBehaviour
{
    public float playerTime = 0;
    public TMP_Text timer;
    public bool complete = false;
    public bool pause = true;
    public List<GameObject> sockets = new List<GameObject>();
    public GameObject keyboard;
    public static ScoreKeeper Instance { get; private set; }

    public float score;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!complete && !pause)
        {
            
            playerTime += Time.deltaTime;
            UpdateTimer();
        }
        foreach(GameObject socket in sockets)
        {
            if (pause || !socket.GetComponent<SlotsBehavior>().detail.GetComponent<DetailBehaviour>().isInHand)
            {
                socket.GetComponent<BoxCollider>().enabled = false;
            }
            if (!pause && socket.GetComponent<SlotsBehavior>().detail.GetComponent<DetailBehaviour>().isInHand)
            {
                socket.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    public void UpdateTimer()
    {
        float minutes = Mathf.FloorToInt(playerTime / 60);
        float seconds = Mathf.FloorToInt(playerTime % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void SetComplete(bool flag)
    {
        complete = flag;
    }

    IEnumerator GetPlayerName(List<LeaderboardEntry> scores)
    {
        if (scores.Count > 10)
        {
            foreach (LeaderboardEntry entry in scores)
            {
                Debug.Log("hi");
                if (entry.score > playerTime)
                {
                    keyboard.SetActive(true);
                    Debug.Log("getting a name in if");
                    yield return new WaitUntil(() => Name.instance.done);
                    string name = Name.instance.playerName;
                    Debug.Log(name);
                    Name.instance.done = false;
                    keyboard.SetActive(false);
                    Name.instance.playerName = "";
                    entry.name = name;
                    entry.score = playerTime;
                    break;
                }
            }
        }
        else
        {
            keyboard.SetActive(true);
            Debug.Log("getting a name");
            yield return new WaitUntil(() => Name.instance.done);
            string name = Name.instance.playerName;
            Debug.Log(name);
            Name.instance.done = false;
            keyboard.SetActive(false);
            Name.instance.playerName = "";
            scores.Add(new LeaderboardEntry { name = name, score = playerTime });
            Leaderboard.instance.AddNewScore(name, playerTime);
        }


        XMLManager.instance.SaveScores(scores);
        Debug.Log("Save");
        Leaderboard.instance.UpdateDisplay();
    }

    public void UpdateScore()
    {
        Debug.Log("UPDATING SCORE");
        List<LeaderboardEntry> scores = XMLManager.instance.LoadScores();
        StartCoroutine(GetPlayerName(scores));
    }
}
