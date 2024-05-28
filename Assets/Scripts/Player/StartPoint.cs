using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPoint : MonoBehaviour
{
    private GameObject thePlayer;
    [SerializeField] private Terrain sceneTerrain;
    [SerializeField] private CinemachineVirtualCamera minimapCamera;

    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        
        //sceneTerrain.enabled = true;
        PlayerSet();
        if (minimapCamera != null)
            CameraSet();


    }
    
    
    
    public void PlayerSet()
    {
        if (thePlayer == null)
            thePlayer = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(thePlayer.name);
        thePlayer.SetActive(false);
        thePlayer.transform.position = this.transform.position;
        Debug.Log(thePlayer.transform.position);
        _playerController = thePlayer.GetComponent<PlayerController>();
        _playerController.shortObjects = new Dictionary<GameObject, float>(4);
        thePlayer.SetActive(true);
    }

    public void CameraSet()
    {
        minimapCamera.Follow = thePlayer.transform;
        //minimapCamera.LookAt = thePlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
