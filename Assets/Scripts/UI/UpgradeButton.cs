using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    private Button _upgradeButton;
    [SerializeField] private UpgradeMenu _upgrageMenu;
    private void Start()
    {
        _upgradeButton = GetComponent<Button>();
        _upgrageMenu.gameObject.SetActive(false);
        _upgradeButton.onClick.AddListener(OpenUpgradeMenu);
    }

    private void OpenUpgradeMenu() => _upgrageMenu.gameObject.SetActive(true);
}
