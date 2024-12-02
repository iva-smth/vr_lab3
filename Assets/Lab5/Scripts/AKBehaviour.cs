using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKBehaviour : MonoBehaviour
{
    [SerializeField] ScoreKeeper scoreKeeper;

    public void StartTime()
    {
        scoreKeeper.pause = false;

    }
}
