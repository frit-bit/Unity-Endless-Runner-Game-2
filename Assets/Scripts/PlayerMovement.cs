using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float playerMovementSpeed = 5f;
    public bool canRun = false;
    public GameObject GameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        GameOverUI.SetActive(false);
    }

    public void IdleDone()
    {
        canRun = true;
        FindObjectOfType<GameManager>().isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
      if (canRun == false) return;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
      if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * playerMovementSpeed * Time.deltaTime);
        }
      if (Input.GetKey(KeyCode.D))
        {
                transform.Translate(Vector3.right * playerMovementSpeed * Time.deltaTime);
        }
    }
    public IEnumerator EnableGameOverUI (float time)
    {
        yield return new WaitForSeconds(time);
        GameOverUI.SetActive(true);
    }
}
