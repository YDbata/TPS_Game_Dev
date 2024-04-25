using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGateObject : MonoBehaviour
{
    [Header("Animations")]
    [SerializeField] private Animator animator;
    [SerializeField] private bool openGete;

    [SerializeField] private KeyList KeyList;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    public void StartAnimation()
    {
        if (KeyList.hasKey)
        {
            OpenGate();
        }
        
    }

    private void OpenGate()
    {
        openGete = !openGete;
        animator.SetBool("Open", openGete);
        audioSource.PlayOneShot(clip);
        if (openGete)
        {
            MissionComplete.Instance.UpdateMissionComplete(1, openGete);
        }
    }
}
