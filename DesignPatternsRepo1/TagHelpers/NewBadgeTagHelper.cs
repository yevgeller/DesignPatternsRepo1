using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DesignPatternsRepo1.TagHelpers
{
    public class NewBadgeTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.Attributes.SetAttribute("class", "is-size-7 has-text-primary is-uppercase mr-3");

            //var icon = new TagBuilder("i");
            //icon.Attributes.Add("class", "fa-regular fa-square-plus mr-1");
            //output.Content.AppendHtml(icon);

            output.Content.AppendHtml("<span class='ml-1'>new</span>");
        }
    }
}
