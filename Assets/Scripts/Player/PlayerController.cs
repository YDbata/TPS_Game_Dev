using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TPSGame.UI;
using UnityEngine;
using UnityEngine.Serialization;


public enum InteractType
{
    EqauipmentTable,
    MissionButton
    
}
public class PlayerController : MonoBehaviour
{
    [SerializeField] float radius = 2f;
    [SerializeField] LayerMask layer;
    //[SerializeField] Collider[] colliders;
    [SerializeField] public Dictionary<GameObject, float> shortObjects;
    public GameObject short_obj;
    Vector3 viewPos;
    [Header("Screen Controll")]
    [SerializeField]Camera camera1;

    [SerializeField] Canvas mainCanvas;

    // Start is called before the first frame update
    void Start()
    {
        shortObjects = new Dictionary<GameObject, float>(4);
        DontDestroyOnLoad(gameObject);
 
    }

    // Update is called once per frame
    void Update()
    {
        
        float short_distance;
        //Debug.Log(shortObjects.Count);
        if (shortObjects.Count > 0)
        {
            short_distance = 9999;
            foreach (var item in shortObjects.Select((value, index) => (value, index)))
            {
                GameObject gam = item.value.Key;
                int idx = item.index;

                float short_distance2 = item.value.Value;
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
                //Debug.Log("short_obj 진입");
                //InteractType interObject = (InteractType)Enum.Parse(typeof(InteractType), short_obj.name);
                InteractiveKeyPress(short_obj);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //camera1.gameObject.SetActive(true);
            // TODO 현재 UI 종료
            Cursor.visible = false;
        }
        
    }

    bool isViewPos(Transform transform)
    {
        viewPos = camera1.WorldToViewportPoint(transform.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0) {
            return true;
        }
        return false;
    }

    void InteractiveKeyPress(GameObject obj)
    {   
        if (Input.GetKeyDown(KeyCode.F))
        {
            InteractType interObject = (InteractType)Enum.Parse(typeof(InteractType), obj.name);
            
            switch (interObject)
            {
                case InteractType.EqauipmentTable:
                    // UI보여주기
                    
                    UIManager.instance.Get<InventoryUI>().Toggle();
                    Cursor.visible = true;
                    break;
                case InteractType.MissionButton:
                    // Mission UI 보여주기
                    Debug.Log("F enter");
                    UIManager.instance.Get<UIMission>().Toggle();
                    Cursor.visible = true;
                    break;
                default:
                    Debug.Log(interObject);
                    break;
            }
        }
    }
}
