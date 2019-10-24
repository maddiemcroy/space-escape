using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogue;

    Fade script;

    // Start is called before the first frame update
    void Start()
    {
        script = dialogue.GetComponent<Fade>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            script.fadeIn = true;
            Destroy(gameObject);
        }
    }
}
