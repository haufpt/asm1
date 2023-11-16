using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoll_mapping : MonoBehaviour
{
    public float ScrollSpeed = 0.5f;
    float Offset;

    // Update is called once per frame
    void Update()
    {
        Offset += Time.deltaTime * ScrollSpeed;

        GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (Offset, 0.01f);
        
    }
}
