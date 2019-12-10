using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManagment : MonoBehaviour
{
    GameObject endMenuGO;

    // Start is called before the first frame update
    void Start()
    {
        endMenuGO = GameObject.Find("Img_EndText");
        endMenuGO.SetActive(false);
    }


    public void Show_EndMenu(string msg)
    {
        int coinCollected = gameObject.GetComponent<PlayerStats>().coinsCollected;
        endMenuGO.transform.Find("CoinsCollected").GetComponent<Text>().text = "You collected " + coinCollected + " coin(s)";
        endMenuGO.transform.Find("EndText").GetComponent<Text>().text = msg;

        endMenuGO.SetActive(true);
    }
}