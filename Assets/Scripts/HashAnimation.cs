using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashAnimation : MonoBehaviour
{
    public readonly int Speed = Animator.StringToHash("Speed");
    public readonly int Jump = Animator.StringToHash("Jump");
    public readonly int Push = Animator.StringToHash("Push");
}
