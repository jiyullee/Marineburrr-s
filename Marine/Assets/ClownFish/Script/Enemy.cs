using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float lifeTime;
<<<<<<< HEAD
    public bool direction;
    public int decrease;
=======
    public int direction;
>>>>>>> 9262ccc841801f6bf52297417b19477d108a7aca
    private void OnEnable()
    {
        StartCoroutine(DisableSelf());
    }

    IEnumerator DisableSelf()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
