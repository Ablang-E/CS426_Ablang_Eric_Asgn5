using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public GameObject door;
    public AudioSource _source;
    public AudioClip clip;

    void Start()
    {
        //monitor = monitor.GetComponent<GameObject>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.SetActive(false);
            _source.PlayOneShot(clip);
        }
    }
}
