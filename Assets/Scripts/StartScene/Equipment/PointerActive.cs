using System.Collections;
using System.Collections.Generic;
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
    int objectNumber;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
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

        }
        else
        {
            pointerColor = new Color(changeColor.r, changeColor.g, changeColor.b, 0.8f);
        }
        pointer.color = pointerColor;
    }
}
