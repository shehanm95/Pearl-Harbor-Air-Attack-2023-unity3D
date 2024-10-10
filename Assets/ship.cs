using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
    public GameObject BigExlosion;
    Animation anim;
    // Start is called before the first frame update
    void Start()
    {
      //  anim = GetComponent<Animation> ( );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getAttack ( )
        {
        //anim.Play ( "sink" );
        }

    private void OnCollisionStay ( Collision collision )
        {
        
        }
    }
