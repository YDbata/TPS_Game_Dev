using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUI : MonoBehaviour
{
    void Update()
    {
		transform.LookAt(Camera.main.transform);
    }
}
