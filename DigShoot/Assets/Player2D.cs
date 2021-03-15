using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    public Animator playerAnim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Anvil>()) {
            playerAnim.SetTrigger("Dead");
            GameController.instance.LevelFailed();
        }        
    }
}
