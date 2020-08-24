using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathExplosion;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 10;

    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scorePerHit);
        GameObject explosion = Instantiate(deathExplosion, transform.position, Quaternion.identity);
        explosion.transform.parent = parent;
        Destroy(gameObject);
    }
}
