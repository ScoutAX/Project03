using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points;
    int current;
    public float speed;

    [Header("Trigger Settings")]
    [SerializeField]
    private bool _triggerOn = false;
    [SerializeField]
    public GameObject _triggerVolume;

    public void Start()
    {
        current = 0;
    }

    public void Update()
    {
        if(_triggerOn == false)
        {
            movePlatform();
        }
        if(_triggerOn == true)
        {
            _triggerVolume.SetActive(true);
            return;
        }
    }

    public void movePlatform()
    {
        if (transform.position != points[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime);
        }
        else
            current = (current + 1) % points.Length;
    }

    public void setFalse()
    {
        _triggerOn = false;
    }
}
