using UnityEngine;
using System.Collections;

public class EarthBehavior : MonoBehaviour {

	private float _sensitivity;
	private Vector3 _mouseReference;
	private Vector3 _mouseOffset;
	private Vector3 _rotation;
	private bool _isRotating;

	// Use this for initialization
	void Start () {
		_sensitivity = 0.4f;
		_rotation = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if(_isRotating)
		{
			// offset
			_mouseOffset = (Input.mousePosition - _mouseReference);
			
			// apply rotation
			_rotation.y = -(_mouseOffset.x) * _sensitivity;
			_rotation.x = (_mouseOffset.y) * _sensitivity;
			
			// rotate
			transform.Rotate(_rotation,Space.World);
			
			// store mouse
			_mouseReference = Input.mousePosition;
		}
	}

	void OnMouseDown()
	{
		// rotating flag
		_isRotating = true;
		
		// store mouse
		_mouseReference = Input.mousePosition;
	}

	void OnMouseUp()
	{
		// rotating flag
		_isRotating = false;
	}
}

