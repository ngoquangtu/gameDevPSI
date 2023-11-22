using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
[SerializeField] private GameObject enemyPrefab;
[SerializeField] private Collider2D  roomCollider;

IEnumerator SpawnRandomEnemies()
{
    Collider roomCollider = GetComponent<Collider>();

    for (int i = 0; i < numberOfEnemies; i++)
    {
        Vector3 randomPosition = GetRandomPositionInCollider(roomCollider);
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        yield return new WaitForSeconds(1f);
    }
}

Vector3 GetRandomPositionInCollider(Collider2D collider)
{
    Vector3 randomPosition = new Vector2(Random.Range(collider.bounds.min.x, collider.bounds.max.x),(Random.Range(collider.bounds.min.y, collider.bounds.max.y))
    );
    return randomPosition;
}
}
