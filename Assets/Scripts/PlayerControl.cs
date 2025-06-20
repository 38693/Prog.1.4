using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private bool IsOnFloor = false;
    [SerializeField] private GameObject coinPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        for (int i = 0; i < 30; i++)
        {
            float randomX = Random.Range(-10f, 10f);
            float randomY = Random.Range(-10f, 10f);
            Vector3 coinPosition = new Vector3(randomX, 0.5f, randomY);
            Quaternion coinRotate = Quaternion.Euler(90f, 0f, 0f);
            Instantiate(coinPrefab, coinPosition, coinRotate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(HorizontalInput, 0f, VerticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
        
        if (Input.GetKeyDown(KeyCode.Space) && IsOnFloor)
        {
            rb.AddForce(Vector3.up * 300f, ForceMode.Force);

            IsOnFloor = false;
            Debug.Log("Test");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            IsOnFloor = true;
        }
        
   }
}
