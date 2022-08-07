using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("GameObjects:")]
    [SerializeField] public GameObject[] levelPrefabs;
    [SerializeField] public GameObject[] basketPrefabs;
    [SerializeField] public GameObject startLevels;
    [SerializeField] private List<GameObject> activeLevels = new List<GameObject>();
    [SerializeField] private List<GameObject> activeBaskets = new List<GameObject>();
    [Header("Controllers:")]
    [SerializeField] public BallController ballController;
    [Header("Transform:")]
    [SerializeField] private Transform ball;
    [Header("Managers:")]
    [SerializeField] private UIManager uiManager;
    [Header("TextMeshPro:")]
    [SerializeField] private TextMeshProUGUI scoreBall;
    [SerializeField] private TextMeshProUGUI scoreStar;

    private readonly float levelLenght = 44f;
    private readonly float basketLenght = 5;
    private float spawnPosBasket = -3f;
    private float spawnPosLevel = 32.97f;
    private readonly int startLevel = 3;
    private readonly int startBasket = 1;
    private bool shoot = false;

    private void Start()
    {
        uiManager.MenuScreen();

        for (int i = 0; i < startLevel; i++)
        {
            SpawnLevel(Random.Range(0, levelPrefabs.Length));
        }

        for (int i = 0; i < startBasket; i++)
        {
            SpawnBasketLeft(0);
            SpawnBasketRight(1);
        }
    }

    private void Update()
    {
        if (ball.position.y - 60 > spawnPosLevel - (startLevel * levelLenght))
        {
            SpawnLevel(Random.Range(0, levelPrefabs.Length));
            
            DeleteLevel();
            DeleteStartLevel();
        }

        if (shoot == false)
        {
            if (ball.position.y  - 1 > spawnPosBasket - (startBasket * basketLenght))
            {
                SpawnBasketLeft(0);
                shoot = true;
                DeleteBasket();
            }
        }

        if (shoot == true)
        {
            if (ball.position.y > spawnPosBasket - (startBasket * basketLenght))
            {
                SpawnBasketRight(1);
                shoot = false;
                DeleteBasket();
            }
        }
    }

    private void SpawnLevel(int levelIndex)
    {
        GameObject nextLevel = Instantiate(levelPrefabs[levelIndex], transform.up * spawnPosLevel, transform.rotation);
        activeLevels.Add(nextLevel);
        spawnPosLevel += levelLenght;
    }

    private void SpawnBasketLeft(int ballUndex)
    {
        var rotation = Quaternion.Euler(0, 0, 50);
        var transforms = Random.Range(-3.1f, -1f);
        GameObject nextBall = Instantiate(basketPrefabs[ballUndex], transform.right * transforms + transform.up * spawnPosBasket, rotation);
        activeBaskets.Add(nextBall);
        spawnPosBasket += basketLenght;
    }

    private void SpawnBasketRight(int ballUndex)
    {
        var rotation = Quaternion.Euler(0, 0, 120);
        var transforms = Random.Range(1.6f, 4.5f);
        GameObject nextBall = Instantiate(basketPrefabs[ballUndex], transform.right * transforms + transform.up * spawnPosBasket, rotation);
        activeBaskets.Add(nextBall);
        spawnPosBasket += basketLenght;
    }

    private void DeleteLevel()
    {
        Destroy(activeLevels[0]);
        activeLevels.RemoveAt(0);
    }

    private void DeleteStartLevel()
    {
        Destroy(startLevels);
    }

    private void DeleteBasket()
    {
        Destroy(activeBaskets[0]);
        activeBaskets.RemoveAt(0);
    }

    public void IncreaseScoreBall()
    {
        ballController.costBall++;
        scoreBall.text = ballController.costBall.ToString();
    }

    public void IncreaseScoreStar()
    {
        ballController.costStar++;
        scoreStar.text = ballController.costStar.ToString();
    }
}
