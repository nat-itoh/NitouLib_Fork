﻿using System;
using UnityEngine;
using UnityEngine.Playables;

namespace nitou.TweenPlayables {

    [Serializable]
    public abstract class TweenAnimationBehaviour<TBinding> : PlayableBehaviour where TBinding : Component {
        
        private bool initialized;

        public override void OnGraphStop(Playable playable) {
            initialized = false;
        }


        /// ----------------------------------------------------------------------------
        // Overrid Method

        public override void OnBehaviourPause(Playable playable, FrameData info) {
            var duration = playable.GetDuration();
            var count = playable.GetTime() + info.deltaTime;

            if ((info.effectivePlayState == PlayState.Paused && count > duration) || playable.GetGraph().GetRootPlayable(0).IsDone()) {
                OnTweenFinished();
            }
        }


        /// ----------------------------------------------------------------------------
        // Public Method

        public virtual void OnTweenInitialize(TBinding playerData) { }
        
        public virtual void OnTweenFinished() { }


        /// ----------------------------------------------------------------------------
        // Internal Method

        internal void Initialize(TBinding playerData) {
            if (playerData == null) return;
            if (initialized) return;
            TBinding target = playerData as TBinding;
            OnTweenInitialize(playerData);
            initialized = true;
        }
    }
}