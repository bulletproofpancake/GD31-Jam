using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameAnnouncement : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject canvas;


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
            text.SetText("You Win");
           
            StartCoroutine("loopEnd");
        }

        if (GameManager.instance.playerDead)
        {
            GameManager.instance.playerDead = false;
            text.SetText("You Lose");

            StartCoroutine("loopEnd");

        }
    }


    IEnumerator loopEnd()
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(3);
        canvas.SetActive(false);
        SceneManager.LoadScene("MainHub");
    }
}
