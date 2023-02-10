using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGameManager : MonoBehaviour
{
    public static ShootingGameManager Instance { get; private set; }
    
    public float gameTimer;
    public float timeDuration;
    public bool gameStart;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameStart = true;
        gameTimer = timeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= 1 * Time.deltaTime;
        if(gameTimer <= 0)
        {
            gameStart = false;
        }
    }
}
