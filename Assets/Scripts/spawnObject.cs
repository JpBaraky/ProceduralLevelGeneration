using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObject : MonoBehaviour
{
   public GameObject[] objects;
   int rand;
    void Start()
    {
        rand = Random.Range(0 , objects.Length);
       Instantiate(objects[rand], transform.position, Quaternion.identity, transform);

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
