using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRooms : MonoBehaviour
{
   
    public LayerMask whatIsRoom;
    public levelGeneration levelGen;
    
    void Update()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1 , whatIsRoom);
        if(roomDetection == null && levelGen.stopLevelGeneration == true){
            int rand = Random.Range(0, levelGen.rooms.Length);
            Instantiate(levelGen.rooms[rand], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
