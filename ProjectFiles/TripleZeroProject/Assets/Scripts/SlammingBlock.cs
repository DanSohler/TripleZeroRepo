using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlammingBlock : MonoBehaviour
{
    Animator slamAnim;

    [SerializeField] float waitTime;
    [SerializeField] [Range (0, 1)] float animationOffset;

    private void Start()
    {
        slamAnim = GetComponent<Animator>();
        slamAnim.SetFloat("WaitTime", 1 / waitTime);
        slamAnim.Play("WaitTime", -1, animationOffset);
    }
}
