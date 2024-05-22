using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private GameObject thePlayer;
    [SerializeField] private Terrain sceneTerrain;

    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        if (thePlayer == null)
            thePlayer = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(thePlayer.name);
        thePlayer.transform.position = this.transform.position;
        Debug.Log(thePlayer.transform.position);
        _playerController = thePlayer.GetComponent<PlayerController>();
        _playerController.shortObjects = new Dictionary<GameObject, float>(4);
        //sceneTerrain.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
