using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = BuilderFactory.CreateBuilder<MBuilder>("First Parameter", "Second Parameter");
            builder.Build();

            var otherBuilder = BuilderFactory.CreateBuilder<XBuilder>("First", "Second", "third", 1, 20.334);
            otherBuilder.Build();
        }
    }


    /// <summary>
    /// Creates Builder objects
    /// Exempllifies the use of a collection of Type/Action pairs to return impelementations of a specified interface"/>
    /// </summary>
    public static class BuilderFactory
    {
        private static readonly Dictionary<Type, BuilderAction> TypeActions = new Dictionary<Type, BuilderAction>();

        private delegate IBuilder BuilderAction(params object[] parameters);

        /// <summary>
        /// Static - We only need this to run once, initialize all members of the Dictionary here
        /// </summary>
        static BuilderFactory()
        {
            //Register all of the possible types and thier respective constructors
            TypeActions.Add(typeof(MBuilder), p => new MBuilder(p));

            TypeActions.Add(typeof(XBuilder), p => new XBuilder(p));

            //ETC...
        }

        /// <summary>
        /// Creates the Builder with the specified type and parameters
        /// </summary>
        /// <typeparam name="T">The type that implements the interface</typeparam>
        /// <param name="parameters">Any specific parameters associated with the ctor on the Builder</param>
        /// <returns>An instance of IBuilder</returns>
        public static IBuilder CreateBuilder<T>(params object[] parameters)
        {
            return TypeActions[typeof(T)].Invoke(parameters);
        }
    }


    /// <summary>
    /// Example Builders and the IBuilder interface
    /// </summary>
    public class MBuilder : IBuilder
    {
        public MBuilder(params object[] parameters)
        {
            //Do something with parameters
        }

        public void Build()
        {
            //Implement the interface's contract
        }
    }

    public class XBuilder : IBuilder
    {
        public XBuilder(params object[] parameters)
        {
            //Do something with parameters
        }

        public void Build()
        {
            //Implement the interface's contract
        }
    }

    public interface IBuilder
    {
        void Build();
    }
}
