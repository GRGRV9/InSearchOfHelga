using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonController : MonoBehaviour
{
    public Animator PapirusAnimator;
    public AudioSource PapirusDestroyingSound;
    
    void Start()
    {
        PapirusAnimator = GetComponent<Animator>();
    }

    public void PapirusActivasion()
    {
        PapirusAnimator.SetBool("IsDestroyed", true);
        PapirusDestroyingSound.Play();                
    }
}
