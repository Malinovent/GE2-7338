using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        //Chaching
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector3(
            InputManager.movementInput.x * moveSpeed, 
            rb.velocity.y, 
            InputManager.movementInput.y * moveSpeed);

    }
}
