﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace nitou.TweenPlayables
{
    [Serializable]
    public class TweenSpriteRendererBehaviour : TweenAnimationBehaviour<SpriteRenderer>
    {
        public ColorTweenParameter color;

        public override void OnTweenInitialize(SpriteRenderer playerData)
        {
            color.SetInitialValue(playerData, playerData.color);
        }
    }

}