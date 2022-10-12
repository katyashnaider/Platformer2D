using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpringboardTriggerHandler : MonoBehaviour
{
    public event Action PlayerEntered;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Player _))
            PlayerEntered?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Player _))
            PlayerEntered?.Invoke();
    }
}
