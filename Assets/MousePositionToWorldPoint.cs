
using UnityEngine;

public class MousePositionToWorldPoint: MonoBehaviour
    {
    public  Transform target;
    Vector3 mousePositionScreen;

    private void Start ( )
        {
        }
    // Update is called once per frame
    void Update ( )
        {
        // Check if the left mouse button is pressed
       
            // Get the mouse position in screen coordinates
            if( !GameManager.gameover)
            mousePositionScreen = Input.mousePosition;
        
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(mousePositionScreen);

            // Create a RaycastHit variable to store information about the hit
            RaycastHit hit;

            // Check if the ray hits something in the scene
            if (Physics.Raycast ( ray,out hit ))
                {
            // Print the world position where the ray hit
            // Debug.Log ( "Mouse position in world coordinates: " + hit.point );
            if (hit.transform.gameObject.layer == 3)
                {
                target.position = hit.point;
                }
                }
            }
       
    }
