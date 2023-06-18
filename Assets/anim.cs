using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class anim : MonoBehaviour
{
    public Animator anime;
    public bool grabb;
    public Grab grabbedObject;
    public PlayerMovement player;
    public bool isGrabbing = true;
    public Grab grabber;
    public AudioSource audioSourceFoot;
    public AudioSource audioSourceGrab;
    // Start is called before the first frame update
    void Start()
    {
        //get animator component
        anime = GetComponent<Animator>();
        //findobject of type grab
        grabbedObject = FindObjectOfType<Grab>().GetComponent<Grab>();
        grabber = grabbedObject;
        player = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();

        //audioSourceFoot = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        
        float move = Input.GetAxis("Horizontal");
        //move set float walk
        if(move != 0)
        {
            anime.SetFloat("walk", 1);
            if(player.IsOnGround == true)
            {
                audioSourceFoot.enabled = true;
            }
            else
            {
                audioSourceFoot.enabled = false;
            }

        }
        else
        {
            anime.SetFloat("walk", 0);
            audioSourceFoot.enabled = false;
        }
        
        if(grabbedObject.isGrabbing == true)
        {
            if(isGrabbing == true)
            {
            anime.SetTrigger("grabb");
            StartCoroutine(Grab());
            audioSourceGrab.enabled = true;
            }
            
        }
        else
        {
            //anime.SetBool("grabb", false);
            audioSourceGrab.enabled = false;
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
        if(player._isJumpFalling == true)
        {
            anime.SetBool("fall", true);
        }
        else
        {
            anime.SetBool("fall", false);
        }
        if(player.IsSliding == true)
        {
            anime.SetBool("slide", true);
        }
        else
        {
            anime.SetBool("slide", false);
        }
    
     
    }

    //coroutine for grab
    IEnumerator Grab()
    {
        //set grab to true
        //wait for 1 second
        yield return new WaitForSeconds(1);
        //set grab to false
        grabb = true;
    }
}
