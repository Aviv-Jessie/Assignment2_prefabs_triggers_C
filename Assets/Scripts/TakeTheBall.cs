using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeTheBall : MonoBehaviour {

    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag = "thrower";
    [Tooltip("key to press")]
    [SerializeField] protected KeyCode keyToPress;

    const float timeToWait = 0.1f;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag) {           
            var keyboardSpawnerComponent = other.GetComponent<KeyboardSpawner>();
            if (keyboardSpawnerComponent) {
                keyboardSpawnerComponent.StartCoroutine(ShieldTemporarily(keyboardSpawnerComponent));
            }
        } else {
            Debug.Log("doesn't have KeyboardSpawner "+other.name);
        }
    }
    private IEnumerator ShieldTemporarily(KeyboardSpawner keyboardSpawnerComponent) {
        keyboardSpawnerComponent.enabled = true;
        bool thrown = false;
        while (!thrown) {            
            if(Input.GetKeyDown(keyToPress))
                thrown = true;
            yield return new WaitForSeconds(timeToWait);
        }     
        keyboardSpawnerComponent.enabled = false;
    }
}