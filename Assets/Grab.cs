using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Transform grabposition;
    public Transform raycastpoint;
    public float raycastdistance;
    public GameObject grabbedObject;
    public int layerm;
    public bool isGrabbing;



    // Start is called before the first frame update
    void Start()
    {
        //debug log 
        Debug.Log("Grab Script is working");
        layerm = LayerMask.NameToLayer("Grabbable");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(raycastpoint.position, transform.right, raycastdistance);
        if(hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerm)
        {
            if(hitInfo.collider.CompareTag("Grabbable"))
            {
                if(Input.GetKeyDown(KeyCode.E) && grabbedObject == null)
                {
                    grabbedObject = hitInfo.collider.gameObject;
                    grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    
                    
                    if (grabbedObject.transform.position != grabposition.position)
                    {
                        //move towards grab position
                        grabbedObject.transform.position = grabposition.position;

                        Debug.Log("Grabbed Object");
                        
                    }else if(grabbedObject.transform.position == grabposition.position)
                    {
                        grabbedObject.transform.position = grabposition.position;
                    }
                    grabbedObject.transform.parent = transform;
                    
                    isGrabbing = true;
                }
                else if(Input.GetKeyUp(KeyCode.E) && grabbedObject != null)
                {
                    grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                     //move towards raycast point
                    grabbedObject.transform.position = Vector2.MoveTowards(grabbedObject.transform.position, raycastpoint.position, (10* Time.deltaTime));
                    grabbedObject.transform.parent = null;
                    grabbedObject = null;

                    isGrabbing = false;
                }
            }
        }
        Debug.DrawRay(raycastpoint.position, transform.right * raycastdistance, Color.red);

    }
}
