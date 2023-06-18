using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ontrigerennterFront : MonoBehaviour
{
    public Grab grab;
    // Start is called before the first frame update
    void Start()
    {
        grab = FindObjectOfType<Grab>().GetComponent<Grab>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ontriggerenter2d
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Ground"))
        {
            
            grab.isObsB = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Ground"))
        {
            
            grab.isObsB = false;
            
        }
    }
}
}
