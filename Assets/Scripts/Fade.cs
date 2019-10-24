using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public bool fadeOnStart;
    public GameObject player;

    public bool fadeIn = false;
    public bool fadeOut = false;

    CanvasGroup cg;
    CharacterController cc;
    AudioSource audio;

    private float timer = 0.0f;
    public float displayTime = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        cg = GetComponent<CanvasGroup>();
        cc = player.GetComponent<CharacterController>();
        audio = player.GetComponent<AudioSource>();

        if (fadeOnStart)
        {
            fadeIn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            cc.enabled = false;
            audio.enabled = false;
            if (cg.alpha < 1f)
            {
                cg.alpha += 0.01f;
            }
            else
            {
                if (timer > displayTime)
                {
                    fadeIn = false;
                    fadeOut = true;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
        }


        if (fadeOut)
        {
            if (cg.alpha > 0f)
            {
                cg.alpha -= 0.01f;
            }
            else
            {
                fadeOut = false;
                cc.enabled = true;
                audio.enabled = true;
            }
        }
    }
}
