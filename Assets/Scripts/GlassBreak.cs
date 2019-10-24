using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlassBreak : MonoBehaviour
{

    public GameObject player;
    public GameObject reticle;
    public GameObject glassSound;
    public GameObject tableCollider;
    public float pickupDistance;

    Text text;
    AudioSource audio;
    TableCollisionTest script;

    // Start is called before the first frame update
    void Start()
    {
        text = reticle.GetComponent<Text>();
        audio = glassSound.GetComponent<AudioSource>();
        script = tableCollider.GetComponent<TableCollisionTest>();

    }

    void OnMouseOver()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < pickupDistance)
        {
            text.fontSize = 40;
            text.color = Color.red;
        }
    }

    void OnMouseExit()
    {
        text.fontSize = 20;
        text.color = Color.white;
    }


    void OnMouseDown()
    {
        if (script.dialogueToggled)
        {
            audio.Play();
            Destroy(gameObject);
        }
    }
}
