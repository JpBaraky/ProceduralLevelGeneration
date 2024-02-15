using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomType : MonoBehaviour
{
    
    public int typeOfRoom;

    public void DestroyRoom(){
        Destroy(gameObject);
    }
    
}
