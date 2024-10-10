using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletScript : MonoBehaviour
{
    GameObject player;
    public Vector3 bullutHitPoint;
    public float bulletSpeed = 40;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find ( "player" );
        transform.LookAt ( bullutHitPoint);
        Destroy ( gameObject,2f );
        }

    // Update is called once per frame
    void Update()
    {
        transform.position =  Vector3.MoveTowards ( transform.position, bullutHitPoint , bulletSpeed*Time.deltaTime );
    }
}
