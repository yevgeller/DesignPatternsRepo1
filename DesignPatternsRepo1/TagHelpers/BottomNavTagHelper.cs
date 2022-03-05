using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DesignPatternsRepo1.TagHelpers
{
    public class BottomNavTagHelper : TagHelper
    {

        public string NextIcon1 { get; set; } = "";
        public string NextIcon2 { get; set; } = "";
        public string NextIcon3 { get; set; } = "";
        public string NextLink { get; set; } = "/Index";
        public string NextName { get; set; } = "";
        public string NextPointerWord { get; set; } = "Next";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "columns");

            var nextIcon1 = this.NextIcon1 == "" ?
                "<i class='fa-solid fa-cube fa-2x mr-" + (this.NextIcon2.Length > 0 ? "1" : "2") + "'></i>" :
                "<i class='" + this.NextIcon1 + " fa-2x mr-" + (this.NextIcon2.Length > 0 ? "1" : "2") + "'></i>";

            var nextIcon2 = this.NextIcon2 == "" ?
                "" :
                "<i class='" + this.NextIcon2 + " fa-2x mr-2'></i>";


            var nextIcon3 = this.NextIcon3 == "" ?
                "" :
                "<i class='" + this.NextIcon3 + " fa-2x ml-2'></i>";

            output.Content.AppendHtml(@$"
                <div class='column is-2'> 
                    <a class='navbar-item' href='/Index'> 
                        <i class='fa-solid fa-house-user fa-2x mr-1'></i>Back 
                    </a> 
                </div> 
                <div class='column is-3'> 
                    <a class='navbar-item' href='/{NextLink.Replace('|', '/')}'> 
                        {nextIcon1}{nextIcon2}
                        {NextPointerWord}: {NextName}
                        {nextIcon3}
                    </a>
                </div>");
        }
    }
}