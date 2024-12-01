using System;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Unity.SceneManagement {
    using Unity.SceneManagement.Internal;

    /// <summary>
    /// Manages SceneLoader.
    /// </summary>
    public class SceneLoaderManager : ISceneLoaderManager {

        public static SceneLoaderManager Instance { get; } = new();

        // 
        private readonly SceneLoadManager _sceneLoad;
        private readonly SceneHandleManager _sceneHandle;
        private readonly SceneOwnershipManager _ownership;
        private readonly SceneLoaderTaskQueueManager _loaderTaskQueueManager;
        private readonly SceneProgressTracker _sceneProgress;


        /// ----------------------------------------------------------------------------
        // Static Prop & Method

        /// <summary>
        /// Returns true if a scene loading process is currently running.
        /// </summary>
        public static bool HasProgress => Instance._sceneProgress.HasProgress;

        /// <summary>
        /// Overall progress of scene loading processes within SceneLoader.
        /// </summary>
        /// <returns></returns>
        public static float Progress() => Instance._sceneProgress.Progress();

        /// <summary>
        /// Gets the handle for a scene loading process.
        /// </summary>
        /// <param name="scene">Target scene</param>
        /// <param name="handle">Handle to manage the loading progress</param>
        /// <returns>True if the loading process is currently running</returns>
        public static bool GetHandle(AssetReferenceScene scene, out AsyncOperationHandle<SceneInstance> handle) {
            return Instance._sceneHandle.GetHandle(scene, out handle);
        }

        /// <summary>
        /// Gets the owner of a scene.
        /// </summary>
        /// <param name="scene">Scene called by SceneLoader</param>
        /// <returns>The object that called SceneLoader for the scene. Returns null if it does not exist.</returns>
        public static GameObject GetOwner(Scene scene) => Instance._ownership.GetOwner(scene);

        /// <summary>
        /// Gets the owner of a scene.
        /// </summary>
        /// <param name="obj">GameObject within the scene called by SceneLoader</param>
        /// <returns>The object that called SceneLoader for the scene. Returns null if it does not exist.</returns>
        public static GameObject GetOwner(GameObject obj) => GetOwner(obj.scene);


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        private SceneLoaderManager() {
            _sceneLoad = new SceneLoadManager();
            _ownership = new SceneOwnershipManager();
            _loaderTaskQueueManager = new SceneLoaderTaskQueueManager();
            _sceneHandle = new SceneHandleManager();
            _sceneProgress = new SceneProgressTracker(_sceneHandle);

            Application.quitting += _loaderTaskQueueManager.Dispose;
        }


        /// ----------------------------------------------------------------------------
        // Interface Method

        /// <summary>
        /// Loads a scene.
        /// </summary>
        /// <param name="scene">Scene asset</param>
        /// <param name="priority">Priority for loading the scene</param>
        /// <param name="isActive">Whether the scene should be registered as active upon completion</param>
        /// <param name="onComplete">Callback when the loading is complete</param>
        /// <returns>True if the loading process has started</returns>
        void ISceneLoaderManager.Load(AssetReferenceScene scene, int priority, bool isActive, Action<Scene> onComplete) {

            var act = _loaderTaskQueueManager.GetOrCreateSceneLoadTask(scene);

            act.EnqueueAction(() => {
                onComplete += _ => act.ExecuteNextAction();

                // Returns false if the scene is already loaded or if loading fails.
                var opHandle = _sceneLoad.Load(scene, priority, isActive);
                _sceneHandle.Add(opHandle, scene, onComplete);
            });
        }

        /// <summary>
        /// Unloads a scene.
        /// </summary>
        /// <param name="sceneReference">Scene asset</param>
        /// <param name="sceneName">Scene name</param>
        /// <param name="onComplete">Callback when the unloading is complete</param>
        void ISceneLoaderManager.Unload(AssetReferenceScene sceneReference, string sceneName, Action onComplete) {
            var act = _loaderTaskQueueManager.GetOrCreateSceneLoadTask(sceneReference);

            act.EnqueueAction(() => {
                onComplete += () => act.ExecuteNextAction();
                _sceneLoad.Unload(sceneReference, sceneName, onComplete);
            });

        }

        void ISceneLoaderManager.Register(string sceneName, GameObject owner) =>
            _ownership.AddOwner(sceneName, owner);

        void ISceneLoaderManager.Unregister(string sceneName) =>
            _ownership.RemoveOwner(sceneName);
    }
}
