using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEmitter : MonoBehaviour
{
    public bool _triggered = false;
    public float soundRange = 10;

    private void OnCollisionEnter(Collision collision)
    {
        var sound = new Sound(transform.position, soundRange);
        Debug.Log("Emitting sound");
        Sounds.MakeSound(sound);
    }
}
