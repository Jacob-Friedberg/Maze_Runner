/* GameOver.cs
 * Benjamin
 * Script pertaining to the game being over. */

using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // Reference to the AudioSource component.
    AudioSource playerAudio;
    // Reference to an image to flash on the screen on being hurt.
    public Image deathImage;
    // The audio clip to play when the player dies.
    public AudioClip deathClip;
    // The speed the damageImage will fade at.
    public float fadeSpeed = 5f;
    // The colour the damageImage is set to, to flash.
    private Color flashColour = new Color(1f, 0f, 0f, 1f);
    // Reference to the player's movement.
    PlayerControl playerMovement;
    // Whether the player is dead.
    bool isDead;
    // True when the player gets damaged.
    bool damaged;
    // Timer to count up to restarting the level
    float restartTimer;

    public bool isPlayerDead(){
      return isDead;
    }

    void Update()
    {
        // If the player has run out of health.
        if (isDead)
        {
            // Set the colour of the damageImage to the flash colour.
            // deathImage.color = flashColour;
            deathImage.color = Color.Lerp(deathImage.color, Color.black, fadeSpeed * Time.deltaTime);
        }
    }

    public void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
        Debug.Log("PLAYER DIED");

        // Tell the animator that the player is dead.
        // anim.SetTrigger("Die");

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        playerAudio.clip = deathClip;
        playerAudio.Play();

        // Turn off the movement script.
        playerMovement.enabled = false;
    }
}
