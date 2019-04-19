using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class ImageHandler : MonoBehaviour
{
    // The speed the damageImage will fade-out at.
    public float flashSpeed = 5f;

    // Makes a GameObject called damageOverlay.
    public GameObject damageOverlay;

    // Reference to an image that flashes on the screen when the player takes damage.
    public Image damageImage;

    // A static singleton property is used here as having more than one instance of these, might cause some very incorrect behavior.
    // This pattern ensure a class has only one instance and provide a global point of access to it.
    public static ImageHandler Instance { get; private set; }

    // The managing of colors below demonstrates the Prototype pattern in which new Color objects are created by copying pre-existing, selected Colors of the same type.
    // This pattern lets the programmer specify the kind of objects to create using a prototypical instance, and create new objects by copying this prototype. 
    ColorManager colormanager = new ColorManager();

    void Start()
    {
        //Activate Image
        damageOverlay.SetActive(true);

        // Initialize with standard colors
        colormanager["red"] = new Colors(255, 0, 0);
        colormanager["green"] = new Colors(0, 255, 0);
        colormanager["blue"] = new Colors(0, 0, 255);
        colormanager["black"] = new Colors(0, 0, 0);
        colormanager["white"] = new Colors(255, 255, 255);

        // Clones selected colors
        Colors red = colormanager["red"].Clone() as Colors;
        Colors black = colormanager["black"].Clone() as Colors;

        // Save a reference to the ImageHandler component as the singleton instance.
        // Defines an Instance operation that lets clients access its unique instance.Instance is a class operation.
        // Responsible for creating and maintaining its own unique instance.
        Instance = this;
    }

    // Instance method, this method can be accesed through the singleton instance.
    public void ImageColor(Color color)
    {
        // Set the damageImage color
        damageImage.color = color;

        // Transition the color back to clear.
        damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
    }
}

// This abstract class declares an interface for cloning itself.
abstract class ColorPrototype
{
    public abstract ColorPrototype Clone();
}

// This class implements an operation for cloning itself.
class Colors : ColorPrototype
{
    private int red;
    private int green;
    private int blue;

    // This is the Colors constructor.
    public Colors(int red, int green, int blue)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
    }

    // Creates a shallow copy. This is also an example of the use of override.
    public override ColorPrototype Clone()
    {
        return this.MemberwiseClone() as ColorPrototype;
    }
}

// This class creates a new object by asking a prototype to clone itself.
class ColorManager
{
    private Dictionary<string, ColorPrototype> colors = new Dictionary<string, ColorPrototype>();

    // The indexer.
    public ColorPrototype this[string key]
    {
        get { return colors[key]; }
        set { colors.Add(key, value); }
    }
}