using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField]private ToggleGroup toggleGroup;

    [SerializeField]Toggle[] toggles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(Toggle actToggle)
    {
        foreach (Toggle to in toggles)
        {
            to.interactable = true;
        }

        actToggle.interactable = false;

    }
}
