using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound
{
    public enum SoundType { Default = -1, Interesting };

    public Sound(Vector3 _pos, float _range, SoundType _type = SoundType.Default)
    {
        soundType = _type;
        pos = _pos;
        range = _range;
    }

    public readonly SoundType soundType;
    public readonly Vector3 pos;
    public readonly float range;
}
