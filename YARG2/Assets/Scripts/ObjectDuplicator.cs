using UnityEngine;

public class ObjectDuplicator : MonoBehaviour
{
    // Offset so the duplicate doesn't spawn directly on top of the original
    public Vector3 duplicateOffset = new Vector3(2, 0, 0);

    // Key to trigger duplication
    public KeyCode duplicateKey = KeyCode.Space;

    void Update()
    {
        if (Input.GetKeyDown(duplicateKey))
        {
            DuplicateObject();
        }
    }

    void DuplicateObject()
    {
        Instantiate(gameObject, transform.position + duplicateOffset, transform.rotation);
    }
}