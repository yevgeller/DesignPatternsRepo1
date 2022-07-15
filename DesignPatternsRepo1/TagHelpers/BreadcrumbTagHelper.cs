using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DesignPatternsRepo1.TagHelpers
{
    public class BreadcrumbTagHelper : TagHelper
    {
        /*
         * <nav class="breadcrumb" aria-label="breadcrumbs">
  <ul>
    <li><a href="/">Creational</a></li>
    <li class="is-active"><a href="#" aria-current="page">Factory</a></li>
  </ul>
</nav>
        */

        public string Group { get; set; } = "Behavioral";
        public string PageName { get; set; } = "Factory";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "nav";
            output.Attributes.SetAttribute("class", "breadcrumb");
            output.Attributes.SetAttribute("aria-label", "breadcrumbs");

            output.Content.AppendHtml($@"<ul><li><a href='/'>{Group}</a></li><li class='is-active'><a href = '#' aria-current='page'>{PageName}</a></li></ul>");

        }
    }
}
