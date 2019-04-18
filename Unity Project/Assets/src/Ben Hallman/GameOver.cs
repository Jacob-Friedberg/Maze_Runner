/* File: GameOver.cs
 * Author: Benjamin
 * Description: The script that manages what occures when the game is over and
 * is used when the player's health reaches zero. */

using UnityEngine;
using UnityEngine.UI;

// The public class GameOver is an example of edited reuse from the Unity website.
public class GameOver : MonoBehaviour
{
    // A boolean statement representing if the player is dead.
    private bool isDead;
    // Timer to count up to restarting the game.
    private float restartTimer;

    // Creates a player GameObject.
    GameObject player;
    // Reference to the player's movement.
    PlayerControl playerMovement;
    AudioSource source;

    void Start()
    {
        // Adds the player death sound.
        SoundManager.Instance.AddSoundFromFile("death", "Attack Jump & Hit Damage Human Sounds/Hit & Damage 1");
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

        // Turn off the movement script.
        playerMovement.enabled = false;

        // Plays the player death sound effect.
        source = GetComponent<AudioSource>();
        SoundManager.Instance.Play(source, "myCoolSound");

        // Teleports the player to the main menu location.
        SceneManager.LoadScene("world1");
        player.transform.position = new Vector3(-103, 0, -43);
    }
}
