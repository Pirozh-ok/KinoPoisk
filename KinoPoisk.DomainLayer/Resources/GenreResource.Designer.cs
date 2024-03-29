﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KinoPoisk.DomainLayer.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class GenreResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal GenreResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("KinoPoisk.DomainLayer.Resources.GenreResource", typeof(GenreResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid ID value.
        /// </summary>
        public static string InvalidId {
            get {
                return ResourceManager.GetString("InvalidId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid name value. The length of the genre name should not exceed 100 characters.
        /// </summary>
        public static string NameExceedsMaxLen {
            get {
                return ResourceManager.GetString("NameExceedsMaxLen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid name value. The minimum length of the genre name is 3.
        /// </summary>
        public static string NameLessMinLen {
            get {
                return ResourceManager.GetString("NameLessMinLen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Argument is null.
        /// </summary>
        public static string NullArgument {
            get {
                return ResourceManager.GetString("NullArgument", resourceCulture);
            }
        }
    }
}
