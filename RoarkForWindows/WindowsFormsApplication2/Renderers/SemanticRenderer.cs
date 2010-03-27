using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.Renderers
{
    public class SemanticRenderer : ICanRenderHtml
    {
        public string Render(string template, List<DivPanel> divs)
        {
            return template.Replace("%CONTENT%", RenderDivs(divs)).Replace("%STYLE%", RenderStyles(divs));
        }

        private static string RenderDivs(List<DivPanel> divs)
        {
            StringBuilder rendered = new StringBuilder();

            foreach (DivPanel div in divs)
            {
                rendered.Append(RenderDiv(div));
                rendered.Append(Environment.NewLine);
            }

            rendered.Append(Environment.NewLine);

            return rendered.ToString();
        }

        private static string RenderStyles(List<DivPanel> divs)
        {
            // It kills me to duplicate code like this! 
            StringBuilder rendered = new StringBuilder();

            rendered.Append("<style>" + Environment.NewLine);

            foreach (DivPanel div in divs)
            {
                rendered.Append(RenderCSS(div));
                rendered.Append(Environment.NewLine);
            }
            rendered.Append("</style>" + Environment.NewLine);

            return rendered.ToString();
        }


        public static string RenderDiv(DivPanel div)
        {
            return string.Format(@"<div id=""{0}""></div>", div.Name);
        }

        public static string RenderCSS(DivPanel div)
        {
            string style = string.Format("top: {0}px; left: {1}px; width: {2}px; height: {3}px;", div.Top, div.Left, div.Width, div.Height);

            style += "border: 1px; border-style: dashed; position: absolute;";

            return "#" + div.Name + " {" + style + "}";
        }

    }
}
