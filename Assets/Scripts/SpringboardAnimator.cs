using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HashAnimation))]
[RequireComponent(typeof(SpringboardTriggerHandler))]
public class SpringboardAnimator : MonoBehaviour
{
    private HashAnimation _hashAnimation;

    private Animator _animator;
    private SpringboardTriggerHandler _springboardPush;

    private void OnEnable()
    {
        _springboardPush.PlayerEntered += OnPlayerEntered;
    }

    private void OnDisable()
    {
        _springboardPush.PlayerEntered -= OnPlayerEntered;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _springboardPush = GetComponent<SpringboardTriggerHandler>();
        _hashAnimation = GetComponent<HashAnimation>();
    }

    private void OnPlayerEntered()
    {
        _animator.SetTrigger(_hashAnimation.Push);
    }
}
