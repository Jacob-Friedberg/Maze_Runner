/* File: GameOver.cs
 * Author: Benjamin
 * Description: The script that manages what occures when the game is over and
 * is used when the player's health reaches zero. */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// The public class GameOver is an example of edited reuse from the Unity website.
public class GameOver : MonoBehaviour
{
    // A boolean statement representing if the player is dead.
    private bool isDead;
    // Timer to count up to restarting the game.
    private float restartTimer;

    // A static singleton property is used here as having more than one instance of these, might cause some very incorrect behavior.
    // public static AudioHandler Instance { get; private set; }

    // The speed the deathImage will fade-out at.
    public float fadeSpeed = 5f;

    // The audio clip that plays when the player dies.
    public AudioClip deathClip;

    // Creates a player GameObject.
    GameObject player;
    // Reference to the player's movement.
    PlayerControl playerMovement;

    void Start()
    {
        // Save a reference to the AudioHandler component as the singleton instance.
        // Instance = this;
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

        // Play the player movement sound effect.
        // AudioHandler.Instance.PlayAudio(AudioHandler.Instance.deathClip);

        // Turn off the movement script.
        playerMovement.enabled = false;

        // Teleports the player to the main menu location.
        SceneManager.LoadScene("world1");
        player.transform.position = new Vector3(-103, 0, -43);
    }

    // Instance method, this method can be accesed through the singleton instance.
    public void PlayAudio(AudioClip clip)
    {
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().Play();
    }
}
