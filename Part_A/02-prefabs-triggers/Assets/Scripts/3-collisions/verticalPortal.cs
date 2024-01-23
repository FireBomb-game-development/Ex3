using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verticalPortal : MonoBehaviour
{
    enum Dir
    {
        right,left
    }
    [SerializeField] Dir dir;
    [SerializeField] float mapSize;

    private void OnTriggerEnter2D(Collider2D other)

    {
        Vector3 port = new Vector3(mapSize, 0.0f, 0.0f);
        if (other.tag == "Player")
        {



            if (dir == Dir.left)
            {
                other.transform.position += port;
            }
            if (dir == Dir.right)
            {
                other.transform.position -= port;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
