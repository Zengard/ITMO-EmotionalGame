using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWorld : MonoBehaviour
{
    public bool outsideWorld = true;
    public bool insideWorld = false;
    public bool canSwitch = true;
    
    [Space]
    public GameObject worldPreset1;
    public GameObject worldPreset2;
    public GameObject worldPreset3;
    public GameObject qText;
    public GameObject exitBlock;
    public GameObject win;
    public GameObject loose;

    [Space]
    public int inTrap = 0;

    [Space]

    public AudioSource music;

    public AudioClip _AudioClip1;
    public AudioClip _AudioClip2;
    public AudioClip _AudioClip3;

    Color outsideWoroldColor = new Color(172, 235, 255);
    Color insideWoroldColor = new Color(255, 131, 124);

    private void Start()
    {
        music.clip = _AudioClip1;
        music.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("test");

            if(canSwitch == true)
            {
                ChangeWorld();
            }
        }
    }

    private void ChangeWorld()
    {
        canSwitch = false;
        qText.SetActive(false);

        if(outsideWorld == true)
        {
            outsideWorld = false;
            insideWorld = true;
            worldPreset2.SetActive(true);
            worldPreset1.SetActive(false);
            //RenderSettings.fogColor = new Color(255, 138, 95);
            RenderSettings.fogStartDistance = 1;
            RenderSettings.fogEndDistance = 20;
            Camera.main.backgroundColor = insideWoroldColor;
            music.Stop();
            music.clip = _AudioClip2;
            music.Play();

        }
        else if(insideWorld == true)
        {
            if(inTrap < 3)
            {
                insideWorld = false;
                outsideWorld = true;
                worldPreset1.SetActive(true);
                worldPreset2.SetActive(false);
                //RenderSettings.fogColor = new Color(213, 243, 255);
                RenderSettings.fogStartDistance = -10;
                RenderSettings.fogEndDistance = 500;
                canSwitch = true;
                Camera.main.backgroundColor = outsideWoroldColor;
                music.Stop();
                music.clip = _AudioClip1;
                music.Play();
                qText.SetActive(true);
            }

            else if (inTrap >= 3)
            {
                insideWorld = false;
                worldPreset1.SetActive(true);
                worldPreset2.SetActive(false);
                worldPreset3.SetActive(true);
                RenderSettings.fog = false;
                Camera.main.backgroundColor = outsideWoroldColor;
                music.Stop();
                music.clip = _AudioClip3;
                music.Play();
                exitBlock.SetActive(false);
            }
           
        }
    }
}
