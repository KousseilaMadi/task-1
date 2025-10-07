using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    Vector2 mouse_pos;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouse_pos.y = Input.GetAxis("Mouse Y");
        transform.RotateAround(player.position, player.right, -Mathf.Clamp(mouse_pos.y * 10, -1, 1));
    }
}
