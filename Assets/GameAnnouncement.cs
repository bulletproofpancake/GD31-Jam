using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameAnnouncement : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject canvas;

    public string winMsg;
    public string loseMsg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.bossDead)
        {
            GameManager.instance.bossDead = false;
            GameManager.instance.bossCounter += 1;

            text.SetText(winMsg);
           
            StartCoroutine("loopEnd");
        }

        if (GameManager.instance.playerDead)
        {
            GameManager.instance.playerDead = false;
            text.SetText(loseMsg);

            StartCoroutine("loopEnd");

        }
    }


    IEnumerator loopEnd()
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(3);
        canvas.SetActive(false);
        LoadScene("MainHub");
    }


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
