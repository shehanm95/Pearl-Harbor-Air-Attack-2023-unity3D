using mymanager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausePanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pauseGame ( )
        {
        if (Time.timeScale == 1)
            {
            Time.timeScale = 0;
            }
        else
            {
            Time.timeScale = 1;
            }
        }

    public void ExitGame ( )
            {
            FindObjectOfType<UIcontroller> ( ).gameOver ( );
            }



        }

