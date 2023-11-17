using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    AiBehaviour newAiBehaviour;
    public float speed;

    private void Start()
    {
        newAiBehaviour = GetComponent<AiBehaviour>();
    }
    public void SpawnSlash()
    {
        GameObject slashFX = Instantiate(newAiBehaviour.Arrow, newAiBehaviour.spawnArcherFX.position, newAiBehaviour.spawnArcherFX.rotation);
        Rigidbody slashRigidbody = slashFX.AddComponent<Rigidbody>();
        slashRigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);

    }
}
