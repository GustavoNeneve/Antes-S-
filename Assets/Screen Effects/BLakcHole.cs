using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BLakcHole : MonoBehaviour
{
    public Keyhole demoKey_keyhole;
    public Color demoKey_Col;
    public AnimationCurve demoKey_anim;
    public float demoKey_fTime;
    public Transform demoKey_target;
    public bool demoKey_bIsEntering;
    
    // Start is called before the first frame update
    void Start()
    {
        demoKey_bIsEntering = false;
        DemoKeyhole();

    }

    //==============================
    //KEYHOLE
    //==============================



    public void DemoKeyhole()
    {
        ScreenEffects.Keyhole(demoKey_keyhole, demoKey_target, demoKey_Col, demoKey_fTime, demoKey_anim, this, demoKey_bIsEntering);
    }

    private void Update()
    {

    }
    

    public IEnumerator Reset()
    {
        
        ScreenEffects.Keyhole(demoKey_keyhole, demoKey_target, demoKey_Col, demoKey_fTime, demoKey_anim, this, false);

        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

       
    }
}
