using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingRocks : MonoBehaviour
{
    /* public float FloatStrenght;
     public float RandomRotationStrenght;


     void Update()
     {
         transform.GetComponent<Rigidbody>().AddForce(Vector3.down * FloatStrenght);
         transform.Rotate(RandomRotationStrenght, RandomRotationStrenght, RandomRotationStrenght);
     } */
    // Public variable to set the distance
    public float _distance;

    // Variables for floating
    private Vector3 _top, _bottom, _left, _right, _diagUp, _diagDown;
    private float _percent = 0.0f;
    public float _speed;
    public Direction _direction;

    // Define direction up and down
    public enum Direction { UP, DOWN, RIGHT, LEFT, DIAG_UP, DIAG_DOWN};

    // Set the direction to up, and the locations
    void Start()
    {
        _top = new Vector3(transform.position.x,
                           transform.position.y + _distance,
                           transform.position.z);
        _bottom = new Vector3(transform.position.x,
                            transform.position.y - _distance,
                            transform.position.z);
        _right = new Vector3(transform.position.x + _distance,
                            transform.position.y,
                            transform.position.z);
        _left = new Vector3(transform.position.x - _distance,
                            transform.position.y,
                            transform.position.z);
        _diagUp = new Vector3(transform.position.x,
                            transform.position.y,
                            transform.position.z + _distance);
        _diagUp = new Vector3(transform.position.x,
                            transform.position.y,
                            transform.position.z - _distance);

    }

    void Update()
    {
       // Debug.Log(_percent); 
        ApplyFloatingEffect();
        ApplyRotationEffect();
    }

    // Apply the floating effect between the given positions
    void ApplyFloatingEffect()
    {
        if (_direction == Direction.UP && _percent < 1)
        {
            _percent += Time.deltaTime * _speed;
            transform.position = Vector3.Lerp(_top, _bottom, _percent);
        }
        else if (_direction == Direction.DOWN && _percent < 1)
        {
            _percent += Time.deltaTime * _speed;
            transform.position = Vector3.Lerp(_bottom, _top, _percent);
        }
        else if (_direction == Direction.RIGHT && _percent < 1)
        {
            _percent += Time.deltaTime * _speed;
            transform.position = Vector3.Lerp(_right, _left, _percent);
        }
        else if (_direction == Direction.LEFT && _percent < 1)
        {
            _percent += Time.deltaTime * _speed;
            transform.position = Vector3.Lerp(_left, _right, _percent);
        }
        else if (_direction == Direction.DIAG_UP && _percent < 1)
        {
            _percent += Time.deltaTime * _speed;
            transform.position = Vector3.Lerp(_diagUp, _diagDown, _percent);
        }
        else if (_direction == Direction.DIAG_DOWN && _percent < 1)
        {
            _percent += Time.deltaTime * _speed;
            transform.position = Vector3.Lerp(_diagDown, _diagUp, _percent);
        }

        if (_percent >= 1)
        {
            _percent = 0.0f;
            if (_direction == Direction.UP)
            {
                _direction = Direction.DOWN;
            }
            else if(_direction == Direction.DOWN)
            {
                _direction = Direction.UP;
            }
            else if (_direction == Direction.RIGHT)
            {
                _direction = Direction.LEFT;
            }
            else if (_direction == Direction.LEFT)
            {
                _direction = Direction.RIGHT;
            }
            else if (_direction == Direction.DIAG_UP)
            {
                _direction = Direction.DIAG_DOWN;
            }
            else if (_direction == Direction.DIAG_DOWN)
            {
                _direction = Direction.DIAG_UP;
            }
        }
    }

    // Apply a random rotation effect
    void ApplyRotationEffect()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * 25f);
    }
}
