using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Xml.Serialization;
using System.IO;

public class XMLManager : MonoBehaviour
{
    public static XMLManager instance;
    public Board leaderboard;

    void Awake()
    {
        instance = this;
        Debug.Log("create dir");

        if (!Directory.Exists(Application.persistentDataPath + "/HighScores/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/HighScores/");
        }
    }

    public void SaveScores(List<LeaderboardEntry> scoresToSave)
    {
        Debug.Log("create file");
        leaderboard.list = scoresToSave;
        XmlSerializer serializer = new XmlSerializer(typeof(Board));
        FileStream stream = new FileStream(Application.persistentDataPath + "/HighScores/highscores.xml", FileMode.Create);
        serializer.Serialize(stream, leaderboard);
        Debug.Log(Application.persistentDataPath + "/HighScores/highscores.xml");
        foreach (LeaderboardEntry entry in scoresToSave)
        {
            Debug.Log(entry.name);
        }    
        stream.Close();
    }

    public List<LeaderboardEntry> LoadScores()
    {
        if (File.Exists(Application.persistentDataPath + "/HighScores/highscores.xml"))
        {
            Debug.Log("load file");
            XmlSerializer serializer = new XmlSerializer(typeof(Board));
            FileStream stream = new FileStream(Application.persistentDataPath + "/HighScores/highscores.xml", FileMode.Open);
            leaderboard = serializer.Deserialize(stream) as Board;
            stream.Close();
        }

        return leaderboard.list;
    }
}

[System.Serializable]
public class Board
{
    public List<LeaderboardEntry> list = new List<LeaderboardEntry>();
}