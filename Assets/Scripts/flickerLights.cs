using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickerLights : MonoBehaviour
{
    public bool flickering = false;
    public float delay;
    private IEnumerator coroutine;
    public Light myLight;
    public AudioSource _source;
    public AudioClip clip;

    // Update is called once per frame
    void Update()
    {
        myLight = myLight.GetComponent<Light>();

        if (flickering == false)
        {
            coroutine = flick();
            StartCoroutine(coroutine);
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
