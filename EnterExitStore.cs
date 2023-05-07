using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterExitScene : MonoBehaviour
{
    // Set Player spawn position for next scene.
    [SerializeField]
    Vector2 _playerPosition;

    // Set Player direction to face in next scene.
    [SerializeField]
    Animator animatorVector2;

    public PlayerSpawnLocationSO playerInitialSpawnLocation;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex;

            // Animator direction when door trigger is hit...
            Vector2 playerDirection = new(animatorVector2.GetFloat("X"),
                animatorVector2.GetFloat("Y"));

            // Pass Player position into scriptable object...
            Vector2 initialPos = playerInitialSpawnLocation
                    .GetInitialPlayerPosition(_playerPosition);

            // Pass Animator direction into scriptable object...
            Vector2 initalDirection = playerInitialSpawnLocation
                .GetPlayerDirection(playerDirection);

            // This logic can be changed accoring to how you want scenes to be loaded.
            if (currentSceneIndex == 0)
            {
                // Enter room (to Scene2)
                nextSceneIndex = currentSceneIndex + 2;
            }
            else
            {
                // Exit room (to Scene0)
                nextSceneIndex = currentSceneIndex - 2;
            }
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
