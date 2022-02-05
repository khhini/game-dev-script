using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 0.5f;
    public float gravityValue = -9.81f;

    public float buttonTime = 0.2f;
    public float jumpAmount = 20;
    float jumpTime;
    bool jumping;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        {

            jumping = true;
            jumpTime = 0;
        }
        if (jumping)
        {
            if (playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
            jumpTime += Time.deltaTime;
            playerVelocity.y += Mathf.Sqrt(jumpHeight);
            Debug.Log(playerVelocity.y);
            
        }

        if (Input.GetKeyUp(KeyCode.Space) | jumpTime > buttonTime)
        {
            jumping = false;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        
    }
}
