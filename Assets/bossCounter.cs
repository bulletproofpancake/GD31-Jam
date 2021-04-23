using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class bossCounter : MonoBehaviour
{
    // Start is called before the first frame update
    private int count;
    public TextMeshProUGUI textmeshPro;

    void Start()
    {
     count = GameManager.instance.bossCounter;
     textmeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textmeshPro.SetText("Boss Defeated: {000}", count);
    }
}
