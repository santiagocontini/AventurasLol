using UnityEngine;

public class FriendController : MonoBehaviour
{
    [SerializeField] private FriendType friend;

    public FriendType Friend => friend;
}