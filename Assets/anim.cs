using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class anim : MonoBehaviour
{
    public Animator anime;
    public bool grabb;
    public Grab grabbedObject;
    public PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        //get animator component
        anime = GetComponent<Animator>();
        //findobject of type grab
        grabbedObject = FindObjectOfType<Grab>().GetComponent<Grab>();
        player = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        //move set float walk
       
        if(grabbedObject.isGrabbing == true)
        {
            anime.SetBool("grabb", true);
        }
        else
        {
            anime.SetBool("grabb", false);
        }
        anime.SetFloat("walk", move);

        if(player.IsJumping == true)
        {
            anime.SetBool("jump", true);
        }
        else
        {
            anime.SetBool("jump", false);
        }
    
     
    }
}