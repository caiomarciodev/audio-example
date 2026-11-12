using UnityEngine;

namespace ZombieToys.Scripts.WeaponShop
{
    public class ShopController : MonoBehaviour
    {
        public GameObject shopPanel;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OpenShop();
            }
        }

        private void OpenShop()
        {
            shopPanel.SetActive(true);
            Time.timeScale = 0;
        }
        
        public void CloseShop()
        {
            shopPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}