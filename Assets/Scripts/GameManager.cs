using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float speed = 5f;
    public float timeLeft = 30f;
    public int score = 0;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

         Vector3 movement = new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;
        transform.Translate(movement);

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0f)
        {
            Debug.Log("Game Over! Eindscore: " + score);
            enabled = false;
            return;
        }

        Debug.Log("Tijd over: " + Mathf.CeilToInt(timeLeft) + " seconden | Score: " + score);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            score += 10;
            Debug.Log("Munt opgepakt! +10 punten");

            Destroy(other.gameObject);
        }
    }
}
