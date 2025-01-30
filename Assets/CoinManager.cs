using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coin;
    public Text amount;
    public GameObject door;
    private bool doorDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        amount.text = coin.ToString();

        if (coin == 30 && !doorDestroyed)
        {
            doorDestroyed = true;
            Destroy(door);
        }
    }
}
