using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.Renderers
{
    public class RenderFactory
    {
        public static ICanRenderHtml Create(int RenderMode)
        {
            switch (RenderMode)
            {
                case RenderModes.Blueprint:

                    return new BlueprintRenderer();

                case RenderModes.Semantic:

                    return new SemanticRenderer();

                default:

                    return new HardcodedHTMLRenderer();
            }
        }
    }
}
