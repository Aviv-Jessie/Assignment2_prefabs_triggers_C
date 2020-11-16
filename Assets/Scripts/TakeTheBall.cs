using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeTheBall : MonoBehaviour {

    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag = "thrower";
    [Tooltip("key to press")]
    [SerializeField] protected KeyCode keyToPress;

    const float timeToWait = 0.0f;

    private void OnTriggerEnter2D(Collider2D other) {
        var keyboardSpawnerComponent = other.GetComponent<KeyboardSpawner>();
        var showBall = this.GetComponent<SpriteRenderer>();
        if (other.tag == triggeringTag) {           
            showBall.enabled = false;
            if (keyboardSpawnerComponent) {
                keyboardSpawnerComponent.StartCoroutine(BallTemporarily(keyboardSpawnerComponent, showBall));
            }
        } else {
            Debug.Log("doesn't have KeyboardSpawner "+other.name);
        }
    }


    private IEnumerator BallTemporarily(KeyboardSpawner keyboardSpawnerComponent, SpriteRenderer showBall){
        keyboardSpawnerComponent.enabled = true;
        bool thrown = false;
        while (!thrown) {
            showBall.enabled = true;
            if (Input.GetKeyDown(keyToPress)){
                thrown = true;
                keyboardSpawnerComponent.enabled = false;
            }
            yield return new WaitForSeconds(timeToWait);
        }     
    }
}