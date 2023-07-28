using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    private void Start()
    {
        int a = 6;
        StartCoroutine(Sonin(a));
    }

    private IEnumerator Sonin(int a)
    {
        yield return new WaitForSeconds(a);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
