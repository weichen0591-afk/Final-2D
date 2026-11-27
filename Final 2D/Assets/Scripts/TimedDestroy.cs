using UnityEngine;

// Write a timer that destroys the gameobject it's attached to when time is up.
// Use this to remove your explosion VFX when they're done playing.
public class TimedDestroy : MonoBehaviour
{
    [SerializeField] private float _timeLeft = 0.85f;

    private void Update()
    {
        _timeLeft -= Time.deltaTime;

        if (_timeLeft <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
