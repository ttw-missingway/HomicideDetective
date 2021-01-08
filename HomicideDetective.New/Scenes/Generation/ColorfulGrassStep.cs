using System;
using System.Collections.Generic;
using GoRogue.MapGeneration;
using SadRogue.Primitives;
using SadRogue.Primitives.GridViews;
using TheSadRogue.Integration;

namespace HomicideDetective.New.Scenes.Generation
{
    public class ColorfulGrassStep : GenerationStep
    {
        protected override IEnumerator<object?> OnPerform(GenerationContext context)
        {
            var map = context.GetFirstOrNew<ISettableGridView<RogueLikeCell>>
                (() => new ArrayView<RogueLikeCell>(context.Width, context.Height), "grass");

            for (int i = 0; i < map.Width; i++)
            {
                for (int j = 0; j < map.Height; j++)
                {
                    byte green = Convert.ToByte((Math.Cos(Math.Sqrt(i*i+j*j))+1) * 32 + 32);
                    Color color = new Color(0, green, 0);
                    map[i, j] = new RogueLikeCell((i, j), color, Color.Black, '"', 0);
                }
            }

            yield return null;
        }
    }
}