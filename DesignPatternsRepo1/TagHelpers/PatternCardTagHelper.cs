using DesignPatternsRepo1.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DesignPatternsRepo1.TagHelpers
{
    public class PatternCardTagHelper : TagHelper
    {
        public SoftwareDesignPattern SoftwareDesignPattern { get; set; } = new SoftwareDesignPattern("fac");
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            string classAttributes = "card ";

           output.Attributes.SetAttribute("class", classAttributes);

            output.Content.AppendHtml($@"<div class='card-content'><p class='title'><i class='fa-solid {SoftwareDesignPattern.Icon} mr-2'></i>{SoftwareDesignPattern.Name}</p>");
            output.Content.AppendHtml($@"<p class='subtitle is-size-6'>{SoftwareDesignPattern.GroupEnum}</p>");
            output.Content.AppendHtml($@"<p class='subtitle'>{SoftwareDesignPattern.Header}</p>");
            output.Content.AppendHtml($@"<div class='content'><div class='card-content'>{SoftwareDesignPattern.InformalDescription}</div>");
            output.Content.AppendHtml($@"<div class='small'>{SoftwareDesignPattern.RecipeForDisplay()}</div>");
            output.Content.AppendHtml($@"<div class='mt-2 has-text-right'><a href='{SoftwareDesignPattern.Hyperlink}'><i class='fas {SoftwareDesignPattern.Icon} mr-1'></i>{SoftwareDesignPattern.Name}<i class='fas fa-arrow-right ml-3'></i></a></div></div></div>");          
        }
    }
}
