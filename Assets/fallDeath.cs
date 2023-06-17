using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fallDeath : MonoBehaviour
{
    public BLakcHole demoKey_keyhole;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //on trigger 2d enter reload scene
    void OnTriggerEnter2D(Collider2D other)
    {

        StartCoroutine(demoKey_keyhole.Reset());
        Debug.Log("Reloaded Scene FallDeath");
 
    }

}
