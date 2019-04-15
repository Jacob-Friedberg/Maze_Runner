using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public AudioSource MusicSource;

	public static SoundManager Instance = null;

	public Dictionary<string, CSound> sounds = new Dictionary<string, CSound>();

	private void LoadDefaults()
	{
		// Add standard damage sounds
		AddSoundFromFile("Hit&Damage1", "Attack Jump & Hit Damage Human Sounds/Hit & Damage 1");
		AddSoundFromFile("Hit&Damage2", "Attack Jump & Hit Damage Human Sounds/Hit & Damage 2");
		AddSoundFromFile("Hit&Damage3", "Attack Jump & Hit Damage Human Sounds/Hit & Damage 3");
		AddSoundFromFile("Hit&Damage4", "Attack Jump & Hit Damage Human Sounds/Hit & Damage 4");
		AddSoundFromFile("Hit&Damage5", "Attack Jump & Hit Damage Human Sounds/Hit & Damage 5");
		AddSoundFromFile("Hit&Damage6", "Attack Jump & Hit Damage Human Sounds/Hit & Damage 6");
		AddSoundFromFile("Hit&Damage7", "Attack Jump & Hit Damage Human Sounds/Hit & Damage 7");
		AddSoundFromFile("Hit&Damage8", "Attack Jump & Hit Damage Human Sounds/Hit & Damage 8");
		AddSoundFromFile("Hit&Damage9", "Attack Jump & Hit Damage Human Sounds/Hit & Damage 9");
		AddSoundFromFile("Hit&Damage10", "Attack Jump & Hit Damage Human Sounds/Hit & Damage 10");
		AddSoundFromFile("Hit&Damage11", "Attack Jump & Hit Damage Human Sounds/Hit & Damage 11");


		// Add decorator test sound
		string path = "Attack Jump & Hit Damage Human Sounds/Hit & Damage 11";
		CSound s = GetSoundFromFile(path).Add(GetSoundFromFile(path).Add(GetSoundFromFile(path).Add(GetSoundFromFile(path))));
		sounds.Add("dectest", s);

		// Add music
		CMusic music = GetMusicFromFile("marching_dream/Loop & Music Free/Music/Music Ambient003(Mach022)");
		sounds.Add("music", music);

	}

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad (gameObject);

		Instance.LoadDefaults();
		Instance.PlayMusic();
	}

	public void PlayMusic()
	{
		MusicSource.loop = true;
		Play(Instance.MusicSource, "music");
	}

	public void Play(AudioSource source, string name)
	{
		Debug.Log("Playing sound: " + name);
		Play(source, sounds[name]);
	}

	public void Play(AudioSource source, CSound sound)
	{
		StartCoroutine(sound.Play(source));
	}

	public CSound GetSound(string name)
	{
		return sounds[name];
	}

	public CSound GetSoundFromFile(string path)
	{
		return new CSound(Resources.Load<AudioClip>(path));
	}

	public CMusic GetMusicFromFile(string path)
	{
		return new CMusic(Resources.Load<AudioClip>(path));
	}

	public void AddSoundFromFile(string name, string path)
	{
		sounds.Add(
			name,
			GetSoundFromFile(path)
		);
	}


}
