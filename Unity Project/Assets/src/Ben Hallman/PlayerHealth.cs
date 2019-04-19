/* File: PlayerHealth.cs
 * Author: Benjamin
 * Description: The script that manages and controls the player's health,
 * damage overlay, and calls the Death() function when the player dies.*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    // A boolean statement representing if the player is being damaged.
    private bool damaged;

    // The amount of health the player starts the game with.
    public int startingHealth = 100;
    // The player's current health.
    public int currentHealth;

    // Makes a GameObject called damageOverlay.
    public GameObject damageOverlay;

    // Reference to the player's movement.
    PlayerControl playerMovement;
    AudioSource source;

    void Start()
    {
        // Adds the player heartbeat sound.
        SoundManager.Instance.AddSoundFromFile("heartbeat", "Attack Jump & Hit Damage Human Sounds/Jump & Attack 7");
        // Adds the player damage sound.
        SoundManager.Instance.AddSoundFromFile("damage", "Attack Jump & Hit Damage Human Sounds/Hit & Damage 1");

        //Activate Image
        damageOverlay.SetActive(true);

        // Sets up the playerMovement reference.
        playerMovement = GetComponent<PlayerControl>();
        source = GetComponent<AudioSource>();

        // Sets the initial health of the player.
        currentHealth = startingHealth;
    }

    void Update()
    {
        // If the player's current health is equal to or less than a certain value...
        if (currentHealth <= 25)
        {
            // Plays the player heartbeat sound effect.
            SoundManager.Instance.Play(source, "heartbeat");

        }

        // If the player has just been damaged...
        if (damaged)
        {
            // Sets the color of the damage image.
            // ImageHandler.Instance.ImageColor(ImageHandler.Instance.red);
            GetComponent<ImageHandler>().ImageColor(Color.red);
        }

        // Reset the damaged flag.
        damaged = false;
    }

    void OnTriggerEnter(Collider coll)
    {
        // If the player is hit by an enemy...
        if (coll.gameObject.CompareTag("DeathTrigger"))
        {
            // If the player is not dead...
            if (!GetComponent<GameOver>().isPlayerDead())
            {
                TakeDamage(25);
                Debug.Log("PLAYER DAMAGE DELT");
            }
        }
    }

    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Plays the player damage sound effect.
        AudioSource source = GetComponent<AudioSource>();
        SoundManager.Instance.Play(source, "damage");

        // If the player has lost all their health and the death flag has not been set yet...
        if (currentHealth <= 0)
        {
            // The player dies.
            Debug.Log("INITIALIZE DEATH");

            //Calls the Death() function in the GameOver script.
            GetComponent<GameOver>().Death();

            // Sets the color of the damage image.
            // ImageHandler.Instance.ImageColor(ImageHandler.Instance.red);
            GetComponent<ImageHandler>().ImageColor(Color.black);

            // Reset the initial health of the player.
            currentHealth = startingHealth;
        }
    }
}
