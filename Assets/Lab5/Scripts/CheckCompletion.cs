using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCompletion : MonoBehaviour
{
    public Material baseMat;
    public Material wrongMat;
    public Material rightMat;
    
    public List<GameObject> completeAssembly=new List<GameObject>();
    public List<GameObject> completeDisassembly = new List<GameObject>();

    public List<GameObject> playersAssembly=new List<GameObject>();

    [SerializeField] ScoreKeeper scoreKeeper;
    [SerializeField] Menu menu;
    public bool assemblyMode;

    private void Start()
    {
        for (int i = 0; i < completeAssembly.Count; i++)
        {
            completeDisassembly.Add (completeAssembly[completeAssembly.Count - i-1]);
        } 
    }
    public void CheckAssembly()
    {
        List<GameObject> list = new List<GameObject>();
        if (assemblyMode)
        {
            list = completeAssembly;
        }
        else
        {
            list = completeDisassembly;
        }

        if (isComplete(list))
        {
            gameObject.GetComponent<MeshRenderer>().material = rightMat;
            Debug.Log("right");
            scoreKeeper.SetComplete(true);
            scoreKeeper.UpdateScore();
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = wrongMat;
            Debug.Log("wrong");
        }
    }

    public void ClearAssembly()
    {
        gameObject.GetComponent<MeshRenderer>().material = baseMat;
        Debug.Log("clear");
    }

    public void AddObject(GameObject obj)
    {
        playersAssembly.Add(obj);
    }

    public void RemoveObject(GameObject obj)
    {  
        playersAssembly.Remove(obj);
    }

    private bool isComplete(List<GameObject> list)
    {
        if (playersAssembly.Count != list.Count) 
        {
            return false;
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].name != playersAssembly[i].name)
            {
                return false;
            }
        }

        return true;
    }

    public void SetAssemblyMode(bool flag)
    {
        assemblyMode = flag;
    }
    
}
