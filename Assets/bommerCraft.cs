using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bommerCraft: MonoBehaviour
    {

    Transform popler ;
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
    GameObject attackPosition;
    public GameObject Bomb;
    Transform bombmuzzel;



    // Start is called before the first frame update
    void Start ( )
        {//far range =   min (-100, 15, 330) , max (100 ,61, 330)
         // attack range  min (49,15,50)   (49,30,50)
         //max ( 313,23, 330)
        attackPosition = GameObject.Find ( "attackposition" );
        player = GameObject.Find ( "player" );
        ui = FindObjectOfType<UIcontroller> ( );
        Bomb = Resources.Load<GameObject> ( "Bomb" );
        bombmuzzel = transform.Find ( "bombt" );
        EnemyBullet = Resources.Load<GameObject> ( "enemyBullet" );
        if (!useoriginalPos)
            {
            transform.position = new Vector3 ( Random.Range ( -spawningX,spawningX ),Random.Range ( spawningYmin,spawningYmax ),330 );
            }
        int randnum = Random.Range(1 , 100);

        if (transform.position.x > -25 && transform.position.x < 25 && randnum < ui.attackPersentage)
            {
            canAttack = true;
            attackDistance = Random.Range ( 20f,45f );
            }
        popler = transform.Find ( "popler" );


        airCraftDestination = transform.parent.Find ( "airCraftDestination" );
        airCraftDestination.transform.position = new Vector3 ( transform.position.x,transform.position.y,-100 );
        transform.position = new Vector3 ( 11.6f,14f,330f );
        airCraftDestination.position = new Vector3 ( 11.6f,14f,-50f );
        }

    // Update is called once per frame
    void Update ( )
        {
        popler.Rotate ( new Vector3 ( 0,0,5 ) );
        transform.LookAt ( airCraftDestination.transform );
        transform.position = Vector3.MoveTowards ( transform.position,airCraftDestination.transform.position,Speed * Time.deltaTime );


        
        //doing attack
        if (!attacked && transform.position.z < attackPosition.transform.position.z)
            {
            attack ( );
            attacked = true;
            }
        } 

    public void attack ( )
        {
        Instantiate ( Bomb,bombmuzzel.position,Quaternion.identity );
        }

    


    }
