using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject[] bulletPrefabs;
    public Transform player;
    public Vector3 spawnPosition;
    public float bulletChance = 0.3f;
    public float distanceBetweenObstacles = 15f;
    public float horizonDistance = 200f;

    public int spawnPerUpdate = 1; 

    void Update()
    {
        float distance = Vector3.Distance(player.position, spawnPosition);

        if (distance < horizonDistance)
        {
            for (int i = 0; i < spawnPerUpdate; i++)
            {
                int x = Random.Range(-3, 4);
                spawnPosition = new Vector3(
                    x,
                    0.5f,
                    spawnPosition.z + distanceBetweenObstacles
                );

                if (Random.value < bulletChance || i==spawnPerUpdate-1)
                {
                    spawnPosition.y = 0.1f;
                    GameObject bulletPrefab =
                        bulletPrefabs[Random.Range(0, bulletPrefabs.Length)];
                    Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
                }
                else
                {
                    GameObject obstaclePrefab =
                        obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
                    Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
                }
            }
        }
    }
}

 