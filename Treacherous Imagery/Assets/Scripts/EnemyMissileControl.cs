using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissileControl : MonoBehaviour
{
    public enum Spawn { Left, Middle, Right };
    public Spawn spawnSelected;
    public int xAxisSpawn;
    public int yAxisSpawn = 6;

    public enum Base { Left, Middle, Right };
    public Base baseSelected;
    public int xAxisTarget;
    public int yAxisTarget = -4;

    public Transform missileObj;

    public float timeKeeper = 0f;
    public float fracDist = .01f;
    public Vector3 targetPosition;
    public static Vector3 objPosition;

    public GameObject[] bases;

    public int enemiesRemaining = 14;

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
            Debug.Log("Error: SpawnLocation");
        }
    }

    void ChoosingTarget()
    {
        int role = Random.Range(0, 3);
        baseSelected = (Base)role;
    }

    void TargetLocation()
    {
        if (baseSelected == Base.Left)
        {
            xAxisTarget = -6;
        }
        if (baseSelected == Base.Middle)
        {
            xAxisTarget = 0;
        }
        if (baseSelected == Base.Right)
        {
            xAxisTarget = 6;
        }
        else
        {
            Debug.Log("Error: BaseCoordinates");
        }
    }

    void SpawnEnemies()
    {
            ChoosingSpawn();
            SpawnLocation();
            Instantiate(missileObj, new Vector3(xAxisSpawn, yAxisSpawn, 0), missileObj.rotation);
            transform.position = Vector3.Lerp(transform.position, targetPosition, fracDist);
            enemiesRemaining = enemiesRemaining -1;
        if (enemiesRemaining == 0)
        {
            Debug.Log("Round should be over.");
        }
    }

    void Start()
    {
        targetPosition = objPosition;
        GetComponent<Transform>().eulerAngles = new Vector3(xAxisSpawn, yAxisSpawn, -15);
        SpawnEnemies();
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
