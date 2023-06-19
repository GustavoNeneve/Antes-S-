using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    BLakcHole demoKey_keyhole;
    // Start is called before the first frame update
    void Start()
    {
        demoKey_keyhole = FindObjectOfType<BLakcHole>().GetComponent<BLakcHole>();
    }

    // Update is called once per frame
    void Update()
    {
        //input key esc for reset
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(demoKey_keyhole.Reset());
            Debug.Log("Reloaded Scene FallDeath");
        }
    }
}
