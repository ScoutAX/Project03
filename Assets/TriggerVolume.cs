using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent()]
[RequireComponent(typeof(Collider))]
public class TriggerVolume : MonoBehaviour
{
    public UnityEvent OnEnterTrigger;

    private Collider _collider;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    [Header("Gizmo Settings")]
    [SerializeField]
    private bool _displayGizmos = false;
    [SerializeField]
    private bool _showOnlyWhileSelected = true;
    [SerializeField]
    private Color _gizmoColor = Color.green;


    private void OnTriggerEnter(Collider other)
    {
        OnEnterTrigger.Invoke();
    }

    private void OnDrawGizmos()
    {
        if(_displayGizmos == false)
        {
            return;
        }
        if(_showOnlyWhileSelected == true)
        {
            return;
        }

        if(_collider == null)
        {
            _collider = GetComponent<Collider>();
        }
        Gizmos.color = _gizmoColor;
        Gizmos.DrawCube(transform.position, _collider.bounds.size);
    }

    private void OnDrawGizmosSelected()
    {
        if (_displayGizmos == false)
        {
            return;
        }
        if (_showOnlyWhileSelected == false)
        {
            return;
        }

        if (_collider == null)
        {
            _collider = GetComponent<Collider>();
        }
        Gizmos.color = _gizmoColor;
        Gizmos.DrawCube(transform.position, _collider.bounds.size);
    }
    
    
    //public void triggerActive()
    //{
    //   gameObject.SetActive(true);
    //}
}
