using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXDamage : MonoBehaviour
{
    public string currentTeam;
    public bool isTriggered = false;

    public void StartVFX(string team)
    {
        currentTeam = team;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered)
        {
            return;
        }
        string team = string.Empty; 

        if (currentTeam == "Team1")
        {
            team = "Team1";
        }
        else if (currentTeam == "Team2")
        {
            team = "Team2";
        }

        if (other.gameObject.CompareTag(team))
        {
            var ai = other.gameObject.GetComponent<AiBehaviour>();
            if (ai.tag != currentTeam)
            {
                ai.health -= ai.damage;
                Debug.Log("test hit");
                isTriggered = true;
                
                if(ai.health <= 0)
                {
                    var animator = ai.animator;
                    //var isDead = animator.GetBool("isDead");
                    var isDead = ai.isDead;
                    if (isDead == false) 
                    {
                        //animator.SetBool("isDead", true);
                        //ai.col.enabled = false;
                        //Debug.Log("ai dead");
                        //ai.isDead = true;
                        //ai.enabled = false;
                        Destroy(ai.gameObject);
                    }
                   
                }
                //Destroy(this.gameObject);
            }
        }
    }
}
