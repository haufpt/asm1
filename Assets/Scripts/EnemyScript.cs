using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float start, end;
    private bool isRight;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //lay ra vi tri cua quai
        var positionEnemy = transform.position.x;
        //end 
        
        //quai di theo player
        if (player != null)
        {
            var positionPlayer = player.transform.position.x;
            if (positionPlayer > start && positionPlayer < end)
            {
                if (positionPlayer < positionEnemy) isRight = false;
                if (positionPlayer > positionEnemy) isRight = true;
            }
        }
        //end
        
        //huong di chuyen cua quai trong vung di chuyen cua no
        if (positionEnemy < start)
        {
            isRight = true;
        }
        
        if (positionEnemy > end)
        {
            isRight = false;
        }
        //end

        
        Vector2 scale = transform.localScale;
        
        //set huong di chuyen
        if (isRight)
        {
            scale.x = -1;
            transform.Translate(Vector3.right * 2f * Time.deltaTime);
        }
        else
        {
            scale.x = 1;
            transform.Translate(Vector3.left * 2f * Time.deltaTime);
        }
        //end

        transform.localScale = scale;
       
    }

    
    //2 con bug cham nhau
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "trai")
        {
            isRight = isRight ? false : true;
            /*
             * if (isRight == true ) isRight = false
             * else isRight=true;
             */
        }
      
    }

    public void setStart(float start)
    {
        this.start = start;
    }
    public void setEnd(float end)
    {
        this.end = end;
    }

    public void setPlayer(GameObject player)
    {
        this.player = player;
    }
}
