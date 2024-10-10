using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhelth : MonoBehaviour
{
    float nextHelthReduceTime;
    public float helthIntaval = 2;
    UIcontroller ui;
    CameraShake cam;
    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<UIcontroller> ();
        cam = FindObjectOfType<CameraShake> ( );

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter ( Collider other )
        {
        if (other.gameObject.tag == "enemybullet")
            {
            nextHelthReduceTime = Time.time + helthIntaval;
            ui.UpdateHelthText ( 1 );
            print ( "hit col" );
            cam.StartShake ( 0.05f,0.03f );
            }
     if (other.gameObject.tag == "airCraft")
            {
            print ( "hit air Craft" );
            cam.StartShake( 0.2f,0.4f );
            }
     }
}


