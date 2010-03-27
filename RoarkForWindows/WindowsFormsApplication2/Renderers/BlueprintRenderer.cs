using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.Renderers
{
    public class BlueprintRenderer : ICanRenderHtml
    {
        public string Render(string template, List<DivPanel> divs)
        {
            // TODO: INSERT STYLESHEET REFERENCE HERE (for Blueprint)
            string stylesheetTag = @"<link rel=stylesheet href=""file:///C:/Documents%20and%20Settings/matt/Desktop/blueprint071/blueprint/screen.css"" type=""text/css""/>";

            template = template.Replace("%STYLE%", stylesheetTag);

            return template.Replace("%CONTENT%", RenderDivs(divs));
        }

        private static string RenderDivs(List<DivPanel> divs)
        {
            StringBuilder rendered = new StringBuilder();

            rendered.Append(@"<div class=""container showgrid"">" + Environment.NewLine);

            foreach (DivPanel div in divs)
            {
                rendered.Append(RenderDiv(div));
                rendered.Append(Environment.NewLine);
            }

            rendered.Append("</div>" + Environment.NewLine);

            return rendered.ToString();
        }

        public static string RenderDiv(DivPanel div)
        {
            BlueprintAdapter blueprintDiv = new BlueprintAdapter(div);

            string classList = string.Format("span-{0}", blueprintDiv.Span);


            return string.Format(@"<div id=""{0}"" class=""border {1}"">0</div>", div.Name, classList);
        }

    }
}
