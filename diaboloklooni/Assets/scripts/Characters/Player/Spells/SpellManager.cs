using UnityEngine;
using System.Collections;

public class SpellManager : MonoBehaviour
{
    
    public GameObject[] spells;
    GameObject Player;
     void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    public void CastSpell(int spell_ID)
    {
        spells[spell_ID].GetComponent<Animator>().SetTrigger("isActivated");
        switch (spell_ID)
        {
            case 0:
                Player.GetComponent<Fighter>().health += 50;
                break;
            default:
                Debug.Log("Spell not found:((");
                break;
        }
        
    }
}
