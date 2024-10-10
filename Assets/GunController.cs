using UnityEngine;

public class GunController: MonoBehaviour
    {
    public Transform target;

    void Update ( )
        {
        transform.LookAt ( target );
        }

    }