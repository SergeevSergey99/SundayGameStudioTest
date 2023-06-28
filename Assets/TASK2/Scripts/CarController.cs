using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] WheelCollider frontLeftWheelCollider;
    [SerializeField] WheelCollider frontRightWheelCollider;
    [SerializeField] WheelCollider rearLeftWheelCollider;
    [SerializeField] WheelCollider rearRightWheelCollider;

    [SerializeField] Transform frontLeftWheelTransform;
    [SerializeField] Transform frontRightWheelTransform;
    [SerializeField] Transform rearLeftWheelTransform;
    [SerializeField] Transform rearRightWheelTransform;

    [SerializeField] float maxSteerAngle = 30f;
    [SerializeField] float motorForce = 50f;
    [SerializeField] float brakeForce = 100f;

    [SerializeField] private List<Light> lights;
    [SerializeField] private List<Light> autoBackLights;

    private float _horizontalInput;
    private float _verticalInput;
    private float _steerAngle;
    private bool _isBreaking;
    
    private bool isLightOn = false;
    bool isAutoBackLightsOn = false;

    private void Start()
    {
        SetLights(false);
        SetAutoBackLights(false);
    }

    private void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }
    
    public void AddHorizontalInput(float input)
    {
        _isBreaking = false;
        _horizontalInput += input;
        _horizontalInput = Mathf.Clamp(_horizontalInput, -1f, 1f);
        
        
    }
    
    public void AddVerticalInput(float input)
    {
        _isBreaking = false;
        _verticalInput += input;
        _verticalInput = Mathf.Clamp(_verticalInput, -1f, 1f);
        
        
        if (isAutoBackLightsOn && _verticalInput > 0f)
            SetAutoBackLights(false);
        else if (!isAutoBackLightsOn && _verticalInput < 0f)
            SetAutoBackLights(true);
    }
    
    public void SetBreaking(bool isBreaking)
    {
        _isBreaking = isBreaking;
        _horizontalInput = 0f;
        _verticalInput = 0f;
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = _verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = _verticalInput * motorForce;
        rearLeftWheelCollider.motorTorque = _verticalInput * motorForce;
        rearRightWheelCollider.motorTorque = _verticalInput * motorForce;

        frontLeftWheelCollider.brakeTorque = _isBreaking ? brakeForce : 0f;
        frontRightWheelCollider.brakeTorque = _isBreaking ? brakeForce : 0f;
        rearLeftWheelCollider.brakeTorque = _isBreaking ? brakeForce : 0f;
        rearRightWheelCollider.brakeTorque = _isBreaking ? brakeForce : 0f;
    }
    
    private void HandleSteering()
    {
        _steerAngle = maxSteerAngle * _horizontalInput;
        frontLeftWheelCollider.steerAngle = _steerAngle;
        frontRightWheelCollider.steerAngle = _steerAngle;
    }
    
    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
    }
    
    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
    
    public void ToggleLights()
    {
        isLightOn = !isLightOn;
        SetLights(isLightOn);
    }
    
    public void SetLights(bool isLightOn)
    {
        this.isLightOn = isLightOn;
        foreach (var light in lights)
        {
            light.enabled = isLightOn;
        }
    }
    
    void SetAutoBackLights(bool val)
    {
        isAutoBackLightsOn = val;
        foreach (var light in autoBackLights)
        {
            light.enabled = isAutoBackLightsOn;
        }
    }
}