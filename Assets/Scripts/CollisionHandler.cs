using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField] float levelLoadDelay = 1f;
    [Tooltip("Death effect prefab on player")] [SerializeField] GameObject deathExplosion;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        deathExplosion.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
