using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startPosition;
    private float repeatWidth;
    void Awake()
    {
        startPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
