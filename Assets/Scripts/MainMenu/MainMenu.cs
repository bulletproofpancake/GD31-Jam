using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject Credits;
    public GameObject QuizButton;

    private void Start()
    {
     
    }


    public void LoadScene(string sceneName)
    {
       //FindObjectOfType<AudioManager>().Play("button");
        StartCoroutine(LoadLevel(sceneName));
        PlayerPrefs.SetFloat("CurrentScore", 0);

    }

    public void credits()
    {
        //FindObjectOfType<AudioManager>().Play("button");
        Credits.SetActive(true);
        StartButton.SetActive(false);
        QuizButton.SetActive(false);

    }

    public void QuitGame()
    {
        Debug.Log("QUIT!!!");
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    IEnumerator LoadLevel(string sceneName)
    {
        //animator.SetTrigger("End");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneName);
    }
}
