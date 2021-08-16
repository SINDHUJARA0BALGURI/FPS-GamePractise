using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public bool damageEnemy, damagePlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && damageEnemy)
        {
            //Destroy(this.gameObject);
            other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(2);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Player" && damagePlayer)
        {
            Debug.Log("Player got hit");
            PlayerHealthcontroll.instance.DamagePlayer(1);
        }

    }

}