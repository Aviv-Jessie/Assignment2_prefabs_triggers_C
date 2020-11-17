using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeTheBall : MonoBehaviour {

    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag = "thrower";
    [Tooltip("key to press")]
    [SerializeField] protected KeyCode keyToPress;
    [Tooltip("position outside the camera")]
    [SerializeField] Vector3 positionOutsideTheCamera = new Vector3(-10,10,0);
 [Tooltip("sprite spawners with ball")]
    [SerializeField] Sprite spriteWithBall;
    [Tooltip("sprite spawners without ball")]
    [SerializeField] Sprite spriteWithOutBall;

    const float timeToWait = 0.0f;

    private void OnTriggerEnter2D(Collider2D other) {        
        var keyboardSpawnerComponent = other.GetComponent<KeyboardSpawner>();        
        var show = other.GetComponent<SpriteRenderer>();
        show.sprite = spriteWithBall;

        if (other.tag == triggeringTag) {           
            transform.position = positionOutsideTheCamera;                        
            if (keyboardSpawnerComponent) {
                keyboardSpawnerComponent.StartCoroutine(BallTemporarily(keyboardSpawnerComponent,show));
            }
        } else {
            Debug.Log("doesn't have KeyboardSpawner "+other.name);
        }
    }


    private IEnumerator BallTemporarily(KeyboardSpawner keyboardSpawnerComponent,SpriteRenderer show){
        keyboardSpawnerComponent.enabled = true;
        bool thrown = false;
        while (!thrown) {            
            if (Input.GetKeyDown(keyToPress)){
                thrown = true;
                keyboardSpawnerComponent.enabled = false;
                show.sprite = spriteWithOutBall;
            }
            yield return new WaitForSeconds(timeToWait);
        }     
    }
}