using UnityEngine;

namespace ZombieToys.Scripts.Audio
{
    // Áudio dinâmico por camadas (layering).
    // A música base e a camada extra tocam juntas o tempo todo, em loop.
    // A camada só fica audível enquanto existir pelo menos um gatilho ativo na cena.
    public class DynamicMusicLayer : MonoBehaviour
    {
        public static DynamicMusicLayer Instance { get; private set; }

        public AudioSource baseMusic;               // A música base (ex.: os instrumentos que sobraram no Moises).
        public AudioSource layer;                   // A camada extra (ex.: o instrumento separado no Moises).
        [Range(0f, 1f)] public float layerVolume = 1f;  // Volume da camada quando ela estiver ligada.
        public float fadeTime = 1.5f;               // Tempo, em segundos, para a camada entrar ou sair.

        private int activeTriggers;                 // Quantos gatilhos (ex.: Hellephants vivos) estão ativos.

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            baseMusic.loop = true;
            layer.loop = true;
            layer.volume = 0f;

            // Para e reinicia as duas faixas no mesmo instante do relógio de áudio.
            // Assim elas ficam sincronizadas, mesmo que o Play On Awake esteja marcado.
            baseMusic.Stop();
            layer.Stop();
            double startTime = AudioSettings.dspTime + 0.1;
            baseMusic.PlayScheduled(startTime);
            layer.PlayScheduled(startTime);
        }

        private void Update()
        {
            // Volume que a camada deve alcançar: ligada se houver gatilho ativo, desligada se não houver.
            float target = activeTriggers > 0 ? layerVolume : 0f;

            // Fade: aproxima o volume atual do alvo um pouco a cada frame.
            float step = layerVolume / Mathf.Max(fadeTime, 0.01f) * Time.deltaTime;
            layer.volume = Mathf.MoveTowards(layer.volume, target, step);
        }

        public void AddTrigger()
        {
            activeTriggers++;
        }

        public void RemoveTrigger()
        {
            activeTriggers = Mathf.Max(0, activeTriggers - 1);
        }

        private void OnDestroy()
        {
            if (Instance == this)
                Instance = null;
        }
    }
}
