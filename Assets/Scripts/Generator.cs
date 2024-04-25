using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [Header("Generator State")]
    public Animator animator;
    [SerializeField]private AudioSource generatorSource;
    private bool state = true;


    [Header("Computer Assign Things")]
    public Transform player;
    public float radius = 2.5f;
    [SerializeField] private KeyCode InteractionKey = KeyCode.F;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(InteractionKey) && Vector3.Distance(transform.position, player.position) < radius)
        {
            state = !state;
            ChangeState();
        }
    }

    private void ChangeState()
    {
        MissionComplete.Instance.UpdateMissionComplete(3, !state);
        if (state)
        {
            // generator 소리 켜기
            generatorSource.Play();

        }
        else
        {
            // generator 소리 끄기
            generatorSource.Stop();
            // generator 애니매이션 끄기
            
            audioSource.PlayOneShot(clip);

        }
    }

}
