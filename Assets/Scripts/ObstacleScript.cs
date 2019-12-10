using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float obstacleOpeningSize;

    private Transform topObstacle;
    private Transform bottomObstacle;

   
    void Start()
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        
        // Create random height for top and bottom part of the obstacle
        float obstacleWidth = transform.GetComponent<RectTransform>().sizeDelta[0];
        float screenHeight = canvas.GetComponent<RectTransform>().rect.height;
        float randomTopHeight = Random.Range(screenHeight / 5, screenHeight / 5 * 4);

        float topObstacleHeight = randomTopHeight - obstacleOpeningSize/2 * screenHeight;
        float bottomObstacleHeight = screenHeight - randomTopHeight - obstacleOpeningSize/2 * screenHeight;

        topObstacle = gameObject.transform.Find("Top");
        bottomObstacle = gameObject.transform.Find("Bottom");

        topObstacle.GetComponent<RectTransform>().sizeDelta = new Vector2(0, topObstacleHeight);
        bottomObstacle.GetComponent<RectTransform>().sizeDelta = new Vector2(0, bottomObstacleHeight);

        // create colliders
        BoxCollider2D topCollider = topObstacle.GetComponent<BoxCollider2D>();
        BoxCollider2D bottomCollider = bottomObstacle.GetComponent<BoxCollider2D>();

        topCollider.size = new Vector2(obstacleWidth, topObstacleHeight);
        topCollider.offset = new Vector2 (0, -topObstacleHeight / 2);
        bottomCollider.size = new Vector2(obstacleWidth, bottomObstacleHeight);
        bottomCollider.offset = new Vector2(0, bottomObstacleHeight / 2);
    }
}
