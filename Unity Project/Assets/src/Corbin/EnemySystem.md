# Maze Runner Enemy System 
In Unity, creating and managing enemies in a combat game can be a headache. The enemy management system in Maze Runner was made with ease of use in mind so that newcomers to combat games can easily port over this system into their game with few modifications.

## Enemies in Unity
There are a couple of important concepts that the programmer needs to be aware of before starting. In Unity, for ground based enemies to move about a scene, their needs to be a single *Nav Mesh Surface* component script in the scene attached to some peristant game object. This generates the areas in which navmesh agent can traverse to in the scene. Speaking of navmesh agents, any enemy game object must have a single *Nav Mesh Agent* component attached to it. This is because a Nav Mesh can have a different surfaces (ie different areas able to be traversed to) for different Nav Mesh Agent types. The settings for the Nav Mesh Surface and for the surface's Nav Mesh Agents are able to be edited within the settings for the *Nav Mesh Surface* component.Once there is a game object in the scene with a *Nav Mesh Surface* component and the setting of that surface's agent has been set to your liking, the *Nav Mesh Surface* component's bake command must be activated, either on the component itself or via a script.


Finally there should be some sort of script that manages the enemies behavior and properties. This would control when and where the enemy is spawned, how much health an ememy has, what causes the enemy to take damage, where the enemy moves to using the Nav Mesh, how it attacks... etc. 

This Enemy System simplifies alot of the implementation specific details related to the management of enemies and provides an easy interface for working with the dragon enemies. 

## General Overview
There are 2 principle components to be able to interface with our enemies included. Those are the *IDragon* interface and the *DragonSpawner.cs* script.

## Getting Started
### Setting up the Enemy Spawner
1. Create a new empty GameObject called `DragonSpawner`.
2. Add the DragonSpawner script to the game object.
3. Add an Nav Mesh Surface component to the `DragonSpawner` object.
4. Add the Nav Mesh Surface component to the Surface variable in the DragonSpawner script.
5. Add the GrundleController script to the `DragonSpawner` object
6. Add the Grundle prefab to the Dragon Prefab variable in the GrundleController scirpt.
7. Repeat steps 5 and 6 for YorgleController and RhindleController scripts and Yorgle and Rhindle prefabs repectively.
8. For each Controller script, select a location in the scene you want the dragons to spawn at by inputing the X, Y, and Z coordinates for that location. Make sure the spawn locations are right on top of the Nav Mesh Surface.
9. For the dragons to move to the player, ensure that their is some object in the scene labled `Target`.
10. For the dragons to play sounds, ensure there is a game object with the sound manager class setup on it. If you are unsure on how to do this checkout https://github.com/scouter238/Maze_Runner/blob/master/Unity%20Project/Assets/src/Conrad/SoundSystem.md


### Adding Enemies
The programmer can only add enemies to the scene before runtime by editing the DragonSpawner script.
Example:

```csharp
dragons.Add(dFactory.getDragon(DragonTypes.grundle);
```
- This function can be called as many times as one wants with a specific dragon type.
- After adding enemies, the DragonSpawner script will spawn all the enemies added and start their behvaior routines.

----------------------------------------------------------
# Class/Script Descriptions

## IDragon
The _IDragon_ interface is a simple interface that allows script's that contain an instance of a dragon enemy to access certain methods of that dragon enemy.
```csharp
IEnumerator takeDamage();
void spawn();
IEnumerator behave();
void addDragonSounds();
```
### `takeDamage()`
Tells a specific instance of an class implementing the IDragon interface to take damage.

### `spawn()`
Spawns a specific instance of an enemy that is controled by a class implementing the IDragon interface.

### `behave()`
Tells an enemy that is controlled by a class that is implementing the IDragon interface to start its routine of behavior.

### `addDragonSounds()`
Used by a instance of an IDragon object to add sounds for dragons to the Sound Manager.


## DragonSpawner
The _DragonSpawner_ class is the Creator part of a factory pattern that creates and spawns enemies.  

```csharp
Start();
```

### `Start()`
Once the scene is loaded, DragonSpawner calls on the Conrete Creator class (*DragonFactory*) to get specific enemies that implement the IDragon interface and adds them to a list of enemies. That list of enemies is then spawned and their behave method is called to start their behavior routine.

## DragonFacory
The _DragonFactory_ class is the Concrete Creator part of a factory pattern and is also a singleton. It is used to return specific IDragon enemies to the DragonSpawner class.  

```csharp
static DragonFactory getInstance();
IDragon getDragon(DragonTypes dragonType);
```

### `getInstance()`
Returns the singleton instance of DragonFactory

### `getDragon(DragonTypes dragonType)`
Returns a specific IDragon object which is found on the "DragonSpawner" game object based on an inputed DragonType.


## DragonTypes
_DragonTypes_ is an enumeration that helps for readability sake when requesting specific dragons from DragonFactory to DragonSpawner.