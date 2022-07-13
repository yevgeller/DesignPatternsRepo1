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
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "nav";
            output.Attributes.SetAttribute("class", "container is-flex is-flex-direction-row is-justify-content-space-evenly mt-6 ");
            output.Content.AppendHtml($@"<div><span class='is-uppercase has-text-weight-semibold ml-5'>Home</span><div class='is-flex is-flex-direction-column is-justify-content-space-evenly'><div><a href='/'><i class='fa-solid fa-house-user mr-2 ml-5'></i>Home</a></div></div></div>");

        }
    }
}
