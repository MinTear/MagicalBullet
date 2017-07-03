using UnityEngine;
namespace Assets.Script.Common.TransitionFunction
{
    public interface ITransitionFunction
    {
        float Transit(float progress);
    }

    public static class TransitionFunctionFactory
    {
        private static ITransitionFunction[] transitionFunctions = {new EaseIn(), new EaseOut(),new Linear(), };
        public static ITransitionFunction GetRandomTransitionFunction()
        {
            return transitionFunctions[Random.Range(0, transitionFunctions.Length)];
        }
    }

    class EaseIn : ITransitionFunction
    {
        public float Transit(float progress)
        {
            return progress*progress;
        }
    }

    class EaseOut : ITransitionFunction
    {
        public float Transit(float progress)
        {
            return Mathf.Sqrt(progress);
        }
    }

    class Linear:ITransitionFunction
    {
        public float Transit(float progress)
        {
            return progress;
        }
    }
}
