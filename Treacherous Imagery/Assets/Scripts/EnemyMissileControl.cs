using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMissileControl : MonoBehaviour
{
    public enum Spawn { Left, Middle, Right };
    public Spawn spawnSelected;
    public int xAxisSpawn;
    public int yAxisSpawn = 6;

    public int xAxisTarget;
    public int yAxisTarget = -100;

    public Transform chosenMan;
    public Transform missileMan01;
    public Transform missileMan02;
    public Transform missileMan03;
    public Transform missileHead01;

    public float timeKeeper = 0f;
    public float fracDist = 1f;
    public Vector3 targetPosition;
    public static Vector3 objPosition;

    public GameObject[] bases;
    public GameObject[] activeBases;
    public GameObject baseSelected;

    public int enemiesThisRound;
    public int enemiesRemaining;

    public Text roundCount;
    public int roundCountNum;

    public static EnemyMissileControl Instance;

    public Button theEnd;

    public static int leftActive = 1;
    public static int middleActive = 1;
    public static int rightActive = 1;

    void Awake()
    {
        Instance = this;
    }

    void ChoosingSpawn()
    {
        int role = Random.Range(0, 3);
        spawnSelected = (Spawn)role;
    }

    void SpawnLocation()
    {
        if (spawnSelected == Spawn.Left)
        {
            xAxisSpawn = -6;
        }
        if (spawnSelected == Spawn.Middle)
        {
            xAxisSpawn = 0;
        }
        if (spawnSelected == Spawn.Right)
        {
            xAxisSpawn = 6;
        }
        else
        {
            //Debug.Log("Error: SpawnLocation");
        }
    }

    void ChoosingTarget()
    {
        int role = Random.Range(0, activeBases.Length);
        baseSelected = activeBases[role];
    }

    void TargetLocation()
    {
        if (baseSelected == activeBases[0])
        {
            if (PlayerMissileControl.LeftHP <= 0)
            {
                Debug.Log("rerolling...");
                ChoosingTarget();
            }
            else
            {
                xAxisTarget = -6;
            }
        }
        if (baseSelected == activeBases[1])
        {
            if (PlayerMissileControl.MiddleHP <= 0)
            {
                ChoosingTarget();
            }
            else
            {
                xAxisTarget = 0;
            }
        }
        if (baseSelected == activeBases[2])
        {
            if (PlayerMissileControl.RightHP <= 0)
            {
                ChoosingTarget();
            }
            else
            {
                xAxisTarget = 6;
            }
        }
        else
        {
            //Debug.Log("Error: BaseCoordinates");
        }
    }

    void SpawnEnemies()
    {
            ChoosingSpawn();
            SpawnLocation();
            ChoosingTarget();
            TargetLocation();
            transform.position = Vector3.Lerp(transform.position, targetPosition, fracDist);
    }

    void LaunchProjectile()
    {
        ChoosingMan();
        checkForAmmo();
    }

    void instantiateMan()
    {
        Instantiate(chosenMan, new Vector3(xAxisSpawn, yAxisSpawn, 0), chosenMan.rotation);
    }

    void instantiateHead()
    {
        Instantiate(missileHead01, new Vector3(xAxisSpawn, yAxisSpawn, 0), missileHead01.rotation);
    }

    void checkForAmmo()
    {
        if (enemiesRemaining > 0)
        {
            if (spawnSelected == Spawn.Left)
            {
                instantiateMan();
            }
            if (spawnSelected == Spawn.Middle)
            {
                instantiateMan();
            }
            if (spawnSelected == Spawn.Right)
            {
                instantiateHead();
            }
            enemiesRemaining -= 1;
        }
        else
        {
            NewRound();
        }
    }

    void NewRound()
    {
        enemiesThisRound += 5;
        enemiesRemaining = enemiesThisRound;
        roundCountNum += 1;
        SetRoundText();
        SpawnEnemies();
        // After 3 seconds, a projectile will be launched every 1.75 seconds
        InvokeRepeating("LaunchProjectile", 3f, 1.75f);
    }

    void ChoosingMan()
    {
        int role = Random.Range(0, 3);
        if (role == 0)
        {
            chosenMan = missileMan01;
        }
        if (role == 1)
        {
            chosenMan = missileMan02;
        }
        if (role == 2)
        {
            chosenMan = missileMan03;
        }
    }

    void SetRoundText()
    {
        roundCount.text = "Round: " + roundCountNum.ToString();
    }

    void Start()
    {
        theEnd.gameObject.SetActive(false);
        roundCountNum = 1;
        SetRoundText();
        enemiesThisRound = 15;
        enemiesRemaining = enemiesThisRound;
        targetPosition = objPosition;
        GetComponent<Transform>().eulerAngles = new Vector3(xAxisSpawn, yAxisSpawn, -15);
        SpawnEnemies();
        // After 3 seconds, a projectile will be launched every 1.75 seconds
        InvokeRepeating("LaunchProjectile", 3f, 1.75f);
    }

    void Update()
    {
        SpawnEnemies();
        targetPosition = new Vector3(xAxisTarget, yAxisTarget, 0);

        if (leftActive == 0 && middleActive == 0 && rightActive == 0)
        {
            theEnd.gameObject.SetActive(true);
        }
        //timeKeeper += Time.deltaTime;

        //if (timeKeeper > .04)
        //{
        //    fracDist += .01f;
        //    timeKeeper = 0f;
        //}
    }
}
