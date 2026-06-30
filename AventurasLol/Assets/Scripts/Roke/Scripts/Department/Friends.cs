using UnityEngine;

public class Friend : MonoBehaviour
{
    [Header("Información")]
    [SerializeField] private FriendType friendType;

    [Header("Diversión")]
    [SerializeField] private int fun = 0;

    [SerializeField] private int maxFun = 100;

    public FriendType Type => friendType;

    public int Fun => fun;

    public bool IsComplete => fun >= maxFun;

    private void Start()
    {
        if (FriendManager.Instance != null)
        {
            FriendManager.Instance.RegisterFriend(this);
        }
    }

    public void AddFun(int amount)
    {
        fun = Mathf.Clamp(fun + amount, 0, maxFun);
    }

    public void SetFun(int value)
    {
        fun = Mathf.Clamp(value, 0, maxFun);
    }
}