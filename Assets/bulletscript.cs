using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
    {
    Rigidbody rb;
    public float forwardForce =140f , destroyIn = 3f;
    // Start is called before the first frame update
    void Start()
    {rb = GetComponent<Rigidbody> ( );
     rb.AddForce ( transform.forward * forwardForce,ForceMode.Impulse );
            Destroy ( gameObject,destroyIn );
     }

    // Update is called once per frame
    void Update()
    {
     }
}
