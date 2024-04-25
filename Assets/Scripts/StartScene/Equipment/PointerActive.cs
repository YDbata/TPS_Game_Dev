using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PointerActive: MonoBehaviour
{

    [Header("Distance Limit")]
    [SerializeField] float ActiveLimit = 2f;

    [Header("Pointer Object")]
    [SerializeField] Image pointer;
    [SerializeField] Color changeColor;
    GameObject player;
    PlayerController playerController;
    int objectNumber;

    [Header("Interative Object")] [SerializeField]
    public GameObject interCamera;

    private bool isAppend = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        Color pointerColor = pointer.color;
        //Debug.Log(distance + "    "+ GameObject.FindWithTag("Player").name);
        if (distance < ActiveLimit)
        {
            pointerColor = new Color(255, 255, 255, 1f);
            //Debug.Log(this.GetType().Name);
            if (!isAppend)
            {

                playerController.shortObjects.Add(this.gameObject, distance);
                isAppend = !isAppend;
                Debug.Log(playerController.shortObjects.Count);
            }
        }
        else
        {
            pointerColor = new Color(changeColor.r, changeColor.g, changeColor.b, 0.8f);
            if (isAppend)
            {
                //int idx = Array.IndexOf(playerController.shortObjects, this.gameObject);
                //Debug.Log("진입 " + idx);
                playerController.shortObjects.Remove(this.gameObject);
                isAppend = !isAppend;
            }
        }
        pointer.color = pointerColor;
    }
}
