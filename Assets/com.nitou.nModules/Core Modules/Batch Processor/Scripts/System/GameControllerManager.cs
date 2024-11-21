using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

// [�Q�l]
//  github: unity3d-jp/Project_TCC https://github.com/unity3d-jp/Project_TCC
//  �͂Ȃ���: PlayerLoop���g���Ė��t���[�����s�����֐���ǉ����� https://www.hanachiru-blog.com/entry/2021/08/23/120000

namespace nitou.BachProcessor {

    /// <summary>
    /// Adds callbacks to execute processing at arbitrary timings to MultiPhaseSingleton.
    /// For example, if a system with <see cref="IEarlyUpdate"/> is added to <see cref="UpdateTiming.Update"/>,
    /// the processing will be called before Update.
    /// 
    /// If a class inherits from IEarlyUpdate, it will be added before the specified timing.
    /// If it inherits from IPostUpdate, it will be added after the specified timing.
    /// </summary>
    public sealed class GameControllerManager : UpdateTimingSingletonSO<GameControllerManager> {

        private readonly List<IEarlyUpdate> _updates = new();
        private readonly List<IPostUpdate> _lateUpdates = new();


        /// ----------------------------------------------------------------------------
        // Static Method

        /// <summary>
        /// Register a system for processing.
        /// </summary>
        /// <param name="system">The system to register</param>
        /// <param name="timing">The timing to register</param>
        public static void Register(ScriptableObject system, UpdateTiming timing) {
            if (system == null) return;

            var gameController = GameControllerManager.GetInstance(timing);

            if (system is IEarlyUpdate update) {
                gameController._updates.Add(update);
            }

            if (system is IPostUpdate lateUpdate) {
                gameController._lateUpdates.Add(lateUpdate);
            }
        }

        /// <summary>
        /// Get the class type to register based on timing.
        /// </summary>
        /// <param name="timing">The timing</param>
        /// <returns>The type of the class</returns>
        private static Type GetTimingType(UpdateTiming timing) {
            return timing switch {
                UpdateTiming.Update => typeof(Update),
                UpdateTiming.FixedUpdate => typeof(FixedUpdate),
                UpdateTiming.LateUpdate => typeof(PostLateUpdate),
                _ => typeof(Update)
            };
        }

        /// <summary>
        /// Register a system to the callbacks.
        /// </summary>
        /// <param name="loopSystem">PlayerLoop</param>
        /// <param name="timing">The timing to register the callback</param>
        /// <param name="earlyUpdate">The callback to register, called before the timing</param>
        /// <param name="postUpdate">The callback to register, called after the timing</param>
        private static void RegisterCallback(ref PlayerLoopSystem loopSystem, Type timing,
                PlayerLoopSystem.UpdateFunction earlyUpdate, 
                PlayerLoopSystem.UpdateFunction postUpdate) {

            var earlyUpdateSystem = new PlayerLoopSystem { updateDelegate = earlyUpdate, type = typeof(GameControllerManager) };
            var postUpdateSystem = new PlayerLoopSystem() { updateDelegate = postUpdate, type = typeof(GameControllerManager) };

            // ���ΏۃC���f�b�N�X���������C�؍\���ɑ}������
            var index = Array.FindIndex(loopSystem.subSystemList, c => c.type == timing);
            var list = new List<PlayerLoopSystem>(loopSystem.subSystemList[index].subSystemList);
            list.Insert(0, earlyUpdateSystem);
            list.Add(postUpdateSystem);
            loopSystem.subSystemList[index].subSystemList = list.ToArray();
        }

        /// <summary>
        /// Unregister a system from the callbacks.
        /// </summary>
        /// <param name="loopSystem">PlayerLoop</param>
        /// <param name="timing">The timing where the system is registered</param>
        private static void UnregisterCallback(ref PlayerLoopSystem loopSystem, Type timing) {

            var type = typeof(GameControllerManager);
            var index = Array.FindIndex(loopSystem.subSystemList, c => c.type == timing);
            var list = new List<PlayerLoopSystem>(loopSystem.subSystemList[index].subSystemList);
            list.RemoveAll(c => c.type == type);
            loopSystem.subSystemList[index].subSystemList = list.ToArray();
        }
      

        /// ----------------------------------------------------------------------------
        // Private Method

        /// <summary>
        /// Callback when the class is created.
        /// </summary>
        /// <param name="timing">The timing</param>
        protected override void OnCreate(UpdateTiming timing) {
            var type = GameControllerManager.GetTimingType(timing);

            _updates.Clear();
            _lateUpdates.Clear();

            // PlayerLoop�ɃR�[���o�b�N�o�^
            var loop = PlayerLoop.GetCurrentPlayerLoop();
            GameControllerManager.RegisterCallback(ref loop, type, OnUpdate, OnLateUpdate);
            PlayerLoop.SetPlayerLoop(loop);
        }

        /// <summary>
        /// Callback when the class is destroyed.
        /// </summary>
        private void OnDestroy() {
            var timing = GetTimingType(Timing);

            // PlayerLoop����R�[���o�b�N�o�^����
            var loop = PlayerLoop.GetCurrentPlayerLoop();
            GameControllerManager.UnregisterCallback(ref loop, timing);
            PlayerLoop.SetPlayerLoop(loop);
        }

        /// <summary>
        /// Callback called before the specified timing.
        /// </summary>
        private void OnUpdate() {
            var count = _updates.Count;
            for (var index = 0; index < count; index++) {
                var update = _updates[index];
                
                // Profiler.BeginSample(update.GetType().Name);
                update.OnUpdate();
                // Profiler.EndSample();
            }
        }

        /// <summary>
        /// Callback called after the specified timing.
        /// </summary>
        private void OnLateUpdate() {
            var count = _lateUpdates.Count;
            for (var index = 0; index < count; index++) {
                var update = _lateUpdates[index];
                
                // Profiler.BeginSample(update.GetType().Name);
                update.OnLateUpdate();
                // Profiler.EndSample();
            }
        }
    }
}