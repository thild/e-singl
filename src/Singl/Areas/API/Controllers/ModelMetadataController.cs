using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNet.Mvc;
using Singl.Core.Scaffolding;
using Singl.Extensions;

namespace Singl.Areas.API.Controllers
{
    [Area("API")]
    [Route("[area]/[controller]")]
    public class ModelMetadataController : Controller
    {
        [HttpGet("{modelName}")]
        public IActionResult Get(string modelName)
        {

            if (string.IsNullOrEmpty(modelName))
            {
                return new HttpStatusCodeResult(404);
            }

            //var model = Activator.CreateInstanceFrom();
            string assemblyName = typeof(ModelMetadataController).AssemblyQualifiedName;
            var type = Type.GetType(modelName);
            return new ObjectResult(new ModelMetadata(type));
        }

        //  public static Type GetType(string typeName)
        // {
        //     var type = Type.GetType(typeName);
        //     if (type != null) return type;
        //     
        //                 
        //     var ass = typeof(ModelMetadataController).GetTypeInfo().Assembly;
        //     
        //     //foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
        //     foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
        //     {
        //         type = a.GetType(typeName);
        //         if (type != null)
        //             return type;
        //     }
        //     return null ;
        // }
    }

}

namespace Singl.Core.Scaffolding
{
    
     public class ModelMetadata
    {

        public ModelMetadata(Type modelType)
        {
            Properties = new List<PropertyMetadata>();

            var properties = modelType
                .GetProperties(BindingFlags.Public | 
                              BindingFlags.Instance)
                .Where(p => p.CanRead);

            foreach (var p in properties)
            {
                Properties.Add(new PropertyMetadata(p));
            }
        }

        public List<PropertyMetadata> Properties { get; set; }
    }

    //TODO: Cache the stuff
    public class PropertyMetadata
    {

        public PropertyMetadata(PropertyInfo propertyInfo)
        {
            PropertyName = propertyInfo.Name;  
            var displayAttr = propertyInfo.GetAttribute<DisplayAttribute>();
            if(displayAttr != null) {
                DisplayName = displayAttr.Name;
                Description = displayAttr.Description ?? string.Empty;
            }
            else {
                DisplayName = PropertyName;
                Description = string.Empty;
            }
            
            DescriptionProperty = string.Empty;
            SelectionProperty = string.Empty;
            NavigationUrl = string.Empty;
            RouteName = string.Empty;
            var eType = propertyInfo.GetEnumerableItemType();
            if(eType != null) {
                var lnAttr = eType.GetAttribute<ModelNavigationAttribute>();
                if(lnAttr != null) {
                    DescriptionProperty = lnAttr.DescriptionProperty;                                
                    SelectionProperty = lnAttr.SelectionProperty;                                
                    NavigationUrl = lnAttr.NavigationUrl;
                    RouteName = lnAttr.RouteName;
                    RouteParams = lnAttr.RouteParams;                
                }
            }

            var mnAttr = propertyInfo.PropertyType.GetAttribute<ModelNavigationAttribute>();
            if(mnAttr != null) {
                    DescriptionProperty = mnAttr.DescriptionProperty;                                
                    SelectionProperty = mnAttr.SelectionProperty;                                
                    NavigationUrl = mnAttr.NavigationUrl;                
                    RouteName = mnAttr.RouteName;                
                    RouteParams = mnAttr.RouteParams;                
            }
            
            var scaffoldAttr = propertyInfo.GetAttribute<ScaffoldColumnAttribute>();
            if(scaffoldAttr != null) {
                Scaffold = scaffoldAttr.Scaffold;
            }
            
            var fk = propertyInfo.GetAttribute<ForeignKeyAttribute>();
            if(fk != null) {
                IsForeignKey = true;
            }
            
            var pk = propertyInfo.GetAttribute<ForeignKeyAttribute>();
            if(pk != null) {
                IsPrimaryKey = true;
            }            
            TypeName = propertyInfo.PropertyType.Name;
            IsEnum = propertyInfo.GetType().GetTypeInfo().IsEnum;  
            IsArray = propertyInfo.PropertyType.GetTypeInfo().IsArray;
            IsList = propertyInfo.PropertyType.IsList();
            IsEnumerable = propertyInfo.PropertyType.GetTypeInfo().ImplementedInterfaces.Any(x => x.FullName == typeof(IEnumerable).FullName);
            //IsComplexType = !propertyInfo.GetType().GetTypeInfo().IsPrimitive;
            IsReadOnly = !propertyInfo.CanWrite;
            ClientType = GetClientType(propertyInfo.PropertyType);
        }

        private string GetClientType (Type type) {
            if (type.IsNumeric())
            {
                return "number";
            }
            else if (type.IsBoolean())
            {
                return "boolean";
            }
            else if (type.IsString())
            {
                return "string";
            }
            else if (IsArray || IsList)
            {
                return "array";
            }
            else if (IsEnum)
            {
                return "enum";
            }
            return "any";
        }

        public bool IsAutoGenerated { get; private set; }

        public bool IsComplexType { get; private set; }

        public bool IsArray { get; private set; }

        public bool IsList { get; private set; }
        
        public bool IsEnumerable { get; private set; }

        public bool IsEnum { get; private set; }

        public bool IsEnumFlags { get; private set; }

        public bool IsForeignKey { get; private set; }

        public bool IsPrimaryKey { get; private set; }

        public bool IsReadOnly { get; private set; }

        public string PropertyName { get; private set; }

        public string DisplayName { get; private set; }
        
        public string Description { get; private set; }

        public bool Scaffold { get; private set; }

        public string TypeName { get; private set; }

        public string ClientType { get; private set; }
        
        public string DescriptionProperty { get; private set; }

        public string SelectionProperty { get; private set; }

        public string NavigationUrl { get; private set; }
        
        public string RouteName { get; private set; }
        public string RouteParams { get; private set; }
        
    }

    //TODO: this attribute must be applied to type. 
    //For now it will be applied to property.
    //We have to get the list item type attribute. 
    [System.AttributeUsage(System.AttributeTargets.Class | 
                           System.AttributeTargets.Struct, AllowMultiple = true)]    
    public class ModelNavigationAttribute : Attribute
    {
        public string NavigationUrl { get; set; }
        
        public string RouteName { get; set; }

        public string DescriptionProperty { get; set; }

        public string SelectionProperty { get; set; }
        
        public string RouteParams { get; set; }
        
    }

}



namespace Singl.Extensions
{
    public static class TypeExtensions
    {
        private static readonly HashSet<Type> NumericTypes = new HashSet<Type>
        {
            typeof(int),  typeof(double),  typeof(decimal),
            typeof(long), typeof(short),   typeof(sbyte),
            typeof(byte), typeof(ulong),   typeof(ushort),
            typeof(uint), typeof(float)
        };

        public static bool IsNumeric(this Type type)
        {
            return NumericTypes.Contains(Nullable.GetUnderlyingType(type) ?? type);
        }
        public static bool IsBoolean(this Type type)
        {
            return type == typeof(bool);
        }
        public static bool IsString(this Type type)
        {
            return type == typeof(string);
        }
        public static bool IsList(this Type type)
        {
            //TODO: gambiarra
            return type.Name.Contains("List");
            //propertyInfo.PropertyType.GetTypeInfo().ImplementedInterfaces.Any(x => x.FullName == typeof(IList<>).FullName)
        }
    }
    public static class ReflectionExtensions
    {
        public static T GetAttribute<T>(this PropertyInfo prop) where T : Attribute
        {
            if (prop.CustomAttributes == null || prop.CustomAttributes.Count() == 0)
                return null;

            var attr = prop.GetCustomAttributes(typeof(T), true)
                .Where(x => x.GetType() == typeof(T))
                .Cast<T>().FirstOrDefault();

            if (attr == null)
                return null;

            return attr;
        }
        
        public static T GetAttribute<T>(this Type type) where T : Attribute
        {
            return type.GetTypeInfo().GetCustomAttribute<T>();
        }
        
         public static Type GetEnumerableItemType(this PropertyInfo prop)
        {
            Console.WriteLine(prop.Name);
            foreach (var item in prop.PropertyType.GetTypeInfo().ImplementedInterfaces)
            {
                Console.WriteLine(item);
            }
            return prop.PropertyType.GetTypeInfo()
                .ImplementedInterfaces
                .Where(t => t.GetTypeInfo().IsGenericType == true && 
                            t.GetTypeInfo().GetGenericTypeDefinition() == typeof(IEnumerable<>))
                .Select(t => t.GetGenericArguments()[0]).SingleOrDefault();
        }
        
    }
}









//         public static T GetAttribute<T>(this PropertyInfo prop) where T : Attribute
//         {
//             if (prop.CustomAttributes == null || prop.CustomAttributes.Count() == 0)
//                 return null;
// 
//             var attr = prop.CustomAttributes.Where(x => x.AttributeType == typeof(T)).FirstOrDefault();
// 
//             if (attr == null || attr.ConstructorArguments == null || attr.ConstructorArguments.Count == 0)
//                 return null;
// 
//             return attr;
//         }
//         public static string GetDisplayName(this PropertyInfo prop)
//         {
//             if (prop.CustomAttributes == null || prop.CustomAttributes.Count() == 0)
//                 return prop.Name;
// 
//             var displayNameAttribute = prop.CustomAttributes.Where(x => x.AttributeType == typeof(DisplayAttribute)).FirstOrDefault();
// 
//             if (displayNameAttribute == null || displayNameAttribute.ConstructorArguments == null || displayNameAttribute.ConstructorArguments.Count == 0)
//                 return prop.Name;
// 
//             return displayNameAttribute.ConstructorArguments[0].Value.ToString() ?? prop.Name;
//         }

//     internal static class Extensions
//     {
//         public static MemberInfo GetMember<T, TProperty>(this LambdaExpression expression)
//         {
//             MemberExpression memberExpression = RemoveUnary(expression.Body);
//             if (memberExpression == null)
//             {
//                 return null;
//             }
//             return memberExpression.Member;
//         }
// 
//         private static MemberExpression RemoveUnary(Expression toUnwrap) {
//             if (toUnwrap is UnaryExpression) {
//                 return ((UnaryExpression)toUnwrap).Operand as MemberExpression;
//             }
// 
//             return toUnwrap as MemberExpression;
//         }
//     }
//     
//     public static class ReflectionExtensions
//     {
// 
//         public static bool IsStatic(this Type type)
//         {
//             return type.GetTypeInfo().IsAbstract && type.GetTypeInfo().IsSealed;
//         }
// 
//         public static object GetValue<T> (this T obj, 
//                                           string propertyName)
//         {
//             if (obj == null)
//                 return null;
//             var attrProperty = obj.GetType ().GetProperty (propertyName);
//             if (attrProperty == null)
//                 return null;
//             return attrProperty.GetValue (obj, null);
//         }
// 
//     }
// 
//     public static class AttributeExtensions
//     {
// 
// 
//         public static TAttribute GetAttribute<TAttribute>  (this object obj, 
//                                                  string propertyName)
//         {
//             return GetAttributeImpl <TAttribute>(obj, obj.GetType().GetProperty(propertyName));
//         }
// 
//         public static TAttribute GetAttribute<TAttribute> (this object obj, 
//                                                  PropertyInfo property)
//         {
//             return GetAttributeImpl <TAttribute>(obj, property);
//         }
// 
//         static TAttribute GetAttributeImpl<TAttribute> (object obj, PropertyInfo property)
//         {
//             if (obj == null)
//                 return default(TAttribute);
//             var atts = property.GetCustomAttributes (true).Cast<TAttribute>().ToArray();
//             if (atts.Length == 0) {
//                 return default(TAttribute);
//             }
//             foreach (var a in atts) {
//                 if (a.GetType () == typeof(TAttribute)) {
//                     return a;
//                 }
//             }
//             return default(TAttribute);
//         }
// 
// 
//         //-------------------
// 
// 
//         public static object GetAttributeValue<T> (this T obj, 
//                                                    string propertyName, 
//                                                    string attribute,
//                                                    string attributeProperty)
//         {
//             if (obj == null)
//                 return null;
//             return GetAttributeValue (obj.GetType (), propertyName, 
//                                       attribute, attributeProperty);
//         }
// 
//         public static object GetAttributeValue<T> (this PropertyInfo property, 
//                                                    Type attribute,
//                                                    string attributeProperty)
//         {
//             return GetAttributeValue (property, attribute, attributeProperty);
//         }
// 
//         static object GetAttributeValue (Type type, string propertyName, 
//                                          string attribute,
//                                          string attributeProperty)
//         {
//             var property = type.GetProperty (propertyName);
//             if (property == null)
//                 return null;
// 
//             return GetAttributeValue (property, 
//                                      attribute, 
//                                      attributeProperty);
//         }
// 
//         static object GetAttributeValue (PropertyInfo property, 
//                                         string attribute,
//                                         string attributeProperty)
//         {
//             var atts = property.GetCustomAttributes (true).ToArray();
//             if (atts.Length == 0)
//                 return null;
//             foreach (var a in atts) {
//                 var attrType = (a as Attribute).GetType ();
//                 if (attrType.Name == attribute + "Attribute") {
//                     var attrProperty = attrType.GetProperty (attributeProperty);
//                     if (attrProperty == null)
//                         return null;
//                     return attrProperty.GetValue (a, null);
//                 }
//             }
//             return null;
//         }
// 
//         static object GetAttributeValue (PropertyInfo property, 
//                                         Type attribute,
//                                         string attributeProperty)
//         {
//             var atts = property.GetCustomAttributes (true).ToArray();
//             if (atts.Length == 0)
//                 return null;
//             foreach (var a in atts) {
//                 if (a.GetType () == attribute) {
//                     var attrProperty = attribute.GetProperty (attributeProperty);
//                     if (attrProperty == null)
//                         return null;
//                     return attrProperty.GetValue (a, null);
//                 }
//             }
//             return null;
//         }
//     }
