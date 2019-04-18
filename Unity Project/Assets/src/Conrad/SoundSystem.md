# Maze Runner Sound System
While Unity provides many features for managing sound, programmers may find that the time required for integrating this framework into an existing project to be rather tedious. This sound system is designed to be fairly portable, extensible, and easy to integrate on every level of your project.

## Sound in Unity
There are a couple of important components that the programmer needs to be aware of before starting. In Unity, there are a minimum of 3 objects needed for sound. An AudioListener, an AudioSource, and an AudioClip. The idea is that anything that needs to emit sound has an AudioSource component attached to it. The AudioSource is responsible for playing one sound at a time, and is primarly controlled through the scripting system. Because of this, every audio-responsive game object needs code to control when and how they emit sound.

Another important condition to note is that Unity only permits *one AudioListener at a time* to exist in the scene. We recommend that this AudioListener be attached to your player object, but we haven't seen any specific reason not to.

As will be described in the following section, this Sound System simplifies some of the implementation specific details related to sound.

## General Overview
There are two primary components (and one example extension) included. The _SoundManager_, and the _CSound_ classes. You may also find the _CMusic_ class, which serves as an extension to _CSound_.

## Getting Started
### Setting up the Manager
1. Create a new empty GameObject called `SoundManager`
2. Add the SoundManager script
3. Add an AudioSource to the `SoundManager` object
4. Add the AudioSource to the MusicSource variable

### Adding Sounds
The programmer can either add sounds to the startup up method of the SoundManager script, or add sounds *anywhere* during runtime.
Example:

```csharp
AddSoundFromFile("myCoolSound", "folder/mySoundFile");
```
- Do not include file extensions in this path.
- Files are searched for within the `Asstes/Resources` folder

### Playing Sounds
Make sure that the object about to play sound has an `AudioSource` attached to it. Within your local object controller script, you can play added sounds with the following code:
```csharp
// You may have already defined a hook for you AudioSource
// Please change this code to best suite your environment
AudioSource source = GetComponent<AudioSource>();
SoundManager.Instance.Play(source, "myCoolSound");
```

----------------------------------------------------------
# Class Descriptions

## SoundManager
The _SoundManager_ is built to handle the loading of new audio resources, and provides a *static* interface for calling upon these resources. The _SoundManager_ provides the following public methods.
```csharp
void PlayMusic();
void Play(AudioSource, string);
void Play(AudioSource, CSound);
CSound GetSound(string);
CSound GetSoundFromFile(string);
CMusic GetMusicFromFile(string);
void AddSoundFromFile(string, string);
```
### `PlayMusic()`
Starts and loops the sound saved as `"music"`
The same as `Play(Instance.MusicSource, "music");`

### `Play(AudioSource, string)`
Plays the sound saved under the name provided using a specific AudioSource

### `Play(AudioSource, CSound)`
Plays the specific _CSound_ using the specified AudioSource

*This method operates as expected, but is not recommended*

### `GetSound(string)`
Returns the _CSound_ saved under the string provided

### `GetSoundFromFile(string)`
Loads a file from the `Assets/Resources/` folder, and returns the appropriate _CSound_

### `GetMusicFromFile(string)`
Works the same way as `GetSoundFromFile(string)`

### `AddSoundFromFile(string, string)`
Loads a file from the `Assets/Resources/` folder and adds it to the _SoundManager_'s local memory for static access.

## CSound
The _CSound_ class is a simple wrapped for AudioClips that provides extra functionality for decorated sounds. See the documentation for `Add(AudioClip)` to see how decorating / chaining works.

```csharp
CSound(AudioClip);
CSound Add(AudioClip);
CSound Add(CSound);
IEnumerator Play(AudioSource);
```

### `CSound(AudioClip)`
The constructor that instantiates the _CSound_ with the desired AudioClip.

### `Add(AudioClip)`
This virtual method allows the programmer to add additional AudioClips to the existing sound

### `Add(CSound)`
Directly inserts the next CSound, is called by `Add(AudioClip)`

### `Play(AudioSource)`
It is recommended that the programmer calls this function inside a coroutine, otherwise expect undetermined behavior. Example:
```csharp
StartCoroutine(Play(GetComponent<AudioSource>));
```
This *must* be called within the scope of a `MonoBehaviour`, or else the namespace for the call will not be found.
