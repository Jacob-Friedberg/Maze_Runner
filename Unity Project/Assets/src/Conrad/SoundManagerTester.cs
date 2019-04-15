using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerTester : MonoBehaviour
{

  private AudioSource source;

  public bool toggle = false;

  void Start()
  {
    source = GetComponent<AudioSource>();
  }

  public void Hit()
  {
    for(int i = 0; i < 100; i++){
      SoundManager.Instance.Play(source, "Hit&Damage1");
    }
  }

  public void DecTest()
  {
    SoundManager.Instance.Play(source, "dectest");
  }

}
