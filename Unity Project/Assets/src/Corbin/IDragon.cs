/* BaseDragons.cs
Corbin
This script implements the "Product" interface for the Fatory Design Pattern
by defining the specific interface methods that the "Concrete Products"
(ie the specific dragons) will be controlled by */

using System.Collections;
using UnityEngine;
public interface IDragon
{
    IEnumerator takeDamage();
    void spawn(int SceneID);
    IEnumerator behave();
    void addDragonSounds();
}