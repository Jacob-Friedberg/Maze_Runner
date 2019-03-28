/* GameOver.cs
 * Benjamin
   Script pertaining to the game being over. */

using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    // Reference to the player's health.
    public PlayerHealth playerHealth;
    // Time to wait before restarting the level
    public float restartDelay = 5f;


    // Reference to the animator component.
    Animator anim;
    // Timer to count up to restarting the level
    float restartTimer;


    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        // If the player has run out of health.
        if (playerHealth.currentHealth <= 0)
        {
            // Tell the animator the game is over.
            anim.SetTrigger("GameOver");

            // Increment a timer to count up to restarting.
            restartTimer += Time.deltaTime;

            // If it reaches the restart delay.
            if (restartTimer >= restartDelay)
            {
                // Then reload the currently loaded scene.
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}