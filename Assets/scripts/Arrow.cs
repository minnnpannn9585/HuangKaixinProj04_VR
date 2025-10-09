using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Arrow : MonoBehaviour
{
    public float speed = 10f;
    public Transform tip;
    private Rigidbody _rigidbody;
    private bool _inAir = false;
    private Vector3 _lastPosition = Vector3.zero;

    //public Text logText;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        PullInteraction.PullActionReleased += Release;

        Stop();
        //logText = GameObject.Find("logText").GetComponent<Text>();
    }

    private void OnDestroy()
    {
        PullInteraction.PullActionReleased -= Release;
    }

    private void Release(float value)
    {
        PullInteraction.PullActionReleased -= Release;
        gameObject.transform.SetParent(null);
        _inAir = true;
        SetPhysics(true);

        Vector3 force = transform.right * value * speed;

        //logText.text = $"Arrow Release: value={value}, speed={speed}, force={force}";
        _rigidbody.AddForce(force, ForceMode.Impulse);

        //StartCoroutine(RotateWithVelocity());
        
        _lastPosition = tip.position;
    }

    //private IEnumerator RotateWithVelocity()
    //{
    //    yield return new WaitForFixedUpdate();
    //    while (_inAir)
    //    {
    //        Quaternion newRotation = Quaternion.LookRotation(
    //            _rigidbody.velocity, transform.up );
    //        transform.rotation = newRotation;
    //        yield return null;
    //    }
    //}

    void FixedUpdate()
    {
        if (_rigidbody == null)
            return;
        if (_inAir)
        {
            //CheckCollision();
            _lastPosition = tip.position;
        }
    }
    
    void CheckCollision()
    {
        if (_rigidbody == null)
            return;
        if (Physics.Linecast(_lastPosition, tip.position, out RaycastHit hitInfo))
        {
            // Fix: Compare layer as int, not string
            // You probably want to compare to a specific layer index, e.g., LayerMask.NameToLayer("Body")
            int bodyLayer = LayerMask.NameToLayer("Body");
            if (hitInfo.transform.gameObject.layer != bodyLayer && hitInfo.transform.gameObject.layer != 14)
            {
                if (hitInfo.transform.TryGetComponent(out Rigidbody body))
                {
                    //logText.text = hitInfo.transform.name;
                    _rigidbody.interpolation = RigidbodyInterpolation.None;
                    transform.parent = hitInfo.transform;
                    body.AddForce(_rigidbody.velocity, ForceMode.Impulse);
                }
                Stop();
            }
            else
            {
                return;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Environment"))
        {
            Destroy(gameObject);
        }

    }

    void Stop()
    {
        if(_rigidbody == null)
            return;
        _inAir = false;
        SetPhysics(false);
        //transform.GetChild(1).GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 2f);
    }

    void SetPhysics(bool usePhysics)
    {
        if (_rigidbody == null)
            return;
        _rigidbody.isKinematic = !usePhysics;
        _rigidbody.useGravity = usePhysics;
    }
}
