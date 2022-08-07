using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Managers:")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private UIManager uIManager;

    public int costBall;
    public int costStar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out BasketController basketController))
        {
            gameManager.IncreaseScoreBall();
        }

        if(collision.gameObject.TryGetComponent(out BasketLose basketLose))
        {
            uIManager.LoseScreen();
        }

        if (collision.gameObject.TryGetComponent(out StarCollect starCollect))
        {
            Destroy(starCollect.gameObject);
            gameManager.IncreaseScoreStar();
        }
    }


}
