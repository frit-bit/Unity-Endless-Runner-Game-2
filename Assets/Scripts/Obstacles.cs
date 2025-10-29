using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            collision.gameObject.GetComponent<Animator>().applyRootMotion = true;
            collision.gameObject.GetComponent<PlayerMovement>().canRun = false;
            collision.gameObject.GetComponent<Animator>().SetTrigger("Death");
            //collision.gameObject.GetComponent<PlayerMovement>().GameOverUI.SetActive(true);
            StartCoroutine(collision.gameObject.GetComponent<PlayerMovement>().EnableGameOverUI(2.5f));
            FindObjectOfType<GameManager>().isAlive = false;
        }
    }
}
