using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class END : MonoBehaviour
{
    private void Start()
    {
        int a = 3;
        StartCoroutine(Sonin(a));
    }

    private IEnumerator Sonin(int a)
    {
        yield return new WaitForSeconds(a);
        SceneManager.LoadScene(0);
    }
}
