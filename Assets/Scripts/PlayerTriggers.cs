using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    // so we can not die after finish
    private bool gameWon = false;

    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if we hit obstacle
        if (collision.tag == "Obstacle" && !gameWon)
        {
            KillPlayer();
        }
        // coin collected
        else if (collision.tag == "Coin")
        {
            gameManager.GetComponent<PlayerStats>().CoinPickedUp(1);
            Destroy(collision.gameObject);
        }
        // touch finish line
        else if (collision.tag == "Finish")
        {
            StartCoroutine(movePlayerToCenter());
            Rigidbody2D playerRb = gameObject.GetComponent<Rigidbody2D>();
            playerRb.gravityScale = 0;
            playerRb.velocity = new Vector3(0, 0, 0);
            gameWon = true;
            StartCoroutine(FinishGame());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    private IEnumerator movePlayerToCenter ()
    {
        RectTransform canvasRect = FindObjectOfType<Canvas>().GetComponent<RectTransform>();
        RectTransform playerRt = transform.GetComponent<RectTransform>();
        Vector2 target = new Vector2(canvasRect.rect.width, 0);

        while (true)
        {
            playerRt.localPosition = Vector2.Lerp(playerRt.localPosition, target, Time.deltaTime/2);
            yield return null;
        }
    }

    private void KillPlayer ()
    {
        Time.timeScale = 0;
        gameObject.SetActive(false);
        call_ShowEndMenu("You died!");
    }

    private IEnumerator FinishGame()
    {
        call_ShowEndMenu("Congratulations!");
        while (true)
        {
            yield return new WaitForSeconds(2f);
            break;
        }

        Time.timeScale = 0;
        StopCoroutine(movePlayerToCenter());
    }

    void call_ShowEndMenu (string msg)
    {
        gameManager.GetComponent<MenuManagment>().Show_EndMenu(msg);
    }

}
