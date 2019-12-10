using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int coinsCollected;

    private void Start()
    {
        coinsCollected = 0;
    }

    public void CoinPickedUp (int coinValue)
    {
        coinsCollected += coinValue;
    }


}
