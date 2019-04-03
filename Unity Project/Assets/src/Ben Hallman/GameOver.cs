/* File: GameOver.cs
 * Author: Benjamin
 * Description: The script that manages what occures when the game is over and
 * is used when the player's health reaches zero. */

using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // The audio clip that plays when the player dies.
    public AudioClip deathClip;
    // Reference to an image that flashes on the screen when the player dies.
    public Image deathImage;
    // The speed the deathImage will fade-out at.
    public float fadeSpeed = 5f;
    // The colour the damageImage is set to when it flashes.
    private Color flashColour = new Color(1f, 0f, 0f, 1f);

    // A boolean statement representing if the player is dead.
    bool isDead;
    // Timer to count up to restarting the game.
    float restartTimer;

    // Reference to the AudioSource component.
    AudioSource playerAudio;
    // Reference to the player's movement.
    PlayerControl playerMovement;

    void Update()
    {
        // If the player has lost all their health.
        if (isDead)
        {
            // Set the colour of the deathImage to the death colour and fade-out.
            deathImage.color = Color.Lerp(deathImage.color, Color.black, fadeSpeed * Time.deltaTime);
        }
    }

    public bool isPlayerDead()
    {
        return isDead;
    }

    public void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
        Debug.Log("PLAYER DIED");

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        playerAudio.clip = deathClip;
        playerAudio.Play();

        // Turn off the movement script.
        playerMovement.enabled = false;
    }
}