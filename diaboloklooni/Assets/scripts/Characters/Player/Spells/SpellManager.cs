using UnityEngine;
using System.Collections;

public class SpellManager : MonoBehaviour
{
    
    public GameObject[] spells;
    public bool spellIsActive;
    GameObject Player;


     void Start()
    {
        spellIsActive = false;
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    public void CastSpell(int spell_ID)
    {
        if (!spellIsActive)
        {
            spellIsActive = true;
            spells[spell_ID].GetComponent<Animator>().SetTrigger("isActivated");
           

            //Iha vitun kamala purkkateippi viritys 
            //Teen joskus paremman tilalle:D
            switch (spell_ID)
            {
                case 0:
                    StartCoroutine(WaitThenSpell(2f, spell_ID));

                    break;
                default:
                    Debug.Log("Spell not found:((");
                    break;
            }
        }
        else
        {
            Debug.Log("SPELL IS ACTIVE :DD");
        }
        
    }
    private IEnumerator WaitThenSpell(float time, int id)
    {
        yield return new WaitForSeconds(time);
        spellIsActive = false;
        Debug.Log("Animation end");
        switch (id)
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
