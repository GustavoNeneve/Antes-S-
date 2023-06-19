using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camarada : MonoBehaviour
{
    public GameObject texto;
    public GameObject texto2;
    public bool tem2;
    // Start is called before the first frame update
    void Start()
    {
        //Fala Coelho
        //texto = GameObject.Find("Fala Coelho").GetComponent<GameObject>();
        texto.SetActive(false);
        //Fala Coelho 2
        //texto2 = GameObject.Find("Fala Coelho 2").GetComponent<GameObject>();
        texto2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //on trigger 2d
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {

                
                if (tem2 == false)
                {
                    texto.SetActive(true);
                }else
                {
                    texto2.SetActive(true);
                }
            }
        }
    }

    //on trigger 2d exit
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            texto.SetActive(false);
            texto2.SetActive(false);
        }
    }
}
