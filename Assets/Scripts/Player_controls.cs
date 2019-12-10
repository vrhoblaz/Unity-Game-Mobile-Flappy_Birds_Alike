using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controls : MonoBehaviour
{
    private Rigidbody2D playerRb;

    private bool gameStarted;

    public float jumpVelocity;
    public float gravityScale;

    private float screenHeight;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        playerRb.gravityScale = 0;

        screenHeight = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameStarted)
            {
                playerRb.velocity = new Vector3(0, jumpVelocity * screenHeight, 0);
            }
            else
            {
                gameStarted = true;
                playerRb.gravityScale = gravityScale * screenHeight;
                playerRb.velocity = new Vector3(0, jumpVelocity / 5, 0);
                StartCoroutine(GameObject.Find("Spawner").GetComponent<Spawner>().obstacleSpawningTimer());

                GameObject.Find("PlayInstructionText").GetComponent<MoveObject>().movingSpeed = 0.35f;
            }
        }

        // rotation of player
        float verticalVelocity = playerRb.velocity.y;
        float angle = verticalVelocity / (jumpVelocity * screenHeight) * 45;
        
        if (angle > 45)
        {
            angle = 45;
        } else if (angle < -45)
        {
            angle = -45;
        }

        transform.eulerAngles = new Vector3(0, 0, angle);

    }

    public void RestartPlayer()
    {
        gameStarted = false;
    }
}
