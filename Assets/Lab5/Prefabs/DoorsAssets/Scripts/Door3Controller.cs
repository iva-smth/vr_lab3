using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3Controller : MonoBehaviour
{
    public Material activeMaterial;
    public Material defaultMaterial;

    private MeshRenderer meshRenderer;

    public GameObject door;
    public Transform posOpen;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = defaultMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            meshRenderer.material = activeMaterial;
            door.transform.position = posOpen.transform.position;
        }
    }
}
