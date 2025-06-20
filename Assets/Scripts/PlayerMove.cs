using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 15f;
    [SerializeField] private ScoreManager SM;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Uw snelheid is" + speed);
        if (SM == null)
        {
            Debug.Log("ScoreManager ontbreekt!");
        }
        else
        {
            Debug.Log("ScoreManager is aanwezig");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Coin")
        {
            SM.AddScore(10);
            Debug.Log("Munt gepakt!");
            Destroy(other.gameObject);
        }
    }
}
