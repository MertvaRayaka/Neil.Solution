using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BuilderPattern
{
    class Custom
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion);

            Builder HPBuilder = ObjectManager.CreateObject<HPBuilder>();
            Builder DellBuilder = ObjectManager.CreateObject<DellBuilder>();
            Builder[] builders = new Builder[] { HPBuilder, DellBuilder };

            Director director = ObjectManager.CreateObject<Director>(builders);
            director.Build<HPBuilder>();
            director.Build<DellBuilder>();

            Computer HPComputer = HPBuilder.GetComputer();
            Computer DellComputer = DellBuilder.GetComputer();

            HPComputer.ShowResults();
            DellComputer.ShowResults();

            Console.ReadLine();
        }
    }

    public static class ObjectManager
    {      
        static Dictionary<string, string> ObjectDic = ReadJsonFile($@"{Environment.CurrentDirectory}\appsettings.json");
        public static Dictionary<string, string> ReadJsonFile(string jsonFilePath)
        {
            using (StreamReader file = File.OpenText(jsonFilePath))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    return o.ToObject<Dictionary<string, string>>();
                }
            }
        }

        public static T CreateObject<T>(object[] args = null)
        {
            var targetKey = ObjectDic.Keys.Single(p => p == typeof(T).Name);
            var targetAssembly = Assembly.Load(ObjectDic[targetKey].Split(',')[0]);
            var targetType = targetAssembly.GetType(ObjectDic[targetKey].Split(',')[1]);
            return (T)Activator.CreateInstance(targetType, args);
        }
    }

    public class Computer
    {
        List<string> ComputerParts = new List<string>();

        public void AddComputerParts(string Parts)
        {
            ComputerParts.Add(Parts);
        }

        public void ShowResults()
        {
            foreach (var part in ComputerParts)
            {
                Console.WriteLine(part);
            }
        }
    }

    public abstract class Builder
    {
        public abstract void BuildScreen();
        public abstract void BuildCPU();
        public abstract void BuildRAM();
        public abstract void BuildWaterCooling();
        public abstract Computer GetComputer();
    }

    public class Director
    {
        public List<Builder> BuilderList { get; }
        public Director(params Builder[] builders)
        {
            BuilderList = builders.ToList();
        }
        public void Build<T>()
        {
            var TargetBuilder = BuilderList.Single(p => p.GetType() == typeof(T));
            TargetBuilder.BuildCPU();
            TargetBuilder.BuildRAM();
            TargetBuilder.BuildWaterCooling();
            TargetBuilder.BuildScreen();
        }
    }

    public class HPBuilder : Builder
    {
        Computer computer = new Computer();
        public override void BuildCPU()=>computer.AddComputerParts("安装好了HP的CPU");

        public override void BuildRAM()=>computer.AddComputerParts("安装好了HP的RAM");

        public override void BuildScreen()=>computer.AddComputerParts("安装好了HP的Screen");

        public override void BuildWaterCooling() { }

        public override Computer GetComputer() => computer;
    }

    public class DellBuilder : Builder
    {
        Computer computer = new Computer();
        public override void BuildCPU()
        {
            computer.AddComputerParts("安装好了Dell的CPU");
        }

        public override void BuildRAM()
        {
            computer.AddComputerParts("安装好了Dell的RAM");
        }

        public override void BuildScreen()
        {
            computer.AddComputerParts("安装好了Dell的Screen");
        }

        public override void BuildWaterCooling()
        {
            computer.AddComputerParts("安装好了Dell的WaterCooling");
        }

        public override Computer GetComputer() => computer;
    }
}
