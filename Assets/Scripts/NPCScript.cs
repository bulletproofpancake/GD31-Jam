using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public GameObject pressUI;

    public GameObject upgradesUI;

    private bool isInBox;

    void Start()
    {
        this.GetComponent<Rigidbody>().sleepThreshold = 0.0f;
    }

    private void FixedUpdate()
    {
        if (isInBox)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("pressing");
                upgradesUI.SetActive(true);
            }
        }
    }

    private void OnTriggerStay (Collider other)
    {
        if (other.tag == "Player")
        {
            pressUI.SetActive(true);

            isInBox = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pressUI.SetActive(false);
            upgradesUI.SetActive(false);
            isInBox = false;
        }
    }

    public void UpgradeBackButton()
    {
        upgradesUI.SetActive(false);
    }    

}
