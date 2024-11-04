using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioClip[] footstepclips;
    private AudioSource audioSource;
    private Rigidbody _rigidbody;
    public float footstepThreshold;
    public float footstepRate;
    private float footstepTime;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Mathf.Abs(_rigidbody.velocity.y) < 0.1f)
        {
            if (_rigidbody.velocity.magnitude > footstepThreshold)
            {
                if (Time.time - footstepTime > footstepRate)
                {
                    footstepTime = Time.time;

                    audioSource.PlayOneShot(footstepclips[Random.Range(0, footstepclips.Length)]);
                }
            }
        }
    }
}
