using UnityEngine;

public class InstantiateWithForce: MonoBehaviour
    {
    public GameObject prefabToInstantiate;
    public Transform muzzel;
    public float forwardForce = 10f , waitTime;
    private float nextFireTime;
    public Transform Gun;
    UIcontroller ui;
    AudioSource au;
    bool play;


    private void Start ( )
        {
        ui = FindObjectOfType<UIcontroller> ( );
        au = GetComponent<AudioSource> ( );
        }
    // Update is called once per frame
    void Update ( )
        {
        // Check if the space key is pressed
        if (Input.GetMouseButtonDown ( 0 ) && !GameManager.gameover)
            {
            au.Play ( );
            }
            if (Input.GetMouseButton(0) && !GameManager.gameover)
            {
            
            if (nextFireTime < Time.time)
                {
                ui.UpdateBulletText ( 1 );
                nextFireTime = Time.time + waitTime;
                // Instantiate the prefab
                GameObject instantiatedObject = Instantiate(prefabToInstantiate, muzzel.position,muzzel.rotation);
                }
              
            }

        if (Input.GetMouseButtonUp ( 0 ) && !GameManager.gameover)
            {
            au.Stop( );
            }
        }
    }
