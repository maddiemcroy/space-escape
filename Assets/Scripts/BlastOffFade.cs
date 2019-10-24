using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastOffFade : MonoBehaviour
{
    public GameObject imgObj;

    public bool fadeIn = true;
    public bool fadeOut = false;

    CanvasGroup cg;
    AudioSource audio;

    private float timer = 0.0f;
    private float waitTime = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        cg = imgObj.GetComponent<CanvasGroup>();
        audio = GetComponent<AudioSource>();
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            fadeOut = true;
        }

        if (fadeIn)
        {
            if (cg.alpha > 0f)
            {
                cg.alpha -= 0.01f;
            }
            else
            {
                fadeIn = false;
            }
        }


        if (fadeOut)
        {
            if (cg.alpha < 1f)
            {
                cg.alpha += 0.01f;
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
