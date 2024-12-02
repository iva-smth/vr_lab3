using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Vector3 startPosition;

    [SerializeField] private float magnitude;
    [SerializeField] private float frequency;
    [SerializeField] private float offset;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPosition + transform.forward * Mathf.Sin(Time.time * frequency + offset) * magnitude;
    }

}
