using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ORBE : MonoBehaviour
{
    public GameObject text;
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
        
        if (other.gameObject.tag == "Grabbable")
        {
        // next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(true);
        }


    }
}
