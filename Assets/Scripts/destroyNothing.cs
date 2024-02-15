using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyNothing : MonoBehaviour
{
    
    void Start()
    {
        Destroy(transform.parent.gameObject);
    }

  
}
