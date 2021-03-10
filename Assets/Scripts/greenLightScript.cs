using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenLightScript : MonoBehaviour
{
    public bool flickering = false;
    public bool activated = false;
    public float delay;
    private IEnumerator coroutine;
    public Light myLight;
    public AudioSource _source;
    public AudioSource source2;
    public AudioClip clip;
    public AudioClip clip2;

    void Update()
    {
        myLight = myLight.GetComponent<Light>();

        if (flickering == false)
        {
            coroutine = flick();
            StartCoroutine(coroutine);
        }

        if (activated == true)
        {
            StopCoroutine(coroutine);
            myLight.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activated = true;
            source2.PlayOneShot(clip2);
        }
    }

    private IEnumerator flick()
    {
        flickering = true;
        myLight.enabled = false;
        delay = Random.Range(0.01f, 1.5f);
        yield return new WaitForSeconds(delay);
        myLight.enabled = true;
        _source.PlayOneShot(clip);
        delay = Random.Range(0.01f, 1.5f);
        yield return new WaitForSeconds(delay);
        flickering = false;
    }
}
