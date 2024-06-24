using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelController : MonoBehaviour
{
    public Camera camera;
    private float camDistance;

    public Slider slider;

    private Transform intialTransform;

    public Material transperantMaterial;
    public Material opaqueMaterial;

    public List<MeshRenderer> renderers;

    public Animator animator;
    private void Awake()
    {
        camera = Camera.main;
        intialTransform = this.transform;
        animator = this.gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        camDistance= slider.value;
        camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, camDistance);

        
    }

    public void RotateLeft()
    {
        transform.Rotate(Vector3.up, -90 * Time.deltaTime);
    }

    public void RotateRight()
    {
        transform.Rotate(Vector3.up, 90 * Time.deltaTime);
    }

    public void ReturnToInitial()
    {
        transform.position = intialTransform.position;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }


    public void Vanish()
    {
        foreach(var render in renderers)
        {
            render.material = transperantMaterial;
        }
    }

    public void Opaque()
    {
        foreach (var render in renderers)
        {
            render.material = opaqueMaterial;
        }
    }


    public void ExplodedView()
    {
        animator.Play("ExplodedView");
    }

    public void NormalView()
    {
        animator.Play("NormalView");
    }

}
