using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain
{
    public class ReflectionHelper
    {
        #region -- SetValue --
        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="val">The val.</param>
        /// <param name="instance">The instance.</param>
        public static void SetValue(
            string propertyName,
            object val,
            object instance)
        {
            if (null == instance) return;

            Type type = instance.GetType();
            PropertyInfo info = GetProperty(type, propertyName);

            if (null == info) return;

            try
            {
                if (info.PropertyType.Equals(typeof(string)))
                {
                    info.SetValue(instance, val, new object[0]);
                }
                else if (info.PropertyType.Equals(typeof(Boolean)))
                {
                    bool value = false;
                    value = val.ToString().ToLower().StartsWith("true");
                    info.SetValue(instance, value, new object[0]);
                }
                else if (info.PropertyType.Equals(typeof(int)))
                {
                    int value = (val == null) ? 0 : int.Parse(val.ToString());
                    info.SetValue(instance, value, new object[0]);
                }
                else if (info.PropertyType.Equals(typeof(double)))
                {
                    double value = 0.0d;
                    if (val != null)
                    {
                        value = Convert.ToDouble(val);
                    }
                    info.SetValue(instance, value, new object[0]);
                }
                else if (info.PropertyType.Equals(typeof(DateTime)))
                {
                    DateTime value = (val == null)
                        ? new DateTime(1753, 1, 1, 0, 0, 0, 0)
                        : DateTime.Parse(val.ToString());
                    info.SetValue(instance, value, new object[0]);
                }
            }
            catch
            {
                throw;
            }
        } 
        #endregion

        #region -- GetProperty --
        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propName">Name of the prop.</param>
        /// <returns></returns>
        public static PropertyInfo GetProperty<T>(string propName)
        {
            return GetProperty(typeof(T), propName);
        }

        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="propName">Name of the prop.</param>
        /// <returns></returns>
        public static PropertyInfo GetProperty(Type type, string propName)
        {
            try
            {
                PropertyInfo[] infos = type.GetProperties();
                if (infos == null || infos.Length == 0)
                {
                    return null;
                }
                foreach (PropertyInfo info in infos)
                {
                    if (propName.ToLower().Equals(info.Name.ToLower()))
                    {
                        return info;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
            return null;
        } 
        #endregion

        #region -- GetType --
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <param name="pathOrAssemblyName">Name of the path or assembly.</param>
        /// <param name="classFullName">Full name of the class.</param>
        /// <returns></returns>
        public static Type GetType(string pathOrAssemblyName, string classFullName)
        {
            try
            {
                if (!pathOrAssemblyName.Contains(Path.DirectorySeparatorChar.ToString()))
                {
                    string assemblyName = AbstractAssemblyName(pathOrAssemblyName);
                    if (!classFullName.Contains(assemblyName))
                    {
                        classFullName = String.Concat(assemblyName, ".", classFullName);
                    }
                    Assembly assembly = Assembly.Load(assemblyName);
                    return assembly.GetType(classFullName);
                }

                Assembly asm = Assembly.LoadFrom(pathOrAssemblyName);
                if (null == asm) return null;

                Type type = asm.GetType(classFullName);

                if (null == type)
                {
                    foreach (Type one in asm.GetTypes())
                    {
                        if (one.Name == classFullName)
                        {
                            type = one;
                            break;
                        }
                    }
                }
                return type;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Abstracts the name of the assembly.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <returns></returns>
        private static string AbstractAssemblyName(string assemblyName)
        {
            string prefix = ".\\";
            string suffix = ".dll";

            if (assemblyName.StartsWith(prefix))
            {
                assemblyName = assemblyName.Substring(prefix.Length);
            }
            if (assemblyName.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
            {
                assemblyName = assemblyName.Substring(0, assemblyName.Length - suffix.Length);
            }
            return assemblyName;
        } 
        #endregion
    }
}
