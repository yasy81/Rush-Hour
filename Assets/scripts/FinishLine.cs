using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public GameObject FireWorks;
    public float distanceToMoveBack = 20f;  // Distance to move the camera backward
    public float moveDuration = 10f;  // Duration of the camera movement

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Car")
        {
            FireWorks.SetActive(true);
            StartCoroutine(MoveCameraBack());
            // Delay loading the next scene to give time for the camera to move back
            StartCoroutine(LoadNextSceneAfterDelay(moveDuration));
        }
    }

    private IEnumerator MoveCameraBack()
    {
        // Find the currently active camera
        Camera activeCamera = Camera.main;
        if (activeCamera == null) yield break;

        float elapsedTime = 0f;
        Vector3 initialPosition = activeCamera.transform.position;
        Vector3 targetPosition = initialPosition - activeCamera.transform.forward * distanceToMoveBack;

        while (elapsedTime < moveDuration)
        {
            // Interpolate the camera's position between its initial position and the target position
            activeCamera.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;

            yield return null;  // Wait for the next frame
        }

        // Ensure the camera reaches the target position at the end
        activeCamera.transform.position = targetPosition;
    }

    private IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
