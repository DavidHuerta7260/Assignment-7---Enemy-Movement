using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseOnFall : MonoBehaviour
{
    public float lowestY;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < lowestY)
        {
            ScoreManager.gameOver = true;
        }
    }
}
