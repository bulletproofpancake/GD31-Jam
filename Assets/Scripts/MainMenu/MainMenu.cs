using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Credits;
    public GameObject GameTitle;

    public GameObject StartButton;
    public GameObject CreditsButton;
  
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

    public void ShowCredits()
    {
        //FindObjectOfType<AudioManager>().Play("button");
        GameTitle.SetActive(false);
        StartButton.SetActive(false);
        CreditsButton.SetActive(false);
        QuizButton.SetActive(false);


        Credits.SetActive(true);
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

    public void MainMenuBack()
    {
        //FindObjectOfType<AudioManager>().Play("button");

        Credits.SetActive(false);

        GameTitle.SetActive(true);
        StartButton.SetActive(true);
        CreditsButton.SetActive(true);
        QuizButton.SetActive(true);


        
    }
}
