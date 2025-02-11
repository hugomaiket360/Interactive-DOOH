using Cysharp.Threading.Tasks;
using DG.Tweening;
using GadGame.Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GadGame.Manager
{
    public class LoadSceneManager : PersistentSingleton<LoadSceneManager>
    {
        [SerializeField] private CanvasGroup _transitionCanvasGroup;

        private void Start()
        {
            _transitionCanvasGroup.alpha = 0;
        }

        public async void LoadSceneWithTransition(int sceneIndex, float transitionDuration = 1)
        {
            await _transitionCanvasGroup.DOFade(1, transitionDuration).SetUpdate(true); 
            var asyncOperation =  SceneManager.LoadSceneAsync(sceneIndex);
            asyncOperation.allowSceneActivation = false;
            await UniTask.WaitUntil(() => asyncOperation.progress >= 0.9f);
            await UniTask.Delay(200, ignoreTimeScale:true);
            asyncOperation.allowSceneActivation = true;
            await _transitionCanvasGroup.DOFade(0, transitionDuration).SetUpdate(true);;
        }
        
        public async UniTask LoadSceneWithTransitionAsync(int sceneIndex, float transitionDuration = 1)
        {
            await _transitionCanvasGroup.DOFade(1, transitionDuration/2).SetUpdate(true);; 
            var asyncOperation =  SceneManager.LoadSceneAsync(sceneIndex);
            asyncOperation.allowSceneActivation = false;
            await UniTask.WaitUntil(() => asyncOperation.progress >= 0.9f);
            await UniTask.Delay(200, ignoreTimeScale:true);
            asyncOperation.allowSceneActivation = true;
            await _transitionCanvasGroup.DOFade(0, transitionDuration/2).SetUpdate(true);;
        }
        
        public async void LoadSceneWithTransition(string scenePath, float transitionDuration = 1)
        {
            await _transitionCanvasGroup.DOFade(1, transitionDuration/2).SetUpdate(true);; 
            var asyncOperation =  SceneManager.LoadSceneAsync(scenePath);
            asyncOperation.allowSceneActivation = false;
            await UniTask.WaitUntil(() => asyncOperation.progress >= 0.9f);
            await UniTask.Delay(200, ignoreTimeScale:true);
            asyncOperation.allowSceneActivation = true;
            await _transitionCanvasGroup.DOFade(0, transitionDuration/2).SetUpdate(true);;
        }

        public async UniTask LoadSceneWithTransitionAsync(string scenePath, float transitionDuration = 1)
        {
            await _transitionCanvasGroup.DOFade(1, transitionDuration/2).SetUpdate(true);; 
            var asyncOperation =  SceneManager.LoadSceneAsync(scenePath);
            asyncOperation.allowSceneActivation = false;
            await UniTask.WaitUntil(() => asyncOperation.progress >= 0.9f);
            await UniTask.Delay(200, ignoreTimeScale:true);
            asyncOperation.allowSceneActivation = true;
            await _transitionCanvasGroup.DOFade(0, transitionDuration/2).SetUpdate(true);;
        }
    }
}