using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    Vector3 move_dir = Vector3.zero;
    Vector3 player_move_dir = Vector3.zero;
    Vector2 mouse_pos = Vector2.zero;
    bool on_ground = true;
    public Rigidbody rb;
    float speed = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move_dir.magnitude > 0)
        {
            move_dir = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        
        mouse_pos.x += Input.GetAxis("Mouse X");
        mouse_pos.y += Input.GetAxis("Mouse Y");
        if (Input.GetKeyDown(KeyCode.Space) && on_ground)
        {
            rb.AddForce(Vector3.up * 280);
            on_ground = false;
        }

        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + mouse_pos.x * 10, transform.rotation.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ground") || collision.collider.CompareTag("obstacle"))
        {
            on_ground = true;
        }
    }

}

