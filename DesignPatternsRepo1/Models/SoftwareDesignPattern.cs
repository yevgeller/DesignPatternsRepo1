namespace DesignPatternsRepo1.Models
{
    public class SoftwareDesignPattern
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string Summary { get; set; }
        public string Icon { get; set; }

        public SoftwareDesignPattern()
        {
            this.Name = "No name";
            this.Group = "No group";
            this.Summary = "Pattern summary";
            this.Icon = "fa-folder-open";
        }

        public SoftwareDesignPattern(string code)
        {
            switch (code.ToLower())
            {
                case "fac":
                    this.Name = "Factory";
                    this.Group = "Creational";
                    this.Summary = "Creation of objects that conform to the same interface without specifying concrete classes";
                    this.Icon = "fa-industry";
                    break;
                case "abs":
                    this.Name = "Abstract Factory";
                    this.Group = "Creational";
                    this.Summary = "Same as Factory (Creation of objects that conform to the same interface without specifying concrete classes) but to 'families' of objects";
                    this.Icon = "fa-boxes-stacked";
                    break;
                case "bui": //Builder
                    this.Name = "Builder";
                    this.Group = "Creational";
                    this.Summary = "Construction of complex objects by extracting the steps and centralizing the control of what happens at each step";
                    this.Icon = "fa-helmet-safety";
                    break;
                case "proto": //Prototype
                    this.Name = "Prototype";
                    this.Group = "Creational";
                    this.Summary = "Copying of existing objects without a dependency on a concrete class that needs to be copied";
                    this.Icon = "fa-clone";
                    break;
                case "sin": //Singleton
                    this.Name = "Singleton";
                    this.Group = "Creational";
                    this.Summary = "";
                    this.Icon = "fa-atom";
                    break;
                case "ada": //Adapter
                    this.Name = "Adapter";
                    this.Group = "Structural";
                    this.Summary = "";
                    this.Icon = "fa-plug";
                    break;
                case "bri": //Bridge
                    this.Name = "Bridge";
                    this.Group = "Structural";
                    this.Summary = "Decoupling Abstraction from Implementation";
                    this.Icon = "fa-left-right";
                    break;
                case "sit": //Composite
                    this.Name = "Composite";
                    this.Group = "Structural";
                    this.Summary = "Working with tree-like components in a uniform way regardless of whether it's a leaf or a container";
                    this.Icon = "fa-magnifying-glass-arrow-right";
                    break;
                case "dec": //Decorator
                    this.Name = "Decorator";
                    this.Group = "Structural";
                    this.Summary = "Enhancing functionality while ensuring single responsibility";
                    this.Icon = "fa-chart-line";
                    break;
                case "fas": //Facade
                    this.Name = "Facade";
                    this.Group = "Structural";
                    this.Summary = "Hiding complex procedures behind a wall and providing a push-button interface";
                    this.Icon = "fa-igloo";
                    break;
                case "fly": //Flyweight
                    this.Name = "Flyweight";
                    this.Group = "Structural";
                    this.Summary = "Creating a large number of similar objects while sharing some of their state to save memory";
                    this.Icon = "fa-bowl-rice";
                    break;
                case "proxy": //Proxy
                    this.Name = "Proxy";
                    this.Group = "Structural";
                    this.Summary = "A placeholder for another object for a few reasons";
                    this.Icon = "fa-door-open";
                    break;
                case "cha": //Chain of Responsibility
                    this.Name = "Chain of Responsibility";
                    this.Group = "Behavioral";
                    this.Summary = "Standardizing similar separate functionality";
                    this.Icon = "fa-link";
                    break;
                case "com": //Command
                    this.Name = "Command";
                    this.Group = "Behavioral";
                    this.Summary = "Abstracting callable actions such that they can be assigned to multiple callers and support undoing";
                    this.Icon = "fa-bullhorn";
                    break;
                case "int": //Interpreter
                    this.Name = "Interpreter";
                    this.Group = "Behavioral";
                    this.Summary = "Setting up grammar, sentence structure, and mechanism(s) for translating";
                    this.Icon = "fa-language";
                    break;
                case "ite": //Iterator
                    this.Name = "Iterator";
                    this.Group = "Behavioral";
                    this.Summary = "Setting up a way to traverse a collection without exposing its inner structure";
                    this.Icon = "fa-arrow-up-right-dots";
                    break;
                case "med": //Mediator
                    this.Name = "Mediator";
                    this.Group = "Behavioral";
                    this.Summary = "Abstracting communication function to a dedicated entity";
                    this.Icon = "fa-tower-cell";
                    break;
                case "mem": //Memento
                    this.Name = "Memento";
                    this.Group = "Behavioral";
                    this.Summary = "An ability to provide and consume internal state via a predefined channel";
                    this.Icon = "fa-gift";
                    break;
                case "obs": //Observer
                    this.Name = "Observer";
                    this.Group = "Behavioral";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "sta": //State
                    this.Name = "State";
                    this.Group = "Behavioral";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "str": //Strategy
                    this.Name = "Strategy";
                    this.Group = "Behavioral";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "tem": //Template Method
                    this.Name = "Template Method";
                    this.Group = "Behavioral";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "vis": //Visitor
                    this.Name = "Visitor";
                    this.Group = "Behavioral";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                default:
                    this.Name = "No name";
                    this.Group = "No group";
                    this.Summary = "Pattern summary";
                    this.Icon = "fa-folder-open";
                    break;
            }
        }

    }
}
