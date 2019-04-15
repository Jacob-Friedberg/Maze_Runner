using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMusic : CSound
{
  public CMusic(AudioClip c) : base(c)
  {
  }

  public CMusic Add(CMusic music)
  {
    additionalSound = music;
    return this;
  }
}
