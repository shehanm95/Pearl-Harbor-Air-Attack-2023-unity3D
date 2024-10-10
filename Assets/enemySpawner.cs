using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public float SpawningRateMin , SpawningRateMax;
    public GameObject airCraft;
    public bool Spawn;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine ( enemySpawn ( ) );
        }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator enemySpawn ( )
        {
        if (Spawn) {
            float time = Random.Range (SpawningRateMax , SpawningRateMin );
            yield return new WaitForSeconds ( time );
            Vector3 pos = new Vector3(0,0,0 );
            GameObject airc = Instantiate ( airCraft );
            airc.transform.position = pos;
            StartCoroutine ( enemySpawn ( ) );


            }
        }
}
