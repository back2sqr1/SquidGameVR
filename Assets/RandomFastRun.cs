// RandomFastRun.cs
// Attach to a Mixamo character that has:
//   • Animator with a “FastRun” state (triggered by the “Speed” float)
//   • CharacterController for collision and gravity
// Works in either HDRP, URP, or Built-in RP.

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class RandomFastRun : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("Constant forward run speed in m/s")]
    [SerializeField] private float speed = 4f;

    [Tooltip("How often (seconds) a new heading is chosen")]
    [SerializeField] private Vector2 changeInterval = new Vector2(1f, 2f);

    [Tooltip("Max heading deviation per turn (degrees)")]
    [SerializeField] private float maxTurnAngle = 180f;

    [Tooltip("Gravity to keep the character on the ground")]
    [SerializeField] private float gravity = -9.81f;

    private CharacterController controller;
    private Animator anim;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable() => StartCoroutine(ChangeHeadingLoop());

    private IEnumerator ChangeHeadingLoop()
    {
        // Pick a random heading, wait a bit, repeat forever.
        while (enabled)
        {
            float wait = Random.Range(changeInterval.x, changeInterval.y);
            yield return new WaitForSeconds(wait);

            // Turn left or right by a random angle within ±maxTurnAngle.
            float turn = Random.Range(-maxTurnAngle, maxTurnAngle);
            transform.Rotate(0f, turn, 0f, Space.World);
        }
    }

    private void Update()
    {
        // Apply gravity so the CharacterController stays grounded.

        // Move in the character’s forward direction.
        Vector3 move = transform.forward * speed;
        controller.Move(move * Time.deltaTime);

        // Drive the Animator –  Mixamo’s locomotion controllers usually
        // blend on a “Speed” float.  Feel free to adjust for your setup.
        anim.SetFloat("Speed", speed);
    }
}
