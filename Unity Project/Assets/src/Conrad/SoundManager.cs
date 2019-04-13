using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public AudioSource EffectsSource;
	public AudioSource MusicSource;

	public static SoundManager Instance = null;

  public AudioClip[] audioClips;

	public AudioClip music;

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
		Instance.PlayMusic(music);
	}

	public IEnumerator Play(AudioClip clip)
	{
		Instance.EffectsSource.clip = clip;
		Instance.EffectsSource.Play();
		yield return new WaitWhile(()=>EffectsSource.isPlaying);
	}

	public void PlayMusic(AudioClip clip)
	{
		Instance.MusicSource.clip = clip;
		Instance.MusicSource.Play();
	}

	public void RandomSoundEffect(params AudioClip[] clips)
	{
		int randomIndex = Random.Range(0, clips.Length);
		StartCoroutine(Instance.Play(clips[randomIndex]));
	}

}
