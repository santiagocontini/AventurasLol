using System.Collections.Generic;
using UnityEngine;

public class FriendManager : MonoBehaviour
{
    public static FriendManager Instance;

    private readonly Dictionary<FriendType, Friend> friends =
        new Dictionary<FriendType, Friend>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterFriend(Friend friend)
    {
        if (!friends.ContainsKey(friend.Type))
        {
            friends.Add(friend.Type, friend);
        }
    }

    public Friend GetFriend(FriendType type)
    {
        if (!friends.ContainsKey(type))
            return null;

        return friends[type];
    }

    public void AddFun(FriendType type, int amount)
    {
        Friend friend = GetFriend(type);

        if (friend == null)
            return;

        friend.AddFun(amount);

        Debug.Log($"{type}: {friend.Fun}");

        CheckFriends();
    }

    private void CheckFriends()
    {
        if (friends.Count < 3)
            return;

        foreach (Friend friend in friends.Values)
        {
            if (!friend.IsComplete)
                return;
        }

        GameStateManager.Instance.ChangeState(GameState.UsePC);
    }
}