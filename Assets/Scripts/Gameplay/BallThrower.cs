using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class BallThrower : MonoBehaviour
{
    [SerializeField] private PlayerInputReader inputReader;
    [SerializeField] private Rigidbody ballPrefab;
    [SerializeField] Transform launchPoint;
    [SerializeField] private float launchSpeed = 20f;
    [SerializeField] private float cooldown = 0.3f;

    [Header("Feedback")]
    [SerializeField] private GameObject launchEffect;
    [SerializeField] private AudioEvent sfxEvent;
    [SerializeField] private AudioClip launchClip;

    private float nextThrowTime;

    private void OnEnable() 
    {
        inputReader.FireEvent += Throw;
    }

    private void OnDisable()
    {
        inputReader.FireEvent -= Throw;
    }

    private void Throw()
    {
        if (Time.time < nextThrowTime) return;
        nextThrowTime = Time.time + cooldown;

        Rigidbody ball = Instantiate(ballPrefab, launchPoint.position, launchPoint.rotation);
        ball.linearVelocity = launchPoint.forward * launchSpeed;
        Instantiate(launchEffect, launchPoint.position, launchPoint.rotation);
        sfxEvent.Raise(launchClip, launchPoint.position);
    }
}
