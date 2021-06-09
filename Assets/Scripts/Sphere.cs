using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Sphere : MonoBehaviour
{
    [SerializeField] private Material _redColor;
    [SerializeField] private Material _blackColor;
    [SerializeField] private float _speed;

    private const int WALL_LAYER_NUMBER = 6;
    private const int BLACK_SPHERE_LAYER_NUMBER = 8;
    private const int RED_SPHERE_LAYER_NUMBER = 7;
    private Rigidbody _rigidbody;

    public Action Death;
    
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        RandomlyChooseColor();
        ChangeSpeed(RandomlyMovingDirection());
    }
    private void FixedUpdate()
    {
        MoveForward();
    }
    private void ChangeSpeed(Vector3 direction)
    {
        _rigidbody.velocity = direction * _speed;
    }
    private void MoveForward()
    {
        _rigidbody.AddForce(_rigidbody.velocity.normalized * _speed);
    }
    private void RandomlyChooseColor()
    {
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            gameObject.GetComponent<Renderer>().material = _redColor;
            gameObject.layer = RED_SPHERE_LAYER_NUMBER;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = _blackColor;
            gameObject.layer = BLACK_SPHERE_LAYER_NUMBER;
        }
    }
    private Vector3 RandomlyMovingDirection()
    {
        return new Vector3(UnityEngine.Random.Range(0f, 1f),0, UnityEngine.Random.Range(0f, 1f));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == WALL_LAYER_NUMBER)
            return;
        Destroy(gameObject);
        Destroy(collision.gameObject);

    }
    private void OnDestroy()
    {
        Death?.Invoke();
        Death = null;
    }
}
