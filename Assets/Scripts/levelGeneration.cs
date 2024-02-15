using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGeneration : MonoBehaviour
{
    public Transform[] startingPositions;
    public GameObject[] rooms; // 0 = LR, 1 = LRB, 2 = LRT, 3 = LRBT
    public GameObject[] startAndEnd;
    public float moveAmount;
    private bool firstRoom;

    private int downCounter;

    private int generationDirection;
    int randStartPosition;

    private float timeBtwSpawn;
    private float startTimeBtwSpawn = 0.25f;
    public bool stopLevelGeneration;
    public float minX;
    public float maxX;
    public float minY;

    public LayerMask whatIsRoom;
    private void Start()
    {
        randStartPosition = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartPosition].position;
        Instantiate(startAndEnd[0], transform.position, Quaternion.identity);

        generationDirection = Random.Range(1, 5);
    }
    private void Update()
    {
        if (timeBtwSpawn <= 0 && !stopLevelGeneration)
        {
            MoveGenerator();
            if(!firstRoom){
                firstRoom = true;
            }
            timeBtwSpawn = startTimeBtwSpawn;

        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

    private void MoveGenerator()
    {
        if (generationDirection == 1 || generationDirection == 2)
        { // moving right
            
            if (transform.position.x < maxX)
            {
                downCounter = 0;
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;

                
                Instantiate(rooms[Random.Range(0, rooms.Length)], transform.position, Quaternion.identity);

                generationDirection = Random.Range(1, 6);
                if (generationDirection == 3)
                {
                    generationDirection = 2;
                }
                else
                {
                    if (generationDirection == 4)
                    {
                        generationDirection = 5;
                    }
                }
            }
            else
            {
               if(!firstRoom){
                generationDirection = 3;
                firstRoom = true;
               } else{

                generationDirection = 5;
               }
            }

        }
        else if (generationDirection == 3 || generationDirection == 4)
        { //moving left
            
            if (transform.position.x > minX)
            {
                downCounter = 0;
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;

                
                Instantiate(rooms[Random.Range(0, rooms.Length)], transform.position, Quaternion.identity);

                generationDirection = Random.Range(3, 6);
            }
            else
            {
                if(!firstRoom){
                    generationDirection = 1;
                    firstRoom = true;
                
                
               } else{
                generationDirection = 5;
               }
            }

        }
        else if (generationDirection == 5)
        { //moving down

            downCounter++;
           
            if (transform.position.y > minY)
            {

                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 2, whatIsRoom);
                if (roomDetection.GetComponent<roomType>().typeOfRoom != 1 && roomDetection.GetComponent<roomType>().typeOfRoom != 3)
                {
                    if (downCounter >= 2)
                    {
                        roomDetection.GetComponent<roomType>().DestroyRoom();
                       Debug.Log("Test");
                        Instantiate(rooms[3], transform.position, Quaternion.identity);
                        
                        
                    }
                    else
                    {
                        roomDetection.GetComponent<roomType>().DestroyRoom();
                    
                        int randBottomRoom = Random.Range(1, 4);
                        if (randBottomRoom == 2)
                        {
                            randBottomRoom = 1;
                        }
                        Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                    }

                }
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;


                int rand = Random.Range(2, 4);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                generationDirection = Random.Range(1, 6);

            }
            else
            {
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 2, whatIsRoom);
                roomDetection.GetComponent<roomType>().DestroyRoom();
                Instantiate(startAndEnd[3], transform.position, Quaternion.identity);
                stopLevelGeneration = true;
            }


        }



    }

}
