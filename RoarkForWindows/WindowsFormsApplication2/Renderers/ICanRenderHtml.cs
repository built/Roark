using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.Renderers
{
    public interface ICanRenderHtml
    {
        string Render(string template, List<DivPanel> divs);

    }
}
