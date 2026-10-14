
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Enemy enemyPrefab;

    [SerializeField] private float spawnRadius = 10.5f;
    [SerializeField] private float spawnInterval = 1f;

    private float timer;



    void Awake()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = spawnInterval;
            Spawn();
        }
    }




    void FixedUpdate()
    {
    
    }



    // Drawing Gizmos
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,spawnRadius);
    }


    void Spawn()
    {
        float angle = Random.Range(0f, Mathf.PI * 2f);                       
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)); 
        Vector2 spawnPosition = (Vector2)transform.position + direction * spawnRadius;

        Enemy newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        newEnemy.SetTarget(targetTransform);
    }



}
