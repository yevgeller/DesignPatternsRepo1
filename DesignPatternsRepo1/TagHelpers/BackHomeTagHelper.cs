using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DesignPatternsRepo1.TagHelpers
{
    public class BackHomeTagHelper : TagHelper
    {

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "columns");

            var col1 = new TagBuilder("div");
            col1.Attributes.Add("class", "column is-2");
            var col2 = new TagBuilder("div");
        }
    }
}


/*
<div class="columns">
    <div class="column is-2">
        <a class="navbar-item" asp-area="" asp-page="/Index">
            <i class="fa-solid fa-house-user fa-2x mr-1"></i>Back
        </a>
    </div>
    <div class="column is-3">
        <a class="navbar-item" asp-area="" asp-page="/Creational/Abstract-problem">
            <i class="fa-solid fa-cube fa-2x mr-1"></i><i class="fa-solid fa-industry fa-2x mr-2"></i>
            Next: Abstract Factory
        </a>
    </div>
</div>
*/