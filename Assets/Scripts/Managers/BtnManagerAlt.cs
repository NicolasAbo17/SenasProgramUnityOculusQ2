﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BtnManagerAlt : MonoBehaviour
{
    private Animator animator;

    // Control de activación 
    private bool _activated = false;
    private bool _touched = false;
    private Renderer rendererComp;

    public AudioClip soundDownEnabled;
    public AudioClip soundDownDisabled;

    public UnityEvent OnTouched;

    void Start()
    {
        animator = GetComponent<Animator>();
        rendererComp = GetComponent<Renderer>();
        _touched = false;
    }

    public void ActiveAnimation()
    {
        _activated = !_activated;
        animator.SetBool("pressed", _activated);

        if (_activated)
        {
            AudioSource.PlayClipAtPoint(soundDownEnabled, Vector3.zero, 5.0f);
            rendererComp.material.SetFloat("_Metallic", 0f);
        }
        else
        {
            AudioSource.PlayClipAtPoint(soundDownDisabled, Vector3.zero, 1.0f);
            rendererComp.material.SetFloat("_Metallic", 1f);
        }
    }

    public void Touched()
    {
        ActiveAnimation();
        OnTouched?.Invoke();
    }


    /** Este método sirve para detectar que se oprime el botón en VR
    /*  Puede usarse con la mano virtual, en este caso se usa un collider en el dedo índice, 
    /*  para detectar la colisión entre el botón y el dedo
    **/
    IEnumerator OnCollisionEnter(Collision collision)
    {
        if (!_touched)
        {
            _touched = true;
            Touched();
            yield return new WaitForSeconds(2f);
            _touched = false;
            ActiveAnimation();
        }
    }

    private void OnEnable()
    {
        _touched = false;
        _activated = false;
        animator = GetComponent<Animator>();
        animator.SetBool("pressed", _activated);
    }
}
