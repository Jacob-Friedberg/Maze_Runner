using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSound
{

  protected AudioClip clip;

  protected CSound additionalSound;

  public CSound(AudioClip c)
  {
    clip = c;
  }

  public CSound Add(AudioClip clip)
  {
    return Add(new CSound(clip));
  }

  public CSound Add(CSound sound)
  {
    additionalSound = sound;
    return this;
  }

  public IEnumerator Play(AudioSource source)
  {
    yield return null;

    source.clip = clip;

    source.Play();
    while(source.isPlaying)
    {
      yield return null;
    }
    if (additionalSound != null)
    {
      SoundManager.Instance.Play(source, additionalSound);
    }
  }

}
