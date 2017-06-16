using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissileControl : MonoBehaviour
{
    public enum Spawn { Left, Middle, Right };
    public Spawn spawnSelected;
    public int xAxisSpawn;
    public int yAxisSpawn = 6;

    public int xAxisTarget;
    public int yAxisTarget = -6;

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

    public int enemiesRemaining;

    public static EnemyMissileControl Instance;

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
            return;
        }
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

    void Start()
    {
        enemiesRemaining = 30;
        targetPosition = objPosition;
        GetComponent<Transform>().eulerAngles = new Vector3(xAxisSpawn, yAxisSpawn, -15);
        SpawnEnemies();
        // After 3 seconds, a projectile will be launched every 1.75 seconds
        InvokeRepeating("LaunchProjectile", 3f, 15f);
    }

    void Update()
    {
        SpawnEnemies();
        targetPosition = new Vector3(xAxisTarget, yAxisTarget, 0);

        timeKeeper += Time.deltaTime;

        if (timeKeeper > .04)
        {
            fracDist += .01f;
            timeKeeper = 0f;
        }
    }
}
