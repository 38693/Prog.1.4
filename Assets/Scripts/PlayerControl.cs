using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private bool IsOnFloor = false;    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        transform.position = new Vector3(0f, 1.3f, 0f);
        transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        transform.localScale = Vector3.one * 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up, 2.5f * Input.GetAxis("Horizontal"));

        if (Input.GetKeyDown(KeyCode.Space) && IsOnFloor)
        {
            rb.AddForce(Vector3.up * 300f, ForceMode.Force);

            IsOnFloor = false;
            Debug.Log("Billenzien");
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
