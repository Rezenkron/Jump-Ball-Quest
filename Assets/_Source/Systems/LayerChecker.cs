using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Service
{
    public static class LayerChecker
    {
        public static bool CheckLayersEquality(LayerMask objectLayer, LayerMask requiredLayer) => ((1 << objectLayer) & requiredLayer) > 0;
    }
}