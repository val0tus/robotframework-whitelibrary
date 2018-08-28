using System;
using System.Collections.Generic;
using System.Reflection;
using static CsDynamicLib.Attributes;

namespace CsDynamicLib
{
    public class CsLib
    {
        public dynamic RunKeyword(string keyword, params object[] args)
        {
            foreach (Type type in GetRobotKeywordClasses())
            {
                foreach (var method in type.GetMethods())
                {
                    if (method.Name.Equals(keyword) && method.GetCustomAttribute<RobotKeyword>() != null)
                    {
                        var expectedArgs = method.GetParameters();
                        args = HandleDefaultValuesAndVarArgs(args, expectedArgs);
                        var instance = Activator.CreateInstance(type);
                        return method.Invoke(instance, args);
                    }
                }
            }
            throw new Exception("No such keyword.");
        }

        public List<string> GetKeywordNames()
        {
            List<string> keywordNames = new List<string>();
            foreach (Type type in GetRobotKeywordClasses())
            {
                foreach (var method in type.GetMethods())
                {
                    if (method.GetCustomAttribute<RobotKeyword>() != null)
                    {
                        keywordNames.Add(method.Name);
                    }
                }
            }
            return keywordNames;
        }

        public List<string> GetKeywordArguments(string keywordName)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            var type = Array.Find(types, t => t.GetMethod(keywordName) != null);
            MethodInfo method = type.GetMethod(keywordName);
            ParameterInfo[] methodParams = method.GetParameters();
            ParameterInfo info = methodParams[0];
            List<string> keywordArgs = new List<string>();
            foreach (var param in methodParams)
            {
                string argString = param.Name;
                if (param.HasDefaultValue)
                {
                    argString = argString + "=" + param.DefaultValue;
                }
                else if (IsParamArray(param))
                {
                    argString = "*" + argString;
                }

                keywordArgs.Add(argString);
            }
            return keywordArgs;
        }

        private IEnumerable<Type> GetRobotKeywordClasses()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(RobotKeywordClass), true).Length > 0)
                {
                    yield return type;
                }
            }
        }

        private object[] HandleDefaultValuesAndVarArgs(object[] args, ParameterInfo[] expectedArgs)
        {
            ParameterInfo lastExpectedArg = expectedArgs[expectedArgs.Length - 1];

            if (args.Length < expectedArgs.Length)
            {
                args = PopulateMissingOptionalArgs(args, expectedArgs, lastExpectedArg);
            }
            else if (args.Length >= expectedArgs.Length && IsParamArray(lastExpectedArg))
            {
                args = MoveVarArgsToArray(args, expectedArgs, lastExpectedArg);
            }

            return args;
        }

        private object[] MoveVarArgsToArray(object[] args, ParameterInfo[] expectedArgs, ParameterInfo lastExpectedArg)
        {
            // Create array from varargs
            Type paramsType = lastExpectedArg.ParameterType;
            int varArgsLength = args.Length - expectedArgs.Length + 1;
            object[] varArgs = (object[])Activator.CreateInstance(paramsType, varArgsLength);
            Array.Copy(args, expectedArgs.Length - 1, varArgs, 0, varArgsLength);

            // Create new args array and replace varargs with the new varargs array
            object[] newArgs = new object[expectedArgs.Length];
            Array.Copy(args, 0, newArgs, 0, newArgs.Length);
            newArgs[newArgs.Length - 1] = varArgs;
            args = newArgs;

            return args;
        }

        private object[] PopulateMissingOptionalArgs(object[] args, ParameterInfo[] expectedArgs, ParameterInfo lastExpectedArg)
        {
            var oldLength = args.Length;
            Array.Resize(ref args, expectedArgs.Length);
            for (int i = oldLength; i < expectedArgs.Length; i++)
            {
                args[i] = Type.Missing;
            }

            if (IsParamArray(lastExpectedArg))
            {
                // Create empty params array
                Type paramsType = lastExpectedArg.ParameterType;
                args[args.Length - 1] = Activator.CreateInstance(paramsType, 0);
            }

            return args;
        }

        private bool IsParamArray(ParameterInfo param)
        {
            return param.IsDefined(typeof(ParamArrayAttribute), false);
        }
    }
}
