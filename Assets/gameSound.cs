using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSound : MonoBehaviour
{

    public AudioClip bulletSound, gotAttackSound , AirCraftDamageSound , AirCraftCrashedSound;

    AudioSource au;
    // Start is called before the first frame update
    void Start()
    {
        au = GetComponent<AudioSource> ( );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound (AudioClip audio )
        {
        au.PlayOneShot ( audio );
        }
}
