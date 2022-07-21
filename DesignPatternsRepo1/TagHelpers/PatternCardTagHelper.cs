using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DesignPatternsRepo1.TagHelpers
{
    public class PatternCardTagHelper : TagHelper
    {
        public string PatternName { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "card");

            string patternHeader = "<i class='fa-solid fa-industry mr-2'></i>Factory";
            string subtitle = "Creational";

            switch(PatternName)
            {
                case "Abstract":
                    patternHeader = "<i class='fa-solid fa-boxes-stacked mr-3'></i>Abstract Factory";
                    subtitle = "Creational";

                    break;
                default:
                    patternHeader = "<i class='fa-solid fa-boxes-stacked mr-3'></i>Abstract Factory";
                    subtitle = "Creational";
                    break;
            }

            output.Content.AppendHtml($@"<div class='card-content'><p class='title'>{patternHeader}</p>");
            output.Content.AppendHtml($@"<p class='subtitle'>{subtitle}</p>");
            output.Content.AppendHtml($@"<div class='content'><div class='card-content'>Some content here...<div><a href='/Creational/Factory'>More...</a></div></div>");

            //if (this.TheEnd.ToLower() == "yes")
            //{
            //    output.Content.AppendHtml(@$"
            //    <div class='column is-2'> 
            //        <a class='navbar-item' href='/Index'> 
            //            <i class='fa-solid fa-house-user fa-2x mr-1'></i>Back 
            //        </a> 
            //    </div>");
            //}
            //else
            //{
            //    output.Content.AppendHtml(@$"
            //    <div class='column is-2'> 
            //        <a class='navbar-item' href='/Index'> 
            //            <i class='fa-solid fa-house-user fa-2x mr-1'></i>Back 
            //        </a> 
            //    </div> 
            //    <div class='column is-3'> 
            //        <a class='navbar-item' href='/{NextLink.Replace('|', '/')}'> 
            //            {nextIcon1}{nextIcon2}
            //            {NextPointerWord}: {NextName}
            //            {nextIcon3}
            //        </a>
            //    </div>");
            //}
        }
    }
}
