using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAirCraft : MonoBehaviour
{
    Transform popler , SmokeParticleSystem;
    private bool hit , dethpositionset;
    Transform airCraftDestination;
    public float Speed = 30f;
    public float spawningX =100, spawningYmin =15 ,spawningYmax =61 , dethPositionXVlue = 19;
    public float DethZPositionMultiplier = 2.3f , DethRotateSpeed = 400f , dethTimeAfterHit= 12f;
    UIcontroller ui;

    [Header("=========EnemyAttack========")]
    public float EnemyFireRate = 0.02f;
    GameObject EnemyBullet;
    private bool attacked;
    bool canAttack;
    float attackDistance;
    GameObject player;
    public bool useoriginalPos;



    // Start is called before the first frame update
    void Start()
        {//far range =   min (-100, 15, 330) , max (100 ,61, 330)
         // attack range  min (49,15,50)   (49,30,50)
         //max ( 313,23, 330)

       

        airCraftDestination = transform.parent.Find ( "airCraftDestination" );
        EnemyBullet = Resources.Load<GameObject> ( "enemyBullet" );
        if (!useoriginalPos)
            {
            transform.position = new Vector3 ( Random.Range ( -spawningX,spawningX ),Random.Range ( spawningYmin,spawningYmax ),330 );
            }

        int randnum = Random.Range(1 , 100);

        if(transform.position.x > -25 && transform.position.x < 25 && randnum < ui.attackPersentage)
            {
            canAttack = true;
            attackDistance = Random.Range ( 20f,45f );
            }
        
        
        airCraftDestination.transform.position = new Vector3 ( transform.position.x,transform.position.y,-100 );
        player = GameObject.Find ( "player" );
        ui = FindObjectOfType<UIcontroller> ( );
        popler = transform.Find ( "popler" );
        SmokeParticleSystem = transform.Find ( "Smoke" );
        }

    // Update is called once per frame
    void Update()
    {
        popler.Rotate ( new Vector3 ( 0,0,5 ) );

        transform.LookAt ( airCraftDestination.transform );
        transform.position = Vector3.MoveTowards ( transform.position,airCraftDestination.transform.position,Speed * Time.deltaTime );

        if (hit)
            {
            if (!dethpositionset)
                {
                airCraftDestination.position = new Vector3 ( Random.Range ( transform.position.x - dethPositionXVlue,transform.position.x + dethPositionXVlue ),-5,transform.position.y * -DethZPositionMultiplier );
                dethpositionset = true;
                Destroy ( transform.parent.gameObject,dethTimeAfterHit );
                }
            Vector3 directionToTarget = airCraftDestination.position - transform.position;

            // Create a rotation that points the forward direction of the object towards the target
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            // Smoothly interpolate between the current rotation and the target rotation
            transform.rotation = Quaternion.Lerp ( transform.rotation,targetRotation,Speed * Time.deltaTime );

            }
        else if (transform.position.z < player.transform.position.z) { Destroy ( gameObject.transform.parent.gameObject ); }
        
        
        
        if (dethpositionset)
            {
            float distance  = Vector3.Distance ( transform.position,airCraftDestination.position );
            if (distance < 0.5f){transform.Rotate ( new Vector3( 0,0,DethRotateSpeed*Time.deltaTime ) );}
            SmokeParticleSystem.gameObject.SetActive ( true );
            }

        float distc = Vector3.Distance(transform.position , player.transform.position);
        //doing attack
        if (!attacked && canAttack && distc < attackDistance)
            {
            StartCoroutine ( attack ( ) );
            attacked = true;
            }
    }

     IEnumerator attack ( )
        {
        
        Vector3 bullutHitPoint = new Vector3 ( Random.Range ( player.transform.position.x - 6f,player.transform.position.x + 10f ),player.transform.position.y - 10f,Random.Range ( player.transform.position.z - 20,player.transform.position.z + 20f ) );

        int attacktimes , howMuchAtOnes;
        attacktimes = Random.Range ( 2,5 );
        for(int i = 0 ; i < attacktimes ; i++)
            {
            howMuchAtOnes = Random.Range(5 , 20);
            for (int a = 0 ; a < howMuchAtOnes ; a++)
                {
                if (hit)
                    {
                    break;
                    }
                GameObject bullet =  Instantiate ( EnemyBullet,transform.position,Quaternion.identity );
                bullet.GetComponent<enemyBulletScript> ( ).bullutHitPoint =
                bullutHitPoint = new Vector3 ( bullutHitPoint.x,bullutHitPoint.y,bullutHitPoint.z - 0.5f );
                yield return new WaitForSeconds (EnemyFireRate );
                }
            float bigIntaval = Random.Range(0.6f , 1.5f);
            yield return new WaitForSeconds ( bigIntaval );
            attacked = true;
            canAttack = false;
            }
        }

    private void OnTriggerEnter ( Collider other )
        {
        if(other.gameObject.tag == "bullet" && !hit)
            {
            hit = true;

            if (ui != null)
                {
                ui.UpdatekillsText ( );
                }
            }

        }


    }
