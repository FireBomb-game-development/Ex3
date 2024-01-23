using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructOnTouch : MonoBehaviour
{
  
    
    [SerializeField] float mapSize;
    [SerializeField] string[] destruct;

    private void OnTriggerEnter2D(Collider2D other)
         
    {

        for (int i = 0; i < destruct.Length; i++)
        {
            if (destruct[i] == other.transform.tag && other.enabled)
            {
                Destroy(other.gameObject);
            }
        }
    }
 
}
