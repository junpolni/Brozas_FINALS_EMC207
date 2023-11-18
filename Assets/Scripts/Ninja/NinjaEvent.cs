using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaEvent : MonoBehaviour
{
    AiBehaviour newAiBehaviour;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        newAiBehaviour = GetComponentInParent<AiBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SlashSword()
    {
        GameObject slashFX = Instantiate(newAiBehaviour.Slash, newAiBehaviour.slashFX.position, newAiBehaviour.slashFX.rotation);
        VFXDamage vFXDamage = slashFX.GetComponent<VFXDamage>();
        vFXDamage.StartVFX(newAiBehaviour.tag);
        Rigidbody slashRigidbody = slashFX.AddComponent<Rigidbody>();
        slashRigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}
