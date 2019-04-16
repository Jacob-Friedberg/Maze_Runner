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

    // A static singleton property is used here as having more than one instance of these, might cause some very incorrect behavior.
    public static AudioHandler Instance { get; private set; }

    // The amount of health the player starts the game with.
    public int startingHealth = 100;
    // The player's current health.
    public int currentHealth;
    // The speed the damageImage will fade-out at.
    public float flashSpeed = 5f;

    // The audio clip that plays when the player takes damage.
    public AudioClip damageClip;
    // The audio clip that plays when the player's health goes below a defined threshold.
    public AudioClip heartBeatClip;
    // Reference to an image that flashes on the screen when the player takes damage.
    public Image damageImage;
    // Makes a GameObject called damageOverlay.
    public GameObject damageOverlay;

    // The managing of colors below demonstrates the Prototype pattern in which new
    // Color objects are created by copying pre-existing, selected Colors of the same type.
    ColorManager colormanager = new ColorManager();

    // Initialize with standard colors
    colormanager["red"] = new Color(255, 0, 0);
    colormanager["green"] = new Color(0, 255, 0);
    colormanager["blue"] = new Color(0, 0, 255);
    colormanager["black"] = new Color(0, 0, 0);
    colormanager["white"] = new Color(255, 255, 255);

    // Clones selected colors
    Color red = colormanager["red"].Clone() as Color;
    Color black = colormanager["black"].Clone() as Color;

    // Reference to the player's movement.
    PlayerControl playerMovement;

    void Start()
    {
        //Activate Image
        damageOverlay.SetActive(true);

        // Sets up the playerMovement reference.
        playerMovement = GetComponent<PlayerControl>();

        // Sets the initial health of the player.
        currentHealth = startingHealth;

        // Save a reference to the AudioHandler component as the singleton instance.
        Instance = this;
    }

    void Update()
    {
        // If the player's current health is equal to or less than a certain value...
        if (currentHealth <= 25)
        {
            // Play the player movement sound effect.
            AudioHandler.Instance.PlayAudio(AudioHandler.Instance.heartBeatClip);
        }

        // If the player has just been damaged...
        if (damaged)
        {
            // Set the color of the damageImage to the correct color.
            damageImage.color = red;
        }
        else
        {
            // Transition the colour back to clear.
            if (!GetComponent<GameOver>().isPlayerDead())
            {
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }
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

        // Play the player movement sound effect.
        AudioHandler.Instance.PlayAudio(AudioHandler.Instance.damageClip);

        // If the player has lost all their health and the death flag has not been set yet...
        if (currentHealth <= 0)
        {
            // The player dies.
            Debug.Log("INITIALIZE DEATH");

            //Calls the Death() function in the GameOver script.
            GetComponent<GameOver>().Death();

            // Set the colour of the damageImage to the death colour and fade-out.
            damageImage.color = Color.Lerp(deathImage.color, Color.black, fadeSpeed * Time.deltaTime);
            // Reset the initial health of the player.
            currentHealth = startingHealth;
        }
    }

    // Instance method, this method can be accesed through the singleton instance.
    public void PlayAudio(AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
    }
}

// This abstract class declares an interface for cloning itself
abstract class ColorPrototype
{
    public abstract ColorPrototype Clone();
}

// This class implements an operation for cloning itself
class Color : ColorPrototype
{
    private int red;
    private int green;
    private int blue;

    // This is a constructor and an example of dynamic binding
    public virtual Color(int red, int green, int blue)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
    }

    // Creates a shallow copy
    public override ColorPrototype Clone()
    {
        Debug.Log("CLONING COLOR RGB: {0,3},{1,3},{2,3}", red, green, blue);

        return this.MemberwiseClone() as ColorPrototype;
    }
}

// This class creates a new object by asking a prototype to clone itself
class ColorManager
{
    private Dictionary<string, ColorPrototype> colors = new Dictionary<string, ColorPrototype>();

    // The indexer
    public ColorPrototype this[string key]
    {
        get { return colors[key]; }
        set { colors.Add(key, value); }
    }
}