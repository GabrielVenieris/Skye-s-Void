using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Define a animação(fade-in e fade-out) 
Define o tempo da animação: AnimationTime
*/

public class SceneTransition : MonoBehaviour
{
    public int AnimationTime;
    public Animator transition;

    IEnumerator LevelTransition()
    {
        transition.SetTrigger("StartTransition");
        yield return new WaitForSeconds(AnimationTime);

    }

}

    