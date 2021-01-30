using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public Animator ShipAnimator;  
    public AudioSource ShipStartSound;    


    void Start()
    {
        ShipAnimator = GetComponent<Animator>();
    }


    public void StartGameButton()
    {
        ShipAnimator.SetBool("IsStarted", true);
        ShipStartSound.Play();
        StartCoroutine(NextSceneLoading());        
    }
    private IEnumerator NextSceneLoading()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);

    }
}
