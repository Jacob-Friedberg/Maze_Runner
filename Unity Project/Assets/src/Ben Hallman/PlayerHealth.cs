/* File: PlayerHealth.cs
 * Author: Benjamin
 * Description: The script that manages and controls the player's health,
 * damage overlay, and calls the Death() function when the player dies.*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    // Makes a GameObject called damageOverlay.
    public GameObject damageOverlay;
    // The amount of health the player starts the game with.
    public int startingHealth = 100;
    // The player's current health.
    public int currentHealth;
    // The audio clip that plays when the player takes damage.
    public AudioClip damageClip;
    // The audio clip that plays when the player's health goes below a defined threshold.
    public AudioClip heartBeatClip;
    // Reference to an image that flashes on the screen when the player takes damage.
    public Image damageImage;
    // The speed the damageImage will fade-out at.
    public float flashSpeed = 5f;
    // The colour the damageImage is set to when it flashes.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    // A boolean statement representing if the player is being damaged.
    bool damaged;

    // Reference to the AudioSource component.
    AudioSource playerAudio;
    // Reference to the player's movement.
    PlayerControl playerMovement;

    void Start()
    {
        //Activate Image
        damageOverlay.SetActive(true);

        // Setting up the references.
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerControl>();

        // Set the initial health of the player.
        currentHealth = startingHealth;
        // Set the initial playerAudio.clip
        playerAudio.clip = damageClip;
    }

    void Update()
    {
        if (currentHealth <= 25)
        {
            // Reset playerAudio.clip
            playerAudio.clip = heartBeatClip;
            // Play the heart beat sound effect.
            playerAudio.play();
        }

        // If the player has just been damaged.
        if (damaged)
        {
            // Set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        else
        {
            // Transition the colour back to clear.
            if(!GetComponent<GameOver>().isPlayerDead()){
              damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }
        }

        // Reset the damaged flag.
        damaged = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("DeathTrigger"))
        {
            if(!GetComponent<GameOver>().isPlayerDead()){
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

        // Play the player damaged sound effect.
        playerAudio.Play();

        // If the player has lost all their health and the death flag has not been set yet.
        if (currentHealth <= 0)
        {
            // The player dies.
            Debug.Log("INITIALIZE DEATH");
            //Calls the Death() function in the GameOver script.
            GetComponent<GameOver>().Death();
            // Reset the initial health of the player.
            currentHealth = startingHealth;
        }
    }
}