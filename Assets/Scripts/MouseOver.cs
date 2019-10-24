using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOver : MonoBehaviour
{
    MeshRenderer mRenderer;
    Rigidbody rb;
    Material original;
    Text text;
    float throwForce = 600f;
    Vector3 objectPos;
    CanvasGroup holdingUIcg;
    CanvasGroup notHoldingUIcg;

    public GameObject player;
    public GameObject reticle;
    public float pickupDistance;
    public bool canHold = true;
    public GameObject tempParent;
    public bool isHolding = false;
    public GameObject holdingUI;
    public GameObject notHoldingUI;


    void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        text = reticle.GetComponent<Text>();
        holdingUIcg = holdingUI.GetComponent<CanvasGroup>();
        notHoldingUIcg = notHoldingUI.GetComponent<CanvasGroup>();
    }

    void Update()
    {
       //check if isHolding
       if (isHolding)
       {
            notHoldingUIcg.alpha = 0;
            holdingUIcg.alpha = 1;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.SetParent(tempParent.transform);

            if (Input.GetMouseButtonDown(1))
            {
                isHolding = false;
                holdingUIcg.alpha = 0;
            }
        } else
        {
            //holdingUIcg.alpha = 0;
            objectPos = transform.position;
            transform.SetParent(null);
            rb.useGravity = true;
            transform.position = objectPos;
        }
    }

    void OnMouseDown()
    {
        if (!isHolding)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < pickupDistance)
            {
                isHolding = true;
                rb.useGravity = false;
                rb.detectCollisions = true;
                holdingUIcg.alpha = 1;
            }
        } else
        {
            rb.AddForce(tempParent.transform.forward * throwForce);
            isHolding = false;
            holdingUIcg.alpha = 0;
        }

    }

    void OnMouseOver()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < pickupDistance)
        {
            notHoldingUIcg.alpha = 1;
            text.fontSize = 40;
            text.color = Color.red;
        }
    }

    void OnMouseExit()
    {
        notHoldingUIcg.alpha = 0;
        text.fontSize = 20;
        text.color = Color.white;
    }
}
