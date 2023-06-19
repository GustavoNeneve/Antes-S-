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
    public GameObject player;
    public GameObject DesgrabF;
    public GameObject DesgrabB;
    public bool isObsF;
    public bool isObsB;
    public bool isCarrying;


    // Start is called before the first frame update
    void Start()
    {
        //debug log 
        Debug.Log("Grab Script is working");
        layerm = LayerMask.NameToLayer("Grabbable");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //compare a escala do player é maior que 0
        if(player.transform.localScale.x > 0)
        {
            //se for maior que 0 a posição do raycastpoin local é 0.199f
            raycastpoint.transform.localPosition = new Vector3(0.199f, -0.3f, 0);
            
        }
        else if (player.transform.localScale.x < 0)
        {
            //se não for maior que 0 a posição do raycastpoin local é -0.606f
            raycastpoint.transform.localPosition = new Vector3(0.606f, -0.3f, 0);
            
        }
        RaycastHit2D hitInfo = Physics2D.Raycast(raycastpoint.position, transform.right, raycastdistance);
        if(hitInfo.collider != null)
        {
            Debug.Log(hitInfo.collider.gameObject.name);
        }
        
        if(isCarrying)
        {
            grabbedObject.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
             grabbedObject.transform.position = grabposition.position;
        }
        if(hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerm)
        {
            Debug.Log(hitInfo.collider.gameObject.name+" is grabbable");
            if(hitInfo.collider.CompareTag("Grabbable"))
            {

                if(Input.GetKeyDown(KeyCode.E) && grabbedObject == null)
                {
                    grabbedObject = hitInfo.collider.gameObject;
                    //grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    
                    
                    if (grabbedObject.transform.position != grabposition.position)
                    {
                        //move towards grab position
                        grabbedObject.transform.position = grabposition.position;
                        isCarrying = true;

                        Debug.Log("Grabbed Object");
                        
                    }
                    grabbedObject.transform.parent = transform;
                    
                    isGrabbing = true;
                }
                
            }
        }
        else if(Input.GetKeyDown(KeyCode.E) && grabbedObject != null)
            {
                //grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                isCarrying = false;
                if(isObsF)
                {
                    grabbedObject.transform.localPosition = DesgrabB.transform.localPosition;
                }else if(isObsB)
                {
                    grabbedObject.transform.localPosition = DesgrabF.transform.localPosition;
                }
                else 
                {
                   
                }
                
                grabbedObject.transform.parent = null;
                grabbedObject = null;

                isGrabbing = false;
            }
        Debug.DrawRay(raycastpoint.position, transform.right * raycastdistance, Color.red);

    }
}
