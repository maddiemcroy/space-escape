using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCollisionTest : MonoBehaviour
{
    public bool isEmpty;
    public int counter;

    public GameObject wall1;
    public GameObject wall2;
    public GameObject ptLight;
    public GameObject dialogue3;
    public GameObject dialogue4;

    private float timer = 0.0f;
    private float timerEnd = 3f;
    private bool dimLights = false;

    Animator anim1;
    Animator anim2;
    Light light;
    AudioSource audio;
    Fade script;

    public bool dialogueToggled = false;

    void Start()
    {
        anim1 = wall1.GetComponent<Animator>();
        anim2 = wall2.GetComponent<Animator>();
        light = ptLight.GetComponent<Light>();
        audio = GetComponent<AudioSource>();
        script = dialogue3.GetComponent<Fade>();
    }

    void Update()
    {
        if (!dialogueToggled && counter == 0)
        {
            if (!dialogueToggled)
            {
                script.fadeIn = true;
                dialogueToggled = true;
            }
        }

        if (dialogueToggled && counter == 10)
        {
            dimLights = true;

            audio.Play();
            anim1.Play("Open");
            anim2.Play("Open");

            counter = -100;
        }

        if (dimLights && (light.intensity > 0 || RenderSettings.ambientIntensity > 0))
        {
            if (light.intensity > 0)
            {
                light.intensity -= 0.025f;
            }
            if (RenderSettings.ambientIntensity > 0)
            {
                RenderSettings.ambientIntensity -= 0.05f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        counter++;
    }
    void OnTriggerExit(Collider other)
    {
        counter--;
    }
}
