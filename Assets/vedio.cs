using mymanager;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class vedio : MonoBehaviour
    {
    public float delayBetweenLetters = 0.3f;
    public TMP_Text textComponent;
    public GameObject vedioScreen , nextButton;
    AudioSource au;
    string fullText ="On December 7, 1941, Japan launched a devastating surprise attack \non the U.S. Pacific Fleet at Pearl Harbor, Hawaii, leading to the destruction of battleships \nand drawing the United States into World War II. \nThe attack resulted in over 2,400 American casualties and marked a pivotal moment in history.";
    void Start ( )
        {
        au = GetComponent<AudioSource> ( );
        StartCoroutine ( loader ( ) );
        }

    // Update is called once per frame
    void Update ( )
        {
        GameManager.round = 0;
        }



    public void GoToTheGame ( )
        {
        StartCoroutine ( Utils.waitSeanLoader ( "level1",1f ) );
        }


    IEnumerator loader ( )
        {
        StartCoroutine ( Utils.RevealText ( fullText,textComponent,vedioScreen,au ) );
        yield return new WaitForSeconds (20f );
        nextButton.SetActive ( true );
        yield return new WaitForSeconds ( 220f );
        GoToTheGame ( );
        }

    }