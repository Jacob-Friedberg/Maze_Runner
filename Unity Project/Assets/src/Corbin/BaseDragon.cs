/* BaseDragons.cs
Corbin
This script implements the "Product" interface for the Fatory Design Pattern
by defining an abstract class called BaseDragon that inherits from MonoBehavior
and implements the interface IDragon. The "Concrete Products" are the specific
dragon classes are subclasses of BaseDragon. Most of the the IDragon methods are 
virtual so that each subclass of BaseDragon can implemnet their own IDragon methods. 
Other methods and variables that each subclass of BaseDragon uses are declared and/or
defined here */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public abstract class BaseDragon : MonoBehaviour, IDragon
{
    // Variable declarations/defintions
    protected int health = 100;
    protected float attackDistance = 4.5f;
    protected DragonTypes type;
    protected GameObject dragonObject;
    protected NavMeshAgent agent;
    protected GameObject playerTarget;
    protected GameObject dragonHeadObject;
    protected AudioSource audioSourceComponent;
    static private bool areSoundsAdded = false;

    
    //          Method Definitions

    // IDragon Method Implementations

    // Loop of behavior for dragon until dragon dies.
    public IEnumerator behave(){
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(0.5f);
        while (health > 0)
        {
            StartCoroutine(ambientDragonSounds());
            yield return move();
        }
        SoundManager.Instance.Play(audioSourceComponent, "mob1die.wav");
        dragonObject.GetComponent<Animator>().Play("Dead_G", 0, 0f);
        yield return despawnDelay();
        dragonObject.SetActive(false);
    }

    // Virtual methods that allow abstract class to adhere to 
    // IDragon interface and defer implementation to subclasses.
    public virtual IEnumerator takeDamage(){
        yield break;
    }
    public virtual void spawn(int SceneID){}
    public void addDragonSounds(){
        if(areSoundsAdded == false){
            SoundManager.Instance.AddSoundFromFile("mob1.wav", "Monster SFX - 111518/monster/highlevel/mob1");
            SoundManager.Instance.AddSoundFromFile("mob1atk.wav", "Monster SFX - 111518/monster/highlevel/mob1atk");
            SoundManager.Instance.AddSoundFromFile("mob1die.wav", "Monster SFX - 111518/monster/highlevel/mob1die");
            areSoundsAdded = true;
        }
        
    }

    // Non-IDragon methods


    // Causes a dragon to start random attack animation.
    public void attack(){
        SoundManager.Instance.Play(audioSourceComponent, "mob1atk.wav");
        switch ((int)Random.Range(0.0f, 2.99f))
        {
            case 0:
            dragonObject.GetComponent<Animator>().Play("Atk_Claw_DBL", 0, 0f);
            break;
            case 1:
            dragonObject.GetComponent<Animator>().Play("Atk_Claw_L", 0, 0f);
            break;
            case 2:
            dragonObject.GetComponent<Animator>().Play("Atk_Claw_R", 0, 0f);
            break;
            default:
            break;
        }
    }

    // Controls the movement of a dragon and calls attack() when within specified
    // distance to player.
    public IEnumerator move()
    {
        if(Vector3.Distance(agent.transform.position, playerTarget.transform.position) > attackDistance 
        || agent.hasPath == false){
            agent.isStopped = false;
            agent.SetDestination(playerTarget.transform.position);
            yield return new WaitForSecondsRealtime(0.75f);
        }
        else {
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
            attack();
            yield return finishAttackAnimationDelay();
        }
    }

    // Allows dragon to lay dead on ground before despawning
    // after 5 seconds.
    public IEnumerator despawnDelay(){
        yield return new WaitForSecondsRealtime(5);
    }

    // Allows dragon to have a damage grace periods 
    // immeadiatly after taking damage.
    public IEnumerator damageBufferDelay(){
        yield return new WaitForSecondsRealtime(1);
    }

    // Allows dragon to finish its attack animation
    // before attack() is called again.
    public IEnumerator finishAttackAnimationDelay(){
        yield return new WaitForSecondsRealtime(1);
    }
    public IEnumerator ambientDragonSounds(){

        yield return new WaitForSecondsRealtime(Random.Range(10.0f, 20.0f));
        SoundManager.Instance.Play(audioSourceComponent, "mob1.wav");
    }
       
}