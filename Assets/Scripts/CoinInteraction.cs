using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInteraction : MonoBehaviour
{
    public Vector3 CoinRotation;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().CoinCollected();
        }
    }

    private void Update()
    {
        transform.Rotate(CoinRotation * Time.deltaTime);
    }
}
