/* BaseDragons.cs
Corbin
This script implements the "Product" interface for the Fatory Design Pattern
by defining the specific interface methods that the "Concrete Products"
(ie the specific dragons) will be controlled by */

using System.Collections;
using UnityEngine;
public interface IDragon
{
    // Tells a specific instance of an class implementing
    // the IDragon interface to take damage.
    IEnumerator takeDamage();
    // Spawns a specific instance of an enemy that is controled 
    // by a class implementing the IDragon interface.
    void spawn();
    // Tells an enemy that is controlled by a class that
    // is implementing the IDragon interface to start its
    // routine of behavior
    IEnumerator behave();
    // Used by a instance of an IDragon object to add 
    // sounds for dragons to the Sound Manager 
    void addDragonSounds();
}