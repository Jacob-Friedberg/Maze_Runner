/* GameOver.cs
 * Benjamin
   Script pertaining to the game being over. */

using UnityEngine;

public class GameOver : MonoBehaviour
{
    // The speed the damageImage will fade at.
    public float restartDelay = 5f;
    // The audio clip to play when the player is damaged.
    public AudioClip deathClip;
    // Reference to the AudioSource component.
    AudioSource playerAudio;
    // Reference to the Animator component.
    Animator anim;
    // Reference to the player's movement.
    PlayerControl playerMovement;
    // Whether the player is dead.
    bool isDead;
    // True when the player gets damaged.
    bool damaged;
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
        if (isDead)
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

    public void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

        // Tell the animator that the player is dead.
        anim.SetTrigger("Die");

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        playerAudio.clip = deathClip;
        playerAudio.Play();

        // Turn off the movement script.
        playerMovement.enabled = false;
    }
}
