using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RocketShip : MonoBehaviour {

    public GameObject player;
    public GameObject reticle;
    public GameObject imgObj;
    public float pickupDistance;

    bool clicked = false;

    CharacterController cc;
    Text text;
    CanvasGroup cg;

    void Start()
    {
        text = reticle.GetComponent<Text>();
        cc = player.GetComponent<CharacterController>();
        cg = imgObj.GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (clicked)
        {
            if (cg.alpha < 1f)
            {
                cg.alpha += 0.01f;
            } else
            {
                SceneManager.LoadScene("BlastOff");
            }
        }
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
        clicked = true;
        cc.enabled = false;
    }
}
