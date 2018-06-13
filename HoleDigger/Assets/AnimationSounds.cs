using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSounds : MonoBehaviour {

    public List<AudioClip> ShovelSounds;
    public Vector2 PitchRange;

    private AudioSource mySource;

    void Start()
    {
        mySource = GetComponent<AudioSource>();
    }

    public void PlayDigSound()
    {
        mySource.clip = ShovelSounds[Random.Range(0, ShovelSounds.Count - 1)];
        mySource.pitch = Random.Range(PitchRange.x, PitchRange.y);
        mySource.Play();
    }
}
