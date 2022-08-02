namespace DesignPatternsRepo1.Models
{
    public class ModelInitializer
    {
        public static List<SoftwareDesignPattern> GetAllPatterns()
        {
            List<SoftwareDesignPattern> patterns = new List<SoftwareDesignPattern>();
            patterns.Add(new SoftwareDesignPattern("fac"));
            patterns.Add(new SoftwareDesignPattern("abs"));
            patterns.Add(new SoftwareDesignPattern("bui"));
            patterns.Add(new SoftwareDesignPattern("proto"));
            patterns.Add(new SoftwareDesignPattern("sin"));
            patterns.Add(new SoftwareDesignPattern("ada"));
            patterns.Add(new SoftwareDesignPattern("bri"));
            patterns.Add(new SoftwareDesignPattern("sit"));
            patterns.Add(new SoftwareDesignPattern("dec"));
            patterns.Add(new SoftwareDesignPattern("fas"));
            patterns.Add(new SoftwareDesignPattern("fly"));
            patterns.Add(new SoftwareDesignPattern("proxy"));
            patterns.Add(new SoftwareDesignPattern("cha"));
            patterns.Add(new SoftwareDesignPattern("com"));
            patterns.Add(new SoftwareDesignPattern("int"));
            patterns.Add(new SoftwareDesignPattern("ite"));
            patterns.Add(new SoftwareDesignPattern("med"));
            patterns.Add(new SoftwareDesignPattern("mem"));
            patterns.Add(new SoftwareDesignPattern("obs"));
            patterns.Add(new SoftwareDesignPattern("sta"));
            patterns.Add(new SoftwareDesignPattern("str"));
            patterns.Add(new SoftwareDesignPattern("tem"));
            patterns.Add(new SoftwareDesignPattern("vis"));

            return patterns;
        }
    }
}
