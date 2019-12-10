using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public int numberOfObstaclesInLevel;
    public float distanceBetweenObstacles_inSeconds;

    public GameObject coinPrefab;
    public GameObject obstaclePrefab;
    public GameObject finishLinePrefab;

    private int obstacleSpawnedNum = 0;
    private float screenHeight;

    private void Start()
    {
        screenHeight = FindObjectOfType<Canvas>().GetComponent<RectTransform>().rect.height;
    }

    public IEnumerator obstacleSpawningTimer ()
    {
        while (numberOfObstaclesInLevel > obstacleSpawnedNum)
        {
            bool spawnCoinBool = Random.Range(0, 3) < 1;
            if (spawnCoinBool)
            {
                SpawnCoin();
            }
            else
            {
                SpawnObstacle();
            }
            yield return new WaitForSeconds(distanceBetweenObstacles_inSeconds);
        }
        
        SpawnFinishLine();
    }

    private void SpawnCoin()
    {
        GameObject coinInst = Instantiate(coinPrefab, transform);
        float yPosistionCoin = Random.Range(screenHeight / 4, screenHeight * 3 / 4) - screenHeight /2;
        coinInst.transform.localPosition = new Vector2(coinInst.transform.localPosition.x, yPosistionCoin);
    }

    private void SpawnObstacle ()
    {
        GameObject obstInst = Instantiate(obstaclePrefab, transform);
        obstacleSpawnedNum++;
    }

    private void SpawnFinishLine ()
    {
        GameObject obstInst = Instantiate(finishLinePrefab, transform);
    }

}
