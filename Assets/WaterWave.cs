using UnityEngine;

public class WaterWave: MonoBehaviour
    {
    public float scrollSpeed = 0.1f;

    void Update ( )
        {
        float offset = Time.time * scrollSpeed;
        GetComponent<Renderer> ( ).material.SetTextureOffset ( "_BumpMap",new Vector2 ( offset,offset ) );
        }
    }
