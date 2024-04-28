using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum InteractType
{
    EqauipmentBox,
}
public class PlayerController : MonoBehaviour
{
    [SerializeField] float radius = 2f;
    [SerializeField] LayerMask layer;
    [SerializeField] Collider[] colliders;
    [SerializeField] GameObject[] shortObjects;
    [SerializeField] int[] objectDistance;
    public GameObject short_obj;
    Vector3 viewPos;
    [SerializeField]Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float short_distance;
        if (shortObjects.Length > 0)
        {
            short_distance = objectDistance[0];
            foreach (var item in shortObjects.Select((value, index) => (value, index)))
            {
                GameObject gam = item.value;
                int idx = item.index;

                float short_distance2 = objectDistance[idx];
                if (isViewPos(gam.transform))
                {
                    if (short_distance > short_distance2)
                    {

                        short_distance = short_distance2;
                        short_obj = gam;

                    }
                }
            }

            if (short_obj)
            {
                InteractType interObject = (InteractType)Enum.Parse(typeof(InteractType), short_obj.name);
                InteractiveKeyPress(interObject);
            }
        }




        //float short_distance;
        // Sphere���� ��ü���� ���� ����� ��ü ����
        //colliders = Physics.OverlapSphere(transform.position, radius, layer);
        /*if (colliders.Length > 0) { 
            short_distance = Vector3.Distance(transform.position, colliders[0].transform.position);
            foreach(Collider col in colliders)
            {
                bool hit = Physics.Raycast(col.transform.position, Vector3.zero, 0f);
                float short_distance2 = Vector3.Distance(transform.position, col.transform.position);
                if (isViewPos(col))
                {
                    if (short_distance > short_distance2)
                    {
                        
                        short_distance = short_distance2;
                        short_enemy = col;
                        
                    }
                }
            }
            
                
            if(short_enemy)
            {
                InteractType interObject = (InteractType)Enum.Parse(typeof(InteractType), short_enemy.name);
                InteractiveKeyPress(interObject);
            }
        }*/
        
    }

    bool isViewPos(Transform transform)
    {
        viewPos = camera.WorldToViewportPoint(transform.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0) {
            return true;
        }
        return false;
    }

    void InteractiveKeyPress(InteractType type)
    {   
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            switch (type)
            {
                case InteractType.EqauipmentBox:
                    Debug.Log("장비구매");
                    break;
                default:
                    Debug.Log(type);
                    break;
            }
        }
    }
}
