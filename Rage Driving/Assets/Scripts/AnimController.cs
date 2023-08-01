using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    public AnimationClip animationClip;        
    public float minInterval = 5f;
    public float maxInterval = 10f;
    public float animationSpeed = 1f;

    private Animator animator;
    private Transform carTransform;

    private void Start()
    {

        animator = GetComponent<Animator>();
        carTransform = GameObject.FindGameObjectWithTag("Car").transform;

        PlayAnimRandomly();
    }

    public void PlayAnimRandomly()
    {
        // Calculate duration of anim based on its length and animationSpeed
        float animationDuration = animationClip.length / animationSpeed;

        // Randomly choose next interval
        float randomInterval = Random.Range(minInterval, maxInterval);

        // Play animation at the car's current position and rotation
        StartCoroutine(PlayAnimationAtCarPosition(animationDuration));

        // Calling again after specified interval
        Invoke("PlayRandomAnimation", randomInterval);
    }

    private System.Collections.IEnumerator PlayAnimationAtCarPosition(float animationDuration)
    {
        transform.position = carTransform.position;
        transform.rotation = carTransform.rotation;

        // Play animation
        animator.Play(animationClip.name);

        // Wait for animation to complete
        yield return new WaitForSeconds(animationDuration);

        // AnimationHolder is at car's position and rotation after animation
        transform.position = carTransform.position;
        transform.rotation = carTransform.rotation;
    }
}
