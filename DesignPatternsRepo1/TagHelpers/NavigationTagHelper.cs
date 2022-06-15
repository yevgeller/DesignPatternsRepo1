using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DesignPatternsRepo1.TagHelpers
{
    public class NavigationTagHelper : TagHelper
    {
        public string Pattern { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "container is-flex is-flex-direction-row is-justify-content-space-evenly mt-6 ");
        }
    }
}


/*
 <div class="container is-flex is-flex-direction-row is-justify-content-space-evenly mt-6">
        <div>
            <span class="is-uppercase has-text-weight-semibold">Creational</span>
            <div class="is-flex is-flex-direction-column is-justify-content-space-evenly">
                <div><a asp-area="" asp-page="/Creational/Factory-problem"><i class="fa-solid fa-industry mr-2"></i>Factory</a></div>
                <div><a asp-area="" asp-page="/Creational/Abstract-problem"><i class="fa-solid fa-cube"></i><i class="fa-solid fa-industry mr-2"></i>Abstract Factory</a></div>
                <div><a asp-area="" asp-page="/Creational/Builder-problem"><i class="fa-solid fa-helmet-safety mr-2"></i>Builder</a></div>
                <div><a asp-area="" asp-page="/Creational/Prototype"><i class="fa-regular fa-clone mr-2"></i>&nbsp;Prototype</a></div>
                <div><a asp-area="" asp-page="/Creational/Singleton"><i class="fa-solid fa-atom mr-2"></i>&nbsp;Singleton</a></div>

            </div>
        </div>
        <div>
            <span class="is-uppercase has-text-weight-semibold">Structural</span>
            <div class="is-flex is-flex-direction-column is-justify-content-space-evenly">
                <div><a asp-area="" asp-page="/Structural/Adapter"><i class="fa-solid fa-plug mr-2"></i>Adapter</a></div>
                <div><a asp-area="" asp-page="/Structural/Bridge"><i class="fa-solid fa-left-right mr-2"></i>Bridge</a></div>
                <div><a asp-area="" asp-page="/Structural/Composite"><i class="fa-solid fa-magnifying-glass-arrow-right mr-2"></i>Composite</a></div>
                <div><a asp-area="" asp-page="/Structural/Decorator"><i class="fa-solid fa-chart-line mr-2"></i>Decorator</a></div>
                <div><a asp-area="" asp-page="/Structural/Facade"><i class="fa-solid fa-igloo mr-2"></i>Facade</a></div>
                <div><a asp-area="" asp-page="/Structural/Flyweight"><i class="fa-solid fa-bowl-rice mr-2"></i>Flyweight</a><new-badge></new-badge></div>
                <div><a asp-area="" asp-page="/Structural/Proxy"><i class="fa-solid fa-door-open mr-2"></i>Proxy</a><new-badge></new-badge></div>
            </div>
        </div>
        <div>
            Behavioral<div class="is-flex is-flex-direction-column is-justify-content-space-evenly">
                <div><a asp-area="" asp-page="/Behavioral/ChainOfResponsibility"><i class="fa-solid fa-link mr-2"></i>Chain of Responsibility</a><new-badge></new-badge></div>
                <div><a asp-area="" asp-page="/Behavioral/Command"><i class="fa-solid fa-bullhorn mr-2"></i>Command</a><new-badge></new-badge></div>
                <div><a asp-area="" asp-page="/Behavioral/Interpreter"><i class="fa-solid fa-language mr-2"></i>Interpreter</a><new-badge></new-badge></div>
                <div><a asp-area="" asp-page="/Behavioral/Iterator"><i class="fa-solid fa-arrow-up-right-dots mr-2"></i>Iterator</a><new-badge></new-badge></div>
                <div><a asp-area="" asp-page="/Behavioral/Mediator"><i class="fa-solid fa-tower-cell mr-2"></i>Mediator</a><new-badge></new-badge></div>
                <div><a asp-area="" asp-page="/Behavioral/Memento"><i class="fa-solid fa-gift mr-2"></i>Memento</a><new-badge></new-badge></div>
                <div><a asp-area="" asp-page="/Behavioral/Memento"><i class="fa-solid fa-eye mr-2"></i>Observer</a><new-badge></new-badge></div>
                <div><a asp-area="" asp-page="/Behavioral/State"><i class="fa-solid fa-wand-sparkles mr-2"></i>State</a><new-badge></new-badge></div>
                <div><a asp-area="" asp-page="/Behavioral/Strategy"><i class="fa-solid fa-chess-knight mr-2"></i>Strategy</a><new-badge></new-badge></div>
                <div><a asp-area="" asp-page="/Behavioral/TemplateMethod"><i class="fa-solid fa-train-tram mr-2"></i>Template Method</a><new-badge></new-badge></div>
                <div><a asp-area="" asp-page="/Behavioral/Visitor"><i class="fa-solid fa-person-circle-question mr-2"></i>Visitor</a><new-badge></new-badge></div>
            </div>
        </div>
    </div>
*/