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
            output.Attributes.SetAttribute("class", "card mw375");

            output.Content.AppendHtml($@"<div class='card-content'><p class='title'><i class='fa-solid {SoftwareDesignPattern.Icon} mr-2'></i>{SoftwareDesignPattern.Name}</p>");
            output.Content.AppendHtml($@"<p class='subtitle'>{SoftwareDesignPattern.Summary}</p>");
            output.Content.AppendHtml($@"<div class='content'><div class='card-content'>Some content here...</div><a href='{SoftwareDesignPattern.Hyperlink}'>More...</a></div></div>");

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
