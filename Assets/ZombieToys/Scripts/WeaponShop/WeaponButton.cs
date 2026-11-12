using UnityEngine;
using UnityEngine.UI;
using ZombieToys.Scripts.Managers;
using ZombieToys.Scripts.Player;

namespace ZombieToys.Scripts.WeaponShop
{
    public class WeaponButton : MonoBehaviour
    {
        public PlayerShooting playerShooting;
        public int weaponNumber;

        public Text weaponName;
        public Text cost;
        public Text description;

        private AudioSource source;

        // Use this for initialization
        private void Start()
        {
            source = GetComponent<AudioSource>();
            SetButton();
        }

        private void SetButton()
        {
            string costString = playerShooting.weapons[weaponNumber].cost.ToString();
            weaponName.text = playerShooting.weapons[weaponNumber].weaponName;
            cost.text = "$" + playerShooting.weapons[weaponNumber].cost;
            description.text = playerShooting.weapons[weaponNumber].description;
        }

        public void OnClick()
        {
            if (ScoreManager.score >= playerShooting.weapons[weaponNumber].cost)
            {
                ScoreManager.score -= playerShooting.weapons[weaponNumber].cost;
                playerShooting.currentWeapon = weaponNumber;
            }
            else
            {
                source.Play();
            }
        }

    }
}

