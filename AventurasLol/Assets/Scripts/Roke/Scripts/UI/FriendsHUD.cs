using TMPro;
using UnityEngine;

public class FriendsHUD : MonoBehaviour
{
    [Header("Textos")]
    [SerializeField] private TextMeshProUGUI rokeText;
    [SerializeField] private TextMeshProUGUI mateoText;
    [SerializeField] private TextMeshProUGUI tinchoText;

    private void Update()
    {
        if (FriendManager.Instance == null)
            return;

        Friend roke = FriendManager.Instance.GetFriend(FriendType.Roke);
        Friend mateo = FriendManager.Instance.GetFriend(FriendType.Mateo);
        Friend tincho = FriendManager.Instance.GetFriend(FriendType.Tincho);

        if (roke != null)
            rokeText.text = $"Roke: {roke.Fun}%";

        if (mateo != null)
            mateoText.text = $"Mateo: {mateo.Fun}%";

        if (tincho != null)
            tinchoText.text = $"Tincho: {tincho.Fun}%";
    }
}