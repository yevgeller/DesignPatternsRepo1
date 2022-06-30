using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DesignPatternsRepo1.TagHelpers
{
    public class NavigationTagHelper : TagHelper
    {
        private string _pattern = "factory";
        public string Pattern { get { return _pattern; } set { this._pattern = value.ToLower(); } }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "container is-flex is-flex-direction-row is-justify-content-space-evenly mt-6 ");
            output.Content.AppendHtml($@"<div><span class='is-uppercase has-text-weight-semibold ml-5'>Creational</span><div class='is-flex is-flex-direction-column is-justify-content-space-evenly'>");

            if (this.Pattern != "fac") output.Content.AppendHtml("<div><a href='/Creational/Factory'><i class='fa-solid fa-industry mr-2 ml-5'></i>Factory</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-industry  mr-1 ml-3'></i>Factory</div>");

            if (this.Pattern != "abs") output.Content.AppendHtml("<div><a href='/Creational/Abstract'><i class='fa-solid fa-boxes-stacked mr-2 ml-5'></i>Abstract Factory</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-boxes-stacked mr-1 ml-3'></i>Abstract Factory</div>");

            if (this.Pattern != "bui") output.Content.AppendHtml("<div><a href='/Creational/Builder'><i class='fa-solid fa-helmet-safety mr-2 ml-5'></i>Builder</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-helmet-safety mr-1 ml-3'></i>Builder</div>");

            if (this.Pattern != "proto") output.Content.AppendHtml("<div><a href='/Creational/Prototype'><i class='fa-regular fa-clone mr-2 ml-5'></i>&nbsp;Prototype</a></div>"); 
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-regular fa-clone  mr-1 ml-3'></i>&nbsp;Prototype</div>");

            if (this.Pattern != "sin") output.Content.AppendHtml("<div><a href='/Creational/Singleton'><i class='fa-solid fa-atom mr-2 ml-5'></i>&nbsp;Singleton</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-atom mr-1 ml-3'></i>&nbsp;Singleton</div>");

            output.Content.AppendHtml("</div></div>");
            output.Content.AppendHtml(@"<div><span class='is-uppercase has-text-weight-semibold ml-5'>Structural</span><div class='is-flex is-flex-direction-column is-justify-content-space-evenly'>");

            if (this.Pattern != "ada") output.Content.AppendHtml("<div><a href='/Structural/Adapter'><i class='fa-solid fa-plug mr-2 ml-5'></i>Adapter</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-plug mr-1 ml-3'></i>Adapter</div>");
            
            if (this.Pattern != "bri") output.Content.AppendHtml("<div><a href='/Structural/Bridge'><i class='fa-solid fa-left-right mr-2 ml-5'></i>Bridge</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-left-right mr-1 ml-3'></i>Bridge</div>");
            
            if (this.Pattern != "sit") output.Content.AppendHtml("<div><a href='/Structural/Composite'><i class='fa-solid fa-magnifying-glass-arrow-right mr-2 ml-5'></i>Composite</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-magnifying-glass-arrow-right mr-1 ml-3'></i>Composite</div>");

            if (this.Pattern != "dec") output.Content.AppendHtml("<div><a href='/Structural/Decorator'><i class='fa-solid fa-chart-line mr-2 ml-5'></i>Decorator</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-chart-line mr-1 ml-3'></i>Decorator</div>");

            if (this.Pattern != "fas") output.Content.AppendHtml("<div><a href='/Structural/Facade'><i class='fa-solid fa-igloo mr-2 ml-5'></i>Facade</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-igloo mr-1 ml-3'></i>Facade</div>");
            
            if (this.Pattern != "fly") output.Content.AppendHtml("<div><a href='/Structural/Flyweight'><i class='fa-solid fa-bowl-rice mr-2 ml-5'></i>Flyweight</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-bowl-rice mr-1 ml-3'></i>Flyweight</div>");
            
            if (this.Pattern != "proxy") output.Content.AppendHtml("<div><a href='/Structural/Proxy'><i class='fa-solid fa-door-open mr-2 ml-5'></i>Proxy</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-door-open mr-1 ml-3'></i>Proxy</div>");

            output.Content.AppendHtml("</div></div>");
            output.Content.AppendHtml(@"<div><span class='is-uppercase has-text-weight-semibold ml-5'>Behavioral</span><div class='is-flex is-flex-direction-column is-justify-content-space-evenly'>");

            if (this.Pattern != "cha") output.Content.AppendHtml("<div><a href='/Behavioral/ChainOfResponsibility'><i class='fa-solid fa-link mr-2 ml-5'></i>Chain of Responsibility</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-link mr-1 ml-3'></i>Chain of Responsibility</div>");
            
            if (this.Pattern != "com") output.Content.AppendHtml("<div><a href='/Behavioral/Command'><i class='fa-solid fa-bullhorn mr-2 ml-5'></i>Command</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-bullhorn mr-1 ml-3'></i>Command</div>");
            
            if (this.Pattern != "int") output.Content.AppendHtml("<div><a href='/Behavioral/Interpreter'><i class='fa-solid fa-language mr-2 ml-5'></i>Interpreter</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-language mr-1 ml-3'></i>Interpreter</div>");
            
            if (this.Pattern != "ite") output.Content.AppendHtml("<div><a href='/Behavioral/Iterator'><i class='fa-solid fa-arrow-up-right-dots mr-2 ml-5'></i>Iterator</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-arrow-up-right-dots mr-1 ml-3'></i>Iterator</div>");
            
            if (this.Pattern != "med") output.Content.AppendHtml("<div><a href='/Behavioral/Mediator'><i class='fa-solid fa-tower-cell mr-2 ml-5'></i>Mediator</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-tower-cell mr-1 ml-3'></i>Mediator</div>");
            
            if (this.Pattern != "mem") output.Content.AppendHtml("<div><a href='/Behavioral/Memento'><i class='fa-solid fa-gift mr-2 ml-5'></i>Memento</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-gift mr-1 ml-3'></i>Memento</div>");
            
            if (this.Pattern != "obs") output.Content.AppendHtml("<div><a href='/Behavioral/Observer'><i class='fa-solid fa-eye mr-2 ml-5'></i>Observer</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-eye mr-1 ml-3'></i>Observer</div>");
            
            if (this.Pattern != "sta") output.Content.AppendHtml("<div><a href='/Behavioral/State'><i class='fa-solid fa-wand-sparkles mr-2 ml-5'></i>State</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-wand-sparkles mr-1 ml-3'></i>State</div>");

            if (this.Pattern != "str") output.Content.AppendHtml("<div><a href='/Behavioral/Strategy'><i class='fa-solid fa-chess-knight mr-2 ml-5'></i>Strategy</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-chess-knight mr-1 ml-3'></i>Strategy</div>");

            if (this.Pattern != "tem") output.Content.AppendHtml("<div><a href='/Behavioral/TemplateMethod'><i class='fa-solid fa-train-tram mr-2 ml-5'></i>Template Method</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-train-tram mr-1 ml-3'></i>Template Method</div>");

            if (this.Pattern != "vis") output.Content.AppendHtml("<div><a href='/Behavioral/Visitor'><i class='fa-solid fa-person-circle-question mr-2 ml-5'></i>Visitor</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-right'></i><i class='fa-solid fa-person-circle-question mr-1 ml-3'></i>Visitor</div>");

            output.Content.AppendHtml("</div>");
        }
    }
}