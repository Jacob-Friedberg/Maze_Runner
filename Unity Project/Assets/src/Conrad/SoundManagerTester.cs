using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManagerTester : MonoBehaviour
{
    public void StartTest()
    {
      for(int i = 0; i < SoundManager.Instance.audioClips.Length; i++){
        Debug.Log("Playing Clip " + i);
        SoundManager.Instance.Play(SoundManager.Instance.audioClips[i]);
      }
    }
}
