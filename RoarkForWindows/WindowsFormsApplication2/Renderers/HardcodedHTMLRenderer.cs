using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.Renderers
{
    public class HardcodedHTMLRenderer : ICanRenderHtml
    {
        public string Render(string template, List<DivPanel> divs)
        {
            template = template.Replace("%STYLE%", ""); // No style used here. Just remove the placeholder.

            return template.Replace("%CONTENT%", RenderDivs(divs));
        }

        private static string RenderDivs(List<DivPanel> divs)
        {
            StringBuilder rendered = new StringBuilder();

            foreach (DivPanel div in divs)
            {
                rendered.Append(RenderDiv(div));
                rendered.Append(Environment.NewLine);
            }

            return rendered.ToString();
        }

        public static string RenderDiv(DivPanel div)
        {
            string style = "";
            style += string.Format("top: {0}px; left: {1}px; width: {2}px; height: {3}px;", div.Top, div.Left, div.Width, div.Height);
            style += "border: 1px; border-style: dashed; position: absolute;";

            return string.Format(@"<div id=""{0}"" style=""{1}""></div>", div.Name, style);
        }


    }
}
