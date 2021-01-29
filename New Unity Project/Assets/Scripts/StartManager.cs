using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public Animator ShipAnimator;

    void Start()
    {
        ShipAnimator = GetComponent<Animator>();
    }


    public void ShipStartGame()
    {
        ShipAnimator.SetBool("IsStarted", true);
    }
}
