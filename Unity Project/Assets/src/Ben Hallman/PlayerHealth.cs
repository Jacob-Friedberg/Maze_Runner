/* PlayerHealth.cs
 * Benjamin
   Script pertaining to the management of the player's health. */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public GameOver GameOver;

    // The amount of health the player starts the game with.
    public int startingHealth = 100;
    // The current health the player has.
    public int currentHealth;
    // Reference to the UI's health bar.
    public Slider healthSlider;
    // Reference to an image to flash on the screen on being hurt.
    public Image damageImage;
    // The audio clip to play when the player is damaged.
    public AudioClip damageClip;
    // The speed the damageImage will fade at.
    public float flashSpeed = 5f;
    // The colour the damageImage is set to, to flash.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    // Reference to the Animator component.
    Animator anim;
    // Reference to the AudioSource component.
    AudioSource playerAudio;
    // Reference to the player's movement.
    PlayerControl playerMovement;
    // Whether the player is dead.
    bool isDead;
    // True when the player gets damaged.
    bool damaged;


    void Start()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerControl>();

        // Set the initial health of the player.
        currentHealth = startingHealth;
    }

    void Update()
    {
        // If the player has just been damaged.
        if (damaged)
        {
            // Set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        else
        {
            // Transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("DeathTrigger"))
        {
            TakeDamage(25);
            Debug.Log("PLAYER DAMAGE DELT");
        }
    }

    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        // Play the hurt sound effect.
        playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet.
        if (currentHealth <= 0 && !isDead)
        {
            // It should die.
            GameOver.Death();
        }
    }
}