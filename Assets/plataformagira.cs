using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformagira : MonoBehaviour
{
    public bool playerOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(playerOn == false)
        {
            if(transform.rotation.z > 10 && transform.rotation.z < 80)
            {
                float angle = transform.rotation.z;
                transform.rotation =  Quaternion.Euler(0, 0, angle - (Time.deltaTime));
            }
            else if(transform.rotation.z < -10 && transform.rotation.z > -80)
            {
                float angle = transform.rotation.z;
                transform.rotation = Quaternion.Euler(0, 0, angle + ( Time.deltaTime));
            }else if (transform.rotation.z > 110 && transform.rotation.z < 170)
            {
                float angle = transform.rotation.z;
                transform.rotation = Quaternion.Euler(0, 0, angle - (Time.deltaTime));
            }
            else if (transform.rotation.z < -80 && transform.rotation.z > -170)
            {
                float angle = transform.rotation.z;
                transform.rotation = Quaternion.Euler(0, 0, angle + (Time.deltaTime));
            }
        }
        */
    }

    //oncollisionenter2d
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOn = true;
        }
    }
    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOn = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //couroutine for rotate
            StartCoroutine(Rotate());
        }
    }

    //couroutine for rotate
    IEnumerator Rotate()
    {
        yield return new WaitForSeconds(2f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

}
