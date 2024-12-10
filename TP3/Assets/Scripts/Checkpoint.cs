using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] int index;
    [HideInInspector] public int Index => index;
}
