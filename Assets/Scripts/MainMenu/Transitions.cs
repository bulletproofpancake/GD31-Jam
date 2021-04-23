using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitions : MonoBehaviour
{
    public Animator animator;
    public float time;

 
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f;
        PauseMenu.GameisPaused = false;
        //FindObjectOfType<AudioManager>().Play("button");
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        animator.SetTrigger("End");
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName);
    }

}
