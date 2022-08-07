using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    [SerializeField] private Collider2D addCostBall;
    [SerializeField] private GameObject loseGameBall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out BallController ballController))
        {
            Destroy(addCostBall);
            loseGameBall.SetActive(true);
        }
    }
}
