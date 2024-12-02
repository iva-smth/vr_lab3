using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMaterial : MonoBehaviour
{
    public Material activeMaterial;
    public Material defaultMaterial;

    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = defaultMaterial;
    }

    // Update is called once per frame
    public void SetActive()
    {
        meshRenderer.material = activeMaterial;
    }

    public void SetDefault()
    {
        meshRenderer.material = defaultMaterial;
    }
}
