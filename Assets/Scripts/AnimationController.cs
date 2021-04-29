using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public UnityEvent animationEvent;

    private Animation animation;

    void Start() {
        animation = gameObject.GetComponent<Animation>();

    }

    public void fade() {
        animation.Play("OutFade");
    }

    public void unfade() {
        animation.Play("UnFading");
    }

    public void animationComplete() {
        animationEvent.Invoke();
    }
}
