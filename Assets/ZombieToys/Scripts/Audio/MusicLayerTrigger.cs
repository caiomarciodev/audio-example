using UnityEngine;
using ZombieToys.Scripts.Enemy;

namespace ZombieToys.Scripts.Audio
{
    // Gatilho do áudio dinâmico. Coloque no Prefab do inimigo que deve ligar a camada (ex.: Hellephant).
    // Evento: o inimigo aparece na cena -> a camada entra.
    // Evento: o inimigo morre -> a camada sai (se não houver outro inimigo desse tipo vivo).
    [RequireComponent(typeof(EnemyHealth))]
    public class MusicLayerTrigger : MonoBehaviour
    {
        private EnemyHealth enemyHealth;
        private bool isActive;

        private void Awake()
        {
            enemyHealth = GetComponent<EnemyHealth>();
        }

        private void OnEnable()
        {
            Activate();
        }

        private void Update()
        {
            // O inimigo continua na cena por alguns segundos depois de morrer (afundando no chão).
            // Por isso desligamos o gatilho assim que a vida chega a zero.
            if (isActive && enemyHealth.currentHealth <= 0)
                Deactivate();
        }

        private void OnDisable()
        {
            Deactivate();
        }

        private void Activate()
        {
            if (isActive || DynamicMusicLayer.Instance == null)
                return;

            DynamicMusicLayer.Instance.AddTrigger();
            isActive = true;
        }

        private void Deactivate()
        {
            if (!isActive)
                return;

            if (DynamicMusicLayer.Instance != null)
                DynamicMusicLayer.Instance.RemoveTrigger();

            isActive = false;
        }
    }
}
