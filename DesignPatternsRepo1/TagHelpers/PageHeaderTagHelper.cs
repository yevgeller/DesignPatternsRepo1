using DesignPatternsRepo1.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DesignPatternsRepo1.TagHelpers
{
    public class PageHeaderTagHelper : TagHelper
    {
        /*
         * <h1 class="title is-1 is-spaced">
                <i class="fa-solid fa-boxes-stacked mr-2"></i>
                Abstract Factory
            </h1>
            <h2 class="subtitle">Organization ... classes</h2>
        */
        public SoftwareDesignPattern SoftwareDesignPattern { get; set; } = new SoftwareDesignPattern("fac");
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml($@"<h1 class='title is-1 is-spaced'><i class='fa-solid {SoftwareDesignPattern.Icon} mr-2'></i>");
            output.Content.AppendHtml($@"{SoftwareDesignPattern.Name}</h1>");
            output.Content.AppendHtml($@"<h2 class='subtitle mb-3'>{SoftwareDesignPattern.Summary}</h2>");
        }
    }
}
