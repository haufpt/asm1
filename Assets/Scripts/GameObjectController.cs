using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectController : MonoBehaviour
{
    private int count = 3;
    private int count2 = 3;
    private int count3 = 2;
    private int count4 = 5;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
        float position = Random.Range(-5f, 6f);
        if (count-- > 0)
        {
        GameObject qv= (GameObject) Instantiate(Resources.Load("Prefabs/quai_vat"), new Vector3(position, -3.5f, 0), Quaternion.identity);
        qv.GetComponent<EnemyScript>().setStart(position - 4);
        qv.GetComponent<EnemyScript>().setEnd(position + 4);
        qv.GetComponent<EnemyScript>().setPlayer(player);
        }
        
        float position2 = Random.Range(6f, 16f);
        if (count2-- > 0)
        {
            GameObject qv= (GameObject) Instantiate(Resources.Load("Prefabs/quai_vat"), new Vector3(position2, -3.5f, 0), Quaternion.identity);
            qv.GetComponent<EnemyScript>().setStart(position2 - 4);
            qv.GetComponent<EnemyScript>().setEnd(position2 + 4);
            qv.GetComponent<EnemyScript>().setPlayer(player);
        }
        
        float position3 = Random.Range(16f, 26f);
        if (count3-- > 0)
        {
            GameObject qv= (GameObject) Instantiate(Resources.Load("Prefabs/quai_vat"), new Vector3(position3, -3.5f, 0), Quaternion.identity);
            qv.GetComponent<EnemyScript>().setStart(position3 - 4);
            qv.GetComponent<EnemyScript>().setEnd(position3 + 4);
            qv.GetComponent<EnemyScript>().setPlayer(player);
        }
        
        float position4 = Random.Range(46f, 56f);
        if (count4-- > 0)
        {
            GameObject qv= (GameObject) Instantiate(Resources.Load("Prefabs/quai_vat"), new Vector3(position4, -3.5f, 0), Quaternion.identity);
            qv.GetComponent<EnemyScript>().setStart(position4 - 4);
            qv.GetComponent<EnemyScript>().setEnd(position4 + 4);
            qv.GetComponent<EnemyScript>().setPlayer(player);
        }
       
    }
}
