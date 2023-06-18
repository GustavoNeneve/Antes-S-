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
    public anim anim;



    // Start is called before the first frame update
    void Start()
    {
        //debug log 
        Debug.Log("Grab Script is working");
        layerm = LayerMask.NameToLayer("Grabbable");
        anim = FindObjectOfType<anim>().GetComponent<anim>();
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
                        
                    }
                    grabbedObject.transform.parent = transform;
                    
                    isGrabbing = true;
                }
                
            }
        }
        else if(Input.GetKeyUp(KeyCode.E) && grabbedObject != null)
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.position = new Vector3(1.4f, raycastpoint.position.y, 0);
                grabbedObject.transform.parent = null;
                grabbedObject = null;

                isGrabbing = false;
                anim.isGrabbing = true;
            }
        Debug.DrawRay(raycastpoint.position, transform.right * raycastdistance, Color.red);

    }
}
