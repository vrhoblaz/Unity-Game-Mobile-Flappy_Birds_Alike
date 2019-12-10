using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    public float movingSpeed;

    float screenWidth;
    // Start is called before the first frame update
    void Start()
    {
        //screenWidth = FindObjectOfType<Canvas>().GetComponent<RectTransform>().rect.width;
        screenWidth = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        // moving the obstacle
        transform.Translate(Vector3.left * Time.deltaTime * movingSpeed * screenWidth);

        // destroy obstacle when out of frame
        if (transform.position.x < -screenWidth/3*2)
        {
            Destroy(gameObject);
        }

    }
}
