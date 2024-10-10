using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public GameObject BigExlosion;
    // Start is called before the first frame update
    void Start()
    {
        BigExlosion = Resources.Load<GameObject> ( "BigExplosion" );
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionStay ( Collision collision )
        {
        if(collision.gameObject.tag == "ship")
            {
            print ( "collied" );
            Instantiate ( BigExlosion,transform.position,Quaternion.identity );
           // collision.gameObject.GetComponent<ship> ( ).getAttack ( );
            }
        }
    }
