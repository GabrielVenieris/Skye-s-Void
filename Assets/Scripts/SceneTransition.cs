// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// /*
// Define a animação(fade-in e fade-out) 
// Define o tempo da animação: AnimationTime
// */

// public class SceneTransition : MonoBehaviour
// {
//     private float fadeInterval = 1f;
//     private Animator sceneFaderAnimator;

//     private void Start()
//     {
//         // sceneFaderAnimator = GetComponent<Animator>();
//     }

//     public void FadeToScene(string sceneName)
//     {
//         StartCoroutine(Transition(sceneName));
//     }

//     public IEnumerator Transition(string sceneName)
//     {
//         sceneFaderAnimator = GetComponent<Animator>();
//         sceneFaderAnimator.SetTrigger("FadeTrigger"); 
//         Debug.Log("Aconteceu o fade");

//         yield return new WaitForSeconds(fadeInterval);

//         SceneManager.LoadScene(sceneName);
//     }
// }


    