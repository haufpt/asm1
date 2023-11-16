using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject player;

    public float start, end;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //lay vi tri truc x cua player
        var playerX = player.transform.position.x;
        //lay vi tri truc x cua cam
        var camX = transform.position.x;
        
        if (playerX > start && playerX < end)
        {
            // cam move theo player
            camX = playerX;
        }
        else
        {
            if (playerX < start)
            {
                camX = start;
            }
            
            if (playerX > end)
            {
                camX = end;
            }
        }

        transform.position = new Vector3(camX, 0, -10);
    }
}
