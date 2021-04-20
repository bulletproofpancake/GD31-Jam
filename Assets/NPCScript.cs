using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public GameObject pressUI;

    public GameObject upgradesUI;



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            pressUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                upgradesUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pressUI.SetActive(false);
        }
    }
}
