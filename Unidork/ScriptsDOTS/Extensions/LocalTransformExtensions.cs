using Unity.Mathematics;
using Unity.Transforms;

namespace Unidork.ScriptsDOTS.Extensions
{
    public static class LocalTransformExtensions
    {
        public static LocalTransform TranslateX(this LocalTransform localTransform, float translation)
        {
            return localTransform.Translate(new float3(translation, 0f, 0f));
        }

        public static LocalTransform TranslateY(this LocalTransform localTransform, float translation)
        {
            return localTransform.Translate(new float3(0f, translation, 0f));
        }

        public static LocalTransform TranslateZ(this LocalTransform localTransform, float translation)
        {
            return localTransform.Translate(new float3(0f, 0f, translation));
        }
    }
}