﻿using Microsoft.AspNetCore.Razor.TagHelpers;

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
            output.Content.AppendHtml($@"<div><span class='is-uppercase has-text-weight-semibold'>Creational</span><div class='is-flex is-flex-direction-column is-justify-content-space-evenly'>");

            if (this.Pattern != "factory") output.Content.AppendHtml("<div><a asp-page='/Creational/Factory-problem'><i class='fa-solid fa-industry mr-2'></i>Factory</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-industry mr-2'></i>Factory</div>");

            if (this.Pattern != "abstractfactory") output.Content.AppendHtml("<div><a asp-page='/Creational/Abstract-problem'><i class='fa-solid fa-cube'></i><i class='fa-solid fa-industry mr-2'></i>Abstract Factory</a></div>");
            else output.Content.AppendHtml("<div<i class='fa-solid fa-cube'></i><i class='fa-solid fa-industry mr-2'></i>Abstract Factory</div>");

            if (this.Pattern != "builder") output.Content.AppendHtml("<div><a asp-page='/Creational/Builder-problem'><i class='fa-solid fa-helmet-safety mr-2'></i>Builder</a></div>");
            else output.Content.AppendHtml("<div><a asp-page='/Creational/Builder-problem'><i class='fa-solid fa-helmet-safety mr-2'></i>Builder</a></div>");

            if (this.Pattern != "prototype") output.Content.AppendHtml("<div><a asp-page='/Creational/Prototype'><i class='fa-regular fa-clone mr-2'></i>&nbsp;Prototype</a></div>"); 
            else output.Content.AppendHtml("<div><i class='fa-regular fa-clone mr-2'></i>&nbsp;Prototype</div>");

            if (this.Pattern != "singleton") output.Content.AppendHtml("<div><a asp-page='/Creational/Singleton'><i class='fa-solid fa-atom mr-2'></i>&nbsp;Singleton</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-atom mr-2'></i>&nbsp;Singleton</div>");

            output.Content.AppendHtml("</div>");
            output.Content.AppendHtml(@"<div><span class='is-uppercase has-text-weight-semibold'>Structural</span><div class='is-flex is-flex-direction-column is-justify-content-space-evenly'>");

            if (this.Pattern != "prototype") output.Content.AppendHtml("<div><a asp-page='/Structural/Adapter'><i class='fa-solid fa-plug mr-2'></i>Adapter</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-plug mr-2'></i>Adapter</div>");
            
            if (this.Pattern != "bridge") output.Content.AppendHtml("<div><a asp-area='' asp-page='/Structural/Bridge'><i class='fa-solid fa-left-right mr-2'></i>Bridge</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-left-right mr-2'></i>Bridge</div>");
            
            if (this.Pattern != "composite") output.Content.AppendHtml("<div><a asp-area='' asp-page='/Structural/Composite'><i class='fa-solid fa-magnifying-glass-arrow-right mr-2'></i>Composite</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-magnifying-glass-arrow-right mr-2'></i>Composite</div>");

            if (this.Pattern != "decorator") output.Content.AppendHtml("<div><a asp-area='' asp-page='/Structural/Decorator'><i class='fa-solid fa-chart-line mr-2'></i>Decorator</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-chart-line mr-2'></i>Decorator</div>");

            if (this.Pattern != "facade") output.Content.AppendHtml("<div><a asp-area='' asp-page='/Structural/Facade'><i class='fa-solid fa-igloo mr-2'></i>Facade</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-igloo mr-2'></i>Facade</div>");
            
            if (this.Pattern != "flyweight") output.Content.AppendHtml("<div><a asp-area='' asp-page='/Structural/Flyweight'><i class='fa-solid fa-bowl-rice mr-2'></i>Flyweight</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-bowl-rice mr-2'></i>Flyweight</div>");
            
            if (this.Pattern != "proxy") output.Content.AppendHtml("<div><a asp-area='' asp-page='/Structural/Proxy'><i class='fa-solid fa-door-open mr-2'></i>Proxy</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-door-open mr-2'></i>Proxy</div>");

            output.Content.AppendHtml("</div>");
            output.Content.AppendHtml(@"<div><span class='is-uppercase has-text-weight-semibold'>Behavioral</span><div class='is-flex is-flex-direction-column is-justify-content-space-evenly'>");

            if (this.Pattern != "chain") output.Content.AppendHtml("<div><a asp-page='/Behavioral/ChainOfResponsibility'><i class='fa-solid fa-link mr-2'></i>Chain of Responsibility</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-link mr-2'></i>Chain of Responsibility</div>");
            
            if (this.Pattern != "command") output.Content.AppendHtml("<div><a asp-page='/Behavioral/Command'><i class='fa-solid fa-bullhorn mr-2'></i>Command</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-bullhorn mr-2'></i>Command</div>");
            
            if (this.Pattern != "interpreter") output.Content.AppendHtml("<div><a asp-page='/Behavioral/Interpreter'><i class='fa-solid fa-language mr-2'></i>Interpreter</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-language mr-2'></i>Interpreter</div>");
            
            if (this.Pattern != "iterator") output.Content.AppendHtml("<div><a asp-page='/Behavioral/Iterator'><i class='fa-solid fa-arrow-up-right-dots mr-2'></i>Iterator</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-arrow-up-right-dots mr-2'></i>Iterator</div>");
            
            if (this.Pattern != "mediator") output.Content.AppendHtml("<div><a asp-page='/Behavioral/Mediator'><i class='fa-solid fa-tower-cell mr-2'></i>Mediator</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-tower-cell mr-2'></i>Mediator</div>");
            
            if (this.Pattern != "memento") output.Content.AppendHtml("<div><a asp-page='/Behavioral/Memento'><i class='fa-solid fa-gift mr-2'></i>Memento</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-gift mr-2'></i>Memento</div>");
            
            if (this.Pattern != "observer") output.Content.AppendHtml("<div><a asp-page='/Behavioral/Observer'><i class='fa-solid fa-eye mr-2'></i>Observer</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-eye mr-2'></i>Observer</div>");
            
            if (this.Pattern != "state") output.Content.AppendHtml("<div><a asp-page='/Behavioral/State'><i class='fa-solid fa-wand-sparkles mr-2'></i>State</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-wand-sparkles mr-2'></i>State</div>");

            if (this.Pattern != "strategy") output.Content.AppendHtml("<div><a asp-page='/Behavioral/Strategy'><i class='fa-solid fa-chess-knight mr-2'></i>Strategy</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-chess-knight mr-2'></i>Strategy</div>");

            if (this.Pattern != "templatemethod") output.Content.AppendHtml("<div><a asp-page='/Behavioral/TemplateMethod'><i class='fa-solid fa-train-tram mr-2'></i>Template Method</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-train-tram mr-2'></i>Template Method</div>");

            if (this.Pattern != "visitor") output.Content.AppendHtml("<div><a asp-page='/Behavioral/Visitor'><i class='fa-solid fa-person-circle-question mr-2'></i>Visitor</a></div>");
            else output.Content.AppendHtml("<div><i class='fa-solid fa-person-circle-question mr-2'></i>Visitor</div>");

            output.Content.AppendHtml("</div>");

        //    output.Content.AppendHtml(@" <div>
        //    <span class='is-uppercase has-text-weight-semibold'>Structural</span>
        //    <div class='is-flex is-flex-direction-column is-justify-content-space-evenly'>
        //        <div><a asp-area='' asp-page='/Structural/Adapter'><i class='fa-solid fa-plug mr-2'></i>Adapter</a></div>
        //        <div><a asp-area='' asp-page='/Structural/Bridge'><i class='fa-solid fa-left-right mr-2'></i>Bridge</a></div>
        //        <div><a asp-area='' asp-page='/Structural/Composite'><i class='fa-solid fa-magnifying-glass-arrow-right mr-2'></i>Composite</a></div>
        //        <div><a asp-area='' asp-page='/Structural/Decorator'><i class='fa-solid fa-chart-line mr-2'></i>Decorator</a></div>
        //        <div><a asp-area='' asp-page='/Structural/Facade'><i class='fa-solid fa-igloo mr-2'></i>Facade</a></div>
        //        <div><a asp-area='' asp-page='/Structural/Flyweight'><i class='fa-solid fa-bowl-rice mr-2'></i>Flyweight</a></div>
        //        <div><a asp-area='' asp-page='/Structural/Proxy'><i class='fa-solid fa-door-open mr-2'></i>Proxy</a></div>
        //    </div>
        //</div>
        //<div>
        //    Behavioral<div class='is-flex is-flex-direction-column is-justify-content-space-evenly'>
        //        <div><a asp-area='' asp-page='/Behavioral/ChainOfResponsibility'><i class='fa-solid fa-link mr-2'></i>Chain of Responsibility</a></div>
        //        <div><a asp-area='' asp-page='/Behavioral/Command'><i class='fa-solid fa-bullhorn mr-2'></i>Command</a></div>
        //        <div><a asp-area='' asp-page='/Behavioral/Interpreter'><i class='fa-solid fa-language mr-2'></i>Interpreter</a></div>
        //        <div><a asp-area='' asp-page='/Behavioral/Iterator'><i class='fa-solid fa-arrow-up-right-dots mr-2'></i>Iterator</a></div>
        //        <div><a asp-area='' asp-page='/Behavioral/Mediator'><i class='fa-solid fa-tower-cell mr-2'></i>Mediator</a></div>
        //        <div><a asp-area='' asp-page='/Behavioral/Memento'><i class='fa-solid fa-gift mr-2'></i>Memento</a></div>
        //        <div><a asp-area='' asp-page='/Behavioral/Memento'><i class='fa-solid fa-eye mr-2'></i>Observer</a></div>
        //        <div><a asp-area='' asp-page='/Behavioral/State'><i class='fa-solid fa-wand-sparkles mr-2'></i>State</a></div>
        //        <div><a asp-area='' asp-page='/Behavioral/Strategy'><i class='fa-solid fa-chess-knight mr-2'></i>Strategy</a></div>
        //        <div><a asp-area='' asp-page='/Behavioral/TemplateMethod'><i class='fa-solid fa-train-tram mr-2'></i>Template Method</a></div>
        //        <div><a asp-area='' asp-page='/Behavioral/Visitor'><i class='fa-solid fa-person-circle-question mr-2'></i>Visitor</a></div>
        //    </div>
        //</div>");

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
                <div><a asp-area="" asp-page="/Structural/Flyweight"><i class="fa-solid fa-bowl-rice mr-2"></i>Flyweight</a></div>
                <div><a asp-area="" asp-page="/Structural/Proxy"><i class="fa-solid fa-door-open mr-2"></i>Proxy</a></div>
            </div>
        </div>
        <div>
            Behavioral<div class="is-flex is-flex-direction-column is-justify-content-space-evenly">
                <div><a asp-area="" asp-page="/Behavioral/ChainOfResponsibility"><i class="fa-solid fa-link mr-2"></i>Chain of Responsibility</a></div>
                <div><a asp-area="" asp-page="/Behavioral/Command"><i class="fa-solid fa-bullhorn mr-2"></i>Command</a></div>
                <div><a asp-area="" asp-page="/Behavioral/Interpreter"><i class="fa-solid fa-language mr-2"></i>Interpreter</a></div>
                <div><a asp-area="" asp-page="/Behavioral/Iterator"><i class="fa-solid fa-arrow-up-right-dots mr-2"></i>Iterator</a></div>
                <div><a asp-area="" asp-page="/Behavioral/Mediator"><i class="fa-solid fa-tower-cell mr-2"></i>Mediator</a></div>
                <div><a asp-area="" asp-page="/Behavioral/Memento"><i class="fa-solid fa-gift mr-2"></i>Memento</a></div>
                <div><a asp-area="" asp-page="/Behavioral/Memento"><i class="fa-solid fa-eye mr-2"></i>Observer</a></div>
                <div><a asp-area="" asp-page="/Behavioral/State"><i class="fa-solid fa-wand-sparkles mr-2"></i>State</a></div>
                <div><a asp-area="" asp-page="/Behavioral/Strategy"><i class="fa-solid fa-chess-knight mr-2"></i>Strategy</a></div>
                <div><a asp-area="" asp-page="/Behavioral/TemplateMethod"><i class="fa-solid fa-train-tram mr-2"></i>Template Method</a></div>
                <div><a asp-area="" asp-page="/Behavioral/Visitor"><i class="fa-solid fa-person-circle-question mr-2"></i>Visitor</a></div>
            </div>
        </div>
    </div>
*/