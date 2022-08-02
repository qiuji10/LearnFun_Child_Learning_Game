using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sound/CreateAudioData")]
public class AudioData : ScriptableObject
{
    public List<SoundFile> SoundList = new List<SoundFile>();
}

