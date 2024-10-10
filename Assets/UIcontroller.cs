using mymanager;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIcontroller : MonoBehaviour
{
    public int helth =100 , Ammo = 6000, kills = 0 , attackPersentage;
    public TMP_Text HelthText, AmmoText  , KillsText , LogText, GameOverText;
    AudioSource au;
    public GameObject toActivateWithText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.score = 0;
        GameManager.gameover = false;
        au = GetComponent<AudioSource> ( );
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Time.time > 600)
            {
            attackPersentage = 100;
            }
        else if (Time.time > 600)
            {
            attackPersentage = 100;
            }
        else if (Time.time > 600)
            {
            attackPersentage = 100;
            }
        else if (Time.time > 540)
            {
            attackPersentage = 90;
            }
        else if (Time.time > 480)
            {
            attackPersentage = 80;
            }
        else if (Time.time > 420)
            {
            attackPersentage = 70;
            }
        else if (Time.time > 300)
            {
            attackPersentage = 60;
            }
        else if (Time.time > 240)
            {
            attackPersentage = 40;
            }
        else if (Time.time > 120)
            {
            attackPersentage = 20;
            }
        else if (Time.time > 60)
            {
            attackPersentage = 10;
            }
        else
            {
            attackPersentage = 5;
            }
      // print ( $"Time.time : {Time.time} , AttackPersentage: {attackPersentage}" );
       // attackPersentage = 40;
    }

    public void UpdateHelthText(int ReduceAmmount )
        {
        helth = helth - ReduceAmmount;
        if(helth > 0)
            {
            HelthText.text = $"Helth       : {helth:00}/100 ";
            }
        else
            {
            HelthText.text = $"Helth       : 00/100 ";
            gameOver ( );
            }
        }

    public void UpdateBulletText (int AmmoReduceAmount)
        {
        Ammo = Ammo - AmmoReduceAmount;
        AmmoText.text = $"Ammo      : {Ammo:0000}/6000 ";
        if(Ammo <= 0)
            {
            AmmoText.text = $"Ammo      : 0000/6000 ";
            gameOver ( );
            }  
        }

    public void UpdatekillsText ()
        {
        kills = kills + 1;
        KillsText.text = $"Kills :  {kills:000}";
        }

    public void UpdateLogText (string LogMessage )
        {
        LogText.text = "";
        if (!Utils.TextOnTyping && !GameManager.gameover)
            {
            StartCoroutine ( Utils.RevealText ( LogMessage,LogText,toActivateWithText,au ) );
            }
        }

    public void gameOver ( )
        {
        if (!GameManager.gameover) {
            GameManager.gameover = true;
            if(Ammo <= 0)
                {
                GameManager.score = kills * 5 + helth * 5;
                }
            else
                {
                GameManager.score = kills * 5;
                }
            StartCoroutine ( Utils.RevealText ( "Game Over",GameOverText,toActivateWithText,au ) );
            StartCoroutine ( Utils.waitSeanLoader ( "leaderboard",5f )); }
        }
    }
